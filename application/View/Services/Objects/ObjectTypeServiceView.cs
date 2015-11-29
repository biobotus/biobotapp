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
using BioBotApp.View.Services.Objects;
using BioBotApp.Presenter.Services.Object;

namespace BioBotApp.View.Services
{
    public partial class ObjectTypeServiceView : DatasetViewControl, IObjectTypeServiceView
    {

        ObjectTypePresenter Presenter;

        public ObjectTypeServiceView()
        {
            InitializeComponent();
            Presenter = new ObjectTypePresenter(this);
            this.bioBotDataSets = dataset;
            this.bbtobjecttypeBindingSource.DataSource = bioBotDataSets;
        }

        public Model.Data.BioBotDataSets.bbt_object_typeRow ObjectTypeCurrentRow
        {
            get
            {
                Model.Data.BioBotDataSets.bbt_object_typeRow row;
                DataRowView RowView = bbtobjecttypeBindingSource.Current as DataRowView;
                if (RowView == null)
                {
                    row = null;
                }
                else
                {
                    row = RowView.Row as Model.Data.BioBotDataSets.bbt_object_typeRow;
                }

                return row;
            }
        }


        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            Model.Data.BioBotDataSets.bbt_object_typeRow row;
            DataRowView rowView = bbtobjecttypeBindingSource.Current as DataRowView;
            row = rowView.Row as Model.Data.BioBotDataSets.bbt_object_typeRow;

            Presenter.OnObjectTypeChanged(row.pk_id, e);
            
        }

        private void AddObjectType(object sender, EventArgs e)
        {
            AbstractDialog dialog = new AbstractDialog("Add Object Type", "Add new object type");
            NamedInputTextBox description = new NamedInputTextBox("Object Type Name: ");
            dialog.addControl(description);

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Presenter.AddObjectType(description.getInputTextValue());
            }


        }
        private void DeleteObjectType(object sender, EventArgs e)
        {
            if (ObjectTypeCurrentRow != null)
            {
                AbstractDialog dialog = new AbstractDialog("Delete Object Type", "Delete Object Type");
                DialogResult result = MessageBox.Show("Delete : " + ObjectTypeCurrentRow.description + " ?", "Delete Object Type ?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result.Equals(DialogResult.No))
                {
                    return;
                }


                Presenter.DeleteObjectType(ObjectTypeCurrentRow);

            }

        }
        private void ModifyObjectType(object sender, EventArgs e)
        {
            if (ObjectTypeCurrentRow == null)
            {
                return;
            }

            AbstractDialog dialog = new AbstractDialog("Modify Property Type", "Modify property type");
            NamedInputTextBox description = new NamedInputTextBox("Property Type Name: ", ObjectTypeCurrentRow.description);
            dialog.addControl(description);

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                ObjectTypeCurrentRow.description = description.getInputTextValue();
                Presenter.ModifyObjectType(ObjectTypeCurrentRow);
            }

        }

    }
}
