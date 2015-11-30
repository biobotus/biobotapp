using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBotApp.Model.Data.Services
{
    class InformationValueService
    {
        DBManager dbManager;
        BioBotDataSetsTableAdapters.bbt_information_valueTableAdapter taInformationValue;

        private static InformationValueService privateInstance;

        private InformationValueService()
        {
            this.dbManager = DBManager.Instance;
            this.taInformationValue = dbManager.taManager.bbt_information_valueTableAdapter;
        }

        public static InformationValueService Instance
        {
            get
            {
                if (privateInstance == null)
                {
                    privateInstance = new InformationValueService();
                }
                return privateInstance;
            }
        }

        // CRUD operations functions
        public void addInformationValueRow(String informationValue, int fkPropertyId, int fkObjectid, int fkInformationValue)
        {
            BioBotDataSets.bbt_information_valueRow row = this.dbManager.projectDataset.bbt_information_value.Newbbt_information_valueRow();
            row.information_value = informationValue;
            row.fk_property = fkPropertyId;

            if(fkInformationValue > 0)
            {
                row.fk_information_value = fkInformationValue;
            }

            row.fk_object = fkObjectid;
            this.dbManager.projectDataset.bbt_information_value.Addbbt_information_valueRow(row);
            updateRow(row);
        }
        public void modifyInformationValueRow(int primaryKey, String informationValue, int fkPropertyId, int fkObjectid, int fkInformationValue)
        {
            BioBotDataSets.bbt_information_valueRow row = this.dbManager.projectDataset.bbt_information_value.FindBypk_id(primaryKey);
            row.information_value = informationValue;
            row.fk_property = fkPropertyId;

            if (fkInformationValue > 0)
            {
                row.fk_information_value = fkInformationValue;
            }

            row.fk_object = fkObjectid;
            updateRow(row);
        }
        public void modifyInformationValueRow(BioBotDataSets.bbt_information_valueRow row)  
        {
            updateRow(row);    //(this.dbManager.projectDataset);
        }

        public void removeInformationValueRow(int primaryKey)
        {
            BioBotDataSets.bbt_information_valueRow row = this.dbManager.projectDataset.bbt_information_value.FindBypk_id(primaryKey);
            row.Delete();
            updateRow(row);    //(this.dbManager.projectDataset);
        }
        public void removeInformationValuerow(BioBotDataSets.bbt_information_valueRow row)
        {            
            row.Delete();
            updateRow(row);    //(this.dbManager.projectDataset);
        }
        public void removeInformationValueWithGivenObject(BioBotDataSets.bbt_objectRow parentToDeleteRow)
        {
            if (parentToDeleteRow != null)
            {                
                foreach (BioBotDataSets.bbt_information_valueRow row in parentToDeleteRow.Getbbt_information_valueRows())
                {                    
                    row.Delete();
                }
            }
            updateRowChanges();
        }
        public void removeInformationValueWithGivenInformation(BioBotDataSets.bbt_propertyRow parentToDeleteRow)
        {
            if (parentToDeleteRow != null)
            {
                foreach (BioBotDataSets.bbt_information_valueRow row in parentToDeleteRow.Getbbt_information_valueRows())
                {
                    row.Delete();
                }
            }
            updateRowChanges();
        }

        public void removeInformationValueRow(BioBotDataSets.bbt_information_valueRow row)
        {
            foreach(BioBotDataSets.bbt_information_valueRow childRows in row.Getbbt_information_valueRows())
            {
                removeInformationValueRow(childRows);
            }
            removeInformationValuerow(row);
        }

        /// <summary>
        /// Will push the updated information to the database and force revert changes whenever an error occurs
        /// </summary>
        /// <param name="row"></param>
        public void updateRow(BioBotDataSets.bbt_information_valueRow row)
        {
            try
            {
                this.taInformationValue.Update(row);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                this.dbManager.projectDataset.bbt_information_value.RejectChanges();
            }
        }

        public void updateRowChanges()
        {
            try
            {
                this.taInformationValue.Update(this.dbManager.projectDataset.bbt_information_value);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                this.dbManager.projectDataset.bbt_information_value.RejectChanges();
            }
        }

        // Other functions :
        public string getInformationValue(string propertyTypeDesc, string propertyDesc)
        {
            String query = String.Empty;
            query = "description = '" + propertyTypeDesc + "'";

            BioBotDataSets.bbt_property_typeRow[] propertyTypeRow = (BioBotDataSets.bbt_property_typeRow[])dbManager.projectDataset.bbt_property_type.Select(query);

            if (propertyTypeRow.Count() != 1) return "";

            BioBotDataSets.bbt_propertyRow[] propertyRow =
                (BioBotDataSets.bbt_propertyRow[])dbManager.projectDataset.bbt_property.Select(
                "fk_property_type = " + propertyTypeRow[0].pk_id + " AND description = '" + propertyDesc + "'");

            if (propertyRow.Count() != 1) return "";

            BioBotDataSets.bbt_information_valueRow[] informationValueRow =
                (BioBotDataSets.bbt_information_valueRow[])dbManager.projectDataset.bbt_information_value.Select(
                "fk_property = " + propertyRow[0].pk_id);

            if (informationValueRow.Count() != 1) return "";
            else return informationValueRow[0].information_value;

            /*
            Could have used the following query :
            SELECT information_value
            FROM deck.bbt_information_value AS informationValues
            INNER JOIN deck.bbt_property AS properties	
            ON informationValues.fk_property = properties.pk_id
            INNER JOIN deck.bbt_property_type as propertyTypes
            ON properties.fk_property_type = propertyTypes.pk_id
            WHERE propertyTypes.description = 'ToolRackPosition' AND
                  properties.description = 'Z'
            */
        }
    }
}
