using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBotApp.View.Operation
{
    public partial class OperationForm : Form
    {

        public OperationForm()
        {
            InitializeComponent();
            this.bioBotDataSets = Model.Data.DBManager.Instance.projectDataset;
            this.bbt_stepBindingSource.DataMember = "bbt_step";
            this.bbt_stepBindingSource.DataSource = this.bioBotDataSets;
            this.bbtobjectBindingSource.DataMember = "bbt_object";
            this.bbtobjectBindingSource.DataSource = this.bioBotDataSets;
            this.bbt_operationBindingSource.DataMember = "bbt_operation";
            this.bbt_operationBindingSource.DataSource = this.bioBotDataSets;
            this.bbtstepbbtoperationBindingSource.DataMember = "bbt_step_bbt_operation";
            this.bbtstepbbtoperationBindingSource.DataSource = this.bbt_stepBindingSource;
        }

        private void bbt_stepBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            Model.Data.BioBotDataSets.bbt_stepRow stepRow = getSelectedStepRow();
            if (stepRow == null) return;
            Model.EventBus.EventBus.Instance.post(new Model.EventBus.Step.StepEvent(stepRow));
        }

        public Model.Data.BioBotDataSets.bbt_stepRow getSelectedStepRow()
        {
            Model.Data.BioBotDataSets.bbt_stepRow stepRow = null;

            if (bbt_stepBindingSource.Current == null) return null;
            if (!(bbt_stepBindingSource.Current.GetType() == typeof(DataRowView))) return null;
            DataRowView rowView = bbt_stepBindingSource.Current as DataRowView;
            if (rowView.Row == null) return null;
            if (!(rowView.Row.GetType() == typeof(Model.Data.BioBotDataSets.bbt_stepRow))) return null;
            stepRow = rowView.Row as Model.Data.BioBotDataSets.bbt_stepRow;
            return stepRow;
        }

        public Model.Data.BioBotDataSets.bbt_operationRow getSelectedOperationRow()
        {
            Model.Data.BioBotDataSets.bbt_operationRow operationRow = null;

            if (bbtstepbbtoperationBindingSource.Current == null) return null;
            if (!(bbtstepbbtoperationBindingSource.Current.GetType() == typeof(DataRowView))) return null;
            DataRowView rowView = bbtstepbbtoperationBindingSource.Current as DataRowView;
            if (rowView.Row == null) return null;
            if (!(rowView.Row.GetType() == typeof(Model.Data.BioBotDataSets.bbt_operationRow))) return null;
            operationRow = rowView.Row as Model.Data.BioBotDataSets.bbt_operationRow;
            return operationRow;
        }

        private void bbtstepbbtoperationBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            Model.Data.BioBotDataSets.bbt_operationRow operationRow = getSelectedOperationRow();
            if (operationRow == null) return;
            Model.EventBus.EventBus.Instance.post(new Model.EventBus.Operation.OperationEvent(operationRow));
        }
    }
}
