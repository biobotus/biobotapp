using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioBotApp.View.Services;
using BioBotApp.View.Services.References;

namespace BioBotApp.Presenter.Services.References
{
    public class ObjectPropertyPresenter : Model.EventBus.Subscriber
    {
        IObjectPropertyServiceView view;
        
        public ObjectPropertyPresenter(IObjectPropertyServiceView view)
        {
            this.view = view;
        }

        [Model.EventBus.Subscribe]
        public void OnPropertyChanged(Model.EventBus.Events.Property.PropertyCurrentChanged e)
        {
            this.view.OnPropertyChanged(e.pk_id);
        }
    }
}
