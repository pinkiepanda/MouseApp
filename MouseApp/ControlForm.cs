using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Timers;
using System.IO.Ports;
using System.Threading;
using System.IO;
using System.Configuration;
using System.Collections.Specialized;
using LibSVMsharp;
using LibSVMsharp.Helpers;
using LibSVMsharp.Core;
using LibSVMsharp.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Controls.Primitives;

namespace MouseApp
{
    public partial class ControlForm : Form
    {        
        private bool clickedDown = false;
        public INIFile ini = new INIFile(Constants.INI_PATH);
        public SerialPort port;
        public static bool portExists = false;
        
        private BackgroundWorker commandListener = new BackgroundWorker(){ WorkerSupportsCancellation = true };
        private BackgroundWorker portChecker = new BackgroundWorker() { WorkerSupportsCancellation = true };
        public Stopwatch stopWatch = new Stopwatch();
        public bool trained = false;

        private bool _activated = false;
        public bool activated
        {
            get { return _activated; }
            set
            {
                _activated = value;
                if (value == false)
                {
                    ledBox.Image = Properties.Resources.Glowing_Led_off;
                    activateButton.Text = "T u r n   O N";
                }
                else if (value == true)
                {
                    stopWatch.Restart();
                    ledBox.Image = Properties.Resources.Glowing_Led_on;
                    activateButton.Text = "T u r n  O F F";
                }
            }
        }

        private bool runCommandListener = true;
        //public static bool holdCommandListener = false;
        private bool _holdCommandListener = true; // need to train first, don't run
        public bool holdCommandListener
        {
            get { return _holdCommandListener; }
            set
            {
                _holdCommandListener = value;
                if (value == true)
                {
                    ledBox2.Image = Properties.Resources.blueledoff;
                    activated = false;
                }
                else
                {
                    //ledBox2.Image = Properties.Resources.blueledon;                    
                }                    
            }
        }

        public ControlForm()
        {
            InitializeComponent();           

            commandListener.WorkerReportsProgress = true; // Enable progress reporting
            // Hook up event handlers
            commandListener.DoWork += commandListener_DoWork;
            commandListener.RunWorkerCompleted += commandListener_RunWorkerCompleted;
            commandListener.ProgressChanged += commandListener_ProgressChanged;

            portChecker.WorkerReportsProgress = true; // Enable progress reporting
            // Hook up event handlers
            portChecker.DoWork += portChecker_DoWork;
            //commandListener.RunWorkerCompleted += commandListener_RunWorkerCompleted;
            portChecker.ProgressChanged += portChecker_ProgressChanged;

            this.SizeChanged += new EventHandler(ControlForm_sizeeventhandler);
            
        }        

        private void Control_Load(object sender, EventArgs e)
        {
            Rectangle screenRect = Screen.GetBounds(Bounds);
            Location = new Point(screenRect.Width/2 - ClientSize.Width/2, screenRect.Height/2 - ClientSize.Height/2 - 100);

            ledBox.Image = Properties.Resources.Glowing_Led_off;
            ledBox2.Image = Properties.Resources.blueledoff;

            if (File.Exists(Constants.INI_PATH))
                Constants.COM_PORT = ini.Read("Settings", "COMPORT").ToUpper().ToString();
            else
            {
                File.Create(Constants.INI_PATH);
                ini.Write("Settings", "COMPORT", "COM1");
                Constants.COM_PORT = "COM1";
            }
            
            Variables.training = false;
            enableCheckboxes();
            

            port = new SerialPort(Constants.COM_PORT, 115200, Parity.None, 8, StopBits.One);
            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived); // Attach a method to be called when there is data waiting in the port's buffer
            try
            {
                port.Open();
                portExists = true;
            }
            catch (Exception ex)
            {
                portExists = false;
                Console.WriteLine("COM port not found!");
            }
            if (portExists)
            {
                Variables.WAS_CONNECTED = true;
                ledBox2.Image = Properties.Resources.blueledon;
            }                
            else
            {
                Variables.WAS_CONNECTED = false;
                //getComPort();
            }

