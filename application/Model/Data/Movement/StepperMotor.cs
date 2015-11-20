using BioBotApp.Model.EventBus.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.Data.Movement
{
    public class StepperMotor
    {
        public void setMotorPosition(int desiredPosition)
        {
            EventBus.EventBus.Instance.post(new MotorMovementEvent(this));
        }
    }
}
