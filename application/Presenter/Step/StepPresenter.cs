using BioBotApp.Presenter.Utils;
using BioBotApp.View.Step;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Presenter.Step
{
    public class StepPresenter : DatasetPresenter
    {
        IStepView view;

        public StepPresenter(IStepView view) : base(view)
        {
            this.view = view;
        }

        public void setSelectedStepRow(Model.Data.BioBotDataSets.bbt_stepRow row)
        {
            Model.Data.Services.StepService.Instance.setSelectedStepRow(row);
        }

        public void addStepRow(int fkProtocolId, String description, int fkObjectId, int index)
        {
            Model.Data.Services.StepService.Instance.addStepRow(fkProtocolId, description, fkObjectId, index);
        }

        public void modifyStepRow(Model.Data.BioBotDataSets.bbt_stepRow row)
        {
            Model.Data.Services.StepService.Instance.modifyStepRow(row);
        }

        public void removeStepRow(Model.Data.BioBotDataSets.bbt_stepRow row)
        {
            Model.Data.Services.StepService.Instance.removeStepRow(row);
        }

        [Model.EventBus.Subscribe]
        public void onAddStepRow(Model.EventBus.Events.Step.StepAddEvent e)
        {
            this.view.addStepRow(e.stepRow);
        }

        [Model.EventBus.Subscribe]
        public void onModifyStepRow(Model.EventBus.Events.Step.StepModifyEvent e)
        {
            this.view.modifyStepRow(e.stepRow);
        }

        [Model.EventBus.Subscribe]
        public void onDeleteStepRow(Model.EventBus.Events.Step.StepDeleteEvent e)
        {
            //this.view.deleteStepRow(e.rowId);
        }

        [Model.EventBus.Subscribe]
        public void onProtocolDeleteEvent(Model.EventBus.Events.Protocol.ProtocolSelectionChangedEvent e)
        {
            this.view.setSelectedProtocolRow(e.Row);
        }
    }
}
