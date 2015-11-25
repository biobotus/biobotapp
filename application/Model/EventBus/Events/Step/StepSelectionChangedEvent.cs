using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.EventBus.Events.Step
{
    public class StepSelectionChangedEvent : EventArgs
    {
        public Data.BioBotDataSets.bbt_stepRow stepRow { get; private set; }

        public StepSelectionChangedEvent(Data.BioBotDataSets.bbt_stepRow stepRow)
        {
            this.stepRow = stepRow;
        }
    }
}
