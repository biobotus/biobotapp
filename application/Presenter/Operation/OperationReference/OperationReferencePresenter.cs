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


        [Model.EventBus.Subscribe]
        public void onOperationSelectionChange(Model.EventBus.Events.Operation.OperationSelectionEvent e)
        {
            this.view.setSelectedOperation(e.row);
        }
    }
}
