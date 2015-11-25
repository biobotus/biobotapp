using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BioBotApp.Model.Data;

namespace BioBotApp.View.Deck
{
    public partial class ObjectView : UserControl
    {
        public ObjectView()
        {
            InitializeComponent();
            this.bsObject.DataMember = "bbt_object";
            this.bsObject.DataSource = Model.Data.DBManager.Instance.projectDataset;
        }


        public BioBotDataSets.bbt_objectRow getSelectedObjectRow()
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

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            BioBotDataSets.bbt_objectRow row = getSelectedObjectRow();
            dataGridView1.DoDragDrop(row, DragDropEffects.Copy | DragDropEffects.Move);
        }
    }
}
