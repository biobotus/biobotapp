using BioBotApp.View.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Presenter
{
    public class ProtocolPresenter
    {
        private IProtocolView _view;

        public ProtocolPresenter(IProtocolView view)
        {
            _view = view;
            _view.setProjectDataset(Model.Data.DBManager.Instance.projectDataset);
        }
    }
}
