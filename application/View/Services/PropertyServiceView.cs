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
    public partial class PropertyServiceView : UserControl, IPropertyServiceView
    {
        private PropertyServicesPresenter presenter = null;
        //private readonly PropertyService m_Model;

        public PropertyServiceView()
        {
            InitializeComponent();

            presenter = new PropertyServicesPresenter(this);
        }

    }
}
