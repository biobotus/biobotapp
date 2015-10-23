using BioBotApp.View.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.View.Operation
{
    public interface IOperationView : IDatasetView
    {
        void setOperation(Model.Data.BioBotDataSets.bbt_operationRow operation);
        void setStep(Model.Data.BioBotDataSets.bbt_stepRow stepRow);
    }
}
