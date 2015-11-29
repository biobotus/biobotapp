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
using BioBotApp.Presenter.Step;

namespace BioBotApp.View.Step
{
    public partial class StepView2 : DatasetViewControl, IStepView
    {
        [PropertyTab("Show toolbar")]
        [Browsable(true)]
        [Description("Show right toolbar"), Category("Behavior")]
        public bool ShowToolbar
        {
            get { return this.toolbarPanel.Visible; }
            set { this.toolbarPanel.Visible = value; }
        }

        private StepPresenter presenter;
        public StepView2()
        {
            InitializeComponent();
            presenter = new StepPresenter(this);
            this.bioBotDataSet = this.dataset;

            this.bsObject.DataSource = this.bioBotDataSet;
            this.bsProtocol.DataSource = this.bioBotDataSet;
            this.bsStep.DataSource = this.bsProtocolStep;
            this.bsProtocolStep.DataSource = this.bsProtocol;
        }

        public void setSelectedProtocolRow(BioBotDataSets.bbt_protocolRow row)
        {
            int index = this.dataset.bbt_protocol.Rows.IndexOf(row);
            if (index < 0) return;
            this.bsProtocol.Position = index;
            BioBotDataSets.bbt_stepRow stepRow = getSelectedStepRow();
            this.presenter.setSelectedStepRow(stepRow);
            try
            {
                dgvOperation.Sort(indexColumn, ListSortDirection.Ascending);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                //exception used to eliminate designer error : 
                //DataGridView control cannot be sorted if it is bound to an IBindingList that does not support sorting. 
            }
        }

        public BioBotDataSets.bbt_protocolRow getSelectedProcotolRow()
        {
            if (this.bsProtocol == null) return null;
            if (this.bsProtocol.Current == null) return null;
            if (!(this.bsProtocol.Current is DataRowView)) return null;
            DataRowView rowView = this.bsProtocol.Current as DataRowView;
            if (rowView.Row == null) return null;
            if (!(rowView.Row is BioBotDataSets.bbt_protocolRow)) return null;
            return rowView.Row as BioBotDataSets.bbt_protocolRow;
        }

        public BioBotDataSets.bbt_objectRow getSelectedObjectRow()
        {
            return getSelectedObjectRow(this.bsObject);
        }

