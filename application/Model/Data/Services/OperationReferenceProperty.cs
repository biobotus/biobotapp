using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.Data.Services
{
    class OperationReferencePropertyService
    {
        DBManager dbManager;
        BioBotDataSetsTableAdapters.bbt_operation_reference_propertyTableAdapter taOperationReferenceProperty;

        private static OperationReferencePropertyService privateInstance;

        private OperationReferencePropertyService()
        {
            this.dbManager = DBManager.Instance;
            this.taOperationReferenceProperty = dbManager.taManager.bbt_operation_reference_propertyTableAdapter;
        }

        public static OperationReferencePropertyService Instance
        {
            get
            {
                if (privateInstance == null)
                {
                    privateInstance = new OperationReferencePropertyService();
                }
                return privateInstance;
            }
        }

        // CRUD operations functions
        public void addObjectPropertyRow(int fk_operation_reference_id, int fkPropertyId)
        {
            BioBotDataSets.bbt_operation_reference_propertyRow row = this.dbManager.projectDataset.bbt_operation_reference_property.Newbbt_operation_reference_propertyRow();
            row.fk_operation_reference_id = fk_operation_reference_id;
            row.fk_properties_id = fkPropertyId;
            this.dbManager.projectDataset.bbt_operation_reference_property.Addbbt_operation_reference_propertyRow(row);
            updateRow(row);
        }

        public void modifyObjectRow(int fkObjectTypeId, int fkPropertyId)
        {
            BioBotDataSets.bbt_operation_reference_propertyRow row = this.dbManager.projectDataset.bbt_operation_reference_property.Where(p => p.fk_operation_reference_id == fkObjectTypeId && p.fk_properties_id == fkPropertyId).First();
            row.fk_operation_reference_id = fkObjectTypeId;
            row.fk_properties_id = fkPropertyId;
            updateRow(row);
        }

        public void modifyObjectRow(BioBotDataSets.bbt_operation_reference_propertyRow row)
        {
            updateRow(row);
        }

        public void removeObjectRow(int fkObjectTypeId, int fkPropertyId)
        {
            BioBotDataSets.bbt_operation_reference_propertyRow row = this.dbManager.projectDataset.bbt_operation_reference_property.Where(p => p.fk_operation_reference_id == fkObjectTypeId && p.fk_properties_id == fkPropertyId).First();
            row.Delete();
            updateRow(row);
        }

        public void removeObjectRow(BioBotDataSets.bbt_operation_reference_propertyRow row)
        {
            row.Delete();
            updateRow(row);
        }

        public void removeObjectRowWithOperationReference(BioBotDataSets.bbt_operation_referenceRow parentToDeleteRow)
        {
            if (parentToDeleteRow != null)
            {
                foreach (BioBotDataSets.bbt_operation_reference_propertyRow row in parentToDeleteRow.Getbbt_operation_reference_propertyRows())
                {
                    row.Delete();
                }
            }
            updateRowChanges();
        }

        public void removeObjectRowWithGivenProperty(BioBotDataSets.bbt_propertyRow parentToDeleteRow)
        {
            if (parentToDeleteRow != null)
            {
                foreach (BioBotDataSets.bbt_operation_reference_propertyRow row in parentToDeleteRow.Getbbt_operation_reference_propertyRows())
                {
                    row.Delete();
                }
            }
            updateRowChanges();
        }

        public void updateRow(BioBotDataSets.bbt_operation_reference_propertyRow row)
        {
            try
            {
                this.taOperationReferenceProperty.Update(row);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                this.dbManager.projectDataset.bbt_operation_reference_property.RejectChanges();
            }
        }

        public void updateRowChanges()
        {
            try
            {
                this.taOperationReferenceProperty.Update(this.dbManager.projectDataset.bbt_operation_reference_property);
            }
            catch (Exception e)
            {                
                this.dbManager.projectDataset.bbt_operation_reference_property.RejectChanges();
            }
        }
    }
}

