using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TACDLL.Chart
{
    public partial class DataDisplayForm : Form
    {
        double count = 0;
        bool isActive;
        DataSets.dsTacCalibration.dtTacSampleDataTable dataTable;
        public DataDisplayForm()
        {
            InitializeComponent();
            dataTable = new DataSets.dsTacCalibration.dtTacSampleDataTable();
            sampleGV.DataSource = dataTable;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count += 1;
            chart1.Series[0].Points.AddXY(count, Math.Cos(count));

            double value = 2.5;
            DateTime date = DateTime.Now;
            string type = "temperature";
            dataTable.AdddtTacSampleRow(value, date, type);
        }

        private void activateBtn_Click(object sender, EventArgs e)
        {
            if(isActive)
            {
                timer1.Stop();
                isActive = false;
                activateBtn.Text = "Start";
            }
            else
            {
                timer1.Start();
                isActive = true;
                activateBtn.Text = "Stop";
            }
        }
    }
}
