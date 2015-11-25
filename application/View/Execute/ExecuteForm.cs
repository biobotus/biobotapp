using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBotApp.View.Execute
{
    public partial class ExecuteForm : Form
    {
        public ExecuteForm()
        {
            InitializeComponent();
        }

        private void ExecuteForm_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine(e.GetType());
        }
    }
}
