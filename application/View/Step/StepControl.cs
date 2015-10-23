using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BioBotApp.Presenter.Step;

namespace BioBotApp.View.Step
{
    public partial class StepControl : UserControl, IStepView
    {
        StepPresenter presenter;
        public StepControl()
        {
            InitializeComponent();
            presenter = new StepPresenter(this);
        }
    }
}
