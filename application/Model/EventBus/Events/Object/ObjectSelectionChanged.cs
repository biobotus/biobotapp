using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.EventBus.Events.Object
{
    public class ObjectSelectionChanged : EventArgs
    {
        public enum SelectionType { OBJECT_SELECTION, STEP_SELECTION }

        public Model.Data.BioBotDataSets.bbt_objectRow row { get; private set; }
        public SelectionType selectionType { get; private set; }

        public ObjectSelectionChanged(Model.Data.BioBotDataSets.bbt_objectRow row)
        {
            this.row = row;
        }

        public ObjectSelectionChanged(Model.Data.BioBotDataSets.bbt_objectRow row, SelectionType selectionType) : this(row)
        {
            this.selectionType = selectionType;
        }
    }
}
