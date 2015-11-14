using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.Data.Services
{
    public class ObjectTypeService
    {
        DBManager dbManager;
        BioBotDataSetsTableAdapters.bbt_object_typeTableAdapter taObjectType;

        private static ObjectTypeService instance;

        private ObjectTypeService()
        {
            this.dbManager = DBManager.Instance;
            this.taObjectType = dbManager.taManager.bbt_object_typeTableAdapter;
        }

        public static ObjectTypeService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ObjectTypeService();
                }
                return instance;
            }
        }

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
        public void removeObjectTypeRow(int primaryKey)
        {
            BioBotDataSets.bbt_object_typeRow row = this.dbManager.projectDataset.bbt_object_type.FindBypk_id(primaryKey);
            row.Delete();
            updateRow(row);    //(this.dbManager.projectDataset);
        }

        public void updateRow(BioBotDataSets.bbt_object_typeRow row)
        {
            try
            {
                this.taObjectType.Update(row);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
        }
    }
}
