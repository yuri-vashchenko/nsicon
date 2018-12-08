
namespace DayscoutIcon
{
    using System;
    using System.Drawing;
    using System.Reflection;
    using System.Windows.Forms;
    using AppIndicator;

    /// <summary>
    /// TrayIcon gui object class.
    /// </summary>
    public sealed class TrayIcon
    {
        private FrmSettings frmSettings;

        //private static int id = 0;

        /// <summary>
        /// Container that holds some objects.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// The trayicon itself.
        /// </summary>

        //private ApplicationIndicator icon;
        private Gtk.StatusIcon gtkStatusIcon;

        private Gtk.Menu gtkMenu;

        //private NotifyIcon icon;

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
        /// Exit menu option
        /// </summary>
        private ToolStripMenuItem menuExit;

        private const string BLGLUNITMMOL = "mmol/l";
        private const string BLGLUNITMGDL = "mg/dl";

        /// <summary>
        /// Initializes a new instance of the TrayIcon class.
        /// New trayicon in the systray.
        /// </summary>
        public TrayIcon ()
        {
            this.components = new System.ComponentModel.Container();
            string executableFolder = AppDomain.CurrentDomain.BaseDirectory;
            // Start building icon and icon contextmenu
            this.gtkStatusIcon = new Gtk.StatusIcon("//media//veracrypt1//Public//sourcecode//Projects_Csharp//DayscoutIcon//DayscoutIcon//bin//Debug//dayscout16x16_8bits.png");
            /*
             * Missing method:
            ApplicationIndicator appicon = new ApplicationIndicator("idDayscoutIcon",
                        "dayscout16x16_8bits",
                        Category.Communications,
                        @"/media/veracrypt1/Public/sourcecode/Projects_Csharp/DayscoutIcon/DayscoutIcon/bin/Debug/"
                    );

            this.icon.Status = AppIndicator.Status.Active;
            */
            this.gtkStatusIcon.Name = "DayscoutIcon.";
            this.gtkStatusIcon.Title = "DayscoutIcon title.";
            this.gtkStatusIcon.TooltipText = "tooltip test.";

            gtkMenu = new Gtk.Menu();
            Gtk.ImageMenuItem gtkMenuItemExit = new Gtk.ImageMenuItem("Exit");
            gtkMenu.Add(gtkMenuItemExit);
            Gtk.ImageMenuItem gtkMenuItemUpdatenow = new Gtk.ImageMenuItem("Update now");
            gtkMenu.Add(gtkMenuItemUpdatenow);
            Gtk.ImageMenuItem gtkMenuItemSettings = new Gtk.ImageMenuItem("Settings");
            gtkMenu.Add(gtkMenuItemSettings);
            this.gtkStatusIcon.Visible = true;

            //this.gtkStatusIcon.Icon = GLib.IIcon();// "//media//veracrypt1//Public//sourcecode//Projects_Csharp//DayscoutIcon//DayscoutIcon//bin//Debug//dayscout16x16_8bits.png");
            //this.gtkStatusIcon.Menu = appIndicatorMenu;

            //this.icon = new System.Windows.Forms.NotifyIcon(this.components);
            //this.menuTrayIcon.AllowDrop = false;
            /*
            this.menuTrayIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUpdateNow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();

            this.icon.ContextMenuStrip = this.menuTrayIcon;
            Icon trayicon = Icon.FromHandle(DayscoutIcon.Properties.Resources.blgl_need_refresh.GetHicon());
            this.icon.Icon = trayicon;
            this.icon.Visible = true;
            this.icon.Icon.InitializeLifetimeService();
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
            */
        }

