using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBotApp.Model.Data.Services
{
    class InformationService
    {
        DBManager dbManager;
        BioBotDataSetsTableAdapters.bbt_informationTableAdapter taInformation;               

        private static InformationService instance;

        private InformationService()
        {
            this.dbManager = DBManager.Instance;
            this.taInformation = dbManager.taManager.bbt_informationTableAdapter;
        }

        public static InformationService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InformationService();
                }
                return instance;
            }
        }

        public void addInformationRow(String description, int fkInformationType)
        {
            BioBotDataSets.bbt_informationRow row = this.dbManager.projectDataset.bbt_information.Newbbt_informationRow();
            row.description = description;
            row.fk_information_type = fkInformationType;
            this.dbManager.projectDataset.bbt_information.Addbbt_informationRow(row);
            updateRow(row);
        }

        public void modifyInformationRow(int pk_Id, String description, int fkInformationType)
        {
            BioBotDataSets.bbt_informationRow row = this.dbManager.projectDataset.bbt_information.FindBypk_id(pk_Id);
            row.description = description;
            row.fk_information_type = fkInformationType;
            updateRow(row);
        }

        public void removeInformationRow(int pk_id)
        {
            BioBotDataSets.bbt_informationRow row = this.dbManager.projectDataset.bbt_information.FindBypk_id(pk_id);
            InformationValueService.Instance.removeInformationValueWithGivenInformation(row);
            row.Delete();
            updateRow(row);
        }

        public void removeInformationRow(BioBotDataSets.bbt_informationRow row)
        {
            InformationValueService.Instance.removeInformationValueWithGivenInformation(row);
            row.Delete();
            updateRow(row);
        }

        public void removeInformationRowWithGivenInformationType(BioBotDataSets.bbt_information_typesRow parentToDeleteRow)
        {
            if (parentToDeleteRow != null)
            {
                foreach (BioBotDataSets.bbt_informationRow row in parentToDeleteRow.Getbbt_informationRows())
                {
                    InformationValueService.Instance.removeInformationValueWithGivenInformation(row);
                    row.Delete();
                }
            }
            updateRowChanges();
        }

        public void updateRow(BioBotDataSets.bbt_informationRow row)
        {
            try
            {
                this.taInformation.Update(row);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                this.dbManager.projectDataset.bbt_information.RejectChanges();
            }
        }

        public void updateRowChanges()
        {
            try
            {
                this.taInformation.Update(this.dbManager.projectDataset.bbt_information);                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                this.dbManager.projectDataset.bbt_information.RejectChanges();
            }
        }
    }
}
