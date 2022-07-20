
namespace NsIcon
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Reflection;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// TrayIcon gui object class.
    /// </summary>
    public sealed class TrayIcon
    {
        /// <summary>
        /// Container that holds some objects.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// The trayicon itself.
        /// </summary>
        private NotifyIcon icon;

        /// <summary>
        /// The trayicon contextmenu
        /// </summary>
        private ContextMenuStrip menuTrayIcon;

        /// <summary>
        /// Settings menu option
        /// </summary>
        private ToolStripMenuItem menuSettings;

        /// <summary>
        /// Settings menu option
        /// </summary>
        private ToolStripMenuItem menuUpdateNow;

        /// <summary>
        /// Settings menu option
        /// </summary>
        private ToolStripMenuItem menuNightscoutLink;

        /// <summary>
        /// Exit menu option
        /// </summary>
        private ToolStripMenuItem menuExit;

        private const string BLGLUNITMMOL = "mmol/l";
        private const string BLGLUNITMGDL = "mg/dl";

        /// <summary>
        /// Initializes a new instance of the TrayIcon class.
        /// New trayicon in the systray.
        /// </summary>
        public TrayIcon()
        {
            this.components = new System.ComponentModel.Container();
            // Start building icon and icon contextmenu
            this.icon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuTrayIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuTrayIcon.AllowDrop = false;
            this.menuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUpdateNow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem ();
            this.icon.ContextMenuStrip = this.menuTrayIcon;
            Icon trayicon = Icon.FromHandle(NsIcon.Properties.Resources.blgl_need_refresh.GetHicon());
            this.icon.Icon = trayicon;
            this.icon.Visible = true;
            // this.icon.Icon.InitializeLifetimeService();
            this.icon.ContextMenuStrip.Name = "MenuTrayIcon";
            this.icon.ContextMenuStrip.ShowImageMargin = false;
            this.icon.ContextMenuStrip.Size = new System.Drawing.Size(145, 114);
            FontStyle menufontstyle = FontStyle.Regular;
            Font menufont = new Font("Arial", 10, menufontstyle);

            // MenuSettings
            this.menuSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuSettings.Name = "MenuSettings";
            this.menuSettings.Size = new System.Drawing.Size(144, 22);
            this.menuSettings.Text = "&Settings";
            this.menuSettings.Font = menufont;
            this.menuSettings.Click += new System.EventHandler(this.MenuSettings_Click);
            this.icon.ContextMenuStrip.Items.Add(this.menuSettings);

            if (NsIcon.Properties.Settings.Default.showNightscoutTrayLink)
            {
                this.menuNightscoutLink = new System.Windows.Forms.ToolStripMenuItem();
                this.menuNightscoutLink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
                this.menuNightscoutLink.Name = "MenuNightscoutLink";
                this.menuNightscoutLink.Size = new System.Drawing.Size(144, 22);
                this.menuNightscoutLink.Text = "Open Nightscout";
                this.menuNightscoutLink.Font = menufont;
                this.menuNightscoutLink.Click += new System.EventHandler(this.MenuOpenNightscout_Click); ;
                this.icon.ContextMenuStrip.Items.Add(this.menuNightscoutLink);
            }

            // MenuUpdateNow
            this.menuUpdateNow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuUpdateNow.Name = "MenuUpdateNow";
            this.menuUpdateNow.Size = new System.Drawing.Size(144, 22);
            this.menuUpdateNow.Text = "Update now";
            this.menuUpdateNow.Font = menufont;
            this.menuUpdateNow.Click += new System.EventHandler(this.MenuUpdateNow_Click); ;
            this.icon.ContextMenuStrip.Items.Add(this.menuUpdateNow);

            // MenuExit
            this.menuExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuExit.Name = "MenuExit";
            this.menuExit.Size = new System.Drawing.Size(144, 22);
            this.menuExit.Text = "E&xit";
            this.menuExit.Font = menufont;
            this.menuExit.Click += new System.EventHandler(this.MenuExit_Click);
            this.icon.ContextMenuStrip.Items.Add(this.menuExit);

            // Assign events
            Program.glucoseService.OnNewBloodsugarValue += new GlucoseService.BloodglucoseNewValueHandler(this.UpdateTrayiconIcon);
            Program.glucoseService.OnNewBloodsugarValue += new GlucoseService.BloodglucoseNewValueHandler(this.UpdateTrayiconBloodglucoseHint);

            Program.glucoseService.OnStatusChange += new GlucoseService.ServiceStatusChangeHandler(this.setTrayiconStatus);

            Program.glucoseService.OnBloodsugarAlarmChange += new GlucoseService.BloodglucoseAlarmHandler(this.showAlarmBalloon);
        }

        /// <summary>
        /// Try to update glucose values from nightscout server now.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuUpdateNow_Click(object sender, EventArgs e)
        {
            Program.glucoseService.UpdateGlucoseValues(null, null);
        }

        /// <summary>
        /// Open nightscout server address.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuOpenNightscout_Click(object sender, EventArgs e)
        {
            ProcessStartInfo procstartinfo = new ProcessStartInfo(NsIcon.Properties.Settings.Default.serverUrl);
            procstartinfo.ErrorDialog = true;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.AppStarting;
            System.Diagnostics.Process.Start(procstartinfo);
        }

        /// <summary>
        /// Display "need to update glucose values"-icon in trayicon and update hint message.
        /// </summary>
        /// <param name="strErrorMessage"></param>
        public void setTrayiconStatus(bool isError, string message)
        {
            if (isError)
            {
                this.icon.Icon = Icon.FromHandle(NsIcon.Properties.Resources.network_issue.GetHicon());
            }
            else
            {
                this.icon.Icon = Icon.FromHandle(NsIcon.Properties.Resources.blgl_need_refresh.GetHicon());
            }

            this.setTrayiconHint(message);
        }

        /// <summary>
        /// Change the trayicon icon to show if the current bloodglucose status is okay or not.
        /// </summary>
        /// <param name="bloodglucoseValue"></param>
        /// <param name="dt"></param>
        /// <param name="direction"></param>
        public void UpdateTrayiconIcon(decimal bloodglucoseValue, DateTime dt, string direction)
        {
            decimal blglLow = NsIcon.Properties.Settings.Default.alarmBlglLow;
            decimal blglLowerThenNormal = NsIcon.Properties.Settings.Default.alarmBlglLower;
            decimal blglHigherThenNormal = NsIcon.Properties.Settings.Default.alarmBlglHigher;
            decimal blglHigh = NsIcon.Properties.Settings.Default.alarmBlglHigh;

            string text = "";
            switch (direction.ToLower()){
                case "none":
                    text += "⇼";
                    break;
                case "doubleup":
                    text += "⇈";
                    break;
                case "singleup":
                    text += "↑";
                    break;
                case "fortyfiveup":
                    text += "↗";
                    break;
                case "flat":
                    text += "→";
                    break;
                case "fortyfivedown":
                    text += "↘";
                    break;
                case "singledown":
                    text += "↓";
                    break;
                case "doubledown":
                    text += "⇊";
                    break;
                case "not computable":
                    text += "-";
                    break;
                case "rate out of range":
                    text += "⇕";
                    break;
            }

            Color color = Color.Gray;
            Color fontColor = Color.White;
            if (bloodglucoseValue.CompareTo(blglLow) < 0)
            {
                // Hypoglycemia alarm
                color = Color.FromArgb(213, 9, 21);
                fontColor = Color.White;
            }
            else if (bloodglucoseValue.CompareTo(blglHigh) >= 0)
            {
                // Hyperglycemia alarm
                color = Color.FromArgb(213, 9, 21);
                fontColor = Color.White;
            }
            else if (bloodglucoseValue.CompareTo(blglHigherThenNormal) > 0)
            {
                // Becoming Hypoglycemia or becoming Hyperglycemia warning
                color = Color.FromArgb(234, 168, 0);
                fontColor = Color.White;
            }
            else if (bloodglucoseValue.CompareTo(blglLowerThenNormal) < 0)
            {
                // Becoming Hypoglycemia or becoming Hyperglycemia warning
                color = Color.FromArgb(78, 143, 207);
                fontColor = Color.White;
            }
            else
            {
                // Bloodglucose within conigured range, green checkmark.
                color = Color.FromArgb(134, 207, 70);
                fontColor = Color.White;
            }

            FontStyle iconFontStyle = FontStyle.Bold;
            Font iconFont = new Font("Arial", 18, iconFontStyle);

            Brush brush = new SolidBrush(fontColor);

            // Create a bitmap and draw text on it
            const int iconWidth = 32;
            const int iconHeight = 32;

            Bitmap bitmap = new Bitmap(iconWidth, iconHeight);
            Graphics graphics = Graphics.FromImage(bitmap);
            using (SolidBrush solidBrush = new SolidBrush(color))
            {
                graphics.FillRectangle(solidBrush, 0, 0, iconWidth, iconHeight);
            }

            graphics.DrawString(text, iconFont, brush, 0, 0);

            // Convert the bitmap with text to an Icon
            this.icon.Icon = Icon.FromHandle(bitmap.GetHicon());

            // if (bloodglucoseValue.CompareTo(blglLow) < 0)
            // {
            //     // Hypoglycemia alarm, show red flag
            //     this.icon.Icon = Icon.FromHandle(NsIcon.Properties.Resources.flag_red.GetHicon());
            // }
            // else if (bloodglucoseValue.CompareTo(blglHigh) >= 0)
            // {
            //     // Hyperglycemia alarm, show orange flag
            //     this.icon.Icon = Icon.FromHandle(NsIcon.Properties.Resources.flag_orange.GetHicon());
            // }
            // else if (bloodglucoseValue.CompareTo(blglLowerThenNormal) < 0 || 
            //          bloodglucoseValue.CompareTo(blglHigherThenNormal) > 0)
            // {
            //     // Becoming Hypoglycemia or becoming Hyperglycemia warning, yellow flag
            //     this.icon.Icon = Icon.FromHandle(NsIcon.Properties.Resources.flag_yellow.GetHicon());
            // }
            // else
            // {
            //     // Bloodglucose within conigured range, green checkmark.
            //     this.icon.Icon = Icon.FromHandle(NsIcon.Properties.Resources.blgl_okay.GetHicon());
            // }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bloodglucoseValue"></param>
        /// <param name="dt"></param>
        /// <param name="direction"></param>
        public void UpdateTrayiconBloodglucoseHint(decimal bloodglucoseValue, DateTime dt, string direction)
        {
            StringBuilder sbhint = new StringBuilder(this.getStrRoundedBlglWithUnit(bloodglucoseValue));
            sbhint.AppendLine(direction);
            sbhint.Append(dt.ToLongTimeString());
            this.setTrayiconHint(sbhint.ToString());
        }

        /// <summary>
        /// Round bloodglucose value as string with for displaying with bloodglucose unit.
        /// </summary>
        /// <param name="blglValue"></param>
        /// <returns>The blood glucose value rounded.</returns>
        private string getStrRoundedBlglWithUnit(decimal blglValue)
        {
            int numDecimals = NsIcon.Properties.Settings.Default.displayMmolDecimalsRouding;
            StringBuilder sbRoundedBlglWithUnit = new StringBuilder(Math.Round(blglValue, numDecimals, MidpointRounding.AwayFromZero).ToString());
            sbRoundedBlglWithUnit.Append(" ");
            if (NsIcon.Properties.Settings.Default.bloodsugerUnitsIndex == 1)
            {
                sbRoundedBlglWithUnit.AppendLine(BLGLUNITMMOL);
            }
            else
            {
                sbRoundedBlglWithUnit.AppendLine(BLGLUNITMGDL);
            }
            
            return sbRoundedBlglWithUnit.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hint"></param>
        private void setTrayiconHint(string hint)
        {
            if (!String.IsNullOrEmpty(hint))
            {
                if (hint.Length > 63)
                {
                    hint = hint.Substring(0, 63);
                }

                this.icon.Text = hint;
            }
            else
            {
                this.icon.Text = String.Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alarm"></param>
        public void showAlarmBalloon(AlarmBlgl alarm, decimal blglValue, DateTime blglDatetime)
        {
            this.icon.BalloonTipText = this.getStrRoundedBlglWithUnit(blglValue);
            switch (alarm)
            {
                case AlarmBlgl.LOW:
                    if (NsIcon.Properties.Settings.Default.alarmLow)
                    {
                        // Show balloon tip
                        this.icon.BalloonTipTitle = "Blood glucose low.";
                        this.icon.BalloonTipIcon = ToolTipIcon.Warning;
                        this.icon.ShowBalloonTip(8000);
                    }

                    break;
                case AlarmBlgl.HIGH:
                    if (NsIcon.Properties.Settings.Default.alarmHigh)
                    {
                        // Show balloon tip
                        this.icon.BalloonTipTitle = "Blood glucose high.";
                        this.icon.ShowBalloonTip(8000);
                    }

                    break;
                case AlarmBlgl.LOWERTHENNORMAL:
                    if (NsIcon.Properties.Settings.Default.alarmLower)
                    {
                        // Show ballon tip
                        this.icon.BalloonTipTitle = "Blood glucose lower than normal.";
                        this.icon.ShowBalloonTip(5000);
                    }

                    break;
                case AlarmBlgl.HIGHERTHENNORMAL:
                    if (NsIcon.Properties.Settings.Default.alarmHigher)
                    {
                        // Show balloon tip
                        this.icon.BalloonTipTitle = "Blood glucose higher then normal.";
                        this.icon.ShowBalloonTip(5000);
                    }

                    break;
            }

        }

        /// <summary>
        /// Destroy NotifyIcon with ContextMenuStrip and ToolStripMenuItems etc.
        /// </summary>
        public void Dispose()
        {
            this.icon.Visible = false; // Mono needs Visible set to false otherwise it keeps showing the trayicon.
            this.components.Dispose();
        }

        /// <summary>
        /// Open settings window.
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event argument</param>
        private void MenuSettings_Click(object sender, EventArgs e)
        {
            if (Program.frmSettings == null || Program.frmSettings.IsDisposed)
            {
                Program.frmSettings = new FrmSettings();
            }
            else
            {
                Program.frmSettings.BringToFront();
            }

            Program.frmSettings.Show();
        }

        /// <summary>
        /// User request to shutdown application.
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event argument</param>
        private void MenuExit_Click(object sender, EventArgs e)
        {
            if (!NsIcon.Properties.Settings.Default.confirmExit || 
                MessageBox.Show(string.Format("Shutdown {0}?", Assembly.GetExecutingAssembly().GetName().Name),
                                "Exit?", 
                                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.components.Dispose();
                Application.Exit();
            }
        }
    }
}
