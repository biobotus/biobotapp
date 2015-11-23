using BioBotApp.Model.Data.Services;
using BioBotApp.View.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Presenter.Services
{
    public class InformationValueServicesPresenter
    {

        private readonly IInformationValueServiceView m_View;
        private IInformationValueService InformationServiceModel;


        public InformationValueServicesPresenter(IInformationValueServiceView view)
        {
            this.m_View = view;
            //this.InformationServiceModel = model;
        }
        /*
        Information value 
        */
        public void AddInformationRow()
        {
            //InformationServiceModel.addInformationValueRow();
        }


    }
}
