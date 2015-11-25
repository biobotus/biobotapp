using BioBotApp.View.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.View.Step
{
    public interface IStepView : IDatasetViewControl
    {
        void setSelectedProtocolRow(Model.Data.BioBotDataSets.bbt_protocolRow row);
    }
}
