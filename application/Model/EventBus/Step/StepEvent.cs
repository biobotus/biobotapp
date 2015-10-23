using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.EventBus.Step
{
    public class StepEvent : EventArgs
    {
        public Data.BioBotDataSets.bbt_stepRow stepRow { get; private set; }

        public StepEvent(Data.BioBotDataSets.bbt_stepRow stepRow)
        {
            this.stepRow = stepRow;
        }
    }
}
