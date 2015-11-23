using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBotApp.Model.Data.Services
{
    class StepService
    {
        DBManager dbManager;
        BioBotDataSetsTableAdapters.bbt_stepTableAdapter taStep;

        private static StepService privateInstance;

        private StepService()
        {
            this.dbManager = DBManager.Instance;
            this.taStep = dbManager.taManager.bbt_stepTableAdapter;
        }

        public static StepService Instance
        {
            get
            {
                if (privateInstance == null)
                {
                    privateInstance = new StepService();
                }
                return privateInstance;
            }
        }

        // CRUD operations functions
        public void addStepRow(int fkProtocolId, String description, int fkObjectId, int index)
        {
            BioBotDataSets.bbt_stepRow row = this.dbManager.projectDataset.bbt_step.Newbbt_stepRow();
            row.fk_protocol = fkProtocolId;
            row.description = description;            
            row.fk_object = fkObjectId;
            row.index = index;
            this.dbManager.projectDataset.bbt_step.Addbbt_stepRow(row);
            updateRow(row);
            row.AcceptChanges();
            Model.EventBus.EventBus.Instance.post(new Model.EventBus.Events.Step.StepAddEvent(row));
        }

        public void modifyStepRow(int primaryKey, int fkProtocolId, String description, int fkObjectId, int index)
        {
            BioBotDataSets.bbt_stepRow row = this.dbManager.projectDataset.bbt_step.FindBypk_id(primaryKey);
            row.fk_protocol = fkProtocolId;
            row.description = description;
            row.fk_object = fkObjectId;
            row.index = index;
            updateRow(row);
            Model.EventBus.EventBus.Instance.post(new Model.EventBus.Events.Step.StepModifyEvent(row));
        }

        public void modifyStepRow(BioBotDataSets.bbt_stepRow row)
        {
            updateRow(row);    //(this.dbManager.projectDataset);
            Model.EventBus.EventBus.Instance.post(new Model.EventBus.Events.Step.StepModifyEvent(row));
        }

        public void removeStepRow(int primaryKey)
        {
            int rowId = -1;
            BioBotDataSets.bbt_stepRow row = this.dbManager.projectDataset.bbt_step.FindBypk_id(primaryKey);
            OperationService.Instance.removeOperationsWithGivenStep(row);
            rowId = row.pk_id;
            row.Delete();
            updateRow(row);
            Model.EventBus.EventBus.Instance.post(new Model.EventBus.Events.Step.StepDeleteEvent(rowId));
        }

        public void removeStepRow(BioBotDataSets.bbt_stepRow row)
        {
            int rowId = -1;
            OperationService.Instance.removeOperationsWithGivenStep(row);
            rowId = row.pk_id;
            row.Delete();
            updateRow(row);    //(this.dbManager.projectDataset);
            Model.EventBus.EventBus.Instance.post(new Model.EventBus.Events.Step.StepDeleteEvent(rowId));
        }

        public void removeStepsWithGivenObject(BioBotDataSets.bbt_objectRow parentToDeleteRow)
        {
            if (parentToDeleteRow != null)
            {                
                foreach (BioBotDataSets.bbt_stepRow row in parentToDeleteRow.Getbbt_stepRows())
                {
                    int rowId = -1;
                    OperationService.Instance.removeOperationsWithGivenStep(row);
                    rowId = row.pk_id;
                    row.Delete();
                    
                    updateRow(row);
                    Model.EventBus.EventBus.Instance.post(new Model.EventBus.Events.Step.StepDeleteEvent(rowId));
                }
            }
        }

        public void removeStepsWithGivenProtocol(BioBotDataSets.bbt_protocolRow parentToDeleteRow)
        {
            if (parentToDeleteRow != null)
            {
                foreach (BioBotDataSets.bbt_stepRow row in parentToDeleteRow.Getbbt_stepRows())
                {
                    int rowId = -1;
                    OperationService.Instance.removeOperationsWithGivenStep(row);
                    rowId = row.pk_id;
                    row.Delete();
                    updateRow(row);
                    Model.EventBus.EventBus.Instance.post(new Model.EventBus.Events.Step.StepDeleteEvent(rowId));
                }
            }
        }

        /// <summary>
        /// Will push the updated information to the database and force revert changes whenever an error occurs
        /// </summary>
        /// <param name="row"></param>
        public void updateRow(BioBotDataSets.bbt_stepRow row)
        {
            try
            {
                this.taStep.Update(row);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                this.dbManager.projectDataset.bbt_information_value.RejectChanges();
            }
        }

        public void updateRowChanges()
        {
            try
            {
                this.taStep.Update(this.dbManager.projectDataset.bbt_step);                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                this.dbManager.projectDataset.bbt_step.RejectChanges();
            }
        }
    }
}
