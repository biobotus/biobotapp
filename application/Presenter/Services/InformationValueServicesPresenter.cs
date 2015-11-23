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
    public class InformationValueServicesPresenter //: DatasetPresenter
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
        public void AddInformationRow()
        {
            
        }


    }
}
