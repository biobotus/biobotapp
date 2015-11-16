using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.Data.Services
{
    class InformationTypeService
    {
        DBManager dbManager;
        BioBotDataSetsTableAdapters.bbt_information_typesTableAdapter taInformationType;

        private static InformationTypeService instance;

        private InformationTypeService()
        {
            this.dbManager = DBManager.Instance;
            this.taInformationType = dbManager.taManager.bbt_information_typesTableAdapter;
        }

        public static InformationTypeService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InformationTypeService();
                }
                return instance;
            }
        }

        public void addInformationTypeRow(String description)
        {
            BioBotDataSets.bbt_information_typesRow row = this.dbManager.projectDataset.bbt_information_types.Newbbt_information_typesRow();
            row.description = description;
            this.dbManager.projectDataset.bbt_information_types.Addbbt_information_typesRow(row);
            updateRow(row);
        }

        public void modifyInformationTypeRow(int id, String description)
        {
            BioBotDataSets.bbt_information_typesRow row = this.dbManager.projectDataset.bbt_information_types.FindBypk_id(id);
            row.description = description;
            updateRow(row);
        }

        public void removeInformationTypeRow(int id)
        {
            BioBotDataSets.bbt_information_typesRow row = this.dbManager.projectDataset.bbt_information_types.FindBypk_id(id);
            InformationService.Instance.removeInformationRowWithGivenInformationType(row);
            row.Delete();
            updateRow(row);
        }

        public void removeInformationTypeRow(BioBotDataSets.bbt_information_typesRow row)
        {
            InformationService.Instance.removeInformationRowWithGivenInformationType(row);
            row.Delete();
            updateRow(row);
        }

        public void updateRow(BioBotDataSets.bbt_information_typesRow row)
        {
            try
            {
                this.taInformationType.Update(row);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                this.dbManager.projectDataset.bbt_information_types.RejectChanges();
            }
        }
    }
}