            //while (!portExists) ;


            //INIFile ini = new INIFile(Constants.INI_PATH);
            //ini.Write("Settings", "COMPORT", "COM1");
            //MessageBox.Show(ini.Read("Settings", "COMPORT").ToUpper().ToString());
            //MessageBox.Show("The program must first be trained.\nPlease click on the Training button.");
            commandListener.RunWorkerAsync();
            portChecker.RunWorkerAsync();
        }        
        

        private void ControlForm_sizeeventhandler(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon1.ShowBalloonTip(100);
            }
                /*MessageBox.Show("Form is mininized");
            else if (this.WindowState == FormWindowState.Normal)            
                MessageBox.Show("Form is restored");
            else if (this.WindowState == FormWindowState.Maximized)
                MessageBox.Show("Form is maximized");*/    
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void ToTrainingButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(port.PortName.ToString());
            if (!port.IsOpen)
            {
                try
                {
                    port.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("port can't be opened");
                }
            }
            
            if (port.IsOpen)
            {
                holdCommandListener = true;
                Variables.training = true;
                TrainingForm trainingForm = new TrainingForm(this);
                trainingForm.Show();
                Console.WriteLine("Port is open: {0}", port.IsOpen);
            }
            else
            {
                getComPort();
            }           
            
        }

        public void enableCheckboxes()
        {
            if (Variables.funcs_TRAINED[1] == 1) // Click and drag
                checkBox_ClickDrag.Enabled = true;
            else
            {
                checkBox_ClickDrag.Enabled = false;
                checkBox_ClickDrag.Checked = false;
            }    
                  
            if (Variables.funcs_TRAINED[2] == 1) // double click
                checkBox_DoubleClick.Enabled = true;
            else
            {
                checkBox_DoubleClick.Enabled = false;
                checkBox_DoubleClick.Checked = false;
            }
                
            if (Variables.funcs_TRAINED[3] == 1) // right click
                checkBox_RightClick.Enabled = true;
            else
            {
                checkBox_RightClick.Enabled = false;
                checkBox_RightClick.Checked = false;
            }                

            if (false)// no move for now... Variables.funcs_TRAINED[4] == 1) // move mouse
            {
                checkBox_Move.Enabled = true;
                //mouseSpeedBar.Enabled = true;
                //label2.Enabled = true;
                //label3.Enabled = true;
            }             
            else
            {
                checkBox_Move.Enabled = false;
                checkBox_Move.Checked = false;
                //mouseSpeedBar.Enabled = false;
                //label2.Enabled = false;
                //label3.Enabled = false;
            }
                
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Console.WriteLine("Training: " + Variables.training.ToString());
            if (!Variables.training)
            {
                Thread.Sleep(33);
                //Console.Write(port.BytesToRead);

                string dataline = port.ReadExisting();
                //Console.Write(dataline);
                Variables.processedline = SVMClass.processData(dataline);
                //Console.WriteLine(Variables.dataline);
                if (Variables.processedline[0] != null)
                    Variables.newdata = "0 " + Variables.processedline[0];                                   
                else
                    Variables.newdata = "0 null";
                File.WriteAllText(Constants.NEWDATA_PATH, Variables.newdata);

                Thread.Sleep(67);
                if (SVMClass.checkExistingModel())
                {
                    doAction();                                        
                }                    
                else
                    Console.WriteLine("No model!");         
            }
            else if (Variables.training)
            {
                Thread.Sleep(33);
                //Console.Write(port.BytesToRead);

                string dataline = port.ReadExisting();
                Console.WriteLine(dataline);
                Variables.processedline = SVMClass.processData(dataline);
                string fulldataline = Variables.selectedCode.ToString() + " " + Variables.processedline[0];
                string randdataline = Variables.selectedCode.ToString() + " " + Variables.processedline[1];
                if (!fulldataline.Contains("null"))
                {
                    Variables.dataset.Add(fulldataline);
                    Variables.randomized.Add(randdataline);
                }
                    
            }
        }

        private void doAction()
        {
            int command = SVMClass.predictSVM();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine("Stopwatch ms: " + ts.Milliseconds.ToString());
            if (ts.Milliseconds > 750)
            {
                if (command == 1 && checkBox_ClickDrag.Checked)
                {
                    if (clickedDown)
                    {
                        ClickFunctions.leftUP();
                        clickedDown = false;
                    }
                        
                    else
                    {
                        ClickFunctions.leftDOWN();
                        clickedDown = true;
                    }
                    stopWatch.Restart();
                }
                else if (command == 2 && checkBox_DoubleClick.Checked)
                {
                    ClickFunctions.doubleCLICK();
                    stopWatch.Restart();
                }

                else if (command == 3 && checkBox_RightClick.Checked)
                {
                    ClickFunctions.rightCLICK();
                    stopWatch.Restart();
                }
                else
                {
                    //
                }
            }
        }

        private void commandListener_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 1;
            BackgroundWorker worker = sender as BackgroundWorker;
            while (runCommandListener)
            {
                Console.WriteLine("Hold command listener: {0}  activated: {0}", holdCommandListener, activated);
                while (holdCommandListener)
                    if(trained)
                        Console.Write("holding...");
                while (!activated)
                    if (trained)
                        Console.Write("not activated...");
                Console.WriteLine("yo I'm here in commandListener for the: {0} time", i);
                i++;                
                if (port.IsOpen)
                {
                    commandListener.ReportProgress(1);
                    Console.WriteLine("port open new");
                }                    
                else
                {
                    Console.WriteLine("port not open new");
                    holdCommandListener = true;
                    activated = false;
                    //getComPort();
                }
                Thread.Sleep(200);
            }
        }

        private void commandListener_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine("requested data");
            request_data();
        }

        private void commandListener_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            /*const string JSON = @"{
                          ""response"": {
                            ""_token"": ""StringValue"",
                            ""code"": ""OK"",
                            ""user"": {
                              ""userid"": ""2630944"",
                              ""firstname"": ""John"",
                              ""lastname"": ""Doe"",
                              ""reference"": ""999999999"",
                              ""guid"": ""StringValue"",
                              ""domainid"": ""99999"",
                              ""username"": ""jdoe"",
                              ""email"": ""jdoe@jdoe.edu"",
                              ""passwordquestion"": """",
                              ""flags"": ""0"",
                              ""lastlogindate"": ""2013-02-05T17:54:06.31Z"",
                              ""creationdate"": ""2011-04-15T14:40:07.22Z"",
                              ""version"": ""3753"",
                              ""data"": {
                                ""aliasname"": {
                                  ""$value"": ""John Doe""
                                },
                                ""smsaddress"": {
                                  ""$value"": ""5555555555@messaging.sprintpcs.com""
                                },
                                ""blti"": {
                                  ""hideemail"": ""false"",
                                  ""hidefullname"": ""false""
                                },
                                ""notify"": {
                                  ""grades"": {
                                    ""$value"": ""0""
                                  },
                                  ""messages"": {
                                    ""$value"": ""1""
                                  }
                                },
                                ""beta_component_courseplanexpress_1"": {
                                  ""$value"": ""true""
                                }
                              }
                            }
                          }
                        }";

            var jo = JObject.Parse(JSON);
            var data = (JObject)jo["response"]["user"]["data"]["aliasname"];
            foreach (var item in data)
            {
                Console.WriteLine("{0}: {1}", item.Key, item.Value);
            }*/
        }

        private void request_data()
        {
            try
            {
                port.WriteLine("d");
            }
            catch (Exception ex)
            {
                holdCommandListener = true;
                activated = false;
            }            
        }

        private void getComPort()
        {
            MessageBox.Show("FMG band is not connected!");
            ConnectForm connectForm = new ConnectForm(this);
            connectForm.Show();            
            //this.SendToBack();
            //connectForm.BringToFront();
            //connectForm.Focus();
            //Application.OpenForms[connectForm.Name].Activate();
        }

        private void portChecker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            while (true)
            {
                portChecker.ReportProgress(1);
                Thread.Sleep(300);
            }
        }

        private void portChecker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (port.IsOpen)
            {
                ledBox2.Image = Properties.Resources.blueledon;
                //activateButton.Enabled = true;
            }
            else
            {
                activated = false;
                ledBox2.Image = Properties.Resources.blueledoff;
                ledBox.Image = Properties.Resources.Glowing_Led_off;
                activateButton.Text = "T u r n  O N";
                //activateButton.Enabled = false;
            }            
        }

        private void checkBox_DoubleClick_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button_Help_Click(object sender, EventArgs e)
        {
            /*if (holdCommandListener)
                holdCommandListener = false;
            else
                holdCommandListener = true;*/
            //testSVM();        
            
                
        }

        private void testSVM()
        {
            if (!holdCommandListener)
            {
                holdCommandListener = true;
            }
            string parentpath = System.AppDomain.CurrentDomain.BaseDirectory;
            string DATA_PATH = parentpath + "Datasets\\dataset - Copy (2).txt";
            string MODEL_PATH = parentpath + "Model\\testmodel.txt";
            string NEWDATA_PATH = parentpath + "Datasets\\testdata.txt";
            string RESULTS_PATH = parentpath + "Datasets\\results.txt";
            List<string> resultsstring = new List<string>();

            SVMProblem testSet = SVMProblemHelper.Load(NEWDATA_PATH);
            SVMParameter testparameter = new SVMParameter();
            testparameter.Type = SVMType.C_SVC;
            testparameter.Kernel = SVMKernelType.RBF;
            testparameter.C = 0.1; //Constants.C;
            testparameter.Gamma = 0.001; // Constants.gammasq;

            List<SVMClass.SVMResult> ResultsList = new List<SVMClass.SVMResult>();

            SVMProblem problem = SVMProblemHelper.Load(DATA_PATH);
            double C = 0.001;
            double gammasq = 0.001;
            for (C = 1; C <= 1000; C = C * 10)
            {
                for (gammasq = 0.001; gammasq <= 1000; gammasq = gammasq * 10)
                {
                    SVMParameter parameter = new SVMParameter();
                    parameter.Type = SVMType.C_SVC;
                    parameter.Kernel = SVMKernelType.RBF;
                    parameter.C = C;
                    parameter.Gamma = gammasq;

                    SVMModel model = SVM.Train(problem, parameter);
                    //File.WriteAllText(MODEL_PATH, String.Empty);
                    //SVM.SaveModel(model, MODEL_PATH);
                    //Console.WriteLine("Trained and saved model.\n");

                    //model = SVM.LoadModel(MODEL_PATH);

                    SVMProblem newData = SVMProblemHelper.Load(NEWDATA_PATH);
                    //Console.Write("Predicted Result:\n");
                    double[] results = newData.Predict(model);
                    //Console.Write(results[0]);
                    int[,] confusionMatrix;
                    double testAccuracy = newData.EvaluateClassificationProblem(results, model.Labels, out confusionMatrix);

                    // Do cross validation to check this parameter set is correct for the dataset or not
                    double[] crossValidationResults; // output labels
                    int nFold = 10;
                    problem.CrossValidation(parameter, nFold, out crossValidationResults);

                    // Evaluate the cross validation result
                    // If it is not good enough, select the parameter set again
                    double crossValidationAccuracy = problem.EvaluateClassificationProblem(crossValidationResults);
                    //Console.WriteLine("\n\nCross validation accuracy: " + crossValidationAccuracy);

                    string temp = "";

                    string resultstring = "Predict accuracy: " + testAccuracy + " C: " + C + " gamma: " + gammasq + " Cross validation accuracy: " + crossValidationAccuracy;
                    resultsstring.Add(resultstring);

                    if (parameter.C == testparameter.C && parameter.Gamma == testparameter.Gamma)
                        resultsstring.Add("This one is same as separate test.");

                    foreach (double res in results)
                    {
                        temp += res.ToString() + " ";
                    }
                    resultsstring.Add(temp);

                    SVMClass.SVMResult compiled = new SVMClass.SVMResult();
                    compiled.C = C;
                    compiled.gamma = gammasq;
                    compiled.testAcc = testAccuracy;
                    compiled.crossValidAcc = crossValidationAccuracy;
                    ResultsList.Add(compiled);
                }

            }
            File.WriteAllLines(RESULTS_PATH, resultsstring);


            SVMModel testmodel = SVM.Train(problem, testparameter);

            // Predict the instances in the test set
            double[] testResults = testSet.Predict(testmodel);
            foreach (double result in testResults)
            {
                Console.WriteLine(result);
            }

            // Evaluate the test results

            double maxTestAcc = ResultsList.Max(resultdata => resultdata.testAcc);
            int maxTestAccIndex = ResultsList.FindIndex(resultdata => resultdata.testAcc.Equals(maxTestAcc));
            //double maxValidAcc = ResultsList.Max(resultdata => resultdata.crossValidAcc);
            //int maxValidAccIndex = ResultsList.FindIndex(resultdata => resultdata.crossValidAcc.Equals(maxValidAcc));
            List<SVMClass.SVMResult> topResults = ResultsList.FindAll(resultdata => resultdata.testAcc.Equals(maxTestAcc));
            double maxC = topResults.Max(resultdata => resultdata.C);
            int maxCIndex = topResults.FindIndex(resultdata => resultdata.C.Equals(maxC));

            double bestC = topResults[topResults.Count - 2].C; //topResults[maxCIndex].C;
            double bestgamma = topResults[topResults.Count - 2].gamma;//topResults[maxCIndex].gamma;
            Console.WriteLine("Best C: " + bestC + "  Best gammasq: " + bestgamma);

            foreach (SVMClass.SVMResult resultdata in topResults)
            {
                Console.WriteLine(resultdata.C.ToString() + " " + resultdata.gamma.ToString());
            }
            //int[,] confusionMatrix;
            //double testAccuracy = testSet.EvaluateClassificationProblem(testResults, testmodel.Labels, out confusionMatrix);
            //Console.WriteLine("\n\nTest accuracy: " + testAccuracy);
        }

        private void checkSettings()
        {
            ConfigurationManager.AppSettings.Set("Rest", "y");
        }

        private void ControlForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            notifyIcon1.Visible = false;
        }

        private void checkBox_Move_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox_RightClick_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox_ClickDrag_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (trained)
            {
                if (port.IsOpen)
                {
                    if (!activated)
                    {
                        //ledBox.Image = Properties.Resources.Glowing_Led_on;
                        //ledBox2.Image = Properties.Resources.blueledon;
                        activated = true;
                        //stopWatch.Restart();
                        //activateButton.Text = "T u r n  O F F";
                    }
                    else
                    {
                        //ledBox.Image = Properties.Resources.Glowing_Led_off;
                        //ledBox2.Image = Properties.Resources.blueledoff;
                        activated = false;
                        //activateButton.Text = "T u r n   O N";
                    }
                }
                else
                {
                    getComPort();
                }
            }
            else
            {
                MessageBox.Show("The program must first be trained.\nPlease click on the Training button."); 
            }
                     
        }

        /*private void toggleButton1_Click(object sender, EventArgs e)
        {
            activateButton.Refresh();
            if (activateButton.ToggleState == CustomToggleButton.ToggleButton.ToggleButtonState.ON)
            {
                Console.WriteLine("ON");
                if (!port.IsOpen)
                {
                    activateButton.ToggleState = CustomToggleButton.ToggleButton.ToggleButtonState.OFF;
                    activateButton.Refresh();
                    Console.WriteLine(activateButton.ToggleState.ToString());
                    holdCommandListener = true;
                    getComPort();
                }
                else
                {
                    holdCommandListener = false;
                    stopWatch.Restart();
                }                
            }
            else if (activateButton.ToggleState == CustomToggleButton.ToggleButton.ToggleButtonState.OFF)
            {
                Console.WriteLine("OFF");
                holdCommandListener = true;
            }
        }*/
    }
}
