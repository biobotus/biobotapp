using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBotApp.Model.Data.Services
{
    public class ObjectTypeService
    {
        DBManager dbManager;
        BioBotDataSetsTableAdapters.bbt_object_typeTableAdapter taObjectType;

        private static ObjectTypeService privateInstance;

        private ObjectTypeService()
        {
            this.dbManager = DBManager.Instance;
            this.taObjectType = dbManager.taManager.bbt_object_typeTableAdapter;
        }

        public static ObjectTypeService Instance
        {
            get
            {
                if (privateInstance == null)
                {
                    privateInstance = new ObjectTypeService();
                }
                return privateInstance;
            }
        }

        // CRUD operations functions
        public void addObjectTypeRow(String description)
        {
            BioBotDataSets.bbt_object_typeRow row = this.dbManager.projectDataset.bbt_object_type.Newbbt_object_typeRow();
            row.description = description;                 
            this.dbManager.projectDataset.bbt_object_type.Addbbt_object_typeRow(row);                    
            updateRow(row);    //(this.dbManager.projectDataset);
        }
        public void modifyObjectTypeRow(int primaryKey, String description)
        {
            BioBotDataSets.bbt_object_typeRow row = this.dbManager.projectDataset.bbt_object_type.FindBypk_id(primaryKey);
            row.description = description;            
            updateRow(row);    //(this.dbManager.projectDataset);
        }
        public void modifyObjectTypeRow(BioBotDataSets.bbt_object_typeRow row)
        {           
            updateRow(row);    //(this.dbManager.projectDataset);
        }

        public void removeObjectTypeRow(int primaryKey)
        {
            BioBotDataSets.bbt_object_typeRow row = this.dbManager.projectDataset.bbt_object_type.FindBypk_id(primaryKey);
            ObjectService.Instance.removeObjectsWithGivenObjectTypeId(row);
            row.Delete();
            updateRow(row);    //(this.dbManager.projectDataset);
        }
        public void removeObjectTypeRow(BioBotDataSets.bbt_object_typeRow row)
        {
            ObjectPropertyService.Instance.removeObjectRowWithGivenObjectType(row);
            ObjectService.Instance.removeObjectsWithGivenObjectTypeId(row);
            row.Delete();
            updateRow(row);    //(this.dbManager.projectDataset);
        }

        /// <summary>
        /// Will push the updated information to the database and force revert changes whenever an error occurs
        /// </summary>
        /// <param name="row"></param>
        public void updateRow(BioBotDataSets.bbt_object_typeRow row)
        {
            try
            {
                this.taObjectType.Update(row);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                this.dbManager.projectDataset.bbt_object_type.RejectChanges();
            }
        }
        public void OnObjectTypeChange(int pk_id,EventArgs e)
        {
            Model.EventBus.EventBus.Instance.post(new Model.EventBus.Events.Object.OnObjectTypeChange(pk_id));
        }
    }
}
