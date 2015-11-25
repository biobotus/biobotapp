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

namespace BioBotApp.View.Protocol.OperationType
{
    public partial class OperationTypeControl : DatasetViewControl
    {
        public OperationTypeControl()
        {
            InitializeComponent();
            this.bioBotDataSets = dataset;
            //this.bbtoperationtypeBindingSource.DataMember = "bbt_operation_type";
            this.bsOperationType.DataSource = dataset;
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
    }
}
