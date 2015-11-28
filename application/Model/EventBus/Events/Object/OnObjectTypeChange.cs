using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.EventBus.Events.Object
{
    public class OnObjectTypeChange : EventArgs
    {
        public int pk_id { get; private set; }

        public OnObjectTypeChange(int Pk_id)
        {
            this.pk_id = Pk_id;
        }
    }
}
