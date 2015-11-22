using BioBotApp.View.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Presenter
{
    public class ProtocolPresenter : Model.EventBus.Subscriber
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

        public void addProtocolRow(int fkProtocolId, String description, int index)
        {
            Model.Data.Services.ProtocolService.Instance.addProtocolRow(fkProtocolId, description, index);
        }

        public void addProtocolRow(String description, int index)
        {
            Model.Data.Services.ProtocolService.Instance.addProtocolRow(description, index);
        }

        public void modifyProtocolRow(Model.Data.BioBotDataSets.bbt_protocolRow row)
        {
            Model.Data.Services.ProtocolService.Instance.modifyProtocolRow(row);
        }

        [Model.EventBus.Subscribe]
        public void onProtocolAddEvent(Model.EventBus.Events.Protocol.ProtocolAddEvent e)
        {
            this.view.onProtocolAddEvent(e.Row);
        }

        [Model.EventBus.Subscribe]
        public void onProtocolModifyEvent(Model.EventBus.Events.Protocol.ProtocolModifyEvent e)
        {
            this.view.onProtocolModifyEvent(e.Row);
        }
    }
}
