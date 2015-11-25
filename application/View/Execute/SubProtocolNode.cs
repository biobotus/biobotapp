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
    public class SubProtocolNode : TreeNode
    {
        private BioBotDataSets.bbt_protocolRow _protocolRow;

        public SubProtocolNode(BioBotDataSets.bbt_protocolRow protocolRow)
        {
            if (protocolRow == null)
            {
                return;
            }
            if (protocolRow.fk_protocol != null)
            {
                _protocolRow = protocolRow;
                this.Text = protocolRow.description;
                this.BackColor = Color.Yellow;
                this.Tag = protocolRow.pk_id;
            }
        }
        
    }
}
