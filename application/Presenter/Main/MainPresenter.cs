using BioBotApp.Presenter.Utils;
using BioBotApp.View.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Presenter.Main
{
    public class MainPresenter : DatasetPresenter
    {
        public MainPresenter(IMainView view) : base(view)
        {

        }

        public void onConnectionStatusChange()
        {

        }
    }
}
