using BioBotApp.Presenter;
using BioBotApp.View.Communication;
using BioBotApp.View.Operation;
using BioBotApp.View.Option;
using BioBotApp.View.Properties;
using BioBotApp.View.Protocol;
using BioBotApp.View.Step;
using BioBotApp.View.TestView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBotApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Model.Data.DBManager.Instance.initializeDataSet();

            //StepForm form = new StepForm();
            OptionMainView form = new OptionMainView();
            Application.Run(form);
        }
    }
}
