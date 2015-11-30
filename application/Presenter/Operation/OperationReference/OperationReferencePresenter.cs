using BioBotApp.Presenter.Utils;
using BioBotApp.View.Operation.OperationReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Presenter.Operation.OperationReference
{
    public class OperationReferencePresenter : DatasetPresenter
    {
        IOperationReferenceView view;
        public OperationReferencePresenter(IOperationReferenceView view) : base(view)
        {
            this.view = view;
        }

        public void addOperationReference(int fkOperation, int fkObject)
        {
            Model.Data.Services.OperationReferenceService.Instance.addOperationReferenceRow(fkOperation, fkObject);
        }

        public void removeOperationReference(Model.Data.BioBotDataSets.bbt_operation_referenceRow row)
        {
            Model.Data.Services.OperationReferenceService.Instance.removeOperationReferenceRow(row);
        }

        [Model.EventBus.Subscribe]
        public void onOperationSelectionChange(Model.EventBus.Events.Operation.OperationSelectionEvent e)
        {
            this.view.setSelectedOperation(e.row);
        }
    }
}
