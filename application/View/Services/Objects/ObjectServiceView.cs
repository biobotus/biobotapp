using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BioBotApp.Presenter.Services.Object;
using BioBotApp.View.Utils;
using BioBotApp.View.Services.Objects;
using BioBotApp.View.Utils.Controls;

namespace BioBotApp.View.Services
{
    public partial class ObjectServiceView : DatasetViewControl, IObjectServiceView
    {
        ObjectPresenter presenter;

        int fk_object_type = 0;
        int[] RotationAngle = { 0, 90, 180, 270 };

        public ObjectServiceView()
        {
            InitializeComponent();
            presenter = new ObjectPresenter(this);
            this.bioBotDataSets = dataset;
            this.bindingSource1.DataSource = bioBotDataSets;
        }

        public Model.Data.BioBotDataSets.bbt_objectRow ObjectCurrentRow
        {
            get
            {
                Model.Data.BioBotDataSets.bbt_objectRow row;
                DataRowView RowView = bindingSource1.Current as DataRowView;
                if (RowView == null)
                {
                    row = null;
                }
                else
                {
                    row = RowView.Row as Model.Data.BioBotDataSets.bbt_objectRow;
                }

                return row;
            }
        }

        private void AddObject(object sender, EventArgs e)
        {
            AbstractDialog dialog = new AbstractDialog("Add Object", "Add new object");
            NamedInputTextBox description = new NamedInputTextBox("Object Name: ");
            dialog.addControl(description);

            NamedInputTextBox deck_x = new NamedInputTextBox("Object Position in X: ");
            dialog.addControl(deck_x);

            NamedInputTextBox deck_y = new NamedInputTextBox("Object Position in Y: ");
            dialog.addControl(deck_y);

            namedComboBox rotation = new namedComboBox("Object Rotation: ");
            rotation.getComboBox().DataSource = RotationAngle;
            dialog.addControl(rotation);

            namedComboBox fk_object = new namedComboBox("Object Reference: ");
            fk_object.getComboBox().DataSource = bioBotDataSets.bbt_object;
            fk_object.getComboBox().ValueMember = "pk_id";
            fk_object.getComboBox().DisplayMember = "description";
            fk_object.getComboBox().SelectedIndex = 2;
            dialog.addControl(fk_object);

            NamedCheckBox activated_bool = new NamedCheckBox("Object Activated? ");
            dialog.addControl(activated_bool);

            int deck_x_int_parse;
            int deck_y_int_parse;
            string activated_str;

            
            DialogResult result = dialog.ShowDialog();

            Model.Data.BioBotDataSets.bbt_objectRow ObjectRow;
            DataRowView ObjectCombo = fk_object.getComboBox().SelectedItem as DataRowView;
            ObjectRow = ObjectCombo.Row as Model.Data.BioBotDataSets.bbt_objectRow;

            if (result == DialogResult.OK)
            {
                if (activated_bool.getInputValue()) { activated_str = "1"; } else { activated_str = "0"; }
                if (int.TryParse(deck_y.getInputTextValue(), out deck_y_int_parse) && int.TryParse(deck_x.getInputTextValue(), out deck_x_int_parse))
                {
                    presenter.AddObject(fk_object_type, deck_x_int_parse, deck_y_int_parse, int.Parse(rotation.getComboBox().SelectedItem.ToString()), activated_str, description.getInputTextValue(),ObjectRow.pk_id);
                }
                else
                {
                    MessageBox.Show("Please enter valid data for the object position");
                    AddObject(sender, e);                    
                }
            }


        }
        private void DeleteObject(object sender, EventArgs e)
        {
            if (ObjectCurrentRow != null)
            {
                AbstractDialog dialog = new AbstractDialog("Delete Object", "Delete Object");
                DialogResult result = MessageBox.Show("Delete : " + ObjectCurrentRow.description + " ?", "Delete Object ?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result.Equals(DialogResult.No))
                {
                    return;
                }


                presenter.DeleteObject(ObjectCurrentRow);

            }

        }
        private void ModifyObject(object sender, EventArgs e)
        {
            if (ObjectCurrentRow == null)
            {
                return;
            }

            bool activated_bool_value;
            string activated_str;
            int deck_y_int_parse;
            int deck_x_int_parse;

            AbstractDialog dialog = new AbstractDialog("Modify Object", "Modify object");
            NamedInputTextBox description = new NamedInputTextBox("Object Name: ", ObjectCurrentRow.description);
            dialog.addControl(description);

            NamedInputTextBox deck_x = new NamedInputTextBox("Object Position in X: ", ObjectCurrentRow.deck_x.ToString());
            dialog.addControl(deck_x);

            NamedInputTextBox deck_y = new NamedInputTextBox("Object Position in Y: ", ObjectCurrentRow.deck_y.ToString());
            dialog.addControl(deck_y);

            namedComboBox rotation = new namedComboBox("Object Rotation: ");
            rotation.getComboBox().DataSource = RotationAngle;
            rotation.getComboBox().SelectedIndex = rotation.getComboBox().Items.IndexOf(ObjectCurrentRow.rotation);
            dialog.addControl(rotation);

            namedComboBox fk_object = new namedComboBox("Object Reference: ");
            fk_object.getComboBox().DataSource = bioBotDataSets.bbt_object;
            fk_object.getComboBox().ValueMember = "pk_id";
            fk_object.getComboBox().DisplayMember = "description";
            fk_object.getComboBox().SelectedValue = ObjectCurrentRow.fk_object;
            dialog.addControl(fk_object);

            namedComboBox fk_object_type = new namedComboBox("Object Reference: ");
            fk_object_type.getComboBox().DataSource = bioBotDataSets.bbt_object_type;
            fk_object_type.getComboBox().ValueMember = "pk_id";
            fk_object_type.getComboBox().DisplayMember = "description";
            fk_object_type.getComboBox().SelectedValue = ObjectCurrentRow.fk_object_type;
            dialog.addControl(fk_object);

            if (ObjectCurrentRow.activated == "1") { activated_bool_value = true; } else { activated_bool_value = false; }
            NamedCheckBox activated_bool = new NamedCheckBox("Object Activated? ", activated_bool_value);
            dialog.addControl(activated_bool);

            DialogResult result = dialog.ShowDialog();

            Model.Data.BioBotDataSets.bbt_objectRow ObjectRow;
            DataRowView ObjectCombo = fk_object.getComboBox().SelectedItem as DataRowView;
            ObjectRow = ObjectCombo.Row as Model.Data.BioBotDataSets.bbt_objectRow;

            Model.Data.BioBotDataSets.bbt_object_typeRow ObjectTypeRow;
            DataRowView ObjectTypeCombo = fk_object_type.getComboBox().SelectedItem as DataRowView;
            ObjectTypeRow = ObjectTypeCombo.Row as Model.Data.BioBotDataSets.bbt_object_typeRow;

            if (result == DialogResult.OK)
            {
                if (activated_bool.getInputValue()) { activated_str = "1"; } else { activated_str = "0"; }
                if (int.TryParse(deck_y.getInputTextValue(), out deck_y_int_parse) && int.TryParse(deck_x.getInputTextValue(), out deck_x_int_parse))
                {
                    ObjectCurrentRow.fk_object_type = ObjectTypeRow.pk_id;
                    ObjectCurrentRow.deck_x = deck_x_int_parse;
                    ObjectCurrentRow.deck_y = deck_y_int_parse;
                    ObjectCurrentRow.rotation = int.Parse(rotation.getComboBox().SelectedItem.ToString());
                    ObjectCurrentRow.activated = activated_str;
                    ObjectCurrentRow.description = description.getInputTextValue();
                    ObjectCurrentRow.fk_object = ObjectRow.pk_id;

                    presenter.ModifyObject(ObjectCurrentRow);
                }
                else
                {
                    MessageBox.Show("Please enter valid data for the object position");
                    AddObject(sender, e);
                }
                
            }

        }

        public void OnObjectTypeChange(int pk_id)
        {
            this.bindingSource1.Filter = "fk_object_type =" + pk_id;
            fk_object_type = pk_id;
        }



    }
}
