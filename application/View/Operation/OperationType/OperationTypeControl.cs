using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BioBotApp.View.Utils;
using BioBotApp.Model.Data;

namespace BioBotApp.View.Operation.OperationType
{
    public partial class OperationTypeControl : DatasetViewControl
    {
        BioBotDataSets.bbt_object_typeRow objectTypeRow;
        public OperationTypeControl()
        {
            InitializeComponent();
            this.bioBotDataSets = dataset;
            //this.bbtoperationtypeBindingSource.DataMember = "bbt_operation_type";
            this.bsOperationType.DataSource = dataset;
            this.bsOperationType.Filter = "pk_id = -1";
        }

        public OperationTypeControl(BioBotDataSets.bbt_object_typeRow objectTypeRow) : this()
        {
            this.objectTypeRow = objectTypeRow;
            foreach(BioBotDataSets.bbt_operation_type_object_typeRow row in objectTypeRow.Getbbt_operation_type_object_typeRows())
            {
                if(this.bsOperationType.Filter == String.Empty)
                {
                    this.bsOperationType.Filter = "pk_id = " + row.fk_operation_type;
                }
                else
                {
                    this.bsOperationType.Filter += " OR pk_id = " + row.fk_operation_type;
                }
            }
            if (this.bsOperationType.Filter == String.Empty)
            {
                this.bsOperationType.Filter = "pk_id = -1";
            }
        }

        public Model.Data.BioBotDataSets.bbt_operation_typeRow getSelectedOperationType()
        {
            Model.Data.BioBotDataSets.bbt_operation_typeRow operationTypeRow;
            if (this.bsOperationType.Current == null) return null;
            DataRowView rowview = this.bsOperationType.Current as DataRowView;
            if (rowview == null) return null;
            operationTypeRow = rowview.Row as Model.Data.BioBotDataSets.bbt_operation_typeRow;
            return operationTypeRow;
        }

        public void setSelectedOperationType(Model.Data.BioBotDataSets.bbt_operation_typeRow row)
        {
            if (row == null) return;
            this.cmbOperationType.SelectedValue = row.pk_id;
        }
    }
}
