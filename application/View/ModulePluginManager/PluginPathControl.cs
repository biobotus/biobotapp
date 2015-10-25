using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BioBotApp.Presenter.ModulePluginManager;

namespace BioBotApp.View.ModulePluginManager
{


    public partial class PluginPathControl : UserControl, IModulePluginPathView
    {

        private DataTable dtpluginPath = new DataTable();
        private PathPresenter presenter;

        public PluginPathControl()
        {
            InitializeComponent();
            dtpluginPath.Columns.Add("path");
            pathListView.DataSource = dtpluginPath;
            presenter = new PathPresenter(this);
        }

        public void LoadModulePluginPath(List<string> path)
        {
            dtpluginPath.Clear();
            foreach (string s in path)
            {
                dtpluginPath.Rows.Add(new object[] { s });
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = pathBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtNewPath.Text = pathBrowserDialog.SelectedPath;
            }
        }

        private void btnAddToPathList_Click(object sender, EventArgs e)
        {
            string path = txtNewPath.Text;
            
            if (path != null && path != "")
            {
                bool isInTable = dtpluginPath.AsEnumerable().Any(row => path == row.Field<String>("path"));
                if(!isInTable)
                {
                    dtpluginPath.Rows.Add(new object[] { txtNewPath.Text });
                }
            }
        }

        private void btnUpdateTextPathList_Click(object sender, EventArgs e)
        {
            if (pathListView.SelectedRows.Count > 0)
            {
                string path = txtNewPath.Text;

                if (path != null)
                {
                    bool isInTable = dtpluginPath.AsEnumerable().Any(row => path == row.Field<String>("path"));
                    if (!isInTable)
                    {
                        int selectedRow;
                        selectedRow = pathListView.SelectedRows[0].Index;
                        pathListView.Rows[selectedRow].SetValues(new object[] { txtNewPath.Text });
                    }
                }

            }
        }

        private void btnUpSel_Click(object sender, EventArgs e)
        {
            if (pathListView.SelectedRows.Count > 0)
            {
                int selectedRow;
                selectedRow = pathListView.SelectedRows[0].Index;

                if (selectedRow > 0)
                {
                    pathListView.CurrentCell = pathListView.Rows[selectedRow - 1].Cells[0];
                }
            }   
        }

        private void btnDownSel_Click(object sender, EventArgs e)
        {
            if (pathListView.SelectedRows.Count > 0)
            {
                int selectedRow;
                selectedRow = pathListView.SelectedRows[0].Index;

                if (selectedRow < pathListView.Rows.Count - 1)
                {
                    pathListView.CurrentCell = pathListView.Rows[selectedRow + 1].Cells[0];
                }
            }
            
            
        }

        private void btnDelLine_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in pathListView.SelectedRows)
            {
                pathListView.Rows.Remove(row);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Is there a cleaner way to do that?
            presenter.saveModulePluginPathList(dtpluginPath.AsEnumerable().Select(x => x[0].ToString()).ToList());
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            presenter.loadModulePluginPathList();
        }
    }
}
