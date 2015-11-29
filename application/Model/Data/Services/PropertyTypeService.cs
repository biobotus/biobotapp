using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBotApp.Model.Data.Services
{
    public class PropertyTypeService
    {
        DBManager dbManager;
        BioBotDataSetsTableAdapters.bbt_property_typeTableAdapter taPropertyType;

        private static PropertyTypeService privateInstance;

        
        private PropertyTypeService()
        {
            this.dbManager = DBManager.Instance;
            this.taPropertyType = dbManager.taManager.bbt_property_typeTableAdapter;
        }

        public static PropertyTypeService Instance
        {
            get
            {
                if (privateInstance == null)
                {
                    privateInstance = new PropertyTypeService();
                }
                return privateInstance;
            }
        }

        // CRUD operations functions
        public void addPropertyTypeRow(String description)
        {
            BioBotDataSets.bbt_property_typeRow row = this.dbManager.projectDataset.bbt_property_type.Newbbt_property_typeRow();
            row.description = description;
            this.dbManager.projectDataset.bbt_property_type.Addbbt_property_typeRow(row);
            updateRow(row);    //(this.dbManager.projectDataset);
        }

        public void modifyPropertyTypeRow(int primaryKey, String description)
        {
            BioBotDataSets.bbt_property_typeRow row = this.dbManager.projectDataset.bbt_property_type.FindBypk_id(primaryKey);
            row.description = description;
            updateRow(row);    //(this.dbManager.projectDataset);
        }

        public void modifyPropertyTypeRow(BioBotDataSets.bbt_property_typeRow row)
        {
            updateRow(row);    //(this.dbManager.projectDataset);
        }

        public void deleteProtpertyTypeRow(BioBotDataSets.bbt_property_typeRow row)
        {
            foreach(BioBotDataSets.bbt_propertyRow propertyRow in row.Getbbt_propertyRows())
            {
                Model.Data.Services.PropertyService.Instance.removePropertyRow(propertyRow);
            }
            row.Delete();
            updateRow(row);
        }

        /// <summary>
        /// Will push the updated information to the database and force revert changes whenever an error occurs
        /// </summary>
        /// <param name="row"></param>
        public void updateRow(BioBotDataSets.bbt_property_typeRow row)
        {
            try
            {
                this.taPropertyType.Update(row);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                this.dbManager.projectDataset.bbt_object_type.RejectChanges();
            }
        }
        public void CurrentChanged(int sender, EventArgs e)
        {

            EventBus.EventBus.Instance.post(new Model.EventBus.Events.Property.PropertyTypeCurrentChanged(sender));
        }
    }
}
