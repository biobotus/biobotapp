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
        void addStepRow(Model.Data.BioBotDataSets.bbt_stepRow stepRow);
        void modifyStepRow(Model.Data.BioBotDataSets.bbt_stepRow stepRow);
    }
}
