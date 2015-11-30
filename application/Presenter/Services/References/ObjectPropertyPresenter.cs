using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioBotApp.View.Services;
using BioBotApp.View.Services.References;
using BioBotApp.Model.Data.Services;

namespace BioBotApp.Presenter.Services.References
{
    public class ObjectPropertyPresenter : Model.EventBus.Subscriber
    {
        IObjectPropertyServiceView view;
        
        public ObjectPropertyPresenter(IObjectPropertyServiceView view)
        {
            this.view = view;
        }

        public void AddObjectProperty(int fkObjectTypeId, int fkPropertyId, string value)
        {
            ObjectPropertyService.Instance.addObjectPropertyRow(fkObjectTypeId, fkPropertyId, value);
        }
        public void DeleteObjectProperty(Model.Data.BioBotDataSets.bbt_object_propertyRow row)
        {
            ObjectPropertyService.Instance.removeObjectRow(row);
        }
        public void ModifyObjectProperty(Model.Data.BioBotDataSets.bbt_object_propertyRow row)
        {
            ObjectPropertyService.Instance.modifyObjectRow(row);
        }

        [Model.EventBus.Subscribe]
        public void OnPropertyChanged(Model.EventBus.Events.Property.PropertyCurrentChanged e)
        {
            this.view.OnPropertyChanged(e.pk_id);
        }
    }
}
