/*private KeyHandler ghk1;
private KeyHandler ghk2;
private KeyHandler ghk3;
private KeyHandler ghk4;

ghk1 = new KeyHandler(Keys.A, this);
ghk1.Register();
            ghk2 = new KeyHandler(Keys.S, this);
ghk2.Register();
            ghk3 = new KeyHandler(Keys.D, this);
ghk3.Register();
            ghk4 = new KeyHandler(Keys.F, this);
ghk4.Register();

protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
            {
                if (m.WParam.ToInt32() == ghk1.GetHashCode()) //The key associated with ghk got pressed
                    ClickFunctions.rightCLICK();
                else if (m.WParam.ToInt32() == ghk2.GetHashCode()) //The key associated with ghk2 got pressed
                    ClickFunctions.leftDOWN();
                else if (m.WParam.ToInt32() == ghk3.GetHashCode())
                    ClickFunctions.leftUP();
                else if (m.WParam.ToInt32() == ghk4.GetHashCode())
                    ClickFunctions.doubleCLICK();
            }
            /*else if (m.Msg == Constants.WM_SYSCOMMAND) // minimized
            {
                int command = m.WParam.ToInt32() & 0xfff0;
                if (command == Constants.SC_MINIMIZE)
                {
                    this.Hide();
                    this.ShowInTaskbar = false;
                    notifyIcon1.Visible = true;
                    notifyIcon1.ShowBalloonTip(100);
                }
            }
            base.WndProc(ref m);
        }
        
     private ControlForm controlForm;

        public ConnectForm(ControlForm controlForm)
        {
            InitializeComponent();

            List<string> portnames = new List<string>();
            for(int i = 1; i <= 30; i++)
            {
                portnames.Add("COM" + i.ToString());
            }
            comboBox_ports.Items.Add(portnames);
        }

        private void ConnectForm_Load(object sender, EventArgs e)
        {
            this.controlForm = controlForm;


        }    
         
         
         
         
         */