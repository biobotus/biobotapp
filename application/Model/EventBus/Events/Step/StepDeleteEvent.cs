using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.EventBus.Events.Step
{
    public class StepDeleteEvent
    {
        public int rowId { get; private set; }

        public StepDeleteEvent(int rowId)
        {
            this.rowId = rowId;
        }
    }
}
