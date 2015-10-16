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

        }

        public void setOperation(BioBotDataSets.bbt_operationRow operation)
        {

        }

        public void setProjectDataset(BioBotDataSets dataset)
        {

        }
    }
}
