using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BioBotApp.Presenter.Services;
using BioBotApp.Model.Data.Services;
using BioBotApp.View.Utils;

namespace BioBotApp.View.Services
{
    public partial class InformationValueServiceView : DatasetViewControl, IInformationValueServiceView
    {
        private InformationValueServicesPresenter presenter = null;

        int fkPropertyID = 0;


        public InformationValueServiceView()
        {
            InitializeComponent();
            presenter = new InformationValueServicesPresenter(this);
            this.bioBotDataSets = dataset;
            this.InformationValueBindingSource.DataSource = bioBotDataSets;
        }

        /* 
        Variable containing passing information 
        */

        public DataGridView InformationValueDataTable
        {
            set
            {
                this.dataGridView1.DataSource = InformationValueBindingSource;
            }
        }

        public int InformationValuePrimaryKey
        {
            get
            {
                Model.Data.BioBotDataSets.bbt_information_valueRow row;
                DataRowView rowView = InformationValueBindingSource.Current as DataRowView;
                row = rowView.Row as Model.Data.BioBotDataSets.bbt_information_valueRow;
                return row.pk_id;
            }
        }
        public Model.Data.BioBotDataSets.bbt_information_valueRow InformationValueCurrentRow
        {
            get
            {
                Model.Data.BioBotDataSets.bbt_information_valueRow row;
                DataRowView rowView = InformationValueBindingSource.Current as DataRowView;
                if(rowView == null)
                {
                    row = null;
                }
                else
                {
                    row = rowView.Row as Model.Data.BioBotDataSets.bbt_information_valueRow;
                }
                
                return row;
            }
        }
        public int PropertyForeignKey
        {
            get
            {
                Model.Data.BioBotDataSets.bbt_propertyRow row;
                DataRowView rowView = InformationValueBindingSource.Current as DataRowView;
                row = rowView.Row as Model.Data.BioBotDataSets.bbt_propertyRow;
                return row.pk_id;
            }
        }
        public int ObjectForeignKey
        {
            get
            {
                Model.Data.BioBotDataSets.bbt_objectRow row;
                DataRowView rowView = InformationValueBindingSource.Current as DataRowView;
                row = rowView.Row as Model.Data.BioBotDataSets.bbt_objectRow;
                return row.pk_id;
            }
        }
        public string PropertyDescription
        {
            get
            {
                Model.Data.BioBotDataSets.bbt_propertyRow row;
                DataRowView rowView = InformationValueBindingSource.Current as DataRowView;
                row = rowView.Row as Model.Data.BioBotDataSets.bbt_propertyRow;
                return row.description;
            }
        }
        public string ObjectDescription
        {
            get
            {
                Model.Data.BioBotDataSets.bbt_objectRow row;
                DataRowView rowView = InformationValueBindingSource.Current as DataRowView;
                row = rowView.Row as Model.Data.BioBotDataSets.bbt_objectRow;
                return row.description;
            }
        }

        /*
        Fonction triggered by the button 
        */

        private void AddInformationValue(object sender, EventArgs e)
        {

            AbstractDialog dialog = new AbstractDialog("Add Information", "Add new Information");
            NamedInputTextBox InformationValue = new NamedInputTextBox("Information Value: ");
            dialog.addControl(InformationValue);

            namedComboBox fk_object = new namedComboBox("Object: ");
            fk_object.getComboBox().DataSource = bioBotDataSets.bbt_object;
            fk_object.getComboBox().ValueMember = "pk_id";
            fk_object.getComboBox().DisplayMember = "description";
            dialog.addControl(fk_object);

            namedComboBox fk_information = new namedComboBox("Information: ");
            fk_information.getComboBox().DataSource = bioBotDataSets.bbt_information_value;
            fk_information.getComboBox().ValueMember = "pk_id";
            fk_information.getComboBox().DisplayMember = "information_value";
            dialog.addControl(fk_information);

            DialogResult result = dialog.ShowDialog();

            Model.Data.BioBotDataSets.bbt_objectRow ObjectRow;
            DataRowView ObjectCombo = fk_object.getComboBox().SelectedItem as DataRowView;
            ObjectRow = ObjectCombo.Row as Model.Data.BioBotDataSets.bbt_objectRow;

            Model.Data.BioBotDataSets.bbt_information_valueRow InformationRow;
            DataRowView InformationCombo = fk_information.getComboBox().SelectedItem as DataRowView;
            InformationRow = InformationCombo.Row as Model.Data.BioBotDataSets.bbt_information_valueRow;

            if (result == DialogResult.OK)
            {
                presenter.AddInformationValue(InformationValue.getInputTextValue(), fkPropertyID, ObjectRow.pk_id, InformationRow.pk_id);
            }

        }
        private void DeleteInformationValue(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Delete : " + InformationValueCurrentRow.information_value + " ?", "Delete Object ?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result.Equals(DialogResult.No))
            {
                return;
            }

