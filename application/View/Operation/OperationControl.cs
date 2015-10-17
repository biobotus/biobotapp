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
using BioBotApp.View.Utils;
using BioBotApp.Presenter.Operation;

namespace BioBotApp.View.Operation
{
    public partial class OperationControl : UserControl, IOperationView
    {
        OperationPresenter presenter;

        public OperationControl()
        {
            InitializeComponent();
            this.presenter = new OperationPresenter(this);
        }

        public void initBindings()
        {
            this.bbt_operation_referenceBindingSource.DataMember = "bbt_operation_reference";
            this.bbt_operation_referenceBindingSource.DataSource = this.bioBotDataSets;
            this.bbtobjectBindingSource.DataMember = "bbt_object";
            this.bbtobjectBindingSource.DataSource = this.bioBotDataSets;
        }

        public void setOperation(BioBotDataSets.bbt_operationRow operation)
        {
            this.bioBotDataSets.bbt_operation.DefaultView.RowFilter = "fk_operation = " + operation.pk_id;
        }

        public void setProjectDataset(BioBotDataSets dataset)
        {
            this.bioBotDataSets = dataset;
            initBindings();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
