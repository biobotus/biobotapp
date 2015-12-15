using System;
using System.Windows.Forms;
using BioBotApp.Utils.Communication.pcan;
using TACDLL.Can;
using TACDLL.Library;

namespace TACDLL.OptionCtrl
{
    /// <summary>
    /// TacDescription provide a custom user control to display the tac current information.
    ///     current goal temperature
    ///     current temperature
    ///     current optical density
    ///     current ventilation setting
    ///     current agitation setting
    /// </summary>
    public partial class TacDescription : UserControl
    {
        /// the instance handling tacs
        private TacDll tac;
        /// The tac we are interested on
        private int tacId;


        /// <summary>
        /// The TacDescription user control constructor need a TacDll containing the needed<
        /// command handling to interact with the TAC and the Id of the tac we need  the information from 
        /// </summary>
        /// <param name="tacDll">the Dll handling tacs</param>
        /// <param name="targetTacId"> the id of the target tac</param>
        public TacDescription(TacDll tacDll, int targetTacId)
        {
            InitializeComponent();
            PCANCom.Instance.OnMessageReceived += CANMessageReceived;
            tac = tacDll;
            tacId = targetTacId;
            tacParamGB.Text = "Tac : " + targetTacId.ToString("X3");
        }

        /// <summary>
        /// Send command askin for information about a given submodule
        /// </summary>
        /// <param name="tacSubModule">the submodule we want information about</param>
        private void refreshSubModuleInformation(int tacSubModule)
        {
            tac.ExecuteCommand(TacDll.BuildTacCmd(tacId, tacSubModule, "send_fan_speed", ""));
            tac.ExecuteCommand(TacDll.BuildTacCmd(tacId, tacSubModule, "send_temperature", ""));
            tac.ExecuteCommand(TacDll.BuildTacCmd(tacId, tacSubModule, "send_agitator_speed", ""));
            tac.ExecuteCommand(TacDll.BuildTacCmd(tacId, tacSubModule, "send_turbidity", ""));
            tac.ExecuteCommand(TacDll.BuildTacCmd(tacId, tacSubModule, "send_goal_temperature", ""));
        }

        #region UI-Event
        /// <summary>
        /// When clicked, we refresh the information about both submodule
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            refreshSubModuleInformation(TACConstant.MODULE0);
            refreshSubModuleInformation(TACConstant.MODULE1);
        }

        #endregion

        #region CommunicationHandling
        private void CANMessageReceived(object sender, PCANComEventArgs e)
        {
            if (e.CanMsg.DATA[2] == TacDll.HARDWARE_FILTER_TAC)
            {
                switch (e.CanMsg.DATA[0])
                {
                    case TACConstant.INST_GET_TARGET_TEMPERATURE:
                        subModule1Desc.SetGoalTemperature(((float)(e.CanMsg.DATA[5] << 8) + (float)e.CanMsg.DATA[4]) / (float)10);
                        break;
                    case TACConstant.INST_GET_CURRENT_TEMPERATURE:
                        subModule1Desc.SetCurrentTemperature(((float)(e.CanMsg.DATA[5] << 8) + (float)e.CanMsg.DATA[4]) / (float)10); 
                        break;
                    case TACConstant.INST_GET_AGITATOR_STATE:
                        subModule1Desc.SetCurrentAgitation(e.CanMsg.DATA[4]);
                        break;
                    case TACConstant.INST_GET_FAN_STATE:
                        subModule1Desc.SetCurrentFan(e.CanMsg.DATA[4]);
                        break;
                    case TACConstant.INST_GET_TURBIDITY:
                        subModule1Desc.SetCurrentTurbidity(MesureToOpticalDensity.ConvertMesureToDo(tacId, BitConverter.ToSingle(e.CanMsg.DATA, 4)));
                        break;
                }
            }
        }




        #endregion

        private void showPlotResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TACDLL.Chart.DataDisplayForm f = new TACDLL.Chart.DataDisplayForm(tac, tacId, getActiveSubmodulId());
            f.Show();
        }

        private int getActiveSubmodulId()
        {
            int subModuleIndex = 0;

            switch (subModulesTab.SelectedIndex)
            {
                case 0:
                    subModuleIndex = TACConstant.MODULE0;
                    break;
                case 1:
                    subModuleIndex = TACConstant.MODULE1;
                    break;
                default:
                    break;
            }
            return subModuleIndex;
        }
    }
}
