using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NsIcon
{
    public partial class FrmSettings : Form
    {
        private const string BLGLUNITMMOL = "mmol/l";
        private const string BLGLUNITMGDL = "mg/dl";
        private bool changeunits = false;

        /// <summary>
        /// Creating a new instance of FrmSettings class.
        /// </summary>
        public FrmSettings()
        {
            InitializeComponent();
            this.numUpDownGlucoseUpdateInterval.Value = Convert.ToDecimal(Program.glucoseService.getInterval());
            this.tbServerUrl.Text = NsIcon.Properties.Settings.Default.serverUrl;
            this.tbApiSecretSha1.Text = NsIcon.Properties.Settings.Default.apiSecretSha1;
            this.numUpDownNetworkTimeout.Value = NsIcon.Properties.Settings.Default.networkTimeout;
            this.numUpDownNumberDisplayRounding.Value = NsIcon.Properties.Settings.Default.displayMmolDecimalsRouding;
            this.numUpDownSecondsBloodsugarValid.Value = Convert.ToDecimal(NsIcon.Properties.Settings.Default.secondsGlucoseValueValid);
            this.cbBloodsugarUnits.Items.Clear();
            this.cbBloodsugarUnits.Items.Add(BLGLUNITMGDL);  // 0
            this.cbBloodsugarUnits.Items.Add(BLGLUNITMMOL);  // 1
            this.cbBloodsugarUnits.SelectedIndex = NsIcon.Properties.Settings.Default.bloodsugerUnitsIndex;
            this.chxLinkNightscout.Checked = NsIcon.Properties.Settings.Default.showNightscoutTrayLink;

            this.chxAlarmLow.Checked = NsIcon.Properties.Settings.Default.alarmLow;
            this.chxAlarmHigh.Checked = NsIcon.Properties.Settings.Default.alarmHigh;
            this.chxAlarmLowerThenNormal.Checked = NsIcon.Properties.Settings.Default.alarmLower;
            this.chxAlarmHigherThenNormal.Checked = NsIcon.Properties.Settings.Default.alarmHigher;

            this.numUpDownAlarmLow.Value = NsIcon.Properties.Settings.Default.alarmBlglLow;
            this.numUpDownAlarmHigh.Value = NsIcon.Properties.Settings.Default.alarmBlglHigh;
            this.numUpDownAlarmLowerThenNormal.Value = NsIcon.Properties.Settings.Default.alarmBlglLower;
            this.numUpDownAlarmHigherThenNormal.Value = NsIcon.Properties.Settings.Default.alarmBlglHigher;

            // Added all timezones
            ReadOnlyCollection<TimeZoneInfo> timezones = TimeZoneInfo.GetSystemTimeZones();
            for (int i = 0; i < timezones.Count; ++i) {
                
                cbxTimezones.Items.Add(timezones[i].DisplayName);
                if (timezones[i].Id == NsIcon.Properties.Settings.Default.timezone)
                {
                    this.cbxTimezones.SelectedIndex = i;
                }
            }
        }

        /// <summary>
        /// Close without saving settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Save settings and close window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            double updateInterval = Convert.ToDouble(this.numUpDownGlucoseUpdateInterval.Value);
            NsIcon.Properties.Settings.Default.updateInterval = updateInterval;
            Program.glucoseService.setInterval(updateInterval);
            NsIcon.Properties.Settings.Default.serverUrl = this.tbServerUrl.Text;
            NsIcon.Properties.Settings.Default.apiSecretSha1 = this.tbApiSecretSha1.Text;
            NsIcon.Properties.Settings.Default.networkTimeout = Convert.ToInt32(this.numUpDownNetworkTimeout.Value);
            NsIcon.Properties.Settings.Default.displayMmolDecimalsRouding = Convert.ToInt32(this.numUpDownNumberDisplayRounding.Value);
            NsIcon.Properties.Settings.Default.bloodsugerUnitsIndex = this.cbBloodsugarUnits.SelectedIndex;
            NsIcon.Properties.Settings.Default.secondsGlucoseValueValid = Convert.ToInt32(this.numUpDownSecondsBloodsugarValid.Value);
            NsIcon.Properties.Settings.Default.showNightscoutTrayLink = this.chxLinkNightscout.Checked;

            NsIcon.Properties.Settings.Default.alarmLow = this.chxAlarmLow.Checked;
            NsIcon.Properties.Settings.Default.alarmHigh = this.chxAlarmHigh.Checked;
            NsIcon.Properties.Settings.Default.alarmLower = this.chxAlarmLowerThenNormal.Checked;
            NsIcon.Properties.Settings.Default.alarmHigher = this.chxAlarmHigherThenNormal.Checked;

            NsIcon.Properties.Settings.Default.alarmBlglLow = this.numUpDownAlarmLow.Value;
            NsIcon.Properties.Settings.Default.alarmBlglHigh = this.numUpDownAlarmHigh.Value;
            NsIcon.Properties.Settings.Default.alarmBlglLower = this.numUpDownAlarmLowerThenNormal.Value;
            NsIcon.Properties.Settings.Default.alarmBlglHigher = this.numUpDownAlarmHigherThenNormal.Value;

            if (this.cbxTimezones.SelectedIndex > 0) {
                ReadOnlyCollection<TimeZoneInfo> timezones = TimeZoneInfo.GetSystemTimeZones();
                String timezoneId = timezones[this.cbxTimezones.SelectedIndex].Id;
                if (!String.IsNullOrEmpty(timezoneId))
                {
                    NsIcon.Properties.Settings.Default.timezone = timezoneId;
                }
            }

            NsIcon.Properties.Settings.Default.Save();
            this.Close();
        }

        private void numUpDownGlucoseUpdateInterval_ValueChanged(object sender, EventArgs e)
        {
            this.numUpDownNetworkTimeout.Maximum = this.numUpDownGlucoseUpdateInterval.Value;
        }

        /// <summary>
        /// Toggle low bloodsugar alarm. Show popup if not showed and bold text if alarm turned off.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chxAlarmLow_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.chxAlarmLow.Checked)
            {
                if (!NsIcon.Properties.Settings.Default.noHypoAlarmWarningShowed)
                {
                    DialogResult res = MessageBox.Show("Are you sure you want to disable low bloodsugar alerts? (not recommended)",
                                                        "Danger: no low bloodsugar alarm?",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Warning);
                    if (res == DialogResult.No)
                    {
                        this.chxAlarmLow.Checked = true;
                    }

                    NsIcon.Properties.Settings.Default.noHypoAlarmWarningShowed = true;
                } else
                {
                    this.chxAlarmLow.ForeColor = Color.Red;
                    Font currentfont = this.chxAlarmLow.Font;
                    this.chxAlarmLow.Font = new Font(currentfont, FontStyle.Bold);
                }
            }
            else
            {
                this.chxAlarmLow.ForeColor = SystemColors.ControlText;
                Font currentfont = this.chxAlarmLow.Font;
                this.chxAlarmLow.Font = new Font(currentfont, FontStyle.Regular);
            }

            this.numUpDownAlarmLow.Enabled = this.chxAlarmLow.Checked;
        }

        /// <summary>
        /// Toggle high bloodsugar alarm. Show bold text if alarm turned off.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chxAlarmHigh_CheckedChanged(object sender, EventArgs e)
        {
            this.numUpDownAlarmHigh.Enabled = chxAlarmHigh.Checked;
            Font currentfont = this.chxAlarmHigh.Font;
            if (!this.chxAlarmHigh.Checked)
            {
                this.chxAlarmHigh.ForeColor = Color.Red;
                this.chxAlarmHigh.Font = new Font(currentfont, FontStyle.Bold);
            }
            else
            {
                this.chxAlarmHigh.ForeColor = SystemColors.ControlText;
                this.chxAlarmHigh.Font = new Font(currentfont, FontStyle.Regular);
            }
        }

        /// <summary>
        /// Toggle "higher then normal" bloodsugar alarm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chxAlarmHigherThenNormal_CheckedChanged(object sender, EventArgs e)
        {
            this.numUpDownAlarmHigherThenNormal.Enabled = chxAlarmHigherThenNormal.Checked;
        }

        /// <summary>
        /// Toggle "lower then normal" bloodsugar alarm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chxAlarmLowerThenNormal_CheckedChanged(object sender, EventArgs e)
        {
            this.numUpDownAlarmLowerThenNormal.Enabled = chxAlarmLowerThenNormal.Checked;
        }

        /// <summary>
        /// Set text property of lblTextAlarmUnitsLow, lblTextAlarmUnitsHigh, lblTextAlarmUnitsHigher and lblTextAlarmUnitsLower.
        /// </summary>
        /// <param name="blglUnits"></param>
        private void setTextAlarmBlglUnits(string blglUnits)
        {
            this.lblTextAlarmUnitsLow.Text = blglUnits;
            this.lblTextAlarmUnitsHigh.Text = blglUnits;
            this.lblTextAlarmUnitsHigher.Text = blglUnits;
            this.lblTextAlarmUnitsLower.Text = blglUnits;
        }

        /// <summary>
        /// Selected a blood sugar value unit.
        /// Convert alarm to proper values.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbBloodsugarUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.changeunits = true;
            // Change units.
            if (cbBloodsugarUnits.SelectedIndex == 0 && this.lblTextAlarmUnitsHigh.Text == BLGLUNITMMOL)
            {
                // Convert values alarm from mmol/l to mg/dl:
                Decimal mmolMgdlConversionRate = new Decimal(18.01801801801802);
                this.numUpDownAlarmLow.Maximum = 150;
                this.numUpDownAlarmLow.Value = Decimal.Multiply(this.numUpDownAlarmLow.Value, mmolMgdlConversionRate);
                this.numUpDownAlarmLow.Minimum = 30;

                this.numUpDownAlarmHigh.Maximum = 500;
                this.numUpDownAlarmHigh.Value = Decimal.Multiply(this.numUpDownAlarmHigh.Value, mmolMgdlConversionRate);
                this.numUpDownAlarmHigh.Minimum = 110;

                this.numUpDownAlarmLowerThenNormal.Maximum = 200;
                this.numUpDownAlarmLowerThenNormal.Value = Decimal.Multiply(this.numUpDownAlarmLowerThenNormal.Value, mmolMgdlConversionRate);
                this.numUpDownAlarmLowerThenNormal.Minimum = 35;

                this.numUpDownAlarmHigherThenNormal.Maximum = 400;
                this.numUpDownAlarmHigherThenNormal.Value = Decimal.Multiply(this.numUpDownAlarmHigherThenNormal.Value, mmolMgdlConversionRate);
                this.numUpDownAlarmHigherThenNormal.Minimum = 100;

                this.setTextAlarmBlglUnits(BLGLUNITMGDL);
            }
            else if (cbBloodsugarUnits.SelectedIndex == 1 && this.lblTextAlarmUnitsHigh.Text == BLGLUNITMGDL)
            {
                // Convert values alarm from mg/dl to mmol/l:
                Decimal mgdlMmolConversionRate = new Decimal(0.0555);
                this.numUpDownAlarmLow.Minimum = 2;
                this.numUpDownAlarmLow.Value = Decimal.Multiply(this.numUpDownAlarmLow.Value, mgdlMmolConversionRate);
                this.numUpDownAlarmLow.Maximum = 5;

                this.numUpDownAlarmHigh.Minimum = 8;
                this.numUpDownAlarmHigh.Value = Decimal.Multiply(this.numUpDownAlarmHigh.Value, mgdlMmolConversionRate);
                this.numUpDownAlarmHigh.Maximum = 25;

                this.numUpDownAlarmLowerThenNormal.Minimum = 3;
                this.numUpDownAlarmLowerThenNormal.Value = Decimal.Multiply(this.numUpDownAlarmLowerThenNormal.Value, mgdlMmolConversionRate);
                this.numUpDownAlarmLowerThenNormal.Maximum = 5;

                this.numUpDownAlarmHigherThenNormal.Minimum = 6;
                this.numUpDownAlarmHigherThenNormal.Value = Decimal.Multiply(this.numUpDownAlarmHigherThenNormal.Value, mgdlMmolConversionRate);
                this.numUpDownAlarmHigherThenNormal.Maximum = 20;

                this.setTextAlarmBlglUnits(BLGLUNITMMOL);
            }

            this.changeunits = false;
        }

        private void numUpDownAlarmLowerThenNormal_ValueChanged(object sender, EventArgs e)
        {
            if (this.numUpDownAlarmLowerThenNormal.Value.CompareTo(this.numUpDownAlarmLow.Value) < 0 && !this.changeunits)
            {
                this.numUpDownAlarmLowerThenNormal.Value = this.numUpDownAlarmLow.Value;
            }
            else if (this.numUpDownAlarmLowerThenNormal.Value.CompareTo(this.numUpDownAlarmLow.Value) == 0)
            {
                this.numUpDownAlarmLowerThenNormal.ForeColor = Color.Red;
            }
            else
            {
                this.numUpDownAlarmLowerThenNormal.ForeColor = Color.Black;
            }
        }

        private void numUpDownAlarmHigherThenNormal_ValueChanged(object sender, EventArgs e)
        {
            if (this.numUpDownAlarmHigh.Value.CompareTo(this.numUpDownAlarmHigherThenNormal.Value) < 0 && !this.changeunits)
            {
                this.numUpDownAlarmHigherThenNormal.Value = this.numUpDownAlarmHigh.Value;
            }
            else if (this.numUpDownAlarmHigh.Value.CompareTo(this.numUpDownAlarmHigherThenNormal.Value) == 0)
            {
                this.numUpDownAlarmHigherThenNormal.ForeColor = Color.Red;
            }
            else
            {
                this.numUpDownAlarmHigherThenNormal.ForeColor = Color.Black;
            }
        }

        private void numUpDownAlarmLow_ValueChanged(object sender, EventArgs e)
        {
            if (this.numUpDownAlarmLowerThenNormal.Value.CompareTo(this.numUpDownAlarmLow.Value) < 0 && !this.changeunits)
            {
                this.numUpDownAlarmLowerThenNormal.Value = this.numUpDownAlarmLow.Value;

            }
        }

        private void numUpDownAlarmHigh_ValueChanged(object sender, EventArgs e)
        {
            if (this.numUpDownAlarmHigh.Value.CompareTo(this.numUpDownAlarmHigherThenNormal.Value) < 0 && !this.changeunits)
            {
                this.numUpDownAlarmHigherThenNormal.Value = this.numUpDownAlarmHigh.Value;
            }
        }
    }
}
