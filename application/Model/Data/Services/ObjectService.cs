using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBotApp.Model.Data.Services
{
    class ObjectService
    {
        DBManager dbManager;
        BioBotDataSetsTableAdapters.bbt_objectTableAdapter taObject;
        BioBotDataSets.bbt_objectRow selectedRow;

        private static ObjectService privateInstance;

        private ObjectService()
        {
            this.dbManager = DBManager.Instance;
            this.taObject = dbManager.taManager.bbt_objectTableAdapter;
        }

        public static ObjectService Instance
        {
            get
            {
                if (privateInstance == null)
                {
                    privateInstance = new ObjectService();
                }
                return privateInstance;
            }
        }

        public void setSelectedObject(BioBotDataSets.bbt_objectRow row)
        {
            this.selectedRow = row;
            EventBus.EventBus.Instance.post(new EventBus.Events.Object.ObjectSelectionChanged(row, EventBus.Events.Object.ObjectSelectionChanged.SelectionType.OBJECT_SELECTION));
        }

        /// <summary>
        /// Set selected object and fires ObjectSelectionChanged for step types. Currently selected object remains. To change selected object call setSelectedObject
        /// method instead
        /// </summary>
        /// <param name="row">Selected object row</param>
        public void setSelectedObjectStepType(BioBotDataSets.bbt_objectRow row)
        {
            EventBus.EventBus.Instance.post(new EventBus.Events.Object.ObjectSelectionChanged(row, EventBus.Events.Object.ObjectSelectionChanged.SelectionType.STEP_SELECTION));
        }

        // CRUD operations functions
        /// <summary>
        /// Add object row, forcing all parameters to be filled
        /// </summary>
        /// <param name="fk_object_type"></param>
        /// <param name="deck_x"></param>
        /// <param name="deck_y"></param>
        /// <param name="rotation"></param>
        /// <param name="activated"></param>
        /// <param name="description"></param>
        public void addObjectRow(int fk_object_type, int deck_x, int deck_y, int rotation, string activated, String description, int fk_object)
        {
            BioBotDataSets.bbt_objectRow row = this.dbManager.projectDataset.bbt_object.Newbbt_objectRow();
            row.fk_object_type = fk_object_type;
            row.deck_x = deck_x;
            row.deck_y = deck_y;
            row.rotation = rotation;
            row.activated = activated;
            row.description = description;
            row.fk_object = fk_object;

            this.dbManager.projectDataset.bbt_object.Addbbt_objectRow(row);                     
            updateRow(row);
        }
        public void addObjectRow(BioBotDataSets.bbt_object_typeRow fk_object_type_row, int deck_x, int deck_y, int rotation, string activated, String description)
        {
            BioBotDataSets.bbt_objectRow row = this.dbManager.projectDataset.bbt_object.Newbbt_objectRow();
            row.fk_object_type = fk_object_type_row.pk_id;  // The pk_id of the object type becomes the reference key here for the object
            row.deck_x = deck_x;
            row.deck_y = deck_y;
            row.rotation = rotation;
            row.activated = activated;
            row.description = description;

            this.dbManager.projectDataset.bbt_object.Addbbt_objectRow(row);
            updateRow(row);
        }

        public void modifyObjectRow(int pk_id, int fk_object_type, int deck_x, int deck_y, int rotation, string activated, String description)
        {
            BioBotDataSets.bbt_objectRow row = this.dbManager.projectDataset.bbt_object.FindBypk_id(pk_id);
            row.fk_object_type = fk_object_type;
            row.deck_x = deck_x;
            row.deck_y = deck_y;
            row.rotation = rotation;
            row.activated = activated;
            row.description = description;

            updateRow(row);
        }
        public void modifyObjectRow(int pk_id, BioBotDataSets.bbt_object_typeRow fk_object_type_row, int deck_x, int deck_y, int rotation, string activated, String description)
        {
            BioBotDataSets.bbt_objectRow row = this.dbManager.projectDataset.bbt_object.FindBypk_id(pk_id);
            row.fk_object_type = fk_object_type_row.pk_id;
            row.deck_x = deck_x;
            row.deck_y = deck_y;
            row.rotation = rotation;
            row.activated = activated;
            row.description = description;

            updateRow(row);
        }
        public void modifyObjectRow(BioBotDataSets.bbt_objectRow row)
        {
            updateRow(row);
        }

        public void removeObjectRow(int primaryKey)
        {
            BioBotDataSets.bbt_objectRow row = this.dbManager.projectDataset.bbt_object.FindBypk_id(primaryKey);
            row.Delete();
            updateRow(row);
        }
        public void removeObjectRow(BioBotDataSets.bbt_objectRow row)
        {
            row.Delete();
            updateRow(row);
        }
        public void removeObjectsWithGivenObjectTypeId(int fkObjectTypeId)
        {

            /*
            IEnumerable<BioBotDataSets.bbt_objectRow> rowsToDelete = this.dbManager.projectDataset.bbt_object.Where(rowToDelete => rowToDelete.fk_object_type == fkObjectTypeId);
            foreach (BioBotDataSets.bbt_objectRow row in rowsToDelete)
            {
                MessageBox.Show("Item deleted with pk_id : " + row.pk_id.ToString());
                row.Delete();
            }*/
                        
            BioBotDataSets.bbt_object_typeRow parentToDelete = this.dbManager.projectDataset.bbt_object_type.FindBypk_id(fkObjectTypeId);
            if (parentToDelete != null)
            {
                foreach(BioBotDataSets.bbt_objectRow row in parentToDelete.Getbbt_objectRows())
                {
                    row.Delete();
                }
            }
            updateRowChanges();
        }
        public void removeObjectsWithGivenObjectTypeId(BioBotDataSets.bbt_object_typeRow parentToDeleteRow)
        {
            if (parentToDeleteRow != null)
            {
                foreach (BioBotDataSets.bbt_objectRow row in parentToDeleteRow.Getbbt_objectRows())
                {
                    // Call services to delete rows in tables : operation_reference, information_value and step
                    InformationValueService.Instance.removeInformationValueWithGivenObject(row);
                    StepService.Instance.removeStepsWithGivenObject(row);
                    OperationReferenceService.Instance.removeOperationReferenceRowWithGivenObject(row);
                    row.Delete();
                }
            }
            updateRowChanges();
        }

        /// <summary>
        /// Will push the updated information to the database and force revert changes whenever an error occurs
        /// </summary>
        /// <param name="row"></param>
        public void updateRow(BioBotDataSets.bbt_objectRow row)
        {
            try
            {
                this.taObject.Update(row);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                this.dbManager.projectDataset.bbt_object.RejectChanges();
            }
        }

        public void updateRowChanges()
        {
            try
            {
                this.taObject.Update(this.dbManager.projectDataset.bbt_object);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                this.dbManager.projectDataset.bbt_object.RejectChanges();
            }
        }

        // Other functions :
        // Can return the id of an object that has been instanciated only once (For example, the ToolRack, Tip 1000, etc)
        public int getUniqueObjectTypeInstanceId(string objectTypeDescription)
        {
            BioBotDataSets.bbt_object_typeRow[] objectTypeRow =
                (BioBotDataSets.bbt_object_typeRow[])dbManager.projectDataset.bbt_object_type.Select(
                    "decription = '" + objectTypeDescription + "'");

            if (objectTypeRow.Count() != 1) return -1;

            BioBotDataSets.bbt_objectRow[] uniqueObjectRow =
                (BioBotDataSets.bbt_objectRow[])dbManager.projectDataset.bbt_object.Select(
                    "fk_object_type = '" + objectTypeRow[0].pk_id + "'");

            if (uniqueObjectRow.Count() != 1) return -1;
            else return uniqueObjectRow[0].pk_id;            
        }
    }
}
