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
    public class ProtocolTreeNode : TreeNode
    {
        BioBotDataSets.bbt_protocolRow protocolRow;

        public ProtocolTreeNode(BioBotDataSets.bbt_protocolRow protocolRow)
        {
            this.protocolRow = protocolRow;
            this.Text = this.protocolRow.description;
            this.BackColor = Color.LightCyan;
        }

        public BioBotDataSets.bbt_protocolRow getProtocolRow()
        {
            return this.protocolRow;
        }

        public void setProtocolRow(BioBotDataSets.bbt_protocolRow protocolRow)
        {
            this.protocolRow = protocolRow;
            this.Text = protocolRow.description;
        }
    }
}
