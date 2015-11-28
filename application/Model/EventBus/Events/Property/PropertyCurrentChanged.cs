using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.EventBus.Events.Property
{
    public class PropertyCurrentChanged : EventArgs
    {
        public int pk_id { get; private set; }

        public PropertyCurrentChanged(int Pk_id)
        {
            this.pk_id = Pk_id;
        }
    }
}
