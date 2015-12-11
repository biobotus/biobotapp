using BioBotApp.Presenter;
using BioBotApp.View.Communication;
using BioBotApp.View.Main;
using BioBotApp.View.Operation;
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
            DLL.PipetteSimple.PipetteSimple pipetteSimple = new DLL.PipetteSimple.PipetteSimple();
            DLL.MultiChannel.MultiChannelPipette multi = new DLL.MultiChannel.MultiChannelPipette();
            BioBotCommunication.Serial.Movement.SerialCommunication.Instance.configure("COM1", "115200", "8", System.IO.Ports.StopBits.One, System.IO.Ports.Parity.None);//.configure("COM4", "57600", "8", "One", "None");
            Model.Movement.MovementAlgorithm algo = Model.Movement.MovementAlgorithm.Instance;
            MainViewForm form = new MainViewForm();
            Application.Run(form);
        }
    }
}
