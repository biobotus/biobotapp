using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.EventBus.Events.OperationReference
{
    public class OperationReferenceRemoveEvent : EventArgs
    {
        public int pkID;

        public OperationReferenceRemoveEvent(int id)
        {
            this.pkID = id;
        }
    }
}
