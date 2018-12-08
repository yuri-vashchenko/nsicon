namespace DayscoutIcon
{
    partial class FrmBloodglucose
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBloodglucose));
            this.lblCurrentBloodglucose = new System.Windows.Forms.Label();
            this.lblBloodglucoseDirection = new System.Windows.Forms.Label();
            this.lblBloodglucoseDatetime = new System.Windows.Forms.Label();
            this.btnAlwaysOnTop = new System.Windows.Forms.Button();
            this.btnUpdateNow = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCurrentBloodglucose
            // 
            this.lblCurrentBloodglucose.AutoSize = true;
            this.lblCurrentBloodglucose.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentBloodglucose.Location = new System.Drawing.Point(3, 9);
            this.lblCurrentBloodglucose.Name = "lblCurrentBloodglucose";
            this.lblCurrentBloodglucose.Size = new System.Drawing.Size(193, 37);
            this.lblCurrentBloodglucose.TabIndex = 0;
            this.lblCurrentBloodglucose.Text = "No value yet";
            // 
            // lblBloodglucoseDirection
            // 
            this.lblBloodglucoseDirection.AutoSize = true;
            this.lblBloodglucoseDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBloodglucoseDirection.Location = new System.Drawing.Point(9, 89);
            this.lblBloodglucoseDirection.Name = "lblBloodglucoseDirection";
            this.lblBloodglucoseDirection.Size = new System.Drawing.Size(0, 33);
            this.lblBloodglucoseDirection.TabIndex = 1;
            // 
            // lblBloodglucoseDatetime
            // 
            this.lblBloodglucoseDatetime.AutoSize = true;
            this.lblBloodglucoseDatetime.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBloodglucoseDatetime.Location = new System.Drawing.Point(9, 46);
            this.lblBloodglucoseDatetime.Name = "lblBloodglucoseDatetime";
            this.lblBloodglucoseDatetime.Size = new System.Drawing.Size(0, 29);
            this.lblBloodglucoseDatetime.TabIndex = 2;
            // 
            // btnAlwaysOnTop
            // 
            this.btnAlwaysOnTop.Location = new System.Drawing.Point(248, 9);
            this.btnAlwaysOnTop.Name = "btnAlwaysOnTop";
            this.btnAlwaysOnTop.Size = new System.Drawing.Size(40, 23);
            this.btnAlwaysOnTop.TabIndex = 3;
            this.btnAlwaysOnTop.Text = "off";
            this.btnAlwaysOnTop.UseVisualStyleBackColor = true;
            this.btnAlwaysOnTop.Click += new System.EventHandler(this.btnAlwaysOnTop_Click);
            // 
            // btnUpdateNow
            // 
            this.btnUpdateNow.Location = new System.Drawing.Point(202, 9);
            this.btnUpdateNow.Name = "btnUpdateNow";
            this.btnUpdateNow.Size = new System.Drawing.Size(40, 23);
            this.btnUpdateNow.TabIndex = 4;
            this.btnUpdateNow.Text = "now";
            this.btnUpdateNow.UseVisualStyleBackColor = true;
            this.btnUpdateNow.Click += new System.EventHandler(this.btnUpdateNow_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(15, 120);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(66, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "shutdown";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(87, 120);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(66, 23);
            this.btnSettings.TabIndex = 6;
            this.btnSettings.Text = "settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // FrmBloodglucose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 155);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnUpdateNow);
            this.Controls.Add(this.btnAlwaysOnTop);
            this.Controls.Add(this.lblBloodglucoseDatetime);
            this.Controls.Add(this.lblBloodglucoseDirection);
            this.Controls.Add(this.lblCurrentBloodglucose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmBloodglucose";
            this.Text = "Current bloodglucose";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCurrentBloodglucose;
        private System.Windows.Forms.Label lblBloodglucoseDirection;
        private System.Windows.Forms.Label lblBloodglucoseDatetime;
        private System.Windows.Forms.Button btnAlwaysOnTop;
        private System.Windows.Forms.Button btnUpdateNow;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSettings;
    }
}