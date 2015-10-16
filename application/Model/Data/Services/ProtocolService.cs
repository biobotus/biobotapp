using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.Data.Services
{
    public class ProtocolService
    {
        private DBManager _dbManager;
        BioBotDataSets _dataset;
        private BioBotDataSetsTableAdapters.bbt_protocolTableAdapter _taProtocol;

        private static ProtocolService _instance;

        private ProtocolService()
        {
            _dbManager = DBManager.Instance;
            _dataset = _dbManager.projectDataset;
            _taProtocol = _dbManager.taManager.bbt_protocolTableAdapter;
        }

        public static ProtocolService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProtocolService();
                }
                return _instance;
            }
        }

        public void modifyProtocol(int pkId, int fkId, String description)
        {
            BioBotDataSets.bbt_protocolRow protocolPk = _dataset.bbt_protocol.FindBypk_id(pkId);
            BioBotDataSets.bbt_protocolRow protocolFk = _dataset.bbt_protocol.FindBypk_id(fkId);

            if (protocolPk == null || protocolFk == null) return;
            protocolPk.fk_protocol = fkId;
            if (description.Length == 0) return;
            protocolPk.description = description;
            updateProtocol();

        }

        public void updateProtocol()
        {
            try
            {
                _taProtocol.Update(_dbManager.projectDataset.bbt_protocol);
            }
            catch(Exception e)
            {

            }
        }
    }
}
