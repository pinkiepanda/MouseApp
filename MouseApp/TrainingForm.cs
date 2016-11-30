using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;

using System.IO;

namespace MouseApp
{
    public partial class TrainingForm : Form
    {
        private readonly ControlForm cntrlForm;
        public INIFile ini = new INIFile(Constants.INI_PATH);

        private string selectedName;
        //private int Variables.selectedCode;
        private int selectedIndex;

        private bool forcedcomplete = false;

        private BackgroundWorker msgWorker = new BackgroundWorker();
        private BackgroundWorker progressWorker = new BackgroundWorker();
        private BackgroundWorker trainWorker = new BackgroundWorker();
        private BackgroundWorker colourFlasher = new BackgroundWorker();
        //public SerialPort port = new SerialPort("COM23", 115200, Parity.None, 8, StopBits.One);

        public TrainingForm(ControlForm controlForm)
        {
            InitializeComponent();

            cntrlForm = controlForm;    
                        
            msgWorker.WorkerReportsProgress = true; // Enable progress reporting
            // Hook up event handlers
            msgWorker.DoWork += msgWorker_DoWork;
            msgWorker.RunWorkerCompleted += msgWorker_RunWorkerCompleted;
            msgWorker.ProgressChanged += msgWorker_ProgressChanged;
            
            progressWorker.WorkerReportsProgress = true; // Enable progress reporting
            // Hook up event handlers
            progressWorker.DoWork += progressWorker_DoWork;
            progressWorker.RunWorkerCompleted += progressWorker_RunWorkerCompleted;
            progressWorker.ProgressChanged += progressWorker_ProgressChanged;

            trainWorker.WorkerReportsProgress = true; // Enable progress reporting
            // Hook up event handlers
            trainWorker.DoWork += trainWorker_DoWork;
            trainWorker.RunWorkerCompleted += trainWorker_RunWorkerCompleted;
            trainWorker.ProgressChanged += trainWorker_ProgressChanged;

            colourFlasher.WorkerReportsProgress = true; // Enable progress reporting
            // Hook up event handlers
            colourFlasher.DoWork += colourFlasher_DoWork;
            //colourFlasher.RunWorkerCompleted += colourFlasher_RunWorkerCompleted;
            colourFlasher.ProgressChanged += colourFlasher_ProgressChanged;

            //controlForm.port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived); // Attach a method to be called when there is data waiting in the port's buffer

        }

        private void Training_Load(object sender, EventArgs e)
        {            

            //string[] optional_functions = { "Click and Drag", "Double Click", "Right Click", "Move Mouse" };
            functionsListBox.Items.AddRange(Constants.FUNCTION_NAMES);
            trainTimeBox.Items.AddRange(Constants.TIMES);
            progressBar1.Hide();
            functionsListBox.SelectedItem = "Rest";            

            if (File.Exists(Constants.INI_PATH))
            {
                trainTimeBox.SelectedItem = ini.Read("Settings", "TRAINTIME");
                if (Constants.TIMES.Contains(trainTimeBox.SelectedItem.ToString()))
                {
                    Variables.TRAIN_TIME = Int32.Parse(trainTimeBox.SelectedItem.ToString());
                    doMATH();
                }
                else
                {
                    trainTimeBox.SelectedItem = "3";
                    Variables.TRAIN_TIME = 3;
                    doMATH();
                }                                
            }
            else
            {
                trainTimeBox.SelectedItem = "3";
                Variables.TRAIN_TIME = 3;
                doMATH();
            } 
            
            label_Message.Text = "Rest position will be trained first.";
            label_Progress.Text = "";
            button_Done.Enabled = false;
            
            Variables.cumul_data.Clear();
            Variables.cumul_rand.Clear();
            Variables.clearFuncs(); // none are trained
            cntrlForm.enableCheckboxes();
            Variables.selectedCode = 0;            
            //MessageBox.Show("The Rest position will be trained first!");
            functionsListBox.Enabled = false;
            button_Done.Enabled = false;
            //train_function();
            //Console.WriteLine("Port is open: {0}", cntrlForm.port.IsOpen);
            if (!cntrlForm.port.IsOpen) ;
                //getComPort();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedName = functionsListBox.SelectedItem.ToString();
            Variables.selectedCode = Array.IndexOf(Constants.FUNCTION_NAMES, selectedName);
            if (selectedName == "Move Mouse")            
                button_StartTrain.Enabled = false;            
            else
                button_StartTrain.Enabled = true;
        }