        /*
        private void ConvertAndAddMenuItem(System.Windows.Forms.ToolStripItem item,
                               Gtk.MenuShell gtkMenuShell)
        {
            if (item is System.Windows.Forms.ToolStripMenuItem)
            {

                var winformMenuItem = item as System.Windows.Forms.ToolStripMenuItem;

                // windows forms use '&' for mneumonic, gtk uses '_'
                var gtkMenuItem = new Gtk.ImageMenuItem(winformMenuItem.Text.Replace("&", "_"));

                if (winformMenuItem.Image != null)
                {
                    MemoryStream memStream;
                    var image = winformMenuItem.Image;
                    if (image.Width != 16 || image.Height != 16)
                    {
                        var newImage = ResizeImage(image, 16, 16);
                        memStream = new MemoryStream(newImage);
                    }
                    else
                    {
                        memStream = new MemoryStream();
                        image.Save(memStream, ImageFormat.Png);
                        memStream.Position = 0;
                    }
                    gtkMenuItem.Image = new Gtk.Image(memStream);
                }

                gtkMenuItem.TooltipText = winformMenuItem.ToolTipText;
                gtkMenuItem.Visible = winformMenuItem.Visible;
                gtkMenuItem.Sensitive = winformMenuItem.Enabled;

                gtkMenuItem.Activated += (sender, e) =>
                  DBusBackgroundWorker.InvokeWinformsThread((Action)winformMenuItem.PerformClick);

                winformMenuItem.TextChanged +=
                  (sender, e) => DBusBackgroundWorker.InvokeGtkThread(() =>
                  {
                      var label = gtkMenuItem.Child as Gtk.Label;
                      if (label != null)
                      {
                          label.Text = winformMenuItem.Text;
                      }
                  }
                );
                winformMenuItem.EnabledChanged += (sender, e) =>
                  DBusBackgroundWorker.InvokeGtkThread
                    (() => gtkMenuItem.Sensitive = winformMenuItem.Enabled);
                winformMenuItem.VisibleChanged += (sender, e) =>
                  DBusBackgroundWorker.InvokeGtkThread
                    (() => gtkMenuItem.Visible = winformMenuItem.Visible);

                gtkMenuItem.Show();
                gtkMenuShell.Insert(gtkMenuItem,
                                    winformMenuItem.Owner.Items.IndexOf(winformMenuItem));

                if (winformMenuItem.HasDropDownItems)
                {
                    var subMenu = new Gtk.Menu();
                    foreach (System.Windows.Forms.ToolStripItem dropDownItem in
                            winformMenuItem.DropDownItems)
                    {
                        ConvertAndAddMenuItem(dropDownItem, subMenu);
                    }
                    gtkMenuItem.Submenu = subMenu;

                    winformMenuItem.DropDown.ItemAdded += (sender, e) =>
                      DBusBackgroundWorker.InvokeGtkThread
                        (() => ConvertAndAddMenuItem(e.Item, subMenu));
                }
            }
            else if (item is System.Windows.Forms.ToolStripSeparator)
            {
                var gtkSeparator = new Gtk.SeparatorMenuItem();
                gtkSeparator.Show();
                gtkMenuShell.Insert(gtkSeparator, item.Owner.Items.IndexOf(item));
            }
            else
            {
                Debug.Fail("Unexpected menu item");
            }
        }
        */

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
        /// Display "need to update glucose values"-icon in trayicon and update hint message.
        /// </summary>
        /// <param name="strErrorMessage"></param>
        public void setTrayiconBloodGlucoseNeedupdate(string errorMessage)
        {
            //this.icon.Icon = Icon.FromHandle(DayscoutIcon.Properties.Resources.blgl_need_refresh.GetHicon());
            this.setTrayiconHintMessage(errorMessage);
        }

        /// <summary>
        /// Display network issue trayicon and update hint message.
        /// </summary>
        /// <param name="errorMessageNetwork"></param>
        public void setTrayiconNetworkIssue(string errorMessageNetwork)
        {
            //this.icon.Icon = Icon.FromHandle(DayscoutIcon.Properties.Resources.network_issue.GetHicon());
            this.setTrayiconHintMessage(errorMessageNetwork);
        }

        /// <summary>
        /// Update hint message on trayicon.
        /// </summary>
        /// <param name="hintMessage"></param>
        private void setTrayiconHintMessage(string hintMessage)
        {
            if (!String.IsNullOrEmpty(hintMessage))
            {
                if (hintMessage.Length > 63)
                {
                    hintMessage = hintMessage.Substring(0, 63);
                }

                //this.icon.Text = hintMessage;
                this.gtkStatusIcon.Title = hintMessage;
            }
            else
            {
                //this.icon.Text = String.Empty;
                this.gtkStatusIcon.Title = String.Empty;
            }
        }

        /// <summary>
        /// Update to okay icon and update trayicon hint message.
        /// </summary>
        /// <param name="strBlGl"></param>
        public void setTrayiconBloodGlucoseOkay(string strBlGl)
        {
            //this.icon.Icon = Icon.FromHandle(DayscoutIcon.Properties.Resources.blgl_okay.GetHicon());
            this.setTrayiconHintMessage(strBlGl);
        }

