using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.View.Services
{
    public interface IPropertyServiceView
    {

        void onPropertyTypeCurrentChange(Model.Data.BioBotDataSets.bbt_property_typeRow row);

    }
}
