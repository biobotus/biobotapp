using BioBotApp.Model.Data.Services;
using BioBotApp.Presenter.Utils;
using BioBotApp.View.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Presenter.Services
{
    public class InformationValueServicesPresenter : Model.EventBus.Subscriber
    {
        IInformationValueServiceView view;

        public InformationValueServicesPresenter(IInformationValueServiceView view) //: base(view)
        {
            this.view = view;
            //this.InformationServiceModel = model;
        }
        /*
        Information value 
        */
        public void AddInformationValue(string informationValue, int fkPropertyId, int fkObjectId, int fkInformationValue)
        {
            InformationValueService.Instance.addInformationValueRow(informationValue, fkPropertyId, fkObjectId, fkInformationValue);
        }
        public void DeleteInformationValue(Model.Data.BioBotDataSets.bbt_information_valueRow row)
        {
            InformationValueService.Instance.removeInformationValueRow(row);
        }
        public void ModifyInformationValue(Model.Data.BioBotDataSets.bbt_information_valueRow row)
        {
            InformationValueService.Instance.modifyInformationValueRow(row);
        }

        [Model.EventBus.Subscribe]
        public void OnPropertyChange(Model.EventBus.Events.Property.PropertyCurrentChanged e)
        {
            this.view.OnPropertyChange(e.pk_id);
        }
    }
}
