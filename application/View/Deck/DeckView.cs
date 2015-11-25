using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BioBotApp.Model.Data.Services;
using BioBotApp.Model.Data;

namespace BioBotApp.View.Deck
{
    public partial class DeckView : UserControl, IDeckView
    {
        private int deckYReal;
        private int deckY;
        private int deckXReal;
        private int deckX;
        private int XPk;
        private int YPk;
        private int dim;
        private int deckTypePk;
        private double ratioX;
        private double ratioY;
        List<Button> buttons = new List<Button>();

        public DeckView()
        {
            InitializeComponent();
            this.bsObject.DataMember = "bbt_object";
            this.bsObject.DataSource = DBManager.Instance.projectDataset;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dim = DBManager.Instance.projectDataset.bbt_property_type.Where(p => (p.description.ToString()).Equals("dimension", StringComparison.InvariantCultureIgnoreCase)).First().pk_id;
            deckTypePk = DBManager.Instance.projectDataset.bbt_object_type.Where(p => (p.description.ToString()).Equals("deck", StringComparison.InvariantCultureIgnoreCase)).First().pk_id;
            XPk = DBManager.Instance.projectDataset.bbt_property.Where(p => (p.description.ToString()).Equals("xlength", StringComparison.InvariantCultureIgnoreCase) && p.fk_property_type == dim).First().pk_id;
            YPk = DBManager.Instance.projectDataset.bbt_property.Where(p => (p.description.ToString()).Equals("ylength", StringComparison.InvariantCultureIgnoreCase) && p.fk_property_type == dim).First().pk_id;
            BioBotDataSets.bbt_objectRow deck = DBManager.Instance.projectDataset.bbt_object.Where(p => p.activated == "1" && p.fk_object_type == deckTypePk).First();
            deckXReal = int.Parse(DBManager.Instance.projectDataset.bbt_object_property.Where(p => p.fk_object_type_id == deck.fk_object_type && p.fk_properties_id == XPk).First().value);
            deckYReal = int.Parse(DBManager.Instance.projectDataset.bbt_object_property.Where(p => p.fk_object_type_id == deck.fk_object_type && p.fk_properties_id == YPk).First().value);
            this.Location = new Point(this.ParentForm.ClientSize.Width - deckX, 0);
            deckX = this.ParentForm.Width;
            deckY = this.ParentForm.Height;
            this.Size = new Size(deckX, deckY);
        }

        public void addObject(BioBotDataSets.bbt_objectRow obj)
        {
            if (obj.activated == "1")
            {
                int pkPropertyLayout = DBManager.Instance.projectDataset.bbt_property.Where(p => (p.description.ToString()).Equals("CanDeckLayout", StringComparison.InvariantCultureIgnoreCase)).First().pk_id;
                string objLayout = DBManager.Instance.projectDataset.bbt_object_property.Where(p => p.fk_object_type_id == obj.fk_object_type && p.fk_properties_id == pkPropertyLayout).First().value;
                if (objLayout == "1")
                {
                    Button Mod = new Button();
                    BioBotDataSets.bbt_object_propertyRow rowX;
                    BioBotDataSets.bbt_object_propertyRow rowY;
                    try
                    {
                        rowX = DBManager.Instance.projectDataset.bbt_object_property.Where(p => p.fk_object_type_id == obj.bbt_object_typeRow.pk_id && p.fk_properties_id == XPk).First();
                        rowY = DBManager.Instance.projectDataset.bbt_object_property.Where(p => p.fk_object_type_id == obj.bbt_object_typeRow.pk_id && p.fk_properties_id == YPk).First();
                    }
                    catch (System.InvalidOperationException)
                    {
                        MessageBox.Show("Object dimensions non-existent");
                        return;
                    }
                    int XDt = int.Parse(rowX.value.ToString()) * deckX / deckXReal;
                    int YDt = int.Parse(rowY.value.ToString()) * deckY / deckYReal;
                    Mod.Text = obj.description;
                    Mod.Location = new Point(deckX - obj.deck_x * deckX / deckXReal - XDt, obj.deck_y * deckY / deckYReal);
                    setRotation(obj, YDt, XDt, Mod);
                    Mod.TextAlign = ContentAlignment.MiddleCenter;
                    if (Mod.Location.X + Mod.Width  - deckX > 0 || Mod.Location.Y + Mod.Height - deckY >= 0)
                    {
                        MessageBox.Show("Conflict between dimensions and referential point of the object, try changing rotation value");
                    }
                    else if (Mod.Location.Y < 0 || Mod.Location.X < 0)
                    {
                        MessageBox.Show("Negative referential point");
                    }
                    else
                    {
                        this.Controls.Add(Mod);
                        buttons.Add(Mod);
                    }
                }
                if (objLayout == "0")
                {
                    MessageBox.Show("Object cannot fit in the deck");
                }
            }
        }

        private void setRotation(BioBotDataSets.bbt_objectRow obj, int height, int width, Button button)
        {
            switch (obj.rotation)
            {
                case 0:
                    button.Width = width;
                    button.Height = height;
                    break;
                case 90:
                    button.Location = new Point(button.Location.X - height, button.Location.Y);
                    button.Width = height;
                    button.Height = width;
                    break;
                case 180:
                    button.Location = new Point(button.Location.X - width, button.Location.Y- height);
                    button.Width = width;
                    button.Height = height;
                    break;
                case 270:
                    button.Location = new Point(button.Location.X, button.Location.Y - width);
                    button.Width = height;
                    button.Height = width;
                    break;
                default:
                    MessageBox.Show("Rotation value not allowed");
                    break;
            }
        }

        public BioBotDataSets.bbt_objectRow getSelectedObjectRow()
        {
            BioBotDataSets.bbt_objectRow objectRow = null;

            if (bsObject.Current == null) return null;
            if (!(bsObject.Current.GetType() == typeof(DataRowView))) return null;
            DataRowView rowView = bsObject.Current as DataRowView;
            if (rowView.Row == null) return null;
            if (!(rowView.Row.GetType() == typeof(Model.Data.BioBotDataSets.bbt_objectRow))) return null;
            objectRow = rowView.Row as Model.Data.BioBotDataSets.bbt_objectRow;
            return objectRow;
        }

        private void DeckView_DragDrop(object sender, DragEventArgs e)
        {
                BioBotDataSets.bbt_objectRow row = e.Data.GetData(typeof(BioBotDataSets.bbt_objectRow)) as BioBotDataSets.bbt_objectRow;
                addObject(row);
        }

        private void DeckView_DragEnter(object sender, DragEventArgs e)
        {
                e.Effect = DragDropEffects.Copy;
        }


        private void DeckView_Resize(object sender, EventArgs e)
        {
            if (deckX != 0 || deckY != 0)
            {
                ratioX = Convert.ToDouble(this.Width) / deckX;
                ratioY = Convert.ToDouble(this.Height) / deckY;
                foreach (Button but in buttons)
                {
                    but.Location = new Point(Convert.ToInt32(but.Location.X * ratioX), Convert.ToInt32(but.Location.Y * ratioY));
                    but.Width = Convert.ToInt32(but.Width * ratioX);
                    but.Height = Convert.ToInt32(but.Height * ratioY);
                }
                deckX = this.Width;
                deckY = this.Height;
                this.Size = new Size(deckX, deckY);
                
            }
        }
    }
}
