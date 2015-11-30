using BioBotApp.Model.Data.Services;
using BioBotApp.View.Operation.OperationTypeObjectType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Presenter.Operation.OperationTypeObjectType
{
    public class OperationTypeObjectTypePresenter:Model.EventBus.Subscriber
    {

        IOperationTypeObjectTypeView view;

        public OperationTypeObjectTypePresenter(IOperationTypeObjectTypeView view)
        {
            this.view = view;
        }
        public void AddOperationTypeObjectType(int fkObjectTypeId,int fkOperationTypeId)
        {
            OperationTypeObjectTypeServices.Instance.addOperationTypeObjectTypeRow(fkObjectTypeId, fkOperationTypeId);
        }
        public void DeleteOperationTypeObjectType(Model.Data.BioBotDataSets.bbt_operation_type_object_typeRow row)
        {
            OperationTypeObjectTypeServices.Instance.removeOperationTypeObjectTypeRow(row);
        }
        public void ModifyOperationTypeObjectType(Model.Data.BioBotDataSets.bbt_operation_type_object_typeRow row)
        {
            OperationTypeObjectTypeServices.Instance.modifyOperationTypeObjectTypeRow(row);
        }

    }
}
