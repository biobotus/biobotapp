using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.Data.Services
{
    public class PropertyService// : IPropertyService
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
            updateRow(row);
        }

        public void modifyPropertyRow(int id, String description)
        {
            BioBotDataSets.bbt_propertyRow row = this.dbManager.projectDataset.bbt_property.FindBypk_id(id);
            row.description = description;
            updateRow(row);
        }

        public void removePropertyRow(int id)
        {
            BioBotDataSets.bbt_propertyRow row = this.dbManager.projectDataset.bbt_property.FindBypk_id(id);
            ObjectPropertyService.Instance.removeObjectRowWithGivenProperty(row);
            row.Delete();
            updateRow(row);
        }

        public void removePropertyRow(BioBotDataSets.bbt_propertyRow row)
        {
            ObjectPropertyService.Instance.removeObjectRowWithGivenProperty(row);
            row.Delete();
            updateRow(row);
        }

        public void updateRow(BioBotDataSets.bbt_propertyRow row)
        {
            try
            {
                this.taProperty.Update(row);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                this.dbManager.projectDataset.bbt_property.RejectChanges();
            }
        }
    }
}