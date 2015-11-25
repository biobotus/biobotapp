using BioBotApp.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.EventBus.Events.Property
{
    public class PropertyCurrentChanged : EventArgs
    {
        public BioBotDataSets.bbt_property_typeRow Row { get; private set; }

        public PropertyCurrentChanged(BioBotDataSets.bbt_property_typeRow PropertyRow)
        {
            this.Row = PropertyRow;
        }
    }
}
