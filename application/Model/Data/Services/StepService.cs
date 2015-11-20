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
        }

        public void modifyStepRow(int primaryKey, int fkProtocolId, String description, int fkObjectId, int index)
        {
            BioBotDataSets.bbt_stepRow row = this.dbManager.projectDataset.bbt_step.FindBypk_id(primaryKey);
            row.fk_protocol = fkProtocolId;
            row.description = description;
            row.fk_object = fkObjectId;
            row.index = index;
            updateRow(row);
        }

        public void modifyStepRow(BioBotDataSets.bbt_stepRow row)
        {
            updateRow(row);    //(this.dbManager.projectDataset);
        }

        public void removeStepRow(int primaryKey)
        {
            BioBotDataSets.bbt_stepRow row = this.dbManager.projectDataset.bbt_step.FindBypk_id(primaryKey);
            OperationService.Instance.removeOperationsWithGivenStep(row);
            row.Delete();
            updateRow(row);
        }

        public void removeStepRow(BioBotDataSets.bbt_stepRow row)
        {
            OperationService.Instance.removeOperationsWithGivenStep(row);
            row.Delete();
            updateRow(row);    //(this.dbManager.projectDataset);
        }

        public void removeStepsWithGivenObject(BioBotDataSets.bbt_objectRow parentToDeleteRow)
        {
            if (parentToDeleteRow != null)
            {                
                foreach (BioBotDataSets.bbt_stepRow row in parentToDeleteRow.Getbbt_stepRows())
                {                    
                    OperationService.Instance.removeOperationsWithGivenStep(row);
                    row.Delete();
                }
            }
            updateRowChanges();
        }

        public void removeStepsWithGivenProtocol(BioBotDataSets.bbt_protocolRow parentToDeleteRow)
        {
            if (parentToDeleteRow != null)
            {
                foreach (BioBotDataSets.bbt_stepRow row in parentToDeleteRow.Getbbt_stepRows())
                {
                    OperationService.Instance.removeOperationsWithGivenStep(row);
                    row.Delete();
                }
            }
            updateRowChanges();
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
