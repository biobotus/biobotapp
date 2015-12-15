using System.Timers;
using TACDLL;
using BioBotApp.Utils.Communication.pcan;
using TACDLL.Can;

namespace SimpleTacClient
{
    class SmallProtocol
    {

        enum State { Stop = 0, Warming, Cooling};
        Timer timer1 = new Timer();

        double tempHigh = 30;
        double tempLow = 4;
        double trubidoThreshold = 0.95;
        State state = State.Stop;
        int tacModuleId;
        int tacSubModule;
        TacDll tacPlugin;

        public SmallProtocol(TacDll tac, int moduleId, int submoduleModule, double temp1, double temp2, double turbido)
        {
            tempHigh = temp1;
            tempLow = temp2;
            trubidoThreshold = turbido;
            timer1.Elapsed += Timer1_Elapsed;
            tacPlugin = tac;
            tacModuleId = moduleId;
            tacSubModule = submoduleModule;

            PCANCom.Instance.OnMessageReceived += CANMessageReceived;
        }

        private void Timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            if(state == State.Warming)
            {
                tacPlugin.ExecuteCommand(TacDll.BuildTacCmd(tacModuleId, tacSubModule, "send_turbidity", ""));
            }
        }

        public void start()
        {
            timer1.Interval = 1000;
            timer1.Start();
            tacPlugin.ExecuteCommand(TacDll.BuildTacCmd(tacModuleId, tacSubModule, "set_target_temperature", tempHigh.ToString()));
            state = State.Warming;
        }

        public void stop()
        {
            state = State.Stop;
            timer1.Stop();
        }

        private void CANMessageReceived(object sender, PCANComEventArgs e)
        {
            if(state == State.Warming)
            {
                if (e.CanMsg.DATA[2] == TacDll.HARDWARE_FILTER_TAC)
                {
                    switch (e.CanMsg.DATA[0])
                    {
                        case TACConstant.INST_GET_TURBIDITY:
                            double doValue = TACDLL.Library.MesureToOpticalDensity.ConvertMesureToDo(tacModuleId, System.BitConverter.ToSingle(e.CanMsg.DATA, 4));
                            if(doValue > trubidoThreshold)
                            {
                                state = State.Cooling;
                                tacPlugin.ExecuteCommand(TacDll.BuildTacCmd(tacModuleId, tacSubModule, "set_target_temperature", tempLow.ToString()));
                            }
                            break;
                    }
                }
            }
        }
    }

}
