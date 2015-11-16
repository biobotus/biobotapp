using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBotApp.Model.Data.Services
{
    class OperationTypeService
    {
        DBManager dbManager;
        BioBotDataSetsTableAdapters.bbt_operation_typeTableAdapter taOperationType;

        private static OperationTypeService instance;

        private OperationTypeService()
        {
            this.dbManager = DBManager.Instance;
            this.taOperationType = dbManager.taManager.bbt_operation_typeTableAdapter;
        }

        public static OperationTypeService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OperationTypeService();
                }
                return instance;
            }
        }

        public void addOperationTypeRow (String description)
        {
            BioBotDataSets.bbt_operation_typeRow row = this.dbManager.projectDataset.bbt_operation_type.Newbbt_operation_typeRow();
            row.description = description;
            this.dbManager.projectDataset.bbt_operation_type.Addbbt_operation_typeRow(row);
            updateRow(row);
        }

        public void removeOperationTypeRow(int OperationType_id)
        {
            BioBotDataSets.bbt_operation_typeRow row = this.dbManager.projectDataset.bbt_operation_type.FindBypk_id(OperationType_id);
            row.Delete();
            updateRow(row);
        }
        public void removeOperationTypeRow(BioBotDataSets.bbt_operation_typeRow row)
        {
            row.Delete();
            updateRow(row);
        }

        public void modifyOperationTypeRow (int OperationType_id, String description)
        {
            BioBotDataSets.bbt_operation_typeRow row = this.dbManager.projectDataset.bbt_operation_type.FindBypk_id(OperationType_id);
            row.description = description;
            updateRow(row);
        }
        public void modifyOperationTypeRow(BioBotDataSets.bbt_operation_typeRow row, String description)
        {
            row.description = description;
            updateRow(row);
        }

        public void updateRow(BioBotDataSets.bbt_operation_typeRow row)
        {
            try
            {
                this.taOperationType.Update(row);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                this.dbManager.projectDataset.bbt_operation_type.RejectChanges();
            }
        }
    }
}
