using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.Data.Services
{
    public interface IPropertyService
    {

        void addPropertyRow(String description);

        void modifyPropertyRow(int id, String description);

        void removePropertyRow(int id);

        void removePropertyRow(BioBotDataSets.bbt_propertyRow row);

        void updateRow(BioBotDataSets.bbt_propertyRow row);



    }
}
