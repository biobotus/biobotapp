using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.View.Jog
{
    public interface IJogView
    {
        void updateMotor(Model.Data.Movement.StepperMotor motor);
        void updateXMotor();
    }
}
