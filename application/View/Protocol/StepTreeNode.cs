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
        private int id = -1;
        public StepTreeNode(BioBotDataSets.bbt_stepRow stepRow)
        {
            this.stepRow = stepRow;
            this.Text = this.stepRow.description;
            this.BackColor = Color.LightGreen;
            this.id = stepRow.pk_id;
        }

        public void updateStepRow(BioBotDataSets.bbt_stepRow row)
        {
            this.stepRow = row;
            this.Text = this.stepRow.description;
            this.id = row.pk_id;
        }

        public BioBotDataSets.bbt_stepRow getStepRow()
        {
            return this.stepRow;
        }

        public int getId()
        {
            return id;
        }
    }
}
