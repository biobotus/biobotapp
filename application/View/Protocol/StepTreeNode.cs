using BioBotApp.Model.Data;
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
        private BioBotDataSets.bbt_stepRow stepRow;
        public StepTreeNode(BioBotDataSets.bbt_stepRow stepRow)
        {
            this.stepRow = stepRow;
            this.Text = this.stepRow.description;
            this.BackColor = Color.LightGreen;
        }

        public void updateStepRow(BioBotDataSets.bbt_stepRow row)
        {
            this.stepRow = row;
            this.Text = this.stepRow.description;
        }

        public BioBotDataSets.bbt_stepRow getStepRow()
        {
            return this.stepRow;
        }
    }
}
