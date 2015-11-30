using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioBotApp.View.Services.Objects;
using BioBotApp.Model.Data.Services;

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
        public void AddObjectType(string description)
        {
            ObjectTypeService.Instance.addObjectTypeRow(description);
        }
        public void DeleteObjectType(Model.Data.BioBotDataSets.bbt_object_typeRow row)
        {
            ObjectTypeService.Instance.removeObjectTypeRow(row);
        }
        public void ModifyObjectType(Model.Data.BioBotDataSets.bbt_object_typeRow row)
        {
            ObjectTypeService.Instance.modifyObjectTypeRow(row);
        }
    }
}
