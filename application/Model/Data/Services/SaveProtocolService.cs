using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.Data.Services
{
    public class SaveProtocolService
    {
        DBManager dbManager;
        BioBotDataSetsTableAdapters.bbt_save_protocolTableAdapter taSaveProtocol;

        private static SaveProtocolService instance;

        private SaveProtocolService()
        {
            this.dbManager = DBManager.Instance;
            this.taSaveProtocol = dbManager.taManager.bbt_save_protocolTableAdapter;
        }

        public static SaveProtocolService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SaveProtocolService();
                }
                return instance;
            }
        }


        public void addSaveProtocolRow(string description)
        {
            BioBotDataSets.bbt_save_protocolRow row = this.dbManager.projectDataset.bbt_save_protocol.Newbbt_save_protocolRow();
            row.description = description;
            this.dbManager.projectDataset.bbt_save_protocol.Addbbt_save_protocolRow(row);
            updateRow(row);
        }

        public void addSaveProtocolRow(int fkSaveProtocol, int fkProtocol, string description)
        {
            BioBotDataSets.bbt_save_protocolRow row = this.dbManager.projectDataset.bbt_save_protocol.Newbbt_save_protocolRow();
            row.fk_protocol = fkProtocol;
            row.fk_save_protocol = fkSaveProtocol;
            row.description = description;
            this.dbManager.projectDataset.bbt_save_protocol.Addbbt_save_protocolRow(row);
            updateRow(row);
        }

        public void addSaveStepRow(int fkSaveProtocol, int fkStep, string description)
        {
            BioBotDataSets.bbt_save_protocolRow row = this.dbManager.projectDataset.bbt_save_protocol.Newbbt_save_protocolRow();
            row.fk_step= fkStep;
            row.fk_save_protocol = fkSaveProtocol;
            row.description = description;
            this.dbManager.projectDataset.bbt_save_protocol.Addbbt_save_protocolRow(row);
            updateRow(row);
        }

        public void modifySaveProtocolRow(BioBotDataSets.bbt_save_protocolRow row)
        {
            updateRow(row);
        }

        public void modifySaveProtocolRow(int pk_id, int fkProtocol, int fkSaveProtocol, int fkStep, String description)
        {
            BioBotDataSets.bbt_save_protocolRow row = this.dbManager.projectDataset.bbt_save_protocol.FindBypk_id(pk_id);
            row.fk_protocol = fkProtocol;
            row.fk_step = fkStep;
            row.fk_save_protocol = fkSaveProtocol;
            row.description = description;
            updateRow(row);
        }

        public void removeSaveProtocolRow(int pk_id)
        {
            List<BioBotDataSets.bbt_save_protocolRow> listSaveProtocol = new List<BioBotDataSets.bbt_save_protocolRow>();
            listSaveProtocol.AddRange(DBManager.Instance.projectDataset.bbt_save_protocol.Where(p => p.fk_save_protocol == pk_id));
            foreach (BioBotDataSets.bbt_save_protocolRow childSaveProtocolRow in listSaveProtocol)
            {
                childSaveProtocolRow.Delete();
            }
        }

        public void removeSaveProtocolRow(BioBotDataSets.bbt_save_protocolRow row)
        {
            List<BioBotDataSets.bbt_save_protocolRow> listSaveProtocol = new List<BioBotDataSets.bbt_save_protocolRow>();
            listSaveProtocol.AddRange(DBManager.Instance.projectDataset.bbt_save_protocol.Where(p => p.fk_save_protocol == row.fk_save_protocol));
            foreach (BioBotDataSets.bbt_save_protocolRow childSaveProtocolRow in listSaveProtocol)
            {
                childSaveProtocolRow.Delete();
            }
        }

        public void updateRow(BioBotDataSets.bbt_save_protocolRow row)
        {
            try
            {
                this.taSaveProtocol.Update(row);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                this.dbManager.projectDataset.bbt_save_protocol.RejectChanges();
            }
        }
    }
}
