using BioBotApp.Model.Data.Services;
using BioBotApp.View.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Presenter.Services
{
    public class PropertyServicesPresenter
    {

        private readonly IPropertyServiceView m_View;
        //private IPropertyService PropertyServiceModel;

   
    public PropertyServicesPresenter(IPropertyServiceView view)
    {
        this.m_View = view;
        //this.PropertyServiceModel = model;
    }

    }
}
