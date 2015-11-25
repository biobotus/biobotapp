using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BioBotApp.Model.Data;
using System.Drawing;

namespace BioBotApp.View.Execute
{
    class StepNode : System.Windows.Forms.TreeNode
    {
        private BioBotDataSets.bbt_stepRow _stepRow;

        public StepNode(BioBotDataSets.bbt_stepRow stepRow)
        {
            if (stepRow == null)
            {
                return;
            }

            if (stepRow.pk_id < 0)
            {
                //return;
            }

            _stepRow = stepRow;
            this.Text = stepRow.description;
            this.BackColor = Color.Yellow;
            this.Tag = stepRow.pk_id;
        }

        public BioBotDataSets.bbt_stepRow getStepRow()
        {
            return _stepRow;
        }
    }
}
