using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioBotApp.View.Services.Objects;

namespace BioBotApp.Presenter.Services.Object
{
    public class ObjectPresenter : Model.EventBus.Subscriber
    {
        IObjectServiceView view;

        public ObjectPresenter(IObjectServiceView view)
        {
            this.view = view;
        }
        [Model.EventBus.Subscribe]
        private void OnObjectTypeChange(Model.EventBus.Events.Object.OnObjectTypeChange e)
        {
            this.view.OnObjectTypeChange(e.pk_id);
        }
    }
}
