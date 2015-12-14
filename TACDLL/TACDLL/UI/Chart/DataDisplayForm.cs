using System;
using System.Windows.Forms;
using System.Data;
using System.ComponentModel;
using System.Text;
using System.Collections.Generic;
using System.IO;
using BioBotApp.Utils.Communication.pcan;
using TACDLL.Can;
using TACDLL.Library;
namespace TACDLL.Chart
{
    public partial class DataDisplayForm : Form
    {
        double count = 0;
        bool isActive;

        int tacId;
        int submodule;
        TacDll tac;

        bool isNewSampleRequired = false;
        bool isNewTemp = false;
        bool isNewDo = false;
        float newTemp = 0;
        float newDo = 0;

        DataSets.dsTacCalibration.dtTacSampleDataTable dataTable;
        

        public DataDisplayForm(TacDll tacDriver, int targetTacId, int targetSubmodule)
        {
            InitializeComponent();
            dataTable = new DataSets.dsTacCalibration.dtTacSampleDataTable();
            sampleGV.DataSource = dataTable;

            tacId = targetTacId;
            submodule = targetSubmodule;
            tac = tacDriver;

            sampleGV.Columns["tacId"].Visible = false;
            sampleGV.Columns["date"].DisplayIndex = 0;
            sampleGV.Columns["opticalDensity"].DisplayIndex = 1;
            sampleGV.Columns["temperature"].DisplayIndex = 2;

            PCANCom.Instance.OnMessageReceived += CANMessageReceived;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            isNewSampleRequired = true;
            tac.ExecuteCommand(TacDll.BuildTacCmd(tacId, submodule, "send_temperature", ""));
            tac.ExecuteCommand(TacDll.BuildTacCmd(tacId, submodule, "send_turbidity", ""));
            count++;
        }

        private void AddSampleRow(double temp, double opticalDensity)
        {
            System.DateTime x = System.DateTime.Now;

            if (this.resultChart.InvokeRequired)
            {
                this.resultChart.BeginInvoke((MethodInvoker)delegate () 
                    {
                        resultChart.Series[0].Points.AddXY(x.ToLocalTime(), temp);
                        resultChart.Series[1].Points.AddXY(x.ToLocalTime(), opticalDensity);

                        DataRow row = dataTable.NewRow();
                        row["tacId"] = tacId;
                        row["date"] = x;
                        row["opticalDensity"] = opticalDensity;
                        row["temperature"] = temp;
                        dataTable.Rows.Add(row);
                    });
            }
            else
            {
                resultChart.Series[0].Points.AddXY(x.ToLocalTime(), temp);
                resultChart.Series[1].Points.AddXY(x.ToLocalTime(), opticalDensity);

                DataRow row = dataTable.NewRow();
                row["tacId"] = tacId;
                row["date"] = x;
                row["opticalDensity"] = opticalDensity;
                row["temperature"] = temp;
                dataTable.Rows.Add(row);
            }
            

        }

        private void activateBtn_Click(object sender, EventArgs e)
        {
            if(isActive)
            {
                timer1.Stop();
                isActive = false;
                activateBtn.Text = "Start";
                sampleIntervalMTxt.Enabled = true;
                saveBtn.Enabled = true;
                resetDataBtn.Enabled = true;
                setIntervalBtn.Enabled = true;
            }
            else
            {
                timer1.Start();
                isActive = true;
                activateBtn.Text = "Stop";
                sampleIntervalMTxt.Enabled = false;
                saveBtn.Enabled = false;
                resetDataBtn.Enabled = false;
                setIntervalBtn.Enabled = false;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            // Get file name.
            string name = saveFileDialog1.FileName;
            string separator = ";";
            saveDataTableAsFile(name, separator);
        }

        private void saveDataTableAsFile(string fileName, string separator)
        {
            var result = new StringBuilder();
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                result.Append(dataTable.Columns[i].ColumnName);
                result.Append(i == dataTable.Columns.Count - 1 ? Environment.NewLine : separator);
            }

            foreach (DataRow row in dataTable.Rows)
            {
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    result.Append(row[i].ToString());
                    result.Append(i == dataTable.Columns.Count - 1 ? Environment.NewLine : separator);
                }
            }
            File.WriteAllText(fileName, result.ToString());
        }

        private void setIntervalBtn_Click(object sender, EventArgs e)
        {
            var minuteText = sampleIntervalMTxt.Text.Substring(0,2);
            var secondText = sampleIntervalMTxt.Text.Substring(3, 2);
            int minute;
            int second;
            bool isMinuteValid = int.TryParse(minuteText, out minute);
            bool isSecondValid = int.TryParse(secondText, out second);
            if (isMinuteValid && isSecondValid)
            {
                timer1.Interval = (second + minute * 60) * 1000;
            }
            

        }

        private void resetDataBtn_Click(object sender, EventArgs e)
        {
            dataTable.Clear();
            foreach (var series in resultChart.Series)
            {
                series.Points.Clear();
            }
        }

        #region CommunicationHandling

        private void CANMessageReceived(object sender, PCANComEventArgs e)
        {
            if (e.CanMsg.DATA[2] == TacDll.HARDWARE_FILTER_TAC)
            {
                switch (e.CanMsg.DATA[0])
                {
                    case TACConstant.INST_GET_CURRENT_TEMPERATURE:
                        if(isNewSampleRequired)
                        {
                            newTemp = ((float)(e.CanMsg.DATA[5] << 8) + (float)e.CanMsg.DATA[4]) / (float)10;
                            isNewTemp = true;
                        }
                        break;
                    case TACConstant.INST_GET_TURBIDITY:
                        if(isNewSampleRequired)
                        {
                            newDo = BitConverter.ToSingle(e.CanMsg.DATA, 4);
                            isNewDo = true;
                        }
                        break;
                }
                if(isNewDo && isNewTemp && isNewSampleRequired)
                {
                    isNewDo = false;
                    isNewTemp = false;
                    isNewSampleRequired = false;
                    AddSampleRow(newTemp, MesureToOpticalDensity.ConvertMesureToDo(tacId, newDo));
                }
            }
        }
        #endregion CommunicationHandling
    }
}
