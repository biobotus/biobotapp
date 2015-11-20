using BioBotApp.Model.Data.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.EventBus.Movement
{
    public class MotorMovementEvent : EventArgs
    {
        public Model.Data.Movement.StepperMotor motor { get; private set; }

        public MotorMovementEvent(StepperMotor motor)
        {
            this.motor = motor;
        }
    }
}
