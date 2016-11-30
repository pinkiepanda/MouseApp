using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibSVMsharp;
using LibSVMsharp.Helpers;
using LibSVMsharp.Core;
using LibSVMsharp.Extensions;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace MouseApp
{
    public class SVMClass
    {     

        public static void intializeProblem()
        {


        }

        public static bool trainProblem()
        {
            if (checkExistingDataset())
            {
                SVMProblem problem = SVMProblemHelper.Load(Constants.DATA_PATH);
                SVMProblem randdata = SVMProblemHelper.Load(Constants.RAND_PATH);
                List<string> resultsstring = new List<string>();
                List<SVMClass.SVMResult> ResultsList = new List<SVMClass.SVMResult>();

                double C, gammasq;
                double Cmin = 1, Cmax = 10000, Cstep = 10;
                double gmin = 0.0001, gmax = 1000, gstep = 10;
                bool satisfied = false;
                while (!satisfied)
                {
                                        
                    for (C = Cmin; C <= Cmax; C = C * Cstep)
                    {
                        for (gammasq = gmin; gammasq <= gmax; gammasq = gammasq * gstep)
                        {
                            SVMParameter tempparameter = new SVMParameter();
                            tempparameter.Type = SVMType.C_SVC;
                            tempparameter.Kernel = SVMKernelType.RBF;
                            tempparameter.C = C;
                            tempparameter.Gamma = gammasq;

                            SVMModel tempmodel = SVM.Train(problem, tempparameter);

                            SVMProblem testData = SVMProblemHelper.Load(Constants.RAND_PATH);
                            double[] results = testData.Predict(tempmodel);
                            int[,] confusionMatrix;
                            double testAccuracy = testData.EvaluateClassificationProblem(results, tempmodel.Labels, out confusionMatrix);

                            // Do cross validation to check this parameter set is correct for the dataset or not
                            double[] crossValidationResults; // output labels
                            int nFold = 10;
                            problem.CrossValidation(tempparameter, nFold, out crossValidationResults);

                            // Evaluate the cross validation result
                            // If it is not good enough, select the parameter set again
                            double crossValidationAccuracy = problem.EvaluateClassificationProblem(crossValidationResults);
                            
                            SVMClass.SVMResult compiled = new SVMClass.SVMResult();
                            compiled.C = C;
                            compiled.gamma = gammasq;
                            compiled.testAcc = testAccuracy;
                            compiled.crossValidAcc = crossValidationAccuracy;
                            ResultsList.Add(compiled);
                        }

                    }

                    // Evaluate the test results
                    double maxTestAcc = ResultsList.Max(resultdata => resultdata.testAcc);
                    //int maxTestAccIndex = ResultsList.FindIndex(resultdata => resultdata.testAcc.Equals(maxTestAcc));
                    double maxValidAcc = ResultsList.Max(resultdata => resultdata.crossValidAcc);
                    //int maxValidAccIndex = ResultsList.FindIndex(resultdata => resultdata.crossValidAcc.Equals(maxValidAcc));
                    if (maxTestAcc < 95  || maxValidAcc < 95)
                    {
                        satisfied = false;
                        Cstep--;
                        gstep--;
                    }
                    else
                    {
                        satisfied = true;

                        List<SVMClass.SVMResult> topResults = ResultsList.FindAll(resultdata => resultdata.testAcc.Equals(maxTestAcc));
                        List<SVMClass.SVMResult> topValid = ResultsList.FindAll(resultdata => resultdata.crossValidAcc.Equals(maxValidAcc));
                        while (topResults.Count > topValid.Count)
                        {
                            topResults.RemoveAt(ResultsList.FindIndex(resultsdata => resultsdata.crossValidAcc.Equals(ResultsList.Min(resultdata => resultdata.crossValidAcc))));
                        }

                        double maxC = topResults.Max(resultdata => resultdata.C);
                        int maxCIndex = topResults.FindIndex(resultdata => resultdata.C.Equals(maxC));
                        double bestgamma = topResults[maxCIndex].gamma;
                        // maxC or not???
                        //double bestC = topResults[topResults.Count - 2].C; //topResults[maxCIndex].C;
                        //double bestgamma = topResults[topResults.Count - 2].gamma;//topResults[maxCIndex].gamma;
                        Console.WriteLine("Best C: " + maxC + "  Best gammasq: " + bestgamma);
                        Constants.C = maxC;
                        Constants.gammasq = bestgamma;

                        foreach (SVMClass.SVMResult resultdata in topResults)
                        {
                            Console.WriteLine(resultdata.C.ToString() + " " + resultdata.gamma.ToString());
                        }
                    }                  
                    

                }

                SVMParameter parameter = new SVMParameter();
                parameter.Type = SVMType.C_SVC;
                parameter.Kernel = SVMKernelType.RBF;
                parameter.C = Constants.C;
                parameter.Gamma = Constants.gammasq;

                Variables.model = SVM.Train(problem, parameter);
                //File.WriteAllText(Constants.MODEL_PATH, String.Empty);
                //SVM.SaveModel(Variables.model, Constants.MODEL_PATH);
                Console.WriteLine("Trained and saved model.\n");
                //return Variables.model;
                return true;
            }
            else
            {
                MessageBox.Show("Invalid training data!");
                return false;
            }            
        }

        public static int predictSVM()
        {
            double[] results = { 99 };
            //Variables.model = getExistingModel();
            if (!Variables.newdata.Contains("null"))
            {
                SVMProblem newData = SVMProblemHelper.Load(Constants.NEWDATA_PATH);

                Console.Write("Predicted command:\n");
                results = newData.Predict(Variables.model);
                /*foreach (var item in results)
                {
                    Console.WriteLine(item.ToString());                
                }*/
                Console.WriteLine(results[0]);
            }
            else
                Console.WriteLine("invalid new data");
            return (int)results[0];
        }

        public static SVMModel getExistingModel()
        {
            //MessageBox.Show("Model Exists");
            return SVM.LoadModel(Constants.MODEL_PATH);
        }        

        public static bool checkExistingModel()
        {
            //if (File.Exists(Constants.MODEL_PATH) && new FileInfo(Constants.MODEL_PATH).Length > 0)
            if (Variables.model.ToString() != String.Empty)
                return true;
            else
                return false;
        }

        public static bool checkExistingDataset()
        {

            //if (Variables.cumul_data.Count > 0) // not empty dataset
            if (File.Exists(Constants.DATA_PATH) && new FileInfo(Constants.DATA_PATH).Length > 0)
                return true;
            else
                return false;
        }

        public static string[] processData(string dataline)
        {
            bool JOworked;
            string toprint = "null";
            string randomized = "null";
            string cleaned = @dataline.Remove(0, 2);
            Console.WriteLine(cleaned);
            try
            {
                JObject test = JObject.Parse(cleaned);
                JOworked = true;
            }
            catch
            {
                JOworked = false;
                Console.WriteLine("JO failed");
            }
            if (JOworked)
            {
                toprint = "";
                randomized = "";
                JObject jo = JObject.Parse(cleaned);
                JArray fsrdata = (JArray)jo.SelectToken("fsr");

                Random rnd = new Random();
                int i = 1;
                foreach (int num in fsrdata)
                {
                    toprint += i.ToString() + ":" + num.ToString() + " ";

                    int rndm = num + rnd.Next(1, 11);
                    if (rndm < 0)
                        rndm = 0;
                    else if (rndm > 255)
                        rndm = 255;
                    randomized += i.ToString() + ":" + rndm.ToString() + " ";

                    i++;
                }
            }            
            Console.WriteLine(toprint);
            string[] set = new string[2] { toprint, randomized }; ;

            return set;
        }

        public struct SVMResult
        {
            public double C;
            public double gamma;
            public double testAcc;
            public double crossValidAcc;
        }

    }
}
