namespace NsIcon
{
    partial class FrmDisclaimer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDisclaimer));
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblTextTerms = new System.Windows.Forms.Label();
            this.chxAgreeTerms = new System.Windows.Forms.CheckBox();
            this.lblImportantKnownIssues = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnContinue
            // 
            this.btnContinue.Enabled = false;
            this.btnContinue.Location = new System.Drawing.Point(191, 222);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(178, 33);
            this.btnContinue.TabIndex = 0;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(15, 222);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(170, 33);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Disagree, shutdown";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblTextTerms
            // 
            this.lblTextTerms.AutoSize = true;
            this.lblTextTerms.Location = new System.Drawing.Point(12, 9);
            this.lblTextTerms.Name = "lblTextTerms";
            this.lblTextTerms.Size = new System.Drawing.Size(348, 130);
            this.lblTextTerms.TabIndex = 2;
            this.lblTextTerms.Text = resources.GetString("lblTextTerms.Text");
            // 
            // chxAgreeTerms
            // 
            this.chxAgreeTerms.AutoSize = true;
            this.chxAgreeTerms.Location = new System.Drawing.Point(15, 142);
            this.chxAgreeTerms.Name = "chxAgreeTerms";
            this.chxAgreeTerms.Size = new System.Drawing.Size(136, 17);
            this.chxAgreeTerms.TabIndex = 3;
            this.chxAgreeTerms.Text = "I understood and agree";
            this.chxAgreeTerms.UseVisualStyleBackColor = true;
            this.chxAgreeTerms.CheckedChanged += new System.EventHandler(this.chxAgreeTerms_CheckedChanged);
            // 
            // lblImportantKnownIssues
            // 
            this.lblImportantKnownIssues.AutoSize = true;
            this.lblImportantKnownIssues.Location = new System.Drawing.Point(12, 167);
            this.lblImportantKnownIssues.Name = "lblImportantKnownIssues";
            this.lblImportantKnownIssues.Size = new System.Drawing.Size(277, 52);
            this.lblImportantKnownIssues.TabIndex = 4;
            this.lblImportantKnownIssues.Text = "Warning the following \'known issues\' apply for sure:\r\nBloodglucose values are del" +
    "ayed due to use of polling.\r\nDate and time and bloodglucose values can be incorr" +
    "ect \r\ndue to incorrect system clock.\r\n";
            // 
            // FrmDisclaimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 267);
            this.Controls.Add(this.lblImportantKnownIssues);
            this.Controls.Add(this.chxAgreeTerms);
            this.Controls.Add(this.lblTextTerms);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnContinue);
            this.Name = "FrmDisclaimer";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "License";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblTextTerms;
        private System.Windows.Forms.CheckBox chxAgreeTerms;
        private System.Windows.Forms.Label lblImportantKnownIssues;
    }
}