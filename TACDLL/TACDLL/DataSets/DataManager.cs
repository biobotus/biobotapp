using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TACDLL.DataSets
{
    
    class DataManager
    {
        private static dsTacCalibration tacDataInstance;

        public static dsTacCalibration tacData
        {
            get
            {
                if (tacDataInstance == null)
                {
                    tacDataInstance = new dsTacCalibration();
                }
                return tacDataInstance;
            }
        }
    }
}
