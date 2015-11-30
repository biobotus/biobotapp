using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioBotApp.View.Services.Objects;

namespace BioBotApp.Presenter.Services.Object
{
        
    public class ObjectTypePresenter : Model.EventBus.Subscriber
    {
        IObjectTypeServiceView view;

        public ObjectTypePresenter(IObjectTypeServiceView view)
        {
            this.view = view;
        }
        public void OnObjectTypeChanged(int sender,EventArgs e)
        {
            Model.Data.Services.ObjectTypeService.Instance.OnObjectTypeChange(sender, e);
        }
    }
}
