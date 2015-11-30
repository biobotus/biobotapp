using System;
using System.Windows.Forms;
using BioBotApp.Utils.Communication.pcan;
using TACDLL.Can;
namespace TACDLL.OptionCtrl
{
    /// <summary>
    /// User control designed to add a value for a tac optical density calibration.
    /// The user can start to pull the density samples at ease, letting him the time to change his tubes.
    /// We want to space the sample in time because we would always pull the same. The timer achieve this goal.
    /// The progress bar is here to give the user a visual feedback between two sample during the calibration.
    /// </summary>
    public partial class optionTacSampleCtrl : UserControl
    {
        private bool isSampling = false;
        private bool resetProgress = false;
        int sampleNumber = 0;
        float sampleSum = 0;

        

        namedInputTextBox sampleDisplayTxt;
        TacDll tac;
        public optionTacSampleCtrl()
        {
            InitializeComponent();
            PCANCom.Instance.OnMessageReceived += CANMessageReceived;

        }

        public optionTacSampleCtrl(namedInputTextBox sampleTxt, TacDll tacDll) :this()
        {
             sampleDisplayTxt = sampleTxt;
             tac = tacDll;
        }


        private void acquisitionTimer_Tick(object sender, EventArgs e)
        {
            sampleCtrl.PerformStep();
            if (resetProgress)
            {
                resetProgress = false;
                sampleCtrl.Value = 0;
            }
            if (sampleCtrl.Value == sampleCtrl.Maximum)
            {
                // Here we want to ask for new value of turbido
                pullTurbidoValue(); 
                resetProgress = true;                
            }
        }

        /// <summary>
        /// The button toggle between start/stop values, initiating the sample or stoping it.
        /// the state is represented by the isSampling value
        /// On stop we reset the progress bar we stop the sampling.
        /// On start we pull a new value
        /// </summary>
        private void btnStartSample_Click(object sender, EventArgs e)
        {
            if(isSampling)
            {
                isSampling = false;
                resetProgress = false;
                btnStartSample.Text = "Start sampling";
                sampleCtrl.Value = 0;
                acquisitionTimer.Stop();
            }
            else
            {
                isSampling = true;
                btnStartSample.Text = "Stop sampling";
                // Here we want to ask for new value of turbido
                tac.ExecuteCommand(TacDll.BuildTacCmd(1,1, "send_turbidity", ""));
                pullTurbidoValue();
            }
        }

        /// <summary>
        /// Increment and display the number of sample received.
        /// </summary>
        void incrementSampleNumber()
        {
            sampleNumber++;
            lblSampleNb.Text = "number of sample : " + sampleNumber.ToString();
        }

        /// <summary>
        /// Ask a new value of turbidity to the target TAC
        /// </summary>
        void pullTurbidoValue()
        {
            //Ask for a new turbido value
            tac.ExecuteCommand(TacDll.BuildTacCmd(1, 1, "send_turbidity", ""));
        }


        /// <summary>
        /// Listening the serial interface plug on the can, we wait for a new value of turbidity to calibrate our TAC
        /// This achieve number of task :
        ///     - decode the message checking it's from the target TAC and a turbidity value.
        ///     - retrieve the sample value.
        ///     - compute a mean of the value received up to this time.
        ///     - display the result.
        /// </summary>
        void onTurbidoValueReceived(float value)
        {
            float meanValue = 0;
            // we wait 2 sec between the turbido values
            acquisitionTimer.Start();
            // get the sample value from the message
            this.sampleSum += value;
            incrementSampleNumber();
            // we calculate the mean value
            meanValue = this.sampleSum / sampleNumber;
            // we display it
            sampleDisplayTxt.setInputTextValue(meanValue.ToString());
        }

        private void CANMessageReceived(object sender, PCANComEventArgs e)
        {
            if (e.CanMsg.DATA[0] == TacDll.HARDWARE_FILTER_TAC)
            {
                switch (e.CanMsg.DATA[2])
                {
                    case TACConstant.INST_GET_TURBIDITY:
                        onTurbidoValueReceived(BitConverter.ToSingle(e.CanMsg.DATA, 4));
                        break;
                }
            }
        }
    }
}