        /// <summary>
        /// Update icon and show ballon alert if alarmLow enabled and update trayicon hint message.
        /// </summary>
        /// <param name="strBlGl"></param>
        public void setTrayiconBloodGlucoseLow(string strBlGl)
        {
            //this.icon.Icon = Icon.FromHandle(DayscoutIcon.Properties.Resources.flag_red.GetHicon());
            // Show ballon tip alert
            if (DayscoutIcon.Properties.Settings.Default.alarmLow)
            {
                //this.icon.BalloonTipTitle = "Blood glucose low.";
                //this.icon.BalloonTipIcon = ToolTipIcon.Warning;
                //this.icon.BalloonTipText = strBlGl;
                //this.icon.ShowBalloonTip(10000);
            }

            this.setTrayiconHintMessage(strBlGl);
        }

        /// <summary>
        /// Update icon and show ballon alert if alarmLower enabled and update trayicon hint message.
        /// </summary>
        /// <param name="strBlGl"></param>
        public void setTrayiconBloodGlucoseLowerThenNormal(string strBlGl)
        {
            //this.icon.Icon = Icon.FromHandle(DayscoutIcon.Properties.Resources.flag_yellow.GetHicon());
            if (DayscoutIcon.Properties.Settings.Default.alarmLower)
            {
                // Show ballon tip
                //this.icon.BalloonTipTitle = "Blood glucose lower than normal.";
                //this.icon.BalloonTipText = strBlGl;
                //this.icon.ShowBalloonTip(5000);
            }

            this.setTrayiconHintMessage(strBlGl);
        }

        /// <summary>
        /// Update icon and show ballon alert if alarmHigher enabled and update trayicon hint message.
        /// </summary>
        /// <param name="strBlGl"></param>
        public void setTrayiconBloodGlucoseHigherThenNormal(string strBlGl)
        {
            //this.icon.Icon.Dispose();
            //this.icon.Icon = Icon.FromHandle(DayscoutIcon.Properties.Resources.flag_yellow.GetHicon());
            if (DayscoutIcon.Properties.Settings.Default.alarmHigher)
            {
                // Show ballon tip
                //this.icon.BalloonTipTitle = "Blood glucose higher then normal.";
                //this.icon.BalloonTipText = strBlGl;
                //this.icon.ShowBalloonTip(5000);
            }

            this.setTrayiconHintMessage(strBlGl);
        }

        /// <summary>
        /// Update icon and show ballon alert if alarmHigh enabled and update trayicon hint message.
        /// </summary>
        /// <param name="strBlGl"></param>
        public void setTrayiconBloodGlucoseHigh(string strBlGl)
        {
            //this.icon.Icon = Icon.FromHandle(DayscoutIcon.Properties.Resources.flag_orange.GetHicon());
            if (DayscoutIcon.Properties.Settings.Default.alarmHigh)
            {
                // Show ballon tip alert
                //this.icon.BalloonTipTitle = "Blood glucose high.";
                //this.icon.BalloonTipIcon = ToolTipIcon.Warning;
                //this.icon.BalloonTipText = strBlGl;
                //this.icon.ShowBalloonTip(10000);
            }

            this.setTrayiconHintMessage(strBlGl);
        }

        /// <summary>
        /// Destroy NotifyIcon with ContextMenuStrip and ToolStripMenuItems etc.
        /// </summary>
        public void Dispose()
        {
            //this.icon.Visible = false; // Mono needs Visible set to false otherwise it keeps showing the trayicon.
            this.components.Dispose();
        }

        /// <summary>
        /// Open settings window.
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event argument</param>
        private void MenuSettings_Click(object sender, EventArgs e)
        {
            this.frmSettings = new FrmSettings();
            this.frmSettings.Show();
        }

        /// <summary>
        /// User request to shutdown application.
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event argument</param>
        private void MenuExit_Click(object sender, EventArgs e)
        {
            if (!DayscoutIcon.Properties.Settings.Default.confirmExit || 
                MessageBox.Show(string.Format("Shutdown {0}?", Assembly.GetExecutingAssembly().GetName().Name), "Exit?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.components.Dispose();
                Application.Exit();
            }
        }
    }
}
