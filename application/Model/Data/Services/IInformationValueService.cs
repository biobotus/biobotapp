using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.Data.Services
{
    public interface IInformationValueService
    {

        void addInformationValueRow(String informationValue, int fkPropertyId, int fkObjectid, int fkInformationValue);

        void modifyInformationValueRow(int primaryKey, String informationValue, int fkPropertyId, int fkObjectid, int fkInformationValue);

        void modifyInformationValueRow(BioBotDataSets.bbt_information_valueRow row);

        void removeInformationValueRow(int primaryKey);

        void removeInformationValueWithGivenObject(BioBotDataSets.bbt_objectRow parentToDeleteRow);

        void removeInformationValueWithGivenInformation(BioBotDataSets.bbt_propertyRow parentToDeleteRow);

        void removeInformationValueRow(BioBotDataSets.bbt_information_valueRow row);

        void updateRow(BioBotDataSets.bbt_information_valueRow row);

        void updateRowChanges();

    }
}
