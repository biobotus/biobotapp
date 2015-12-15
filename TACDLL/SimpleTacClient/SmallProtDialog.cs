using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleTacClient
{
    public partial class SmallProtDialog : Form
    {
        public SmallProtDialog()
        {
            InitializeComponent();
        }

        public double getTempHigh()
        {
            double result = 25;
            bool isValidDouble;
            isValidDouble = Double.TryParse(tempHighTxt.Text, out result);
            return result;
        }

        public double getTempLow()
        {
            double result = 25;
            bool isValidDouble;
            isValidDouble = Double.TryParse(tempLowTxt.Text, out result);
            return result;
        }

        public double getDoThreshold()
        {
            double result = 0.5;
            bool isValidDouble;
            isValidDouble = Double.TryParse(tempLowTxt.Text, out result);
            return result;

        }

        private void tempHight_Validating(object sender, CancelEventArgs e)
        {
            double result;
            if (!Double.TryParse(tempHighTxt.Text,  out result))
            {
                e.Cancel = true;
                ShowFormatError();

            }
        }

        private void tempLow_Validating(object sender, CancelEventArgs e)
        {
            double result;
            if (!Double.TryParse(tempLowTxt.Text, out result))
            {
                e.Cancel = true;
                ShowFormatError();
            }
        }

        private void do_Validating(object sender, CancelEventArgs e)
        {
            double result;
            if (!Double.TryParse(doThresholdTxt.Text, out result))
            {
                e.Cancel = true;
                ShowFormatError();
            }
        }

        private void ShowFormatError()
        {
            DialogResult result2 = MessageBox.Show("The input should be a doube using a comma as separator",
                    "Input error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }

        private void doThresholdTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || Char.IsControl(e.KeyChar))
            {
            }
            else
            {
                e.Handled = true;
            }       
        }

        private void tempHighTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void tempHighTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',' || Char.IsControl(e.KeyChar))
            {

            }
            else
            {
                MessageBox.Show(e.KeyChar.ToString());

                e.Handled = true;
            }
        }
    }
}
