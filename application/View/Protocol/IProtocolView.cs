using BioBotApp.Presenter.Protocols;
using BioBotApp.View.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.View.Protocol
{
    public interface IProtocolView : IDatasetViewControl
    {
        void onProtocolAddEvent(Model.Data.BioBotDataSets.bbt_protocolRow row);
        void onProtocolModifyEvent(Model.Data.BioBotDataSets.bbt_protocolRow row);
        void onProtocolDeleteEvent(int rowId);
    }
}
