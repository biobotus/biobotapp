using BioBotApp.Model.Data.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBotApp.View.TestView
{
    public partial class ObjectTypeTestForm : Form
    {
        public ObjectTypeTestForm()
        {
            InitializeComponent();
            this.bioBotDataSets = Model.Data.DBManager.Instance.projectDataset;
            this.bsObjectType.DataMember = "bbt_object_type";
            this.bsObjectType.DataSource = this.bioBotDataSets;
        }       

        public Model.Data.BioBotDataSets.bbt_object_typeRow getSelectedOperationRow()
        {
            Model.Data.BioBotDataSets.bbt_object_typeRow operationRow = null;

            if (bsObjectType.Current == null) return null;
            if (!(bsObjectType.Current.GetType() == typeof(DataRowView))) return null;
            DataRowView rowView = bsObjectType.Current as DataRowView;
            if (rowView.Row == null) return null;
            if (!(rowView.Row.GetType() == typeof(Model.Data.BioBotDataSets.bbt_object_typeRow))) return null;
            operationRow = rowView.Row as Model.Data.BioBotDataSets.bbt_object_typeRow;
            return operationRow;
        }

        #region events
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ObjectTypeService.Instance.addObjectTypeRow("allo");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ObjectTypeService.Instance.removeObjectTypeRow(getSelectedOperationRow());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Model.Data.BioBotDataSets.bbt_object_typeRow currentRow = getSelectedOperationRow();
            currentRow.description = tbDescription.Text;
            ObjectTypeService.Instance.updateRow(currentRow);
        }
        #endregion
    }
}
