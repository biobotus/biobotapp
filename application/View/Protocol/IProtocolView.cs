using BioBotApp.View.Utils;

namespace BioBotApp.View.Protocol
{
    public interface IProtocolView : IDatasetViewControl
    {
        void onProtocolAddEvent(Model.Data.BioBotDataSets.bbt_protocolRow row);
        void onProtocolModifyEvent(Model.Data.BioBotDataSets.bbt_protocolRow row);
        void onProtocolDeleteEvent(int rowId);
    }
}
