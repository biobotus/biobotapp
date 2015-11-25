using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBotApp.Model.Data.Services
{
    class OperationService
    {
        DBManager dbManager;
        BioBotDataSetsTableAdapters.bbt_operationTableAdapter taOperation;
  
        private static OperationService instance;

        private OperationService()
        {
            this.dbManager = DBManager.Instance;
            this.taOperation = dbManager.taManager.bbt_operationTableAdapter;
        }

        public static OperationService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OperationService();
                }
                return instance;
            }
        }

        public void addOperationRow(BioBotDataSets.bbt_operation_typeRow operationTypeRow, BioBotDataSets.bbt_stepRow stepRow, int index,String value)
        {
            BioBotDataSets.bbt_operationRow row = this.dbManager.projectDataset.bbt_operation.Newbbt_operationRow();
            row.fk_operation_type = operationTypeRow.pk_id;
            row.fk_step = stepRow.pk_id;
            row.index = index;
            row.value = value;
            this.dbManager.projectDataset.bbt_operation.Addbbt_operationRow(row);
            updateRow(row);
        }

        public void modifyOperationRow(BioBotDataSets.bbt_operationRow row)
        {
            updateRow(row);
            Model.EventBus.EventBus.Instance.post(new Model.EventBus.Events.Operation.OperationModifyEvent(row));
        }

        public void removeOperationRow(int Operation_id)
        {
            BioBotDataSets.bbt_operationRow row = this.dbManager.projectDataset.bbt_operation.FindBypk_id(Operation_id);
            OperationReferenceService.Instance.removeOperationReferenceRowWithGivenOperation(row);
            row.Delete();
            updateRow(row);
        }

        public void removeOperationRow(BioBotDataSets.bbt_operationRow row)
        {
            OperationReferenceService.Instance.removeOperationReferenceRowWithGivenOperation(row);
            row.Delete();
            updateRow(row);
        }

        public void removeOperationsWithGivenStepId(int fkStepId)
        {
            BioBotDataSets.bbt_stepRow parentToDelete = this.dbManager.projectDataset.bbt_step.FindBypk_id(fkStepId);
            if (parentToDelete != null)
            {
                foreach (BioBotDataSets.bbt_operationRow row in parentToDelete.Getbbt_operationRows())
                {
                    OperationReferenceService.Instance.removeOperationReferenceRowWithGivenOperation(row);
                    row.Delete();
                }
            }
            updateRowChanges();
        }

        public void removeOperationsWithGivenOperationTypeId(int fkOperationTypeId)
        {
            BioBotDataSets.bbt_operation_typeRow parentToDelete = this.dbManager.projectDataset.bbt_operation_type.FindBypk_id(fkOperationTypeId);
            if (parentToDelete != null)
            {
                foreach (BioBotDataSets.bbt_operationRow row in parentToDelete.Getbbt_operationRows())
                {
                    OperationReferenceService.Instance.removeOperationReferenceRowWithGivenOperation(row);
                    row.Delete();
                }
            }
            updateRowChanges();
        }

        public void removeOperationsWithGivenStep(BioBotDataSets.bbt_stepRow parentToDeleteRow)
        {
            if (parentToDeleteRow != null)
            {
                foreach(BioBotDataSets.bbt_operationRow row in parentToDeleteRow.Getbbt_operationRows())
                {
                    OperationReferenceService.Instance.removeOperationReferenceRowWithGivenOperation(row);
                    row.Delete();
                }
            }
            updateRowChanges();
        }

        public void removeOperationsWithGivenOperationType(BioBotDataSets.bbt_operation_typeRow parentToDeleteRow)
        {
            if (parentToDeleteRow != null)
            {
                foreach (BioBotDataSets.bbt_operationRow row in parentToDeleteRow.Getbbt_operationRows())
                {
                    OperationReferenceService.Instance.removeOperationReferenceRowWithGivenOperation(row);
                    row.Delete();
                }
            }
            updateRowChanges();
        }

        public void modifyOperationTypeRow(int Operation_id, int newFkOperationTypeId, int newFkStepId, int index, String value)
        {
            BioBotDataSets.bbt_operationRow row = this.dbManager.projectDataset.bbt_operation.FindBypk_id(Operation_id);
            row.fk_operation_type = newFkOperationTypeId;
            row.fk_step = newFkStepId;
            row.index = index;
            row.value = value;
            updateRow(row);
        }

        public void modifyOperationTypeRow(BioBotDataSets.bbt_operationRow row, int newFkOperationTypeId, int newFkStepId)
        {
            row.fk_operation_type = newFkOperationTypeId;
            row.fk_step = newFkStepId;
            updateRow(row);
        }

        public void updateRow(BioBotDataSets.bbt_operationRow row)
        {
            try
            {
                this.taOperation.Update(row);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                this.dbManager.projectDataset.bbt_operation.RejectChanges();
            }
        }

        public void updateRowChanges()
        {
            try
            {
                this.taOperation.Update(this.dbManager.projectDataset.bbt_operation);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                this.dbManager.projectDataset.bbt_operation.RejectChanges();
            }
        }
    }
}
