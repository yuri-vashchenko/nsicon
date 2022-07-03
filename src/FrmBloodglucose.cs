
namespace NsIcon
{
    using System;
    using System.Drawing;
    using System.Reflection;
    using System.Text;
    using System.Windows.Forms;

    public partial class FrmBloodglucose : Form
    {
        private const string BLGLUNITMMOL = "mmol/l";
        private const string BLGLUNITMGDL = "mg/dl";

        /// <summary>
        /// Creating a new instance of FrmBloodsugar class.
        /// </summary>
        public FrmBloodglucose()
        {
            InitializeComponent();
            // Assign events:
            Program.glucoseService.OnNewBloodsugarValue += new GlucoseService.BloodglucoseNewValueHandler(this.DisplayBloodglucoseDetails);
            Program.glucoseService.OnBloodsugarAlarmChange += new GlucoseService.BloodglucoseAlarmHandler(this.ChangeBackgroundOnAlarm);
            Program.glucoseService.OnStatusChange += new GlucoseService.ServiceStatusChangeHandler(this.ChangeBackgroundOnStatus);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bloodglucoseValue"></param>
        /// <param name="dt"></param>
        /// <param name="direction"></param>
        private void DisplayBloodglucoseDetails(decimal bloodglucoseValue, DateTime dt, string direction)
        {
            this.lblCurrentBloodglucose.Text = getStrRoundedBlglWithUnit(bloodglucoseValue);
            this.lblBloodglucoseDatetime.Text = dt.ToShortDateString() + " " + dt.ToLongTimeString();
            this.lblBloodglucoseDirection.Text = direction;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alarm"></param>
        /// <param name="blglvalue"></param>
        /// <param name="blglDatetime"></param>
        private void ChangeBackgroundOnAlarm(AlarmBlgl alarm, decimal blglvalue, DateTime blglDatetime)
        {
            switch (alarm)
            {
                case AlarmBlgl.LOW:
                    this.BackColor = Color.Red;
                    break;
                case AlarmBlgl.HIGH:
                    this.BackColor = Color.Yellow;
                    break;
                case AlarmBlgl.LOWERTHENNORMAL:
                case AlarmBlgl.HIGHERTHENNORMAL:
                    this.BackColor = Color.LightYellow;
                    break;
                case AlarmBlgl.NO:
                    this.BackColor = Color.LightGreen;
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isError"></param>
        /// <param name="message"></param>
        private void ChangeBackgroundOnStatus(bool isError, string message)
        {
            if (isError)
            {
                this.BackColor = Color.Gray;
                this.lblCurrentBloodglucose.Text = "Error";
            } else
            {
                this.lblCurrentBloodglucose.Text = string.Empty;
            }
            
            this.lblBloodglucoseDatetime.Text = message;
            this.lblBloodglucoseDirection.Text = string.Empty;
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
        /// Toggle showing this form as always on top or not.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAlwaysOnTop_Click(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
            if (this.TopMost)
            {
                this.btnAlwaysOnTop.Text = "on";
            } else
            {
                this.btnAlwaysOnTop.Text = "off";
            }
        }

        /// <summary>
        /// Update blood glucose now.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateNow_Click(object sender, EventArgs e)
        {
            Program.glucoseService.UpdateGlucoseValues(null, null);
        }

        /// <summary>
        /// Shutdown program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (!NsIcon.Properties.Settings.Default.confirmExit ||
                MessageBox.Show(string.Format("Shutdown {0}?", Assembly.GetExecutingAssembly().GetName().Name),
                                "Exit?",
                                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Open settings window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSettings_Click(object sender, EventArgs e)
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
    }
}