        private void radioButton_DoubleClick_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button_Done_Click(object sender, EventArgs e)
        {
            Variables.cumul_data.ForEach(Console.WriteLine);
            File.WriteAllLines(Constants.DATA_PATH, Variables.cumul_data);
            File.WriteAllLines(Constants.RAND_PATH, Variables.cumul_rand);

            Variables.training = false;
            progressWorker.RunWorkerAsync();
            Thread.Sleep(100);
            bool trained = SVMClass.trainProblem();
            Thread.Sleep(300);
            if (trained)
            {              
                cntrlForm.holdCommandListener = false;
                //cntrlForm.stopWatch.Restart();
                Console.WriteLine("Port is open: {0}", cntrlForm.port.IsOpen);
                cntrlForm.trained = true;        
            }
            else
            {
                MessageBox.Show("Training failed, please restart the program.");
            }
            this.Close();
        }
        
        private void train_function()
        {
            progressBar1.Show();
            progressBar1.Value = 0;
            label_Message.Text = String.Format("Training {0} in...", Constants.FUNCTION_NAMES[Variables.selectedCode]);
            msgWorker.RunWorkerAsync();
            // SVM(selectedIndex);  
        }

        private void button_StartTrain_Click(object sender, EventArgs e)
        {
            functionsListBox.Enabled = false;
            trainTimeBox.Enabled = false;
            button_StartTrain.Enabled = false;
            button_Done.Enabled = false;
            train_function();      
        }

        private int get_numTrained()
        {
            int numTrained = 0;
            for (int i = 0; i < Constants.NUM_FUNCTIONS; i++)
            {
                if(Variables.funcs_TRAINED[i] == 1)
                {
                    numTrained++;
                }
            }
            return numTrained;
        }
        
