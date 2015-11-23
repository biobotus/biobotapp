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
        private int deckY = 0;
        private int deckXReal;
        private int deckX = 0;
        private int XPk;
        private int YPk;
        private int dim;
        private int deckTypePk;
        private int ratio = 2;
        private int ratioX;
        private int ratioY;

        public DeckView()
        {
            InitializeComponent();
            this.bsObject.DataMember = "bbt_object";
            this.bsObject.DataSource = DBManager.Instance.projectDataset;
            dim = DBManager.Instance.projectDataset.bbt_property_type.Where(p => (p.description.ToString()).Equals("dimension", StringComparison.InvariantCultureIgnoreCase)).First().pk_id;
            deckTypePk = DBManager.Instance.projectDataset.bbt_object_type.Where(p => (p.description.ToString()).Equals("deck",StringComparison.InvariantCultureIgnoreCase)).First().pk_id;
            XPk = DBManager.Instance.projectDataset.bbt_property.Where(p => (p.description.ToString()).Equals("xlength", StringComparison.InvariantCultureIgnoreCase) && p.fk_property_type==dim).First().pk_id;
            YPk = DBManager.Instance.projectDataset.bbt_property.Where(p => (p.description.ToString()).Equals("ylength", StringComparison.InvariantCultureIgnoreCase) && p.fk_property_type == dim).First().pk_id;
            BioBotDataSets.bbt_objectRow deck = DBManager.Instance.projectDataset.bbt_object.Where(p => p.activated == "1" && p.fk_object_type==deckTypePk).First();
            deckXReal = int.Parse(DBManager.Instance.projectDataset.bbt_object_property.Where(p => p.fk_object_type_id == deck.fk_object_type && p.fk_properties_id == XPk).First().value);
            deckYReal = int.Parse(DBManager.Instance.projectDataset.bbt_object_property.Where(p => p.fk_object_type_id == deck.fk_object_type && p.fk_properties_id == YPk).First().value);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            deckX = 550; // Convert.ToInt32(Math.Floor(Convert.ToDecimal(this.ParentForm.ClientSize.Width / ratio)));
            deckY = 443; // Convert.ToInt32(Math.Floor(Convert.ToDecimal(this.ParentForm.ClientSize.Height / ratio)));
            this.Size = new Size(deckX, deckY);
            this.Location = new Point(this.ParentForm.ClientSize.Width - deckX, 0);
            ratioX = deckX / deckXReal;
            ratioY = deckY / deckYReal;
        }

        //protected override void OnParentChanged(EventArgs e)
        //{
        //    base.OnParentChanged(e);
        //    if (deckX != 0 || deckY != 0)
        //    {
        //        deckX = Convert.ToInt32(Math.Floor(Convert.ToDecimal(this.ParentForm.ClientSize.Width / ratio)));
        //        deckY = Convert.ToInt32(Math.Floor(Convert.ToDecimal(this.ParentForm.ClientSize.Height / ratio)));
        //        this.Size = new Size(deckX, deckY);
        //        this.Location = new Point(this.ParentForm.ClientSize.Width - deckX, 0);
        //        ratioX = deckX / deckXReal;
        //        ratioY = deckY / deckYReal;
        //    }
        //}

        //protected override void OnSizeChanged(EventArgs e)
        //{
        //    base.OnSizeChanged(e);
        //    if (deckX != 0 || deckY != 0)
        //    {
        //        deckX = Convert.ToInt32(Math.Floor(Convert.ToDecimal(this.ParentForm.ClientSize.Width / ratio)));
        //        deckY = Convert.ToInt32(Math.Floor(Convert.ToDecimal(this.ParentForm.ClientSize.Height / ratio)));
        //        this.Size = new Size(deckX, deckY);
        //        this.Location = new Point(this.ParentForm.ClientSize.Width - deckX, 0);
        //        ratioX = deckX / deckXReal;
        //        ratioY = deckY / deckYReal;
        //    }
        //}

        public void addObject(BioBotDataSets.bbt_objectRow obj)
        {
            if (obj.activated == "1") // || obj.deck_x != null || obj.deck_y != null)
            {
                Button Mod = new Button();
                BioBotDataSets.bbt_object_propertyRow rowX = DBManager.Instance.projectDataset.bbt_object_property.Where(p => p.fk_object_type_id == obj.bbt_object_typeRow.pk_id && p.fk_properties_id == XPk).First();
                BioBotDataSets.bbt_object_propertyRow rowY = DBManager.Instance.projectDataset.bbt_object_property.Where(p => p.fk_object_type_id == obj.bbt_object_typeRow.pk_id && p.fk_properties_id == YPk).First();
                int XDt = int.Parse(rowX.value.ToString());
                int YDt = int.Parse(rowY.value.ToString());
                Mod.Text = obj.description;
                Mod.Location = new Point(deckX - obj.deck_x * ratioX - XDt * ratioX, obj.deck_y * ratioY);
                setRotation(obj,XDt, YDt, Mod);
                Mod.TextAlign = ContentAlignment.MiddleCenter;

                this.Controls.Add(Mod);
            }
        }

        private void setRotation(BioBotDataSets.bbt_objectRow obj, int height, int width, Button button)
        {
            switch (obj.rotation)
            {
                case 0:
                    button.Width = width * ratioX;
                    button.Height = height * ratioY;
                    break;
                case 90:
                    button.Width = - height * ratioX;
                    button.Height = width * deckY / deckYReal;
                    break;
                case 180:
                    button.Width = - width * ratioX;
                    button.Height = -height* ratioY;
                    break;
                case 270:
                    button.Width = - height * ratioX;
                    button.Height = width * ratioY;
                    break;
                default:
                    MessageBox.Show("Rotation value not allowed");
                    break;
            }
        }

        public Model.Data.BioBotDataSets.bbt_objectRow getSelectedObjectRow()
        {
            Model.Data.BioBotDataSets.bbt_objectRow objectRow = null;

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
            try
            {
                BioBotDataSets.bbt_objectRow row = e.Data.GetData(typeof(BioBotDataSets.bbt_objectRow)) as BioBotDataSets.bbt_objectRow;
            }
            //if (row.bbt_object_typeRow.description == "Deck" || typeof(row.deck_x) != ) return;
            catch (StrongTypingException)
            {
                
            }
        }

        private void DeckView_DragEnter(object sender, DragEventArgs e)
        {
                e.Effect = DragDropEffects.Copy;
        }
    }
}
