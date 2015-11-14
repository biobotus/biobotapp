using BioBotApp.Model.Data.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBotApp.View.TestView
{
    public partial class ObjectTypeTestForm : Form
    {
        public ObjectTypeTestForm()
        {
            InitializeComponent();
        }

        private void ObjectTypeTestForm_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'bioBotDataSets.bbt_object_type'. Vous pouvez la déplacer ou la supprimer selon vos besoins.
            this.bbt_object_typeTableAdapter.Fill(this.bioBotDataSets.bbt_object_type);            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ObjectTypeService.Instance.addObjectTypeRow("allo");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Row: " + dataGridView1.CurrentRow.Cells[0].Value);
            ObjectTypeService.Instance.removeObjectTypeRow((int)(dataGridView1.CurrentRow.Cells[0].Value));
        }
    }
}
