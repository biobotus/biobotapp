using BioBotApp.Model.Data;
using BioBotApp.Presenter.Utils;
using BioBotApp.View.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Presenter.Operation
{
    public class OperationPresenter : DatasetPresenter
    {
        IOperationView view;

        public OperationPresenter(IOperationView view) : base(view)
        {
            this.view = view;
        }

        public void addOperationRow(BioBotDataSets.bbt_operation_typeRow operationType, BioBotDataSets.bbt_stepRow stepRow, int index, String value)
        {
            Model.Data.Services.OperationService.Instance.addOperationRow(operationType, stepRow, index, value);
        }

        public void modifyOperationRow(Model.Data.BioBotDataSets.bbt_operationRow row)
        {
            Model.Data.Services.OperationService.Instance.modifyOperationRow(row);
        }

        public void deleteOperationRow(Model.Data.BioBotDataSets.bbt_operationRow row)
        {
            Model.Data.Services.OperationService.Instance.removeOperationRow(row);
        }

        public void addOperationReferenceRow(int fkOperationId, int fkObjectId)
        {
            Model.Data.Services.OperationReferenceService.Instance.addOperationReferenceRow(fkOperationId,fkObjectId);
        }

        public void removeOperationReferenceRow(BioBotDataSets.bbt_operation_referenceRow row)
        {
            Model.Data.Services.OperationReferenceService.Instance.removeOperationReferenceRow(row);
        }

        [Model.EventBus.Subscribe]
        public void onOperationAddEvent(Model.EventBus.Events.Operation.OperationAddEvent e)
        {
            //view.setOperation(e.operationRow);
        }

        [Model.EventBus.Subscribe]
        public void onOperationRemoveEvent(Model.EventBus.Events.Operation.OperationRemoveEvent e)
        {
            //view.deleteOperation(e.pkId);
        }

        [Model.EventBus.Subscribe]
        public void onOperationModifyEvent(Model.EventBus.Events.Operation.OperationModifyEvent e)
        {
            //this.view.modifyOperation(e.operationRow);
        }


        [Model.EventBus.Subscribe]
        public void onStepSelectionChange(Model.EventBus.Events.Step.StepSelectionChangedEvent e)
        {
            this.view.setSelectedStepRow(e.stepRow);
        }

        [Model.EventBus.Subscribe]
        public void onObjectSelectionChange(Model.EventBus.Events.Object.ObjectSelectionChanged e)
        {
            if (e.row == null) return;
            if (e.selectionType != Model.EventBus.Events.Object.ObjectSelectionChanged.SelectionType.STEP_SELECTION) return;
            this.view.setSelectedObjectTypeRow(e.row.bbt_object_typeRow);
        }

        [Model.EventBus.Subscribe]
        public void onProtocolSelectionChange(Model.EventBus.Events.Protocol.ProtocolSelectionChangedEvent e)
        {
            if (e.Row != null) return;
            this.view.setSelectedStepRow(null);
        }
    }
}
