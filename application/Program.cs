using BioBotApp.Presenter;
using BioBotApp.View.Communication;
using BioBotApp.View.Protocol;
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

            CommunicationTestForm form = new CommunicationTestForm();         
            
            Application.Run(form);
        }
    }
}
