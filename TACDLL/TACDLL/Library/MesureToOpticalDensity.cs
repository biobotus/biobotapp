using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace TACDLL.Library
{
    public class MesureToOpticalDensity
    {
        //static double[] polyCoefs = {0,1,0,0};
        private static Dictionary<int, double[]> polyCoefs = new Dictionary<int, double[]>();
        private static string jsonFilePath = "tacODCalibration.json";

        public static void AddTacODCalibration(int tacId, double[] coef)
        {
            polyCoefs[tacId] = coef;
        }

        public static double ConvertMesureToDo(int tacId, double sample)
        {
            double result = 0;
            int i = 0;
            double[] polyCoef = {0,1};

            if (polyCoefs.ContainsKey(tacId))
            {
                polyCoef = polyCoefs[tacId];
            }
            
            foreach (var coef in polyCoef)
            {
                result = result + coef * Math.Pow(sample, i);
                i++;
            }

            return Math.Exp(result);
        }

        public static void SaveODCalibration()
        {
            List<CalibrationResult> calibrationList = new List<CalibrationResult>();
            foreach (KeyValuePair<int, double[]> entry in polyCoefs)
            {
                CalibrationResult cr = new CalibrationResult(entry.Key, entry.Value);
                calibrationList.Add(cr);

            }
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (StreamWriter sw = new StreamWriter(jsonFilePath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, calibrationList);
            }
        }

        public static void LoadODCalibration()
        {
            List<CalibrationResult> calibrationList = new List<CalibrationResult>();
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using (StreamReader sr = new StreamReader(jsonFilePath))
            using (JsonTextReader reader = new JsonTextReader(sr))
            {
                calibrationList = serializer.Deserialize<List<CalibrationResult>>(reader);
            }

            polyCoefs.Clear();
            foreach (CalibrationResult calibrationData in calibrationList)
            {
                polyCoefs.Add(calibrationData.tacId, calibrationData.polyCoefs);
            }
        }

        [DataContract]
        internal class CalibrationResult
        {
            [DataMember]
            public int tacId;
            [DataMember]
            public double[] polyCoefs = { 0, 1, 0, 0 };

            public CalibrationResult(int tac, double[] coefs)
            {
                tacId = tac;
                polyCoefs = coefs;
            }
        }
    }




}
