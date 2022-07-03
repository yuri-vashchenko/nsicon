
namespace NsIcon
{
    using System;
    using System.Windows.Forms;

    public partial class FrmDisclaimer : Form
    {
        private System.Timers.Timer timer;

        /// <summary>
        /// Creating a new instance of FrmDisclaimer class for displaying 
        /// disclaimer the user is required to agree to for use.
        /// </summary>
        /// <param name="timer"></param>
        public FrmDisclaimer(System.Timers.Timer timer)
        {
            InitializeComponent();
            this.timer = timer;
        }

        /// <summary>
        /// chxAgreeTerms chechstate changed, only allow to click enable if chxAgreeTerms is checked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chxAgreeTerms_CheckedChanged(object sender, EventArgs e)
        {
            this.btnContinue.Enabled = this.chxAgreeTerms.Checked;
        }

        /// <summary>
        /// Clicked on disagree / shutdown button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnContinue_Click(object sender, EventArgs e)
        {
            NsIcon.Properties.Settings.Default.disclaimerAgreed = true;
            NsIcon.Properties.Settings.Default.Save();
            this.timer.Start();
            this.Close();
        }
    }
}
