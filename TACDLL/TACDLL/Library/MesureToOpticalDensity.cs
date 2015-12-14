using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TACDLL.Library
{
    public class MesureToOpticalDensity
    {
        static double[] polyCoefs = {0,1,0,0};

        public static void SaveTacODCalibration(int tacId, double[] coef)
        {
            polyCoefs = coef;
        }

        public static double ConvertMesureToDo(int tacId, double sample)
        {
            double result = 0;
            int i = 0;
            foreach(var coef in polyCoefs)
            {
                result = result + coef * Math.Pow(sample, i);
                i++;
            }
            return Math.Exp(result);
        }
    }
}
