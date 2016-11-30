using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseApp
{
    public partial class ConnectForm : Form
    {
        private readonly ControlForm cntrlForm;
        INIFile ini = new INIFile(Constants.INI_PATH);
        string PREV_PORT;
        bool firstOpen;

        public ConnectForm(ControlForm controlForm)
        {
            InitializeComponent();
            this.cntrlForm = controlForm;

            comboBox_ports.Items.Clear();
            for (int i = 1; i <= 30; i++)
            {
                comboBox_ports.Items.Add("COM" + i.ToString());
            }
        }

        private void ConnectForm_Load(object sender, EventArgs e)
        {
            Location = new Point(cntrlForm.Location.X + (cntrlForm.Size.Width / 2 - Size.Width / 2), cntrlForm.Location.Y + cntrlForm.Size.Height/2);

            firstOpen = Variables.firstOpen;
            Console.WriteLine("First open program: " + firstOpen.ToString());
            Variables.firstOpen = false;
            //if(cntrlForm.port.IsOpen)                
                //cntrlForm.port.Close();
            //cntrlForm.port.Dispose();
            if (Variables.WAS_CONNECTED)
            {
                PREV_PORT = Constants.COM_PORT;
            }

            Thread.Sleep(100);
            this.BringToFront();
            comboBox_ports.SelectedItem = ini.Read("Settings", "COMPORT").ToUpper().ToString();
        }

        private void button_Done_Click(object sender, EventArgs e)
        {
            if(Variables.WAS_CONNECTED && (PREV_PORT == comboBox_ports.SelectedItem.ToString()))
            {
                Thread.Sleep(200);
                if (cntrlForm.port.IsOpen)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid port or FMG band is not connected!");
                }
            }
            else
            {
                if (cntrlForm.port.IsOpen)
                {
                    cntrlForm.port.Close();
                    cntrlForm.port.Dispose();
                    Console.WriteLine("closed and disposed port");
                }
                Thread.Sleep(200);
                cntrlForm.port = new SerialPort(comboBox_ports.SelectedItem.ToString(), 115200, Parity.None, 8, StopBits.One);
                bool validPort = false;
                try
                {
                    cntrlForm.port.Open();
                    validPort = true;
                    Console.WriteLine("replacing port worked");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("replacing port failed");
                }

                if (validPort)
                {
                    Constants.COM_PORT = comboBox_ports.SelectedItem.ToString();
                    ini.Write("Settings", "COMPORT", Constants.COM_PORT);
                    Variables.WAS_CONNECTED = true;

                    this.Close();
                }
                else
                {
                    Variables.WAS_CONNECTED = false;
                    MessageBox.Show("Invalid port or FMG band is not connected!");
                }
            }
                        

        }

        private void ConnectForm_Closing(object sender, CancelEventArgs e)
        {
            if (firstOpen)
            {
                MessageBox.Show("The program must first be trained.\nPlease click on the Training button.");
            }
        }           

    }
            
}
