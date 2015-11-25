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
        BioBotDataSets.bbt_stepRow row;
        private int id = -1;

        public StepTreeNode(BioBotDataSets.bbt_stepRow row)
        {
            this.row = row;
            this.Text = this.row.description;
            this.BackColor = Color.LightGreen;
            this.id = row.pk_id;
        }

        public BioBotDataSets.bbt_stepRow getProtocolRow()
        {
            return this.row;
        }

        public void setProtocolRow(BioBotDataSets.bbt_stepRow row)
        {
            this.row = row;
            this.Text = row.description;
            this.id = row.pk_id;
        }

        public int getId()
        {
            return id;
        }
    }
}
