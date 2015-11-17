using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.Data.Services
{
    public interface IInformationService
    {

        void addInformationRow(String description, int fkInformationType);

        void modifyInformationRow(int pk_Id, String description, int fkInformationType);

        void removeInformationRow(int pk_id);

        void removeInformationRow(BioBotDataSets.bbt_informationRow row);

        void removeInformationRowWithGivenInformationType(BioBotDataSets.bbt_information_typesRow parentToDeleteRow);

        void updateRow(BioBotDataSets.bbt_informationRow row);

        void updateRowChanges();

    }
}