            presenter.DeleteInformationValue(InformationValueCurrentRow);

        }
        private void ModifyInformationValue(object sender, EventArgs e)
        {

            Model.Data.BioBotDataSets.bbt_information_valueRow CurrentInformationRow = InformationValueCurrentRow;

            if (CurrentInformationRow == null)
            {
                return;
            }

            AbstractDialog dialog = new AbstractDialog("Add Information", "Add new Information");

            NamedInputTextBox InformationValue = new NamedInputTextBox("Information Value: ", CurrentInformationRow.information_value);
            dialog.addControl(InformationValue);

            namedComboBox fk_object = new namedComboBox("Object: ");
            fk_object.getComboBox().DataSource = bioBotDataSets.bbt_object;
            fk_object.getComboBox().ValueMember = "pk_id";
            fk_object.getComboBox().DisplayMember = "description";
            fk_object.getComboBox().SelectedValue = CurrentInformationRow.fk_object;
            dialog.addControl(fk_object);

            namedComboBox fk_Property = new namedComboBox("Property: ");
            fk_Property.getComboBox().DataSource = bioBotDataSets.bbt_property;
            fk_Property.getComboBox().ValueMember = "pk_id";
            fk_Property.getComboBox().DisplayMember = "description";
            fk_Property.getComboBox().SelectedValue = CurrentInformationRow.fk_property;
            dialog.addControl(fk_Property);

            namedComboBox fk_information = new namedComboBox("Information: ");
            fk_information.getComboBox().DataSource = bioBotDataSets.bbt_information_value;
            fk_information.getComboBox().ValueMember = "pk_id";
            fk_information.getComboBox().DisplayMember = "information_value";
            fk_information.getComboBox().SelectedValue = CurrentInformationRow.fk_information_value;
            dialog.addControl(fk_information);

            DialogResult result = dialog.ShowDialog();

            Model.Data.BioBotDataSets.bbt_objectRow ObjectRow;
            DataRowView ObjectCombo = fk_object.getComboBox().SelectedItem as DataRowView;
            ObjectRow = ObjectCombo.Row as Model.Data.BioBotDataSets.bbt_objectRow;

            Model.Data.BioBotDataSets.bbt_propertyRow PropertyRow;
            DataRowView PropetyCombo = fk_Property.getComboBox().SelectedItem as DataRowView;
            PropertyRow = PropetyCombo.Row as Model.Data.BioBotDataSets.bbt_propertyRow;

            Model.Data.BioBotDataSets.bbt_information_valueRow InformationRow;
            DataRowView InformationCombo = fk_information.getComboBox().SelectedItem as DataRowView;
            InformationRow = InformationCombo.Row as Model.Data.BioBotDataSets.bbt_information_valueRow;

            if (result == DialogResult.OK)
            {
                CurrentInformationRow.fk_information_value = InformationRow.pk_id;
                CurrentInformationRow.fk_object = ObjectRow.pk_id;
                CurrentInformationRow.information_value = InformationValue.getInputTextValue();
                CurrentInformationRow.fk_property = PropertyRow.pk_id;

                presenter.ModifyInformationValue(CurrentInformationRow);
            }

        }
        public void OnPropertyChange(int pk_id)
        {
            this.InformationValueBindingSource.Filter = "fk_property =" + pk_id;
            fkPropertyID = pk_id;
        }
                
    }
}
