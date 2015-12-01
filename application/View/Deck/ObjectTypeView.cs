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
    public partial class ObjectTypeView : UserControl
    {
        public ObjectTypeView()
        {
            InitializeComponent();
            this.bsObjectType.DataMember = "bbt_object_type";
            this.bsObjectType.DataSource = DBManager.Instance.projectDataset;
        }


        public BioBotDataSets.bbt_object_typeRow getSelectedObjectTypeRow()
        {
            Model.Data.BioBotDataSets.bbt_object_typeRow objectTypeRow = null;

            if (bsObjectType.Current == null) return null;
            if (!(bsObjectType.Current.GetType() == typeof(DataRowView))) return null;
            DataRowView rowView = bsObjectType.Current as DataRowView;
            if (rowView.Row == null) return null;
            if (!(rowView.Row.GetType() == typeof(Model.Data.BioBotDataSets.bbt_object_typeRow))) return null;
            objectTypeRow = rowView.Row as Model.Data.BioBotDataSets.bbt_object_typeRow;
            return objectTypeRow;
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            BioBotDataSets.bbt_object_typeRow row = getSelectedObjectTypeRow();
            dataGridView1.DoDragDrop(row, DragDropEffects.Copy | DragDropEffects.Move);
        }
    }
}
