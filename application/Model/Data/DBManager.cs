using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.Data
{
    public class DBManager
    {
        private static DBManager instance;
        public BioBotDataSets projectDataset { get; set; }
        public BioBotDataSetsTableAdapters.TableAdapterManager taManager { private set; get; }

        private DBManager()
        {
            projectDataset = new BioBotDataSets();
            initializeTableAdapters();
        }

        public static DBManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DBManager();
                }
                return instance;
            }
        }

        public void initializeTableAdapters()
        {
            taManager = new BioBotDataSetsTableAdapters.TableAdapterManager();
            taManager.bbt_informationTableAdapter = new BioBotDataSetsTableAdapters.bbt_informationTableAdapter();
            taManager.bbt_information_typesTableAdapter = new BioBotDataSetsTableAdapters.bbt_information_typesTableAdapter();
            taManager.bbt_information_valueTableAdapter = new BioBotDataSetsTableAdapters.bbt_information_valueTableAdapter();
            taManager.bbt_objectTableAdapter = new BioBotDataSetsTableAdapters.bbt_objectTableAdapter();
            taManager.bbt_object_propertyTableAdapter = new BioBotDataSetsTableAdapters.bbt_object_propertyTableAdapter();
            taManager.bbt_object_typeTableAdapter = new BioBotDataSetsTableAdapters.bbt_object_typeTableAdapter();
            taManager.bbt_operationTableAdapter = new BioBotDataSetsTableAdapters.bbt_operationTableAdapter();
            taManager.bbt_operation_referenceTableAdapter = new BioBotDataSetsTableAdapters.bbt_operation_referenceTableAdapter();
            taManager.bbt_operation_typeTableAdapter = new BioBotDataSetsTableAdapters.bbt_operation_typeTableAdapter();
            taManager.bbt_propertyTableAdapter = new BioBotDataSetsTableAdapters.bbt_propertyTableAdapter();
            taManager.bbt_protocolTableAdapter = new BioBotDataSetsTableAdapters.bbt_protocolTableAdapter();
            taManager.bbt_stepTableAdapter = new BioBotDataSetsTableAdapters.bbt_stepTableAdapter();
        }

        public void initializeDataSet()
        {
            taManager.bbt_informationTableAdapter.Fill(projectDataset.bbt_information);
            taManager.bbt_information_typesTableAdapter.Fill(projectDataset.bbt_information_types);
            taManager.bbt_information_valueTableAdapter.Fill(projectDataset.bbt_information_value);
            taManager.bbt_objectTableAdapter.Fill(projectDataset.bbt_object);
            taManager.bbt_object_propertyTableAdapter.Fill(projectDataset.bbt_object_property);
            taManager.bbt_object_typeTableAdapter.Fill(projectDataset.bbt_object_type);
            taManager.bbt_operationTableAdapter.Fill(projectDataset.bbt_operation);
            taManager.bbt_operation_referenceTableAdapter.Fill(projectDataset.bbt_operation_reference);
            taManager.bbt_operation_typeTableAdapter.Fill(projectDataset.bbt_operation_type);
            taManager.bbt_propertyTableAdapter.Fill(projectDataset.bbt_property);
            taManager.bbt_protocolTableAdapter.Fill(projectDataset.bbt_protocol);
            taManager.bbt_stepTableAdapter.Fill(projectDataset.bbt_step);
        }
    }
}
