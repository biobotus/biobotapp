using BioBotApp.Model.Data.Services;
using BioBotApp.View.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Presenter.Services
{
    public class InformationServicePresenter
    {

        private readonly IInformationServiceView m_View;
        private IInformationService m_Model;


        public InformationServicePresenter(IInformationServiceView view, IInformationService model)
        {
            this.m_View = view;
            this.m_Model = model;
        }

        public void AddInformationRow()
        {
            //m_Model.addInformationRow();
        }

    }
}
