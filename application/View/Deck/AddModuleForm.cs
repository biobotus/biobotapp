using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBotApp.View.Deck
{
    public partial class AddModuleForm : Form
    {
        public AddModuleForm()
        {
            InitializeComponent();
        }

        public AddModuleForm(int fkObject, int fkObjectType, int deck_x, int deck_y, int deck_z) : this()
        {
            //fkObjectBox.SelectedItem = getCollectionPk
        }
    }
}
