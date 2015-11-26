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
using BioBotApp.View.Utils;
using BioBotApp.Presenter.Deck;

namespace BioBotApp.View.Deck
{
    public partial class DeckView : DatasetViewControl, IDeckView
    {
        private DeckPresenter presenter;
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
        private Module _NewObject;


        public DeckView()
        {
            InitializeComponent();
            this.presenter = new DeckPresenter(this);
            this.bsObject.DataMember = "bbt_object";
            this.bsObject.DataSource = DBManager.Instance.projectDataset;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            BioBotDataSets.bbt_property_typeRow PropertyDim = dataset.bbt_property_type.Where(p => (p.description.ToString()).Equals("dimension", StringComparison.InvariantCultureIgnoreCase)).First();
            dim = PropertyDim.pk_id;
            BioBotDataSets.bbt_object_typeRow deckType = dataset.bbt_object_type.Where(p => (p.description.ToString()).Equals("deck", StringComparison.InvariantCultureIgnoreCase)).First();
            deckTypePk = deckType.pk_id;
            BioBotDataSets.bbt_propertyRow PropertyX = dataset.bbt_property.Where(p => (p.description.ToString()).Equals("xlength", StringComparison.InvariantCultureIgnoreCase) && p.fk_property_type == dim).First();
            XPk = PropertyX.pk_id;
            BioBotDataSets.bbt_propertyRow PropertyY = dataset.bbt_property.Where(p => (p.description.ToString()).Equals("ylength", StringComparison.InvariantCultureIgnoreCase) && p.fk_property_type == dim).First();
            YPk = PropertyY.pk_id;
            BioBotDataSets.bbt_objectRow deck = dataset.bbt_object.Where(p => p.activated == "1" && p.fk_object_type == deckTypePk).First();
            BioBotDataSets.bbt_object_propertyRow deckXRealRow = dataset.bbt_object_property.Where(p => p.fk_object_type_id == deck.fk_object_type && p.fk_properties_id == XPk).First();
            deckXReal = int.Parse(deckXRealRow.value);
            BioBotDataSets.bbt_object_propertyRow deckYRealRow = dataset.bbt_object_property.Where(p => p.fk_object_type_id == deck.fk_object_type && p.fk_properties_id == YPk).First();
            deckYReal = int.Parse(deckYRealRow.value);
            this.Location = new Point(this.ParentForm.ClientSize.Width - deckX, 0);
            deckX = this.ParentForm.Width;
            deckY = this.ParentForm.Height;
            this.Size = new Size(deckX, deckY);
        }

        public void addObject(BioBotDataSets.bbt_objectRow obj)
        {
            if (obj.activated == "1")
            {
                BioBotDataSets.bbt_propertyRow pkPropertyLayout = DBManager.Instance.projectDataset.bbt_property.Where(p => (p.description.ToString()).Equals("CanDeckLayout", StringComparison.InvariantCultureIgnoreCase)).First();
                BioBotDataSets.bbt_object_propertyRow objLayout = DBManager.Instance.projectDataset.bbt_object_property.Where(p => p.fk_object_type_id == obj.fk_object_type && p.fk_properties_id == pkPropertyLayout.pk_id).First();
                if (objLayout.value == "1")
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
                if (objLayout.value == "0")
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
            if (!(rowView.Row.GetType() == typeof(BioBotDataSets.bbt_objectRow))) return null;
            objectRow = rowView.Row as BioBotDataSets.bbt_objectRow;
            return objectRow;
        }

        private void DeckView_DragDrop(object sender, DragEventArgs e)
        {
            BioBotDataSets.bbt_objectRow row = e.Data.GetData(typeof(BioBotDataSets.bbt_objectRow)) as BioBotDataSets.bbt_objectRow;
            BioBotDataSets.bbt_object_propertyRow ModuleSize = dataset.bbt_object_property.Where(p => p.fk_object_type_id == row.fk_object_type && p.fk_properties_id == XPk).First();
            int ModuleSizeX = int.Parse(ModuleSize.value);
            ModuleSize = dataset.bbt_object_property.Where(p => p.fk_object_type_id == row.pk_id && p.fk_properties_id == YPk).First();
            int ModuleSizeY = int.Parse(ModuleSize.value);
            UserDeckForm popup = new UserDeckForm(deckXReal, deckYReal);
            DialogResult result = popup.ShowDialog();

                if (result == DialogResult.OK && popup.FullField() == true)
                {
                    // check if it fits the deck
                    if (popup.FitInDeck(deckXReal, deckYReal, popup.setRotation(ModuleSizeX, ModuleSizeY))==true)
                    {
                        _NewObject = popup.getObjectUserForm(ModuleSizeX,ModuleSizeY);
                        this.presenter.addNewObject(_NewObject, row.pk_id, row.fk_object_type, row.description);
                    }
                    else
                    {
                    MessageBox.Show("Wrong dimensions");
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    popup.Close();
                }
            popup.Dispose();
        }

        private void DeckView_DragEnter(object sender, DragEventArgs e)
        {
           
                e.Effect = DragDropEffects.Copy;
        }

        public Module NewObject
        {
            get
            {
                return _NewObject;
            }

            set
            {
                _NewObject = value;
                //addObject(_NewObject);
            }
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
