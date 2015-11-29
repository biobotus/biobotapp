using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioBotApp.View.Services.Objects;
using BioBotApp.Model.Data.Services;

namespace BioBotApp.Presenter.Services.Object
{
    public class ObjectPresenter : Model.EventBus.Subscriber
    {
        IObjectServiceView view;

        public ObjectPresenter(IObjectServiceView view)
        {
            this.view = view;
        }
        public void AddObject(int fk_object_type,int deck_x,int deck_y,int rotation,string activated, string description, int fk_object)
        {
            ObjectService.Instance.addObjectRow(fk_object_type, deck_x, deck_y, rotation, activated, description, fk_object);
        }
        public void DeleteObject(Model.Data.BioBotDataSets.bbt_objectRow row)
        {
            ObjectService.Instance.removeObjectRow(row);
        }
        public void ModifyObject(Model.Data.BioBotDataSets.bbt_objectRow row)
        {
            ObjectService.Instance.modifyObjectRow(row);
        }
        [Model.EventBus.Subscribe]
        private void OnObjectTypeChange(Model.EventBus.Events.Object.OnObjectTypeChange e)
        {
            this.view.OnObjectTypeChange(e.pk_id);
        }
    }
}
