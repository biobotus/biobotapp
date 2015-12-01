using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBotApp.Model.Data.Services
{
    class OperationTypeObjectTypeServices
    {
        DBManager dbManager;
        BioBotDataSetsTableAdapters.bbt_operation_type_object_typeTableAdapter taOperationTypeObjectType;

        private static OperationTypeObjectTypeServices privateInstance;

        private OperationTypeObjectTypeServices()
        {
            this.dbManager = DBManager.Instance;
            this.taOperationTypeObjectType = dbManager.taManager.bbt_operation_type_object_typeTableAdapter;
        }

        public static OperationTypeObjectTypeServices Instance
        {
            get
            {
                if (privateInstance == null)
                {
                    privateInstance = new OperationTypeObjectTypeServices();
                }
                return privateInstance;
            }
        }

        // CRUD operations functions
        public void addOperationTypeObjectTypeRow(int fkObjectTypeId, int fkOperationTypeId)
        {
            BioBotDataSets.bbt_operation_type_object_typeRow row = this.dbManager.projectDataset.bbt_operation_type_object_type.Newbbt_operation_type_object_typeRow();
            row.fk_object_type = fkObjectTypeId;
            row.fk_operation_type = fkOperationTypeId;
            this.dbManager.projectDataset.bbt_operation_type_object_type.Addbbt_operation_type_object_typeRow(row);
            updateRow(row);
        }

        public void modifyOperationTypeObjectTypeRow(int fkObjectTypeId, int fkOperationTypeId)
        {
            BioBotDataSets.bbt_operation_type_object_typeRow row = this.dbManager.projectDataset.bbt_operation_type_object_type.Where(p => p.fk_object_type == fkObjectTypeId && p.fk_operation_type == fkOperationTypeId).First();
            row.fk_object_type = fkObjectTypeId;
            row.fk_operation_type = fkOperationTypeId;
            updateRow(row);
        }

        public void modifyOperationTypeObjectTypeRow(BioBotDataSets.bbt_operation_type_object_typeRow row)
        {
            updateRow(row);
        }

        public void removeOperationTypeObjectTypeRow(int fkObjectTypeId, int fkOperationTypeId)
        {
            BioBotDataSets.bbt_operation_type_object_typeRow row = this.dbManager.projectDataset.bbt_operation_type_object_type.Where(p => p.fk_object_type == fkObjectTypeId && p.fk_operation_type == fkOperationTypeId).First();
            row.Delete();
            updateRow(row);
        }

        public void removeOperationTypeObjectTypeRow(BioBotDataSets.bbt_operation_type_object_typeRow row)
        {
            row.Delete();
            updateRow(row);
        }

        public void removeOperationTypeObjectTypeRowWithGivenObjectType(BioBotDataSets.bbt_operation_typeRow parentToDeleteRow)
        {
            if (parentToDeleteRow != null)
            {
                foreach (BioBotDataSets.bbt_operation_type_object_typeRow row in parentToDeleteRow.Getbbt_operation_type_object_typeRows())
                {
                    row.Delete();
                }
            }
            updateRowChanges();
        }

        public void removeOperationTypeObjectTypeRowWithGivenProperty(BioBotDataSets.bbt_object_typeRow parentToDeleteRow)
        {
            if (parentToDeleteRow != null)
            {
                foreach (BioBotDataSets.bbt_operation_type_object_typeRow row in parentToDeleteRow.Getbbt_operation_type_object_typeRows())
                {
                    row.Delete();
                }
            }
            updateRowChanges();
        }

        public void updateRow(BioBotDataSets.bbt_operation_type_object_typeRow row)
        {
            try
            {
                this.taOperationTypeObjectType.Update(row);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                this.dbManager.projectDataset.bbt_operation_type_object_type.RejectChanges();
            }
        }

        public void updateRowChanges()
        {
            try
            {
                this.taOperationTypeObjectType.Update(this.dbManager.projectDataset.bbt_operation_type_object_type);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                this.dbManager.projectDataset.bbt_operation_type_object_type.RejectChanges();
            }
        }
    }

}

