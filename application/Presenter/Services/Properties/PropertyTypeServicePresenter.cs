using BioBotApp.View.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBotApp.Presenter.Services
{
    public class PropertyTypeServicePresenter
    {
        IpropertyTypeServiceView View;

        

        public PropertyTypeServicePresenter(IpropertyTypeServiceView View)
        {
            this.View = View;
        }
        public void CurrentChanged(int sender, EventArgs e)
        {
            Model.Data.Services.PropertyTypeService.Instance.CurrentChanged(sender,e);
        }
        

    }
}
