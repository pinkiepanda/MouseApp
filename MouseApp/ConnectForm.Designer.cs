namespace MouseApp
{
    partial class ConnectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectForm));
            this.comboBox_ports = new System.Windows.Forms.ComboBox();
            this.button_Done = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox_ports
            // 
            this.comboBox_ports.BackColor = System.Drawing.Color.LightSteelBlue;
            this.comboBox_ports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ports.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comboBox_ports.FormattingEnabled = true;
            this.comboBox_ports.Location = new System.Drawing.Point(18, 75);
            this.comboBox_ports.Name = "comboBox_ports";
            this.comboBox_ports.Size = new System.Drawing.Size(70, 21);
            this.comboBox_ports.TabIndex = 0;
            // 
            // button_Done
            // 
            this.button_Done.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button_Done.FlatAppearance.BorderSize = 0;
            this.button_Done.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Done.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Done.ForeColor = System.Drawing.Color.White;
            this.button_Done.Location = new System.Drawing.Point(104, 64);
            this.button_Done.Name = "button_Done";
            this.button_Done.Size = new System.Drawing.Size(134, 39);
            this.button_Done.TabIndex = 3;
            this.button_Done.Text = "C O N F I R M";
            this.button_Done.UseVisualStyleBackColor = false;
            this.button_Done.Click += new System.EventHandler(this.button_Done_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 40);
            this.label1.TabIndex = 4;
            this.label1.Text = "Please select the correct \r\nCOM port and click Confirm.";
            // 
            // ConnectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.BackgroundImage = global::MouseApp.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(255, 121);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Done);
            this.Controls.Add(this.comboBox_ports);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Connect";
            this.Load += new System.EventHandler(this.ConnectForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_ports;
        private System.Windows.Forms.Button button_Done;
        private System.Windows.Forms.Label label1;
    }
}