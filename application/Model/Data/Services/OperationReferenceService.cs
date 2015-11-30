using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBotApp.Model.Data.Services
{
    class OperationReferenceService
    {
        DBManager dbManager;
        BioBotDataSetsTableAdapters.bbt_operation_referenceTableAdapter taOperationReference;

        private static OperationReferenceService privateInstance;

        private OperationReferenceService()
        {
            this.dbManager = DBManager.Instance;
            this.taOperationReference = dbManager.taManager.bbt_operation_referenceTableAdapter;
        }

        public static OperationReferenceService Instance
        {
            get
            {
                if (privateInstance == null)
                {
                    privateInstance = new OperationReferenceService();
                }
                return privateInstance;
            }
        }



        // CRUD operations functions

        public void addOperationReferenceRow(int fkOperationId, int fkObjectId)
        {
            BioBotDataSets.bbt_operation_referenceRow row = this.dbManager.projectDataset.bbt_operation_reference.Newbbt_operation_referenceRow();
            row.fk_operation = fkOperationId;
            row.fk_object = fkObjectId;
            this.dbManager.projectDataset.bbt_operation_reference.Addbbt_operation_referenceRow(row);
            updateRow(row);
            EventBus.EventBus.Instance.post(new Model.EventBus.Events.OperationReference.OperationReferenceAddEvent(row));
        }

        public void modifyOperationReferenceRow(int fkOperationId, int fkObjectId)
        {
            BioBotDataSets.bbt_operation_referenceRow row = this.dbManager.projectDataset.bbt_operation_reference.Where(p => p.fk_object == fkObjectId && p.fk_operation == fkOperationId).First();
            row.fk_operation = fkOperationId;
            row.fk_object = fkObjectId;
            updateRow(row);
            EventBus.EventBus.Instance.post(new Model.EventBus.Events.OperationReference.OperationReferenceModifyEvent(row));
        }

        public void modifyOperationReferenceRow(BioBotDataSets.bbt_operation_referenceRow row)
        {
            updateRow(row);    //(this.dbManager.projectDataset);
            EventBus.EventBus.Instance.post(new Model.EventBus.Events.OperationReference.OperationReferenceModifyEvent(row));
        }

        public void removeOperationReferenceRow(int fkOperationId, int fkObjectId)
        {
            BioBotDataSets.bbt_operation_referenceRow row = this.dbManager.projectDataset.bbt_operation_reference.Where(p => p.fk_object == fkObjectId && p.fk_operation == fkOperationId).First();
            row.Delete();
            updateRow(row);
            EventBus.EventBus.Instance.post(new Model.EventBus.Events.OperationReference.OperationReferenceRemoveEvent(row));
        }
        public void removeOperationReferenceRow(BioBotDataSets.bbt_operation_referenceRow row)
        {
            row.Delete();
            updateRow(row);    //(this.dbManager.projectDataset);
            EventBus.EventBus.Instance.post(new Model.EventBus.Events.OperationReference.OperationReferenceRemoveEvent(row));
        }

        public void removeOperationReferenceRowWithGivenObject(BioBotDataSets.bbt_objectRow parentToDeleteRow)
        {
            if (parentToDeleteRow != null)
            {
                foreach (BioBotDataSets.bbt_operation_referenceRow row in parentToDeleteRow.Getbbt_operation_referenceRows())
                {
                    row.Delete();
                    updateRow(row);    //(this.dbManager.projectDataset);
                    EventBus.EventBus.Instance.post(new Model.EventBus.Events.OperationReference.OperationReferenceRemoveEvent(row));
                }
            }
        }
        public void removeOperationReferenceRowWithGivenOperation(BioBotDataSets.bbt_operationRow parentToDeleteRow)
        {
            if (parentToDeleteRow != null)
            {
                foreach (BioBotDataSets.bbt_operation_referenceRow row in parentToDeleteRow.Getbbt_operation_referenceRows())
                {
                    row.Delete();
                    updateRow(row);    //(this.dbManager.projectDataset);
                    EventBus.EventBus.Instance.post(new Model.EventBus.Events.OperationReference.OperationReferenceRemoveEvent(row));
                }
            }
        }

        /// <summary>
        /// Will push the updated information to the database and force revert changes whenever an error occurs
        /// </summary>
        /// <param name="row"></param>
        public void updateRow(BioBotDataSets.bbt_operation_referenceRow row)
        {
            try
            {
                this.taOperationReference.Update(row);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                this.dbManager.projectDataset.bbt_operation_reference.RejectChanges();
            }
        }

        public void updateRowChanges()
        {
            try
            {
                this.taOperationReference.Update(this.dbManager.projectDataset.bbt_operation_reference);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                this.dbManager.projectDataset.bbt_operation_reference.RejectChanges();
            }            
        }
    }
}