        public BioBotDataSets.bbt_objectRow getSelectedObjectRow(BindingSource bindingSource)
        {
            if (bindingSource == null) return null;
            if (bindingSource.Current == null) return null;
            if (!(bindingSource.Current is DataRowView)) return null;
            DataRowView rowView = bindingSource.Current as DataRowView;
            if (rowView.Row == null) return null;
            if (!(rowView.Row is BioBotDataSets.bbt_objectRow)) return null;
            return rowView.Row as BioBotDataSets.bbt_objectRow;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            BioBotDataSets.bbt_stepRow stepRow = getSelectedStepRow();
            if (stepRow == null) return;
            if (stepRow.index > this.bsStep.Count) return;
            foreach (DataRowView rowView in bsStep)
            {
                if (rowView.Row is BioBotDataSets.bbt_stepRow)
                {
                    BioBotDataSets.bbt_stepRow row = rowView.Row as BioBotDataSets.bbt_stepRow;
                    if (row.index == stepRow.index - 1)
                    {
                        row.index++;
                        stepRow.index--;
                        this.presenter.modifyStepRow(row);
                        this.presenter.modifyStepRow(stepRow);
                        break;
                    }
                }
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            BioBotDataSets.bbt_stepRow stepRow = getSelectedStepRow();
            if (stepRow == null) return;
            if (stepRow.index > this.bsStep.Count) return;
            foreach (DataRowView rowView in bsStep)
            {
                if (rowView.Row is BioBotDataSets.bbt_stepRow)
                {
                    BioBotDataSets.bbt_stepRow row = rowView.Row as BioBotDataSets.bbt_stepRow;
                    if (row.index == stepRow.index + 1)
                    {
                        row.index--;
                        stepRow.index++;
                        this.presenter.modifyStepRow(row);
                        this.presenter.modifyStepRow(stepRow);
                        break;
                    }
                }
            }
        }

        public BioBotDataSets.bbt_stepRow getSelectedStepRow()
        {
            if (bsStep.Current == null) return null;
            if (!(bsStep.Current is DataRowView)) return null;
            DataRowView rowView = bsStep.Current as DataRowView;
            if (rowView.Row == null) return null;
            if (!(rowView.Row is BioBotDataSets.bbt_stepRow)) return null;
            return rowView.Row as BioBotDataSets.bbt_stepRow;
        }

        private void StepView2_Load(object sender, EventArgs e)
        {
            try
            {
                dgvOperation.Sort(indexColumn, ListSortDirection.Ascending);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                //exception used to eliminate designer error : 
                //DataGridView control cannot be sorted if it is bound to an IBindingList that does not support sorting. 
            }
        }

        private void dgvOperation_EnabledChanged(object sender, EventArgs e)
        {
            try
            {
                dgvOperation.Sort(indexColumn, ListSortDirection.Ascending);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                //exception used to eliminate designer error : 
                //DataGridView control cannot be sorted if it is bound to an IBindingList that does not support sorting. 
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            BioBotDataSets.bbt_stepRow row = getSelectedStepRow();
            if (row == null) return;
            this.presenter.removeStepRow(row);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            AbstractDialog dialog = new AbstractDialog();
            BioBotDataSets.bbt_stepRow stepRow = getSelectedStepRow();
            if (stepRow == null) return;

            NamedInputTextBox stepDescription = new NamedInputTextBox("Description: ", stepRow.description);
            NamedInputTextBox stepValue = new NamedInputTextBox("Value: ", stepRow.value);
            namedComboBox stepObjectReference = new namedComboBox("Object: ");
            stepObjectReference.getComboBox().DataSource = this.bsObject;
            stepObjectReference.getComboBox().DisplayMember = "description";
            stepObjectReference.getComboBox().ValueMember = "pk_id";
            stepObjectReference.getComboBox().SelectedValue = stepRow.fk_object;
            dialog.addControl(stepDescription);
            dialog.addControl(stepObjectReference);
            dialog.addControl(stepValue);

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                String description = stepDescription.getInputTextValue();
                String value = stepValue.getInputTextValue();
                BioBotDataSets.bbt_protocolRow protocolRow = getSelectedProcotolRow();

                if (description == null) return;
                if (protocolRow == null) return;
                if (description == String.Empty) return;
                if (!(stepObjectReference.getComboBox().DataSource is BindingSource)) return;
                BioBotDataSets.bbt_objectRow objectRow = getSelectedObjectRow(stepObjectReference.getComboBox().DataSource as BindingSource);
                stepRow.description = description;
                stepRow.value = value;
                stepRow.fk_object = objectRow.pk_id;

                this.presenter.modifyStepRow(stepRow);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AbstractDialog dialog = new AbstractDialog();
            NamedInputTextBox stepDescription = new NamedInputTextBox("Description: ", String.Empty);
            NamedInputTextBox stepValue = new NamedInputTextBox("Value: ", String.Empty);
            namedComboBox stepObjectReference = new namedComboBox("Object: ");
            stepObjectReference.getComboBox().DataSource = this.bsObject;
            stepObjectReference.getComboBox().DisplayMember = "description";
            stepObjectReference.getComboBox().ValueMember = "pk_id";

            dialog.addControl(stepDescription);
            dialog.addControl(stepObjectReference);
            dialog.addControl(stepValue);

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                String description = stepDescription.getInputTextValue();
                String value = stepValue.getInputTextValue();
                BioBotDataSets.bbt_protocolRow protocolRow = getSelectedProcotolRow();

                if (description == null) return;
                if (protocolRow == null) return;
                if (description == String.Empty) return;
                if (!(stepObjectReference.getComboBox().DataSource is BindingSource)) return;

                BioBotDataSets.bbt_objectRow objectRow = getSelectedObjectRow(stepObjectReference.getComboBox().DataSource as BindingSource);
                int index = protocolRow.Getbbt_stepRows().Length + protocolRow.Getbbt_protocolRows().Length + 1;

                this.presenter.addStepRow(protocolRow.pk_id, description, objectRow.pk_id, index);
            }
        }

        private void dgvOperation_SelectionChanged(object sender, EventArgs e)
        {
            BioBotDataSets.bbt_stepRow stepRow = getSelectedStepRow();
            if (stepRow == null) return;
            this.presenter.setSelectedStepRow(stepRow);
        }

        private void bsStep_ListChanged(object sender, ListChangedEventArgs e)
        {
            Boolean enableControl = !(dgvOperation.Rows.GetRowCount(DataGridViewElementStates.Visible) == 0);
            btnDelete.Enabled = enableControl;
            btnEdit.Enabled = enableControl;
        }

        public void addStepRow(BioBotDataSets.bbt_stepRow row)
        {
        }

        public void modifyStepRow(BioBotDataSets.bbt_stepRow row)
        {
        }

        public void deleteStepRow(int id)
        {
        }
    }
}
