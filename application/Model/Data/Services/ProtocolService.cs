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
        BioBotDataSets.bbt_protocolRow selectedRow;

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

        public void setSelectedRow(BioBotDataSets.bbt_protocolRow selectedRow)
        {
            this.selectedRow = selectedRow;
            EventBus.EventBus.Instance.post(new Model.EventBus.Events.Protocol.ProtocolSelectionChangedEvent(selectedRow));
        }

        public void addProtocolRow(int fkProtocolId, String description, int index)
        {
            BioBotDataSets.bbt_protocolRow row = this.dbManager.projectDataset.bbt_protocol.Newbbt_protocolRow();
            row.description = description;
            row.fk_protocol = fkProtocolId;
            row.index = index;
            this.dbManager.projectDataset.bbt_protocol.Addbbt_protocolRow(row);
            updateRow(row);
            EventBus.EventBus.Instance.post(new Model.EventBus.Events.Protocol.ProtocolAddEvent(row));
        }
        public void addProtocolRow(String description, int index)
        {
            BioBotDataSets.bbt_protocolRow row = this.dbManager.projectDataset.bbt_protocol.Newbbt_protocolRow();
            row.description = description;
            this.dbManager.projectDataset.bbt_protocol.Addbbt_protocolRow(row);
            updateRow(row);
            EventBus.EventBus.Instance.post(new Model.EventBus.Events.Protocol.ProtocolAddEvent(row));
        }

        public void modifyProtocolRow(BioBotDataSets.bbt_protocolRow row)
        {
            updateRow(row);
            EventBus.EventBus.Instance.post(new Model.EventBus.Events.Protocol.ProtocolModifyEvent(row));
        }

        public void modifyProtocolRow(int pk_id, int fkProtocolId, String description, int index)
        {
            BioBotDataSets.bbt_protocolRow row = this.dbManager.projectDataset.bbt_protocol.FindBypk_id(pk_id);
            row.fk_protocol = fkProtocolId;
            row.description = description;
            updateRow(row);
            EventBus.EventBus.Instance.post(new Model.EventBus.Events.Protocol.ProtocolModifyEvent(row));
        }

        // Need to do a recursive function to delete the protocols and the sub protocols
        public void removeProtocolRow(int pk_id)
        {
            BioBotDataSets.bbt_protocolRow row = this.dbManager.projectDataset.bbt_protocol.FindBypk_id(pk_id);
            removeProtocolRow(row);
        }

        public void removeProtocolRow(BioBotDataSets.bbt_protocolRow row)
        {
            int rowId = -1;
            int index = -1;
            BioBotDataSets.bbt_protocolRow parentProtocolRow = row.bbt_protocolRowParent;
            StepService.Instance.removeStepsWithGivenProtocol(row);
            foreach (BioBotDataSets.bbt_protocolRow childProtocolRow in row.Getbbt_protocolRows())
            {
                StepService.Instance.removeStepsWithGivenProtocol(childProtocolRow);
                removeChildRows(childProtocolRow);
            }
            index = row.index;
            rowId = row.pk_id;
            row.Delete();
            updateRow(row);
            EventBus.EventBus.Instance.post(new Model.EventBus.Events.Protocol.ProtocolDeleteEvent(rowId));
            updateIndex(parentProtocolRow, index);
        }

        private void removeChildRows(BioBotDataSets.bbt_protocolRow row)
        {
            int rowId = -1;
            StepService.Instance.removeStepsWithGivenProtocol(row);
            foreach (BioBotDataSets.bbt_protocolRow childProtocolRow in row.Getbbt_protocolRows())
            {
                StepService.Instance.removeStepsWithGivenProtocol(childProtocolRow);
                removeChildRows(childProtocolRow);
            }
            rowId = row.pk_id;
            row.Delete();
            updateRow(row);
        }

        public void updateIndex(BioBotDataSets.bbt_protocolRow parentRow, int index)
        {
            if (parentRow == null) return;
            foreach (BioBotDataSets.bbt_protocolRow protocolRow in parentRow.Getbbt_protocolRows())
            {
                if(protocolRow.index > index)
                {
                    protocolRow.index--;
                    modifyProtocolRow(protocolRow);
                }
            }
            foreach(BioBotDataSets.bbt_stepRow stepRow in parentRow.Getbbt_stepRows())
            {
                if(stepRow.index > index)
                {
                    stepRow.index--;
                    StepService.Instance.modifyStepRow(stepRow);
                }
            }
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
