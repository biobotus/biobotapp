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
        private BioBotDataSets.bbt_objectRow _objectRow;
        public DeckView()
        {
            InitializeComponent();
            this.bsBiobot.DataMember = "bbt_object";
            this.bsBiobot.DataSource = Model.Data.DBManager.Instance.projectDataset;
        }

        public void addObject(BioBotDataSets.bbt_objectRow obj)
        {
            Label Mod = new Label();
            BioBotDataSets.bbt_object_propertyRow rowWidth = DBManager.Instance.projectDataset.bbt_object_property.Where(p => p.fk_object_type_id == _objectRow.bbt_object_typeRow.pk_id && p.fk_properties_id == 2).First();
            BioBotDataSets.bbt_object_propertyRow rowLength = DBManager.Instance.projectDataset.bbt_object_property.Where(p => p.fk_object_type_id == _objectRow.bbt_object_typeRow.pk_id && p.fk_properties_id == 3).First();
            Mod.Text = obj.pk_id.ToString();
            Mod.Location = new Point(obj.deck_x, obj.deck_y);
            Mod.Height = Int16.Parse(rowWidth.value);
            Mod.Width = Int16.Parse(rowLength.value);
            Mod.BorderStyle = BorderStyle.FixedSingle;
            Mod.TextAlign = ContentAlignment.MiddleCenter;
            
            this.deck.Controls.Add(Mod);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
                _objectRow = getSelectedObjectRow();
            addObject(_objectRow);
        }

        public Model.Data.BioBotDataSets.bbt_objectRow getSelectedObjectRow()
        {
            Model.Data.BioBotDataSets.bbt_objectRow objectRow = null;

            if (bsBiobot.Current == null) return null;
            if (!(bsBiobot.Current.GetType() == typeof(DataRowView))) return null;
            DataRowView rowView = bsBiobot.Current as DataRowView;
            if (rowView.Row == null) return null;
            if (!(rowView.Row.GetType() == typeof(Model.Data.BioBotDataSets.bbt_objectRow))) return null;
            objectRow = rowView.Row as Model.Data.BioBotDataSets.bbt_objectRow;
            return objectRow;
        }
    }
}
