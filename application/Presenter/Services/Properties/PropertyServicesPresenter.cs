using BioBotApp.Model.Data;
using BioBotApp.Model.Data.Services;
using BioBotApp.View.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Presenter.Services
{
        public class PropertyServicesPresenter : Model.EventBus.Subscriber
        {

            private readonly IPropertyServiceView m_View;
            //private IPropertyService PropertyServiceModel;

   
        public PropertyServicesPresenter(IPropertyServiceView view)
        {
            this.m_View = view;
            //this.PropertyServiceModel = model;    
        }

        public void OnPropertyChanged(int sender, EventArgs e)
        {
                Model.Data.Services.PropertyService.Instance.OnPropertyChange(sender, e);
        }
        public void addProperty(string description, int fk_property_type)
        {
            PropertyService.Instance.addPropertyRow(description, fk_property_type);
        }
        public void deleteProperty(BioBotDataSets.bbt_propertyRow row)
        {
            PropertyService.Instance.removePropertyRow(row);
        }
        public void modifyProperty(BioBotDataSets.bbt_propertyRow row)
        {
            PropertyService.Instance.modifyPropertyRow(row);
        }

        [Model.EventBus.Subscribe]
        public void onCurrentChanged(Model.EventBus.Events.Property.PropertyTypeCurrentChanged e)
        {
            this.m_View.onPropertyTypeCurrentChange(e.pk_id);
        }

        }

}
