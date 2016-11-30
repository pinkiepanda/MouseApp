namespace MouseApp
{
    partial class ControlForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.button_ToTraining = new System.Windows.Forms.Button();
            this.checkBox_ClickDrag = new System.Windows.Forms.CheckBox();
            this.checkBox_DoubleClick = new System.Windows.Forms.CheckBox();
            this.checkBox_RightClick = new System.Windows.Forms.CheckBox();
            this.checkBox_Move = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Help = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ledBox = new System.Windows.Forms.PictureBox();
            this.ledBox2 = new System.Windows.Forms.PictureBox();
            this.activateButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ledBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "MouseApp is running in the background. Double click icon to open the window.";
            this.notifyIcon1.BalloonTipTitle = "MENRVA MouseApp";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "MouseApp";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // button_ToTraining
            // 
            this.button_ToTraining.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button_ToTraining.FlatAppearance.BorderSize = 0;
            this.button_ToTraining.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ToTraining.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ToTraining.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_ToTraining.Location = new System.Drawing.Point(350, 105);
            this.button_ToTraining.Name = "button_ToTraining";
            this.button_ToTraining.Size = new System.Drawing.Size(163, 48);
            this.button_ToTraining.TabIndex = 0;
            this.button_ToTraining.Text = "T R A I N I N G";
            this.button_ToTraining.UseVisualStyleBackColor = false;
            this.button_ToTraining.Click += new System.EventHandler(this.ToTrainingButton_Click);
            // 
            // checkBox_ClickDrag
            // 
            this.checkBox_ClickDrag.AutoSize = true;
            this.checkBox_ClickDrag.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_ClickDrag.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_ClickDrag.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBox_ClickDrag.Location = new System.Drawing.Point(30, 55);
            this.checkBox_ClickDrag.Name = "checkBox_ClickDrag";
            this.checkBox_ClickDrag.Size = new System.Drawing.Size(125, 24);
            this.checkBox_ClickDrag.TabIndex = 1;
            this.checkBox_ClickDrag.Text = "Click and Drag";
            this.checkBox_ClickDrag.UseVisualStyleBackColor = false;
            this.checkBox_ClickDrag.CheckedChanged += new System.EventHandler(this.checkBox_ClickDrag_CheckedChanged);
            // 
            // checkBox_DoubleClick
            // 
            this.checkBox_DoubleClick.AutoSize = true;
            this.checkBox_DoubleClick.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_DoubleClick.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_DoubleClick.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBox_DoubleClick.Location = new System.Drawing.Point(30, 81);
            this.checkBox_DoubleClick.Name = "checkBox_DoubleClick";
            this.checkBox_DoubleClick.Size = new System.Drawing.Size(112, 24);
            this.checkBox_DoubleClick.TabIndex = 2;
            this.checkBox_DoubleClick.Text = "Double Click";
            this.checkBox_DoubleClick.UseVisualStyleBackColor = false;
            this.checkBox_DoubleClick.CheckedChanged += new System.EventHandler(this.checkBox_DoubleClick_CheckedChanged);
            // 
            // checkBox_RightClick
            // 
            this.checkBox_RightClick.AutoSize = true;
            this.checkBox_RightClick.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_RightClick.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_RightClick.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBox_RightClick.Location = new System.Drawing.Point(30, 107);
            this.checkBox_RightClick.Name = "checkBox_RightClick";
            this.checkBox_RightClick.Size = new System.Drawing.Size(98, 24);
            this.checkBox_RightClick.TabIndex = 3;
            this.checkBox_RightClick.Text = "Right Click";
            this.checkBox_RightClick.UseVisualStyleBackColor = false;
            this.checkBox_RightClick.CheckedChanged += new System.EventHandler(this.checkBox_RightClick_CheckedChanged);
            // 
            // checkBox_Move
            // 
            this.checkBox_Move.AutoSize = true;
            this.checkBox_Move.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_Move.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Move.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBox_Move.Location = new System.Drawing.Point(30, 133);
            this.checkBox_Move.Name = "checkBox_Move";
            this.checkBox_Move.Size = new System.Drawing.Size(113, 24);
            this.checkBox_Move.TabIndex = 4;
            this.checkBox_Move.Text = "Move Mouse";
            this.checkBox_Move.UseVisualStyleBackColor = false;
            this.checkBox_Move.CheckedChanged += new System.EventHandler(this.checkBox_Move_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(25, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Enable Features";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button_Help
            // 
            this.button_Help.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button_Help.FlatAppearance.BorderSize = 0;
            this.button_Help.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Help.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Help.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_Help.Location = new System.Drawing.Point(350, 36);
            this.button_Help.Name = "button_Help";
            this.button_Help.Size = new System.Drawing.Size(163, 48);
            this.button_Help.TabIndex = 6;
            this.button_Help.Text = "I N F O";
            this.button_Help.UseVisualStyleBackColor = false;
            this.button_Help.Click += new System.EventHandler(this.button_Help_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(175, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 21);
            this.label4.TabIndex = 11;
            this.label4.Text = "FMG Connected: ";
            // 
            // ledBox
            // 
            this.ledBox.BackColor = System.Drawing.Color.Transparent;
            this.ledBox.ErrorImage = null;
            this.ledBox.Image = global::MouseApp.Properties.Resources.Glowing_Led_off;
            this.ledBox.Location = new System.Drawing.Point(296, 98);
            this.ledBox.Name = "ledBox";
            this.ledBox.Size = new System.Drawing.Size(38, 38);
            this.ledBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ledBox.TabIndex = 13;
            this.ledBox.TabStop = false;
            // 
            // ledBox2
            // 
            this.ledBox2.BackColor = System.Drawing.Color.Transparent;
            this.ledBox2.ErrorImage = null;
            this.ledBox2.Image = global::MouseApp.Properties.Resources.blueledoff;
            this.ledBox2.Location = new System.Drawing.Point(296, 42);
            this.ledBox2.Name = "ledBox2";
            this.ledBox2.Size = new System.Drawing.Size(38, 38);
            this.ledBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ledBox2.TabIndex = 15;
            this.ledBox2.TabStop = false;
            // 
            // activateButton
            // 
            this.activateButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.activateButton.FlatAppearance.BorderSize = 0;
            this.activateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.activateButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activateButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.activateButton.Location = new System.Drawing.Point(179, 98);
            this.activateButton.Name = "activateButton";
            this.activateButton.Size = new System.Drawing.Size(111, 38);
            this.activateButton.TabIndex = 16;
            this.activateButton.Text = "T u r n   O N";
            this.activateButton.UseVisualStyleBackColor = false;
            this.activateButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::MouseApp.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(544, 183);
            this.Controls.Add(this.activateButton);
            this.Controls.Add(this.ledBox2);
            this.Controls.Add(this.ledBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_Help);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_Move);
            this.Controls.Add(this.checkBox_RightClick);
            this.Controls.Add(this.checkBox_DoubleClick);
            this.Controls.Add(this.checkBox_ClickDrag);
            this.Controls.Add(this.button_ToTraining);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ControlForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MouseApp";
            this.Load += new System.EventHandler(this.Control_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ledBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button button_ToTraining;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Help;
        private System.Windows.Forms.CheckBox checkBox_ClickDrag;
        private System.Windows.Forms.CheckBox checkBox_DoubleClick;
        private System.Windows.Forms.CheckBox checkBox_RightClick;
        private System.Windows.Forms.CheckBox checkBox_Move;
        private System.Windows.Forms.Label label4;
        private System.Windows.Controls.Primitives.ToggleButton toggleButton1;
        private System.Windows.Forms.PictureBox ledBox;
        private System.Windows.Forms.PictureBox ledBox2;
        private System.Windows.Forms.Button activateButton;
    }
}

