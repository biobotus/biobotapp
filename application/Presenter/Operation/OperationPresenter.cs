using BioBotApp.View.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Presenter.Operation
{
    public class OperationPresenter
    {
        IOperationView view;
        public OperationPresenter(IOperationView view)
        {
            this.view = view;
        }
    }
}
