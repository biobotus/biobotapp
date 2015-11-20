using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public optionTacSampleCtrl()
        {
            InitializeComponent();
        }

        public optionTacSampleCtrl(namedInputTextBox sampleTxt):this()
        {
             sampleDisplayTxt = sampleTxt;
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
            // @TODO we may coinsider a class sending message to the tac
            // here we send the request for the right TAC throught the serial/can
            // ID SUB_MODULE COMMANDE _ _ _ _ _ 
            byte[] turbidityRequest = { 0x00 , 0x01, 0x10, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };

            //@TODO here for test purpose to be change by a call to the serial interface
            onTurbidoValueReceived();
        }

        /// <summary>
        /// Listening the serial interface plug on the can, we wait for a new value of turbidity to calibrate our TAC
        /// This achieve number of task :
        ///     - decode the message checking it's from the target TAC and a turbidity value.
        ///     - retrieve the sample value.
        ///     - compute a mean of the value received up to this time.
        ///     - display the result.
        /// </summary>
        void onTurbidoValueReceived()
        {
            float meanValue = 0;
            // we wait 2 sec between the turbido values
            acquisitionTimer.Start();
            // get the sample value from the message
            this.sampleSum += 1;
            incrementSampleNumber();
            // we calculate the mean value
            meanValue = this.sampleSum / sampleNumber;
            // we display it
            sampleDisplayTxt.setInputTextValue(meanValue.ToString());
        }

    }
}
