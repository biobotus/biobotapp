using BioBotApp.Model.EventBus.Movement;
using BioBotApp.View.Jog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Presenter   //.Jog
{
    public class JogPresenter
    {
        private IJogView view;

        private enum PositionType
        {
            Relative, Absolute
        }

        private PositionType currentPositionMode = PositionType.Relative;

        public JogPresenter(IJogView view)
        {
            this.view = view;
        }

        [Model.EventBus.Subscribe]
        public void onMotorPropertyChanged(MotorMovementEvent e)
        {
            view.updateMotor(e.motor);
        }

        public void updateMotorPosition(Model.Movement.Services.PlatformStateService.MotorAxisEnum motor, double position)
        {
            System.Windows.Forms.MessageBox.Show("Motor chosen: " + motor);
            if (currentPositionMode == PositionType.Absolute)
            {
                Model.Movement.Services.PlatformStateService.Instance.updateMotorPos(motor, position);
            }
            else
            {

            }

        }
    }
}
