using BioBotApp.Model.Data;
using BioBotApp.View.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.View.Operation
{
    public interface IOperationView : IDatasetViewControl
    {
        void setSelectedStepRow(BioBotDataSets.bbt_stepRow row);
        void setSelectedObjectTypeRow(BioBotDataSets.bbt_object_typeRow row);
    }
}
