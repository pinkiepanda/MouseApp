using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseApp
{
    public static class Constants
    {
        public const int NUM_FUNCTIONS = 5;
        public static readonly int[] FUNCTION_CODES = { 0, 1, 2, 3, 4 };
        public static readonly string[] FUNCTION_NAMES = { "Rest", "Click and Drag", "Double Click", "Right Click", "Move Mouse" };
        public static readonly string[] TIMES = { "1", "2", "3", "4", "5" };

        //windows message id for hotkey
        public const int WM_HOTKEY_MSG_ID = 0x0312;
        // for minimizng
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MINIMIZE = 0xF020;

        public static string parentpath = System.AppDomain.CurrentDomain.BaseDirectory;
        public static string DATA_PATH = parentpath + "Datasets\\dataset.txt";
        public static string RAND_PATH = parentpath + "Datasets\\randset.txt";
        public static string MODEL_PATH = parentpath + "Model\\model.txt";
        public static string TEMP_MODEL_PATH = parentpath + "Model\\tempmodel.txt";
        public static string NEWDATA_PATH = parentpath + "Datasets\\newdata.txt";
        public static string INI_PATH = parentpath + "config.ini";
        public static string COM_PORT = "COM1";


        public const int MIN_SAMPLES = 50;
        public const int RECOMMEND_SAMPLES = 100;

        public static double C = 100;
        public static double gammasq = 0.001;
        

    }
    
}
