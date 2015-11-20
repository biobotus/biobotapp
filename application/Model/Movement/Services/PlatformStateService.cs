using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioBotCommunication.Serial.Movement;

namespace BioBotApp.Model.Movement.Services
{
    public class PlatformStateService
    {
        private Dictionary<MotorAxisEnum, double> motorPos = new Dictionary<MotorAxisEnum, double>();

        BioBotCommunication.Serial.Movement.SerialCommunication test;

        private static PlatformStateService _instance;
        private PlatformStateService()
        {
            motorPos[MotorAxisEnum.X] = 0.00;
            motorPos[MotorAxisEnum.Y] = 0.00;
            motorPos[MotorAxisEnum.Z1] = 0.00;
            motorPos[MotorAxisEnum.Z2] = 0.00;
            motorPos[MotorAxisEnum.Z3] = 0.00;

            test = new SerialCommunication();
        }

        public static PlatformStateService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PlatformStateService();
                }
                return _instance;
            }
        }

        public enum MotorAxisEnum
        {
            X = 0, Y = 1, Z1 = 2, Z2 = 3, Z3 = 4
        }

        public void updateMotorPos(MotorAxisEnum motor, double pos)
        {
            motorPos[motor] = pos;
        }
    }


}
