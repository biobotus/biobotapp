using BioBotApp.View.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Presenter
{
    public class ProtocolPresenter
    {
        private IProtocolView view;

        public ProtocolPresenter(IProtocolView view)
        {
            this.view = view;
            this.view.setProjectDataset(Model.Data.DBManager.Instance.projectDataset);
        }

        public void updateProtocol()
        {
            Model.Data.DBManager.Instance.taManager.bbt_protocolTableAdapter.Update(Model.Data.DBManager.Instance.projectDataset.bbt_protocol);
        }
    }
}
