using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.Data.Services
{
    public class SaveProtocolService
    {
        //DBManager dbManager;
        //BioBotDataSetsTableAdapters.bbt_save_protocol taProtocol;

        //private static SaveProtocolService instance;

        //private SaveProtocolService()
        //{
        //    this.dbManager = DBManager.Instance;
        //    this.taSaveProtocol = dbManager.taManager.bbt_save_protocolTableAdapter;
        //}

        //public static SaveProtocolService Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            instance = new SaveProtocolService();
        //        }
        //        return instance;
        //    }
        //}

        //public void addProtocolRow(int fkProtocolId, String description, int index)
        //{
        //    BioBotDataSets.bbt_save_protocolRow row = this.dbManager.projectDataset.bbt_protocol.Newbbt_protocolRow();
        //    row.description = description;
        //    row.fk_protocol = fkProtocolId;
        //    row.index = index;
        //    this.dbManager.projectDataset.bbt_protocol.Addbbt_protocolRow(row);
        //    updateRow(row);
        //    EventBus.EventBus.Instance.post(new Model.EventBus.Events.Protocol.ProtocolAddEvent(row));
        //}
    }
}
