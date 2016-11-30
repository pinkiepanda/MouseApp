namespace MouseApp
{
    partial class TrainingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrainingForm));
            this.label_Progress = new System.Windows.Forms.Label();
            this.button_Done = new System.Windows.Forms.Button();
            this.button_StartTrain = new System.Windows.Forms.Button();
            this.label_Message = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.trainTimeBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_recommend = new System.Windows.Forms.Label();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.functionsListBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_Progress
            // 
            this.label_Progress.AutoSize = true;
            this.label_Progress.BackColor = System.Drawing.Color.Transparent;
            this.label_Progress.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Progress.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_Progress.Location = new System.Drawing.Point(468, 19);
            this.label_Progress.Name = "label_Progress";
            this.label_Progress.Size = new System.Drawing.Size(25, 30);
            this.label_Progress.TabIndex = 1;
            this.label_Progress.Text = "3";
            // 
            // button_Done
            // 
            this.button_Done.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button_Done.FlatAppearance.BorderSize = 0;
            this.button_Done.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Done.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Done.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_Done.Location = new System.Drawing.Point(326, 110);
            this.button_Done.Name = "button_Done";
            this.button_Done.Size = new System.Drawing.Size(161, 45);
            this.button_Done.TabIndex = 2;
            this.button_Done.Text = "F I N I S H E D";
            this.button_Done.UseVisualStyleBackColor = false;
            this.button_Done.Click += new System.EventHandler(this.button_Done_Click);
            // 
            // button_StartTrain
            // 
            this.button_StartTrain.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button_StartTrain.FlatAppearance.BorderSize = 0;
            this.button_StartTrain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_StartTrain.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_StartTrain.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_StartTrain.Location = new System.Drawing.Point(37, 75);
            this.button_StartTrain.Name = "button_StartTrain";
            this.button_StartTrain.Size = new System.Drawing.Size(141, 39);
            this.button_StartTrain.TabIndex = 5;
            this.button_StartTrain.Text = "T R A I N";
            this.button_StartTrain.UseVisualStyleBackColor = false;
            this.button_StartTrain.Click += new System.EventHandler(this.button_StartTrain_Click);
            // 
            // label_Message
            // 
            this.label_Message.AutoSize = true;
            this.label_Message.BackColor = System.Drawing.Color.Transparent;
            this.label_Message.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Message.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_Message.Location = new System.Drawing.Point(219, 24);
            this.label_Message.Name = "label_Message";
            this.label_Message.Size = new System.Drawing.Size(224, 25);
            this.label_Message.TabIndex = 6;
            this.label_Message.Text = "Training Click and Drag in...";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(223, 55);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(264, 25);
            this.progressBar1.TabIndex = 7;
            // 
            // trainTimeBox
            // 
            this.trainTimeBox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.trainTimeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.trainTimeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trainTimeBox.FormattingEnabled = true;
            this.trainTimeBox.Location = new System.Drawing.Point(172, 129);
            this.trainTimeBox.Margin = new System.Windows.Forms.Padding(2);
            this.trainTimeBox.Name = "trainTimeBox";
            this.trainTimeBox.Size = new System.Drawing.Size(39, 24);
            this.trainTimeBox.TabIndex = 8;
            this.trainTimeBox.SelectedIndexChanged += new System.EventHandler(this.trainTimeBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(33, 130);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "Training duration: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(215, 130);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 21);
            this.label3.TabIndex = 10;
            this.label3.Text = "seconds";
            // 
            // label_recommend
            // 
            this.label_recommend.AutoSize = true;
            this.label_recommend.BackColor = System.Drawing.Color.Transparent;
            this.label_recommend.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_recommend.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label_recommend.Location = new System.Drawing.Point(34, 155);
            this.label_recommend.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_recommend.Name = "label_recommend";
            this.label_recommend.Size = new System.Drawing.Size(248, 57);
            this.label_recommend.TabIndex = 11;
            this.label_recommend.Text = "Recommend training each gesture at \r\nleast 3 times, ideally 5 times if possible.\r" +
    "\nVary each gesture for better prediction.";
            // 
            // button_Cancel
            // 
            this.button_Cancel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button_Cancel.FlatAppearance.BorderSize = 0;
            this.button_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Cancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Cancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_Cancel.Location = new System.Drawing.Point(326, 167);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(161, 45);
            this.button_Cancel.TabIndex = 12;
            this.button_Cancel.Text = "C A N C E L";
            this.button_Cancel.UseVisualStyleBackColor = false;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // functionsListBox
            // 
            this.functionsListBox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.functionsListBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.functionsListBox.FormattingEnabled = true;
            this.functionsListBox.Location = new System.Drawing.Point(37, 48);
            this.functionsListBox.Name = "functionsListBox";
            this.functionsListBox.Size = new System.Drawing.Size(141, 21);
            this.functionsListBox.TabIndex = 0;
            this.functionsListBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(48, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Train Function";
            // 
            // TrainingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.BackgroundImage = global::MouseApp.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(525, 244);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.functionsListBox);
            this.Controls.Add(this.label_recommend);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.trainTimeBox);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label_Message);
            this.Controls.Add(this.button_StartTrain);
            this.Controls.Add(this.button_Done);
            this.Controls.Add(this.label_Progress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TrainingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Training";
            this.Load += new System.EventHandler(this.Training_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_Progress;
        private System.Windows.Forms.Button button_Done;
        private System.Windows.Forms.Button button_StartTrain;
        private System.Windows.Forms.Label label_Message;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox trainTimeBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_recommend;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.ComboBox functionsListBox;
        private System.Windows.Forms.Label label1;
    }
}