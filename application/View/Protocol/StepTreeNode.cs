using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBotApp.View.Protocol
{
    public class StepTreeNode : TreeNode
    {
        public StepTreeNode(String text)
        {
            this.Text = text;
            this.BackColor = Color.LightGreen;
        }
    }
}
