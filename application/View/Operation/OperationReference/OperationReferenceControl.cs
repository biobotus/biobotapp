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

namespace BioBotApp.View.Operation.OperationReference
{
    public partial class OperationReferenceControl : DatasetViewControl, IOperationReferenceView
    {
        BioBotDataSets.bbt_operationRow operationRow;
        Presenter.Operation.OperationReference.OperationReferencePresenter presenter;
        public OperationReferenceControl()
        {
            InitializeComponent();
            presenter = new Presenter.Operation.OperationReference.OperationReferencePresenter(this);
            this.bioBotDataSets = dataset;
            this.bsOperation.DataSource = this.bioBotDataSets;
            this.bsObject.DataSource = this.bioBotDataSets;
            this.bsOperationReference.DataSource = this.bsOperation;
        }

        public void setSelectedOperation(BioBotDataSets.bbt_operationRow row)
        {
            int index = this.dataset.bbt_operation.Rows.IndexOf(row);
            if (index < 0)
            {
                this.bsOperation.Filter = "pk_id = -1";
                return;
            }
            this.bsOperation.Filter = "pk_id = " + row.pk_id;
            operationRow = row;
            this.bsOperation.Position = index;
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