        private void msgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = 3; i >= 0; i--)
            {                
                Thread.Sleep(1000); // Perform a time consuming operation and report progress.
                msgWorker.ReportProgress(i);
            }
        }

        private void msgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            label_Progress.Text = e.ProgressPercentage.ToString();
        }

        private void msgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {            
            label_Progress.Text = "";
            progressWorker.RunWorkerAsync();
            read_dataset();
            label_Message.Text = String.Format("Training {0}...", Constants.FUNCTION_NAMES[Variables.selectedCode]);
        }

        private void progressWorker_DoWork(object sender, DoWorkEventArgs e)
        {            
            BackgroundWorker worker = sender as BackgroundWorker;
            if (Variables.training)
            {
                for (int i = 1; i <= Variables.TRAIN_TIME; i++)
                {
                    Thread.Sleep(1000); // Perform a time consuming operation and report progress.
                    int progress = i * (100 / Variables.TRAIN_TIME) + 1;
                    if (progress > 100)
                        progress = 100;
                    progressWorker.ReportProgress(progress);
                }
            }
            else
            {
                for (int i = 0; i <= 100; i = i + 50)
                {
                    progressWorker.ReportProgress(i);
                }
            }            

        }

        private void progressWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (Variables.training)
                progressBar1.Value = e.ProgressPercentage;
            else            
                label_Message.Text = "Please wait...";            
        }

        private void progressWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Variables.training)
            {
                //Thread.Sleep(133*2);
                label_Message.Text = "Done!";
                Variables.funcs_TRAINED[Variables.selectedCode] = 1;
                cntrlForm.enableCheckboxes();

                functionsListBox.Enabled = true;
                button_StartTrain.Enabled = true;
                if (get_numTrained() > 1)
                    button_Done.Enabled = true;
            }
        }

        private void read_dataset()
        {
            Variables.dataset.Clear();
            Variables.randomized.Clear();
            trainWorker.RunWorkerAsync();
        }

        private void trainWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = 1; i <= Variables.TRAINING_SAMPLES; i++)
            {
                if (!forcedcomplete)
                {
                    Console.WriteLine("I'm here in commandListener");
                    if (cntrlForm.port.IsOpen)
                        trainWorker.ReportProgress(i);
                    else
                    {
                        forcedcomplete = true;
                        i = Variables.TRAINING_SAMPLES + 1;
                        //Thread thread = new Thread(MethodThread);
                        //thread.Start(SynchronizationContext.Current);
                        //getComPort();
                    }

                    Thread.Sleep(100);
                }
                else
                {
                    i = Variables.TRAINING_SAMPLES + 1;
                }                
            }
        }

        private void getComPort()
        {
            //MessageBox.Show("FMG band is not connected!");
            ConnectForm connectForm = new ConnectForm(cntrlForm);
            connectForm.Show();            
            this.Close();
            // CloseForm(this);
            //BeginInvoke(new MethodInvoker(Close));
            //this.Invoke((MethodInvoker)delegate () { this.Close(); });
        }

        private void MethodThread(Object syncronizationContext)
        {
            ((SynchronizationContext)syncronizationContext).Send(CloseForm, this);
        }

        private void CloseForm(Object state)
        {
            Close();
        }

        private void trainWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                request_data();
            }
            catch (Exception ex)
            {
                forcedcomplete = true;
                //MessageBox.Show("FMG band is not on!");
                //getComPort();
            }            
        }

        private void trainWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!forcedcomplete)
            {
                // consolidate data
                try
                {
                    Variables.dataset.ForEach(Console.WriteLine);
                }
                catch
                {
                }
                
                Variables.cumul_data.AddRange(Variables.dataset);
                Variables.cumul_rand.AddRange(Variables.randomized);


                trainTimeBox.Enabled = true;
            }
            else
            {
                ConnectForm connectForm = new ConnectForm(cntrlForm);
                connectForm.Show();
                this.Close();
            }
                
        }

        private void request_data()
        {
            cntrlForm.port.WriteLine("d");
        }

        private void trainTimeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedName != "Move Mouse")
                button_StartTrain.Enabled = true;
            Variables.TRAIN_TIME = Int32.Parse(trainTimeBox.SelectedItem.ToString());
            ini.Write("Settings", "TRAINTIME", Variables.TRAIN_TIME.ToString());
            doMATH();
            colourFlasher.RunWorkerAsync();
        }

        private void doMATH()
        {
            double samples = Variables.TRAIN_TIME * 1000 / 133.0;
            Variables.TRAINING_SAMPLES = (int)Math.Ceiling(samples);
            double min_Train = Constants.MIN_SAMPLES / samples;
            double recommend_Train = Constants.RECOMMEND_SAMPLES / samples;
            Variables.MIN_TRAIN_CLICKS = (int)Math.Floor(min_Train);
            Variables.RECOMMEND_CLICKS = (int)Math.Floor(recommend_Train);

            string temp = "Recommend training each position at \nleast " + Variables.MIN_TRAIN_CLICKS + " times, ";
            temp += "ideally " + Variables.RECOMMEND_CLICKS + " times if possible.";
            temp += "\nVary each gesture for better prediction.";
            label_recommend.Text = temp;            
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void colourFlasher_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = 1; i < 3; i++)
            {                
                colourFlasher.ReportProgress(i);
                if (i == 1)
                    Thread.Sleep(1000); // Perform a time consuming operation and report progress.
            }
        }

        private void colourFlasher_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 1)
                label_recommend.ForeColor = SystemColors.ControlLightLight;
            else if (e.ProgressPercentage == 2)
                label_recommend.ForeColor = SystemColors.ControlDark;
        }

        /*private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Console.WriteLine("IN TRAINING: " + Variables.training.ToString());
            if (Variables.training)
            {
                Thread.Sleep(33);
                //Console.Write(port.BytesToRead);

                string dataline = controlForm.port.ReadExisting();
                Console.WriteLine(dataline);
                Variables.dataline = SVMClass.processData(dataline);
                string fulldataline = Variables.selectedCode.ToString() + " " + Variables.dataline;
                Variables.dataset.Add(fulldataline);
            }
        }*/

    }
}
