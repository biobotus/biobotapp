using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.Data.Services
{
    public class PropertyService
    {
        DBManager dbManager;
        BioBotDataSetsTableAdapters.bbt_propertyTableAdapter taProperty;

        private static PropertyService instance;

        private PropertyService()
        {
            this.dbManager = DBManager.Instance;
            this.taProperty = dbManager.taManager.bbt_propertyTableAdapter; // table adapter
        }

        public static PropertyService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PropertyService();
                }
                return instance;
            }
        }

        public void addPropertyRow(String description)
        {
            BioBotDataSets.bbt_propertyRow row = this.dbManager.projectDataset.bbt_property.Newbbt_propertyRow();
            row.description = description;
            this.dbManager.projectDataset.bbt_property.Addbbt_propertyRow(row);
            taProperty.Update(row);
        }

        public void modifyPropertyRow(int id, String description)
        {
            BioBotDataSets.bbt_propertyRow row = this.dbManager.projectDataset.bbt_property.FindBypk_id(id);
            row.description = description;
            taProperty.Update(row);
        }

        public void removePropertyRow(int id)
        {
            BioBotDataSets.bbt_propertyRow row = this.dbManager.projectDataset.bbt_property.FindBypk_id(id);
            row.Delete();
            taProperty.Update(row);
        }
    }
}