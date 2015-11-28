using BioBotApp.View.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBotApp.View.Option
{
    public partial class OptionMainView : Form
    {
        public OptionMainView()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Name.Equals("PropertyNode"))
            {
                setOptionControl(new OptionServicesPropertyView());
            }
            else if (e.Node.Name.Equals("ObjectNode"))
            {
                setOptionControl(new OptionServicesObjectView());
            }
            else
            {
                setOptionControl(null);
            }

        }
        private void setOptionControl(UserControl optionControl)
        {
            if (optionControl == null)
            {
                mainPanel.Controls.Clear();
                return;
            }
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(optionControl);
            optionControl.Dock = DockStyle.Fill;
        }
    }
}
