using BioBotApp.Presenter;
using BioBotApp.View.Communication;
using BioBotApp.View.Deck;
using BioBotApp.View.Execute;
using BioBotApp.View.Operation;
using BioBotApp.View.Option;
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

            //ObjectTypeTestForm form = new ObjectTypeTestForm();
            //OptionMainView form = new OptionMainView();
            //OptionServicesPropertyView form2 = new OptionServicesPropertyView(); 
            //form.Controls.Add(form2);
            DeckForm form = new DeckForm();
            Application.Run(form);
        }
    }
}
