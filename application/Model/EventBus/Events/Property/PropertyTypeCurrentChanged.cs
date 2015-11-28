using BioBotApp.Model.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBotApp.Model.EventBus.Events.Property
{
    public class PropertyTypeCurrentChanged : EventArgs
    {
        public int pk_id { get; private set; }

        public PropertyTypeCurrentChanged(int Pk_id)
        {
            //Model.Data.BioBotDataSets.bbt_property_typeRow row;
            //DataRowView rowView = PropertyBs.Current as DataRowView;
            //row = rowView.Row as Model.Data.BioBotDataSets.bbt_property_typeRow;
            this.pk_id = Pk_id;
        }
    }
}
