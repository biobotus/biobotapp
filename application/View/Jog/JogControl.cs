using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BioBotApp.Presenter;
using BioBotApp.Model.Data.Movement;

namespace BioBotApp.View.Jog
{
    public partial class JogControl : UserControl, IJogView
    {
        private JogPresenter presenter;

        public JogControl()
        {
            InitializeComponent();
            this.presenter = new JogPresenter(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private bool ValidateAndSendValue(String valueReceived, Model.Movement.Services.PlatformStateService.MotorAxisEnum motor)
        {
            String tbValue = tbXPos.Text;
            double value;
            if (!String.IsNullOrWhiteSpace(valueReceived) && Double.TryParse(valueReceived, out value))
            {
                this.presenter.updateMotorPosition(motor, value);
                MessageBox.Show("Réussite");
                return true;
            }
            else
                return false;  // Error converting string content do double
        }

        private void tbXPos_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void tbYPos_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void tbZ1Pos_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void tbZ2Pos_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void tbZ3Pos_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        public void updateMotor(StepperMotor motor)
        {
            System.Console.WriteLine("lfkdsgkl;");
        }

        public void updateXMotor()
        {
            throw new NotImplementedException();
        }
    }
}
