using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BioBotApp.Presenter.Step;
using BioBotApp.View.Utils;
using BioBotApp.Model.Data;

namespace BioBotApp.View.Step
{
    public partial class StepControl : DatasetViewControl, IStepView
    {
        StepPresenter presenter;
        BioBotDataSets.bbt_stepRow stepRow;
        public StepControl()
        {
            InitializeComponent();
            presenter = new StepPresenter(this);
            this.bioBotDataSets = dataset;
            this.bsObject.DataSource = this.bioBotDataSets;
            this.bsOperationType.DataSource = this.bioBotDataSets;
            this.bsOperation.DataSource = this.bioBotDataSets;
        }

        public StepControl(BioBotDataSets.bbt_stepRow stepRow) : this()
        {
            setStepRow(stepRow);
        }

        public void setStepRow(BioBotDataSets.bbt_stepRow stepRow)
        {
            this.stepRow = stepRow;
            this.txtStepName.Text = stepRow.description;
            cmbObject.SelectedValue = stepRow.fk_object;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AbstractDialog dialog = new AbstractDialog("Add operation", "Add new operation");
            Operation.OperationControl control = new Operation.OperationControl();
            dialog.addControl(control);
            DialogResult result = dialog.ShowDialog();
            if(result == DialogResult.OK)
            {

            }
        }

        public Model.Data.BioBotDataSets.bbt_objectRow getSelectedObjectRow()
        {
            Model.Data.BioBotDataSets.bbt_objectRow objectRow;
            if (this.bsObject.Current == null) return null;
            DataRowView rowView = this.bsObject.Current as DataRowView;
            if (rowView.Row == null) return null;
            if (!(rowView.Row is Model.Data.BioBotDataSets.bbt_objectRow)) return null;
            objectRow = rowView.Row as Model.Data.BioBotDataSets.bbt_objectRow;
            return objectRow;
        }

        public String getDescription()
        {
            if (txtStepName.Text == String.Empty) return null;
            return txtStepName.Text;
        }

        public void addStepRow(BioBotDataSets.bbt_stepRow stepRow)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        public void modifyStepRow(BioBotDataSets.bbt_stepRow stepRow)
        {
            if (this.stepRow == null) return;
            if (this.stepRow.pk_id == stepRow.pk_id)
            {
                setStepRow(stepRow);
            }
        }
        /*
public void executeAddStepRow(int fkProtocolId, int index)
{
BioBotDataSets.bbt_objectRow row = getSelectedObjectRow();
if (row == null) return;
int fkObjectRow = row.pk_id;
this.presenter.addStepRow(fkProtocolId,this.txtStepName.Text, fkObjectRow, index);
}
*/
    }
}
