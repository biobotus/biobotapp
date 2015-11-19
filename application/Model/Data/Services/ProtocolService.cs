using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.Data.Services
{
    public class ProtocolService
    {
        DBManager dbManager;
        BioBotDataSetsTableAdapters.bbt_protocolTableAdapter taProtocol;

        private static ProtocolService instance;

        private ProtocolService()
        {
            this.dbManager = DBManager.Instance;
            this.taProtocol = dbManager.taManager.bbt_protocolTableAdapter;
        }

        public static ProtocolService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProtocolService();
                }
                return instance;
            }
        }

        public void addProtocolRow(int fkProtocolId, String description, int index)
        {
            BioBotDataSets.bbt_protocolRow row = this.dbManager.projectDataset.bbt_protocol.Newbbt_protocolRow();
            row.description = description;
            row.fk_protocol = fkProtocolId;
            this.dbManager.projectDataset.bbt_protocol.Addbbt_protocolRow(row);
            updateRow(row);
        }

        public void modifyProtocolRow(int pk_id, int fkProtocolId, String description, int index)
        {
            BioBotDataSets.bbt_protocolRow row = this.dbManager.projectDataset.bbt_protocol.FindBypk_id(pk_id);
            row.fk_protocol = fkProtocolId;
            row.description = description;
            updateRow(row);
        }

        // Need to do a recursive function to delete the protocols and the sub protocols
        public void removeProtocolRow(int pk_id)
        {
            BioBotDataSets.bbt_protocolRow row = this.dbManager.projectDataset.bbt_protocol.FindBypk_id(pk_id);
            removeProtocolRow(row);
        }

        public void removeProtocolRow(BioBotDataSets.bbt_protocolRow protocolRow)
        {       
            foreach (BioBotDataSets.bbt_protocolRow childProtocolRow in protocolRow.Getbbt_protocolRows())
            {
                StepService.Instance.removeStepsWithGivenProtocol(childProtocolRow);
                removeProtocolRow(childProtocolRow);
            }
            protocolRow.Delete();
            updateRow(protocolRow);
        }

        public void updateRow(BioBotDataSets.bbt_protocolRow row)
        {
            try
            {
                this.taProtocol.Update(row);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                this.dbManager.projectDataset.bbt_protocol.RejectChanges();
            }
        }
    }
}
