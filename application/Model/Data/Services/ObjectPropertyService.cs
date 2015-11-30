﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBotApp.Model.Data.Services
{
    class ObjectPropertyService
    {
        DBManager dbManager;
        BioBotDataSetsTableAdapters.bbt_object_propertyTableAdapter taObjectProperty;        

        private static ObjectPropertyService privateInstance;

        private ObjectPropertyService()
        {
            this.dbManager = DBManager.Instance;
            this.taObjectProperty = dbManager.taManager.bbt_object_propertyTableAdapter;
        }

        public static ObjectPropertyService Instance
        {
            get
            {
                if (privateInstance == null)
                {
                    privateInstance = new ObjectPropertyService();
                }
                return privateInstance;
            }
        }

        // CRUD operations functions
        public void addObjectPropertyRow(int fkObjectTypeId, int fkPropertyId, string value)
        {
            BioBotDataSets.bbt_object_propertyRow row = this.dbManager.projectDataset.bbt_object_property.Newbbt_object_propertyRow();
            row.fk_object_type_id = fkObjectTypeId;
            row.fk_properties_id = fkPropertyId;
            row.value = value;
            this.dbManager.projectDataset.bbt_object_property.Addbbt_object_propertyRow(row);
            updateRow(row);
        }

        public void modifyObjectRow(int fkObjectTypeId, int fkPropertyId)
        {
            BioBotDataSets.bbt_object_propertyRow row = this.dbManager.projectDataset.bbt_object_property.Where(p => p.fk_object_type_id == fkObjectTypeId && p.fk_properties_id == fkPropertyId).First();
            row.fk_object_type_id = fkObjectTypeId;
            row.fk_properties_id = fkPropertyId;
            updateRow(row);
        }

        public void modifyObjectRow(BioBotDataSets.bbt_object_propertyRow row)
        {
            updateRow(row);
        }

        public void removeObjectRow(int fkObjectTypeId, int fkPropertyId)
        {
            BioBotDataSets.bbt_object_propertyRow row = this.dbManager.projectDataset.bbt_object_property.Where(p => p.fk_object_type_id == fkObjectTypeId && p.fk_properties_id == fkPropertyId).First();
            row.Delete();
            updateRow(row);
        }

        public void removeObjectRow(BioBotDataSets.bbt_object_propertyRow row)
        {
            row.Delete();
            updateRow(row);
        }

        public void removeObjectRowWithGivenObjectType(BioBotDataSets.bbt_object_typeRow parentToDeleteRow)
        {
            if (parentToDeleteRow != null)
            {
                foreach (BioBotDataSets.bbt_object_propertyRow row in parentToDeleteRow.Getbbt_object_propertyRows())
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
                foreach (BioBotDataSets.bbt_object_propertyRow row in parentToDeleteRow.Getbbt_object_propertyRows())
                {
                    row.Delete();
                }
            }
            updateRowChanges();
        }

        public void updateRow(BioBotDataSets.bbt_object_propertyRow row)
        {
            try
            {
                this.taObjectProperty.Update(row);       
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                this.dbManager.projectDataset.bbt_object_property.RejectChanges();
            }
        }

        public void updateRowChanges()
        {
            try
            {
                this.taObjectProperty.Update(this.dbManager.projectDataset.bbt_object_property);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                this.dbManager.projectDataset.bbt_object_property.RejectChanges();
            }
        }

        // Other functions :

        public string getObjectPropertyValue(string propertyDesc, string propertyTypeDesc, int fk_object_type_id)
        {
            BioBotDataSets.bbt_property_typeRow[] propertyTypeRow =
                (BioBotDataSets.bbt_property_typeRow[])dbManager.projectDataset.bbt_property_type.Select(
                "description = '" + propertyTypeDesc + "'");

            if (propertyTypeRow.Count() != 1) return "";

            BioBotDataSets.bbt_propertyRow[] propertyRow =
                (BioBotDataSets.bbt_propertyRow[])dbManager.projectDataset.bbt_property.Select(
                "fk_property_type = " + propertyTypeRow[0].pk_id + " AND description = '" + propertyDesc + "'");

            if (propertyRow.Count() != 1) return "";

            BioBotDataSets.bbt_object_propertyRow[] objectPropertyRows =
                (BioBotDataSets.bbt_object_propertyRow[])dbManager.projectDataset.bbt_object_property.Select(
                "fk_object_type_id = " + fk_object_type_id + " AND fk_properties_id = " + propertyRow[0].pk_id
                );

            if (objectPropertyRows.Count() != 1) return "";
            else return objectPropertyRows[0].value.ToString();
        }
    }
}
