using BioBotApp.View.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Presenter.Properties
{
    public class PropertiesPresenter
    {
        public PropertiesPresenter(IPropertiesView view)
        {
            view.setBioBotDataset(Model.Data.DBManager.Instance.projectDataset);
        }

        public void addObjectPropertiesValueRow(int object_type_id, int properties_id, String value)
        {
            Model.Data.Services.PropertiesService.Instance.addObjectPropertiesValueRow(object_type_id, properties_id, value);
        }
    }
}
