using BioBotApp.View.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Presenter.Operation
{
    public class OperationPresenter : Model.EventBus.Subscriber
    {
        IOperationView view;
        Model.Data.BioBotDataSets biobotDataSet;

        public OperationPresenter(IOperationView view)
        {
            this.view = view;
            biobotDataSet = Model.Data.DBManager.Instance.projectDataset;
            this.view.setProjectDataset(biobotDataSet);
        }

        [Model.EventBus.Subscribe]
        public void Test(Model.EventBus.Events.Step.StepAddEvent e)
        {
            view.setStep(e.stepRow);
        }

        [Model.EventBus.Subscribe]
        public void Test(Model.EventBus.Events.Operation.OperationEvent e)
        {
            view.setOperation(e.operationRow);
        }
    }
}
