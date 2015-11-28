using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PCAN;
using BioBotApp.Utils.Communication.pcan;
namespace SimpleTacClient.Option
{
    public partial class frmOptions : Form
    {
        private Dictionary<string, UserControl> treeViewAction = new Dictionary<string, UserControl>();

        public frmOptions(TreeNode tacConfRoot, Dictionary<string, UserControl> actions)
        {
            InitializeComponent();
            tlvOptions.Nodes.Add(tacConfRoot);
            treeViewAction = actions;
            treeViewAction.Add("canNode", new CanConnectorControl());
            PCANCom p = PCANCom.Instance;
            p.test = "toto";
        }

        private void tlvOptions_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UserControl control = null;

            string nodeName = e.Node.Name;

            if (treeViewAction.Keys.Contains(nodeName))
            {
                control = treeViewAction[nodeName];
            }

            if (control != null)
            {
                setOptionControl(control);
            }
            
        }


        /// <summary>
        /// Function that sets the center control
        /// </summary>
        /// <param name="optionControl">The user control to be set</param>
        private void setOptionControl(UserControl optionControl)
        {
            if (optionControl.Tag == null)
            {
                throw new System.ArgumentException("Option control tag is null !");
            }

            this.lblTitle.Text = optionControl.Tag.ToString();
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(optionControl);
            optionControl.Dock = DockStyle.Fill;
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
