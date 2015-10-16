using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.Data.Services
{
    public class PropertiesService
    {
        DBManager dbManager;
        BioBotDataSetsTableAdapters.bbt_object_propertyTableAdapter taObjectProperty;

        private static PropertiesService instance;

        private PropertiesService()
        {
            this.dbManager = DBManager.Instance;
            this.taObjectProperty = dbManager.taManager.bbt_object_propertyTableAdapter;
        }

        public static PropertiesService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PropertiesService();
                }
                return instance;
            }
        }

        public void addObjectPropertiesValueRow(int object_type_id, int properties_id, String value)
        {
            BioBotDataSets.bbt_object_propertyRow row = this.dbManager.projectDataset.bbt_object_property.Newbbt_object_propertyRow();
            row.fk_object_type_id = object_type_id;
            row.fk_properties_id = properties_id;
            row.value = value;
            this.dbManager.projectDataset.bbt_object_property.Addbbt_object_propertyRow(row);
            this.taObjectProperty.Update(this.dbManager.projectDataset);
        }
    }
}
