using BioBotApp.Model.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBotApp.View.Execute
{
    class ProtocolNode: TreeNode
    {
        private BioBotDataSets.bbt_protocolRow _protocolRow;

        public ProtocolNode(BioBotDataSets.bbt_protocolRow protocolRow)
        {
            if (protocolRow == null)
            {
                return;
            }
            this.Text = protocolRow.description;
            this.BackColor = Color.LightGreen;
        }

        public BioBotDataSets.bbt_protocolRow getProtocolRow()
        {
            return _protocolRow;
        }
    }
}
