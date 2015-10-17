using BioBotApp.View.Step;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Presenter.Step
{
    public class StepPresenter
    {
        IStepView view;

        public StepPresenter(IStepView view)
        {
            this.view = view;
        }
    }
}
