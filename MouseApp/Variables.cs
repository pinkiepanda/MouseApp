using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibSVMsharp;
using LibSVMsharp.Helpers;
using LibSVMsharp.Core;
using LibSVMsharp.Extensions;

namespace MouseApp
{
    public class Variables
    {
        public static bool firstOpen = true;

        public static int[] funcs_ENABLED = new int[Constants.NUM_FUNCTIONS] { 0, 0, 0, 0, 0 };
        public static int[] funcs_TRAINED = new int[Constants.NUM_FUNCTIONS] { 0, 0, 0, 0, 0 };
        
        public static void clearFuncs()
        {
            Array.Clear(funcs_ENABLED, 0, Constants.NUM_FUNCTIONS);
            Array.Clear(funcs_TRAINED, 0, Constants.NUM_FUNCTIONS);
        }

        public static SVMModel model = new SVMModel();
        public static string newdata = "";

        public static string COM_PORT;

        public static string[] processedline;
        public static List<string> dataset = new List<string>();
        public static List<string> randomized = new List<string>();
        public static List<string> cumul_data = new List<string>();
        public static List<string> cumul_rand = new List<string>();
        public static bool training;

        public static int NUM_FSRs = 16;
        public static int BYTES_TO_READ = 16;//50 + 5 + (9 + 16);

        public static int TRAIN_TIME = 3;
        public static int TRAINING_SAMPLES = 33;
        public static int MIN_TRAIN_CLICKS = 1;
        public static int RECOMMEND_CLICKS = 3;

        public static bool WAS_CONNECTED = false;

        public static int selectedCode;

        

    }

    
}
