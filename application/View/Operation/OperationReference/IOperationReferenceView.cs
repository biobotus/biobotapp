using BioBotApp.Model.Data;
using BioBotApp.View.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.View.Operation.OperationReference
{
    public interface IOperationReferenceView : IDatasetViewControl
    {
        void setSelectedOperation(BioBotDataSets.bbt_operationRow row);
    }
}
