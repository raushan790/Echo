namespace ServerExeForAutomatedJobs
{
    partial class Form1
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.ValidateOfflineAttendanceTimer = new System.Windows.Forms.Timer(this.components);
            this.lblGenerateCode = new System.Windows.Forms.Label();
            this.lblNotification = new System.Windows.Forms.Label();
            this.lblAttendanceVerification = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 900000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 5000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // ValidateOfflineAttendanceTimer
            // 
            this.ValidateOfflineAttendanceTimer.Interval = 600000;
            this.ValidateOfflineAttendanceTimer.Tick += new System.EventHandler(this.ValidateOfflineAttendance_Tick);
            // 
            // lblGenerateCode
            // 
            this.lblGenerateCode.AutoSize = true;
            this.lblGenerateCode.Location = new System.Drawing.Point(125, 97);
            this.lblGenerateCode.Name = "lblGenerateCode";
            this.lblGenerateCode.Size = new System.Drawing.Size(35, 13);
            this.lblGenerateCode.TabIndex = 0;
            this.lblGenerateCode.Text = "label1";
            // 
            // lblNotification
            // 
            this.lblNotification.AutoSize = true;
            this.lblNotification.Location = new System.Drawing.Point(125, 124);
            this.lblNotification.Name = "lblNotification";
            this.lblNotification.Size = new System.Drawing.Size(35, 13);
            this.lblNotification.TabIndex = 1;
            this.lblNotification.Text = "label1";
            // 
            // lblAttendanceVerification
            // 
            this.lblAttendanceVerification.AutoSize = true;
            this.lblAttendanceVerification.Location = new System.Drawing.Point(125, 151);
            this.lblAttendanceVerification.Name = "lblAttendanceVerification";
            this.lblAttendanceVerification.Size = new System.Drawing.Size(35, 13);
            this.lblAttendanceVerification.TabIndex = 2;
            this.lblAttendanceVerification.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblAttendanceVerification);
            this.Controls.Add(this.lblNotification);
            this.Controls.Add(this.lblGenerateCode);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer ValidateOfflineAttendanceTimer;
        private System.Windows.Forms.Label lblGenerateCode;
        private System.Windows.Forms.Label lblNotification;
        private System.Windows.Forms.Label lblAttendanceVerification;
    }
}

