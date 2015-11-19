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
        private BioBotDataSets.bbt_propertyRow length = DBManager.Instance.projectDataset.bbt_property.Where(p => p.description == "length").First();
        private BioBotDataSets.bbt_propertyRow width = DBManager.Instance.projectDataset.bbt_property.Where(p => p.description == "width").First();

        public DeckView()
        {
            InitializeComponent();
            this.bsObject.DataMember = "bbt_object";
            this.bsObject.DataSource = DBManager.Instance.projectDataset;
            BioBotDataSets.bbt_propertyRow length = DBManager.Instance.projectDataset.bbt_property.Where(p => p.description == "length").First();
            BioBotDataSets.bbt_propertyRow width = DBManager.Instance.projectDataset.bbt_property.Where(p => p.description == "width").First();
            BioBotDataSets.bbt_objectRow deck = DBManager.Instance.projectDataset.bbt_object.Where(p => p.description == "deck" && p.activated == "1").First();
            BioBotDataSets.bbt_object_propertyRow rowWidth = DBManager.Instance.projectDataset.bbt_object_property.Where(p => p.fk_object_type_id == deck.pk_id && p.fk_properties_id == length.pk_id).First();
            BioBotDataSets.bbt_object_propertyRow rowLength = DBManager.Instance.projectDataset.bbt_object_property.Where(p => p.fk_object_type_id == deck.bbt_object_typeRow.pk_id && p.fk_properties_id == width.pk_id).First();
            this.Size = new Size(Int32.Parse(rowWidth.value),Int32.Parse(rowLength.value));

        }



        public void addObject(BioBotDataSets.bbt_objectRow obj)
        {
            if (obj.activated == "1")
            {
                Label Mod = new Label();
                BioBotDataSets.bbt_object_propertyRow rowWidth = DBManager.Instance.projectDataset.bbt_object_property.Where(p => p.fk_object_type_id == obj.bbt_object_typeRow.pk_id && p.fk_properties_id == length.pk_id).First();
                BioBotDataSets.bbt_object_propertyRow rowLength = DBManager.Instance.projectDataset.bbt_object_property.Where(p => p.fk_object_type_id == obj.bbt_object_typeRow.pk_id && p.fk_properties_id == width.pk_id).First();
                Mod.Text = obj.pk_id.ToString();
                Mod.Location = new Point(obj.deck_x, obj.deck_y);
                Mod.Height = Int16.Parse(rowWidth.value);
                Mod.Width = Int16.Parse(rowLength.value);
                Mod.BorderStyle = BorderStyle.FixedSingle;
                Mod.TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add(Mod);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
            BioBotDataSets.bbt_objectRow row = e.Data.GetData(typeof(BioBotDataSets.bbt_objectRow)) as BioBotDataSets.bbt_objectRow;
            addObject(row);
        }

        private void DeckView_DragEnter(object sender, DragEventArgs e)
        {
                e.Effect = DragDropEffects.Copy;
        }
    }
}
