using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BioBotApp.Presenter.Services;
using BioBotApp.Model.Data.Services;

namespace BioBotApp.View.Services
{
    public partial class InformationServiceView : UserControl, IInformationServiceView
    {
        private ServicesPresenter presenter = null;
        private readonly InformationService m_Model;

        public InformationServiceView(InformationService model)
        {
            InitializeComponent();
            m_Model = model;
            presenter = new ServicesPresenter(this, m_Model);

        }
        private void Add_Click(object sender, EventArgs e)
        {
            //Insert Dialog with new view but same presenter
            presenter.AddInformationRow();
        }
        private void Modify_Click(object sender, EventArgs e)
        {

        }
        private void Delete_Click(object sender, EventArgs e)
        {

        }
    }
}
