namespace DayscoutIcon
{
    partial class FrmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSettings));
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbTextGlucoseUpdateInterval = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.numUpDownGlucoseUpdateInterval = new System.Windows.Forms.NumericUpDown();
            this.lblTextUpdateIntervalUnit = new System.Windows.Forms.Label();
            this.tbServerUrl = new System.Windows.Forms.TextBox();
            this.lbTextServerUrl = new System.Windows.Forms.Label();
            this.tbApiSecretSha1 = new System.Windows.Forms.TextBox();
            this.lbTextApiSecret = new System.Windows.Forms.Label();
            this.numUpDownNetworkTimeout = new System.Windows.Forms.NumericUpDown();
            this.lblTextNetworkTimeout = new System.Windows.Forms.Label();
            this.lblTextNetworkTimeoutUnit = new System.Windows.Forms.Label();
            this.chxAlarmHigherThenNormal = new System.Windows.Forms.CheckBox();
            this.chxAlarmHigh = new System.Windows.Forms.CheckBox();
            this.chxAlarmLow = new System.Windows.Forms.CheckBox();
            this.numUpDownAlarmHigherThenNormal = new System.Windows.Forms.NumericUpDown();
            this.numUpDownAlarmHigh = new System.Windows.Forms.NumericUpDown();
            this.numUpDownAlarmLow = new System.Windows.Forms.NumericUpDown();
            this.chxAlarmLowerThenNormal = new System.Windows.Forms.CheckBox();
            this.numUpDownAlarmLowerThenNormal = new System.Windows.Forms.NumericUpDown();
            this.lblTextAlarmUnitsHigh = new System.Windows.Forms.Label();
            this.lblTextAlarmUnitsHigher = new System.Windows.Forms.Label();
            this.lblTextAlarmUnitsLower = new System.Windows.Forms.Label();
            this.lblTextAlarmUnitsLow = new System.Windows.Forms.Label();
            this.lblTextBloodsugar = new System.Windows.Forms.Label();
            this.numUpDownNumberDisplayRounding = new System.Windows.Forms.NumericUpDown();
            this.cbBloodsugarUnits = new System.Windows.Forms.ComboBox();
            this.lblTextBloodsugarUnits = new System.Windows.Forms.Label();
            this.lbTextDecimals = new System.Windows.Forms.Label();
            this.toolTipSettings = new System.Windows.Forms.ToolTip(this.components);
            this.numUpDownSecondsBloodsugarValid = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTextBloodsugarValidUnit = new System.Windows.Forms.Label();
            this.chxLinkNightscout = new System.Windows.Forms.CheckBox();
            this.groupBoxAlerts = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownGlucoseUpdateInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownNetworkTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownAlarmHigherThenNormal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownAlarmHigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownAlarmLow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownAlarmLowerThenNormal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownNumberDisplayRounding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownSecondsBloodsugarValid)).BeginInit();
            this.groupBoxAlerts.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(10, 347);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(171, 32);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbTextGlucoseUpdateInterval
            // 
            this.lbTextGlucoseUpdateInterval.AutoSize = true;
            this.lbTextGlucoseUpdateInterval.Location = new System.Drawing.Point(7, 77);
            this.lbTextGlucoseUpdateInterval.Name = "lbTextGlucoseUpdateInterval";
            this.lbTextGlucoseUpdateInterval.Size = new System.Drawing.Size(139, 13);
            this.lbTextGlucoseUpdateInterval.TabIndex = 1;
            this.lbTextGlucoseUpdateInterval.Text = "Blood sugar update interval:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(184, 347);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(180, 32);
            this.btnOk.TabIndex = 14;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // numUpDownGlucoseUpdateInterval
            // 
            this.numUpDownGlucoseUpdateInterval.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUpDownGlucoseUpdateInterval.Location = new System.Drawing.Point(159, 75);
            this.numUpDownGlucoseUpdateInterval.Maximum = new decimal(new int[] {
            3600000,
            0,
            0,
            0});
            this.numUpDownGlucoseUpdateInterval.Minimum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numUpDownGlucoseUpdateInterval.Name = "numUpDownGlucoseUpdateInterval";
            this.numUpDownGlucoseUpdateInterval.Size = new System.Drawing.Size(63, 20);
            this.numUpDownGlucoseUpdateInterval.TabIndex = 2;
            this.numUpDownGlucoseUpdateInterval.ThousandsSeparator = true;
            this.toolTipSettings.SetToolTip(this.numUpDownGlucoseUpdateInterval, "The amount of time in miliseconds between checking the Nightscout server.");
            this.numUpDownGlucoseUpdateInterval.Value = new decimal(new int[] {
            120000,
            0,
            0,
            0});
            this.numUpDownGlucoseUpdateInterval.ValueChanged += new System.EventHandler(this.numUpDownGlucoseUpdateInterval_ValueChanged);
            // 
            // lblTextUpdateIntervalUnit
            // 
            this.lblTextUpdateIntervalUnit.AutoSize = true;
            this.lblTextUpdateIntervalUnit.Location = new System.Drawing.Point(228, 77);
            this.lblTextUpdateIntervalUnit.Name = "lblTextUpdateIntervalUnit";
            this.lblTextUpdateIntervalUnit.Size = new System.Drawing.Size(20, 13);
            this.lblTextUpdateIntervalUnit.TabIndex = 4;
            this.lblTextUpdateIntervalUnit.Text = "ms";
            // 
            // tbServerUrl
            // 
            this.tbServerUrl.Location = new System.Drawing.Point(86, 12);
            this.tbServerUrl.MaxLength = 2047;
            this.tbServerUrl.Name = "tbServerUrl";
            this.tbServerUrl.Size = new System.Drawing.Size(278, 20);
            this.tbServerUrl.TabIndex = 0;
            this.toolTipSettings.SetToolTip(this.tbServerUrl, "The FQDN of the Nightscout server.");
            // 
            // lbTextServerUrl
            // 
            this.lbTextServerUrl.AutoSize = true;
            this.lbTextServerUrl.Location = new System.Drawing.Point(7, 17);
            this.lbTextServerUrl.Name = "lbTextServerUrl";
            this.lbTextServerUrl.Size = new System.Drawing.Size(55, 13);
            this.lbTextServerUrl.TabIndex = 6;
            this.lbTextServerUrl.Text = "Server url:";
            // 
            // tbApiSecretSha1
            // 
            this.tbApiSecretSha1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbApiSecretSha1.Location = new System.Drawing.Point(86, 38);
            this.tbApiSecretSha1.MaxLength = 40;
            this.tbApiSecretSha1.Name = "tbApiSecretSha1";
            this.tbApiSecretSha1.PasswordChar = '●';
            this.tbApiSecretSha1.Size = new System.Drawing.Size(278, 20);
            this.tbApiSecretSha1.TabIndex = 1;
            this.toolTipSettings.SetToolTip(this.tbApiSecretSha1, "The SHA-1 hexadecimal API_SECRET string.");
            // 
            // lbTextApiSecret
            // 
            this.lbTextApiSecret.AutoSize = true;
            this.lbTextApiSecret.Location = new System.Drawing.Point(7, 41);
            this.lbTextApiSecret.Name = "lbTextApiSecret";
            this.lbTextApiSecret.Size = new System.Drawing.Size(76, 13);
            this.lbTextApiSecret.TabIndex = 8;
            this.lbTextApiSecret.Text = "API_SECRET:";
            // 
            // numUpDownNetworkTimeout
            // 
            this.numUpDownNetworkTimeout.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUpDownNetworkTimeout.Location = new System.Drawing.Point(159, 96);
            this.numUpDownNetworkTimeout.Maximum = new decimal(new int[] {
            3600000,
            0,
            0,
            0});
            this.numUpDownNetworkTimeout.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numUpDownNetworkTimeout.Name = "numUpDownNetworkTimeout";
            this.numUpDownNetworkTimeout.Size = new System.Drawing.Size(63, 20);
            this.numUpDownNetworkTimeout.TabIndex = 3;
            this.numUpDownNetworkTimeout.ThousandsSeparator = true;
            this.toolTipSettings.SetToolTip(this.numUpDownNetworkTimeout, "How many miliseconds before a server connection is consider failed.");
            this.numUpDownNetworkTimeout.Value = new decimal(new int[] {
            15000,
            0,
            0,
            0});
            // 
            // lblTextNetworkTimeout
            // 
            this.lblTextNetworkTimeout.AutoSize = true;
            this.lblTextNetworkTimeout.Location = new System.Drawing.Point(7, 98);
            this.lblTextNetworkTimeout.Name = "lblTextNetworkTimeout";
            this.lblTextNetworkTimeout.Size = new System.Drawing.Size(90, 13);
            this.lblTextNetworkTimeout.TabIndex = 10;
            this.lblTextNetworkTimeout.Text = "Netwerk time out:";
            // 
            // lblTextNetworkTimeoutUnit
            // 
            this.lblTextNetworkTimeoutUnit.AutoSize = true;
            this.lblTextNetworkTimeoutUnit.Location = new System.Drawing.Point(228, 98);
            this.lblTextNetworkTimeoutUnit.Name = "lblTextNetworkTimeoutUnit";
            this.lblTextNetworkTimeoutUnit.Size = new System.Drawing.Size(20, 13);
            this.lblTextNetworkTimeoutUnit.TabIndex = 11;
            this.lblTextNetworkTimeoutUnit.Text = "ms";
            // 
            // chxAlarmHigherThenNormal
            // 
            this.chxAlarmHigherThenNormal.AutoSize = true;
            this.chxAlarmHigherThenNormal.Location = new System.Drawing.Point(6, 42);
            this.chxAlarmHigherThenNormal.Name = "chxAlarmHigherThenNormal";
            this.chxAlarmHigherThenNormal.Size = new System.Drawing.Size(224, 17);
            this.chxAlarmHigherThenNormal.TabIndex = 10;
            this.chxAlarmHigherThenNormal.Text = "Show alert higher then normal bloodsugar.";
            this.chxAlarmHigherThenNormal.UseVisualStyleBackColor = true;
            this.chxAlarmHigherThenNormal.CheckedChanged += new System.EventHandler(this.chxAlarmHigherThenNormal_CheckedChanged);
            // 
            // chxAlarmHigh
            // 
            this.chxAlarmHigh.AutoSize = true;
            this.chxAlarmHigh.Checked = true;
            this.chxAlarmHigh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chxAlarmHigh.Location = new System.Drawing.Point(6, 19);
            this.chxAlarmHigh.Name = "chxAlarmHigh";
            this.chxAlarmHigh.Size = new System.Drawing.Size(230, 17);
            this.chxAlarmHigh.TabIndex = 9;
            this.chxAlarmHigh.Text = "Show alert high bloodsugar (recommended)";
            this.chxAlarmHigh.UseVisualStyleBackColor = true;
            this.chxAlarmHigh.CheckedChanged += new System.EventHandler(this.chxAlarmHigh_CheckedChanged);
            // 
            // chxAlarmLow
            // 
            this.chxAlarmLow.AutoSize = true;
            this.chxAlarmLow.Checked = true;
            this.chxAlarmLow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chxAlarmLow.Location = new System.Drawing.Point(6, 87);
            this.chxAlarmLow.Name = "chxAlarmLow";
            this.chxAlarmLow.Size = new System.Drawing.Size(226, 17);
            this.chxAlarmLow.TabIndex = 12;
            this.chxAlarmLow.Text = "Show alert low bloodsugar (recommended)";
            this.chxAlarmLow.UseVisualStyleBackColor = true;
            this.chxAlarmLow.CheckedChanged += new System.EventHandler(this.chxAlarmLow_CheckedChanged);
            // 
            // numUpDownAlarmHigherThenNormal
            // 
            this.numUpDownAlarmHigherThenNormal.DecimalPlaces = 1;
            this.numUpDownAlarmHigherThenNormal.Enabled = false;
            this.numUpDownAlarmHigherThenNormal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numUpDownAlarmHigherThenNormal.Location = new System.Drawing.Point(254, 38);
            this.numUpDownAlarmHigherThenNormal.Maximum = new decimal(new int[] {
            199,
            0,
            0,
            65536});
            this.numUpDownAlarmHigherThenNormal.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numUpDownAlarmHigherThenNormal.Name = "numUpDownAlarmHigherThenNormal";
            this.numUpDownAlarmHigherThenNormal.Size = new System.Drawing.Size(56, 20);
            this.numUpDownAlarmHigherThenNormal.TabIndex = 6;
            this.numUpDownAlarmHigherThenNormal.Value = new decimal(new int[] {
            90,
            0,
            0,
            65536});
            this.numUpDownAlarmHigherThenNormal.ValueChanged += new System.EventHandler(this.numUpDownAlarmHigherThenNormal_ValueChanged);
            // 
            // numUpDownAlarmHigh
            // 
            this.numUpDownAlarmHigh.DecimalPlaces = 1;
            this.numUpDownAlarmHigh.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numUpDownAlarmHigh.Location = new System.Drawing.Point(254, 15);
            this.numUpDownAlarmHigh.Maximum = new decimal(new int[] {
            27,
            0,
            0,
            0});
            this.numUpDownAlarmHigh.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numUpDownAlarmHigh.Name = "numUpDownAlarmHigh";
            this.numUpDownAlarmHigh.Size = new System.Drawing.Size(56, 20);
            this.numUpDownAlarmHigh.TabIndex = 5;
            this.numUpDownAlarmHigh.Value = new decimal(new int[] {
            100,
            0,
            0,
            65536});
            this.numUpDownAlarmHigh.ValueChanged += new System.EventHandler(this.numUpDownAlarmHigh_ValueChanged);
            // 
            // numUpDownAlarmLow
            // 
            this.numUpDownAlarmLow.DecimalPlaces = 1;
            this.numUpDownAlarmLow.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numUpDownAlarmLow.Location = new System.Drawing.Point(254, 85);
            this.numUpDownAlarmLow.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numUpDownAlarmLow.Minimum = new decimal(new int[] {
            23,
            0,
            0,
            65536});
            this.numUpDownAlarmLow.Name = "numUpDownAlarmLow";
            this.numUpDownAlarmLow.Size = new System.Drawing.Size(56, 20);
            this.numUpDownAlarmLow.TabIndex = 8;
            this.numUpDownAlarmLow.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numUpDownAlarmLow.ValueChanged += new System.EventHandler(this.numUpDownAlarmLow_ValueChanged);
            // 
            // chxAlarmLowerThenNormal
            // 
            this.chxAlarmLowerThenNormal.AutoSize = true;
            this.chxAlarmLowerThenNormal.Checked = true;
            this.chxAlarmLowerThenNormal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chxAlarmLowerThenNormal.Location = new System.Drawing.Point(6, 64);
            this.chxAlarmLowerThenNormal.Name = "chxAlarmLowerThenNormal";
            this.chxAlarmLowerThenNormal.Size = new System.Drawing.Size(220, 17);
            this.chxAlarmLowerThenNormal.TabIndex = 11;
            this.chxAlarmLowerThenNormal.Text = "Show alert lower then normal bloodsugar.";
            this.chxAlarmLowerThenNormal.UseVisualStyleBackColor = true;
            this.chxAlarmLowerThenNormal.CheckedChanged += new System.EventHandler(this.chxAlarmLowerThenNormal_CheckedChanged);
            // 
            // numUpDownAlarmLowerThenNormal
            // 
            this.numUpDownAlarmLowerThenNormal.DecimalPlaces = 1;
            this.numUpDownAlarmLowerThenNormal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numUpDownAlarmLowerThenNormal.Location = new System.Drawing.Point(254, 61);
            this.numUpDownAlarmLowerThenNormal.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numUpDownAlarmLowerThenNormal.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            65536});
            this.numUpDownAlarmLowerThenNormal.Name = "numUpDownAlarmLowerThenNormal";
            this.numUpDownAlarmLowerThenNormal.Size = new System.Drawing.Size(56, 20);
            this.numUpDownAlarmLowerThenNormal.TabIndex = 7;
            this.numUpDownAlarmLowerThenNormal.Value = new decimal(new int[] {
            48,
            0,
            0,
            65536});
            this.numUpDownAlarmLowerThenNormal.ValueChanged += new System.EventHandler(this.numUpDownAlarmLowerThenNormal_ValueChanged);
            // 
            // lblTextAlarmUnitsHigh
            // 
            this.lblTextAlarmUnitsHigh.AutoSize = true;
            this.lblTextAlarmUnitsHigh.Location = new System.Drawing.Point(316, 20);
            this.lblTextAlarmUnitsHigh.Name = "lblTextAlarmUnitsHigh";
            this.lblTextAlarmUnitsHigh.Size = new System.Drawing.Size(38, 13);
            this.lblTextAlarmUnitsHigh.TabIndex = 20;
            this.lblTextAlarmUnitsHigh.Text = "mmol/l";
            // 
            // lblTextAlarmUnitsHigher
            // 
            this.lblTextAlarmUnitsHigher.AutoSize = true;
            this.lblTextAlarmUnitsHigher.Location = new System.Drawing.Point(316, 45);
            this.lblTextAlarmUnitsHigher.Name = "lblTextAlarmUnitsHigher";
            this.lblTextAlarmUnitsHigher.Size = new System.Drawing.Size(38, 13);
            this.lblTextAlarmUnitsHigher.TabIndex = 21;
            this.lblTextAlarmUnitsHigher.Text = "mmol/l";
            // 
            // lblTextAlarmUnitsLower
            // 
            this.lblTextAlarmUnitsLower.AutoSize = true;
            this.lblTextAlarmUnitsLower.Location = new System.Drawing.Point(316, 66);
            this.lblTextAlarmUnitsLower.Name = "lblTextAlarmUnitsLower";
            this.lblTextAlarmUnitsLower.Size = new System.Drawing.Size(38, 13);
            this.lblTextAlarmUnitsLower.TabIndex = 22;
            this.lblTextAlarmUnitsLower.Text = "mmol/l";
            // 
            // lblTextAlarmUnitsLow
            // 
            this.lblTextAlarmUnitsLow.AutoSize = true;
            this.lblTextAlarmUnitsLow.Location = new System.Drawing.Point(316, 90);
            this.lblTextAlarmUnitsLow.Name = "lblTextAlarmUnitsLow";
            this.lblTextAlarmUnitsLow.Size = new System.Drawing.Size(38, 13);
            this.lblTextAlarmUnitsLow.TabIndex = 23;
            this.lblTextAlarmUnitsLow.Text = "mmol/l";
            // 
            // lblTextBloodsugar
            // 
            this.lblTextBloodsugar.AutoSize = true;
            this.lblTextBloodsugar.Location = new System.Drawing.Point(7, 151);
            this.lblTextBloodsugar.Name = "lblTextBloodsugar";
            this.lblTextBloodsugar.Size = new System.Drawing.Size(111, 13);
            this.lblTextBloodsugar.TabIndex = 24;
            this.lblTextBloodsugar.Text = "Rounding bloodsugar:";
            // 
            // numUpDownNumberDisplayRounding
            // 
            this.numUpDownNumberDisplayRounding.Location = new System.Drawing.Point(159, 147);
            this.numUpDownNumberDisplayRounding.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numUpDownNumberDisplayRounding.Name = "numUpDownNumberDisplayRounding";
            this.numUpDownNumberDisplayRounding.Size = new System.Drawing.Size(63, 20);
            this.numUpDownNumberDisplayRounding.TabIndex = 4;
            this.numUpDownNumberDisplayRounding.ThousandsSeparator = true;
            this.toolTipSettings.SetToolTip(this.numUpDownNumberDisplayRounding, "The amount of decimals the blood sugar is rounded to for displaying.");
            this.numUpDownNumberDisplayRounding.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // cbBloodsugarUnits
            // 
            this.cbBloodsugarUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBloodsugarUnits.Items.AddRange(new object[] {
            "mmol",
            "mg/dl"});
            this.cbBloodsugarUnits.Location = new System.Drawing.Point(159, 173);
            this.cbBloodsugarUnits.MaxDropDownItems = 3;
            this.cbBloodsugarUnits.Name = "cbBloodsugarUnits";
            this.cbBloodsugarUnits.Size = new System.Drawing.Size(63, 21);
            this.cbBloodsugarUnits.TabIndex = 26;
            this.toolTipSettings.SetToolTip(this.cbBloodsugarUnits, "The blood sugar value units to use.");
            this.cbBloodsugarUnits.SelectedIndexChanged += new System.EventHandler(this.cbBloodsugarUnits_SelectedIndexChanged);
            // 
            // lblTextBloodsugarUnits
            // 
            this.lblTextBloodsugarUnits.AutoSize = true;
            this.lblTextBloodsugarUnits.Location = new System.Drawing.Point(7, 176);
            this.lblTextBloodsugarUnits.Name = "lblTextBloodsugarUnits";
            this.lblTextBloodsugarUnits.Size = new System.Drawing.Size(88, 13);
            this.lblTextBloodsugarUnits.TabIndex = 27;
            this.lblTextBloodsugarUnits.Text = "Bloodsugar units:";
            // 
            // lbTextDecimals
            // 
            this.lbTextDecimals.AutoSize = true;
            this.lbTextDecimals.Location = new System.Drawing.Point(228, 151);
            this.lbTextDecimals.Name = "lbTextDecimals";
            this.lbTextDecimals.Size = new System.Drawing.Size(48, 13);
            this.lbTextDecimals.TabIndex = 28;
            this.lbTextDecimals.Text = "decimals";
            // 
            // toolTipSettings
            // 
            this.toolTipSettings.AutoPopDelay = 5000;
            this.toolTipSettings.InitialDelay = 200;
            this.toolTipSettings.ReshowDelay = 100;
            // 
            // numUpDownSecondsBloodsugarValid
            // 
            this.numUpDownSecondsBloodsugarValid.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numUpDownSecondsBloodsugarValid.Location = new System.Drawing.Point(159, 122);
            this.numUpDownSecondsBloodsugarValid.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.numUpDownSecondsBloodsugarValid.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numUpDownSecondsBloodsugarValid.Name = "numUpDownSecondsBloodsugarValid";
            this.numUpDownSecondsBloodsugarValid.Size = new System.Drawing.Size(63, 20);
            this.numUpDownSecondsBloodsugarValid.TabIndex = 30;
            this.numUpDownSecondsBloodsugarValid.ThousandsSeparator = true;
            this.toolTipSettings.SetToolTip(this.numUpDownSecondsBloodsugarValid, "The number of seconds the current bloodsugar value is still valid, if not availab" +
        "le within current time complain about no current bloodsugar values.");
            this.numUpDownSecondsBloodsugarValid.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "bloodsugar value valid for:";
            // 
            // lblTextBloodsugarValidUnit
            // 
            this.lblTextBloodsugarValidUnit.AutoSize = true;
            this.lblTextBloodsugarValidUnit.Location = new System.Drawing.Point(228, 125);
            this.lblTextBloodsugarValidUnit.Name = "lblTextBloodsugarValidUnit";
            this.lblTextBloodsugarValidUnit.Size = new System.Drawing.Size(12, 13);
            this.lblTextBloodsugarValidUnit.TabIndex = 31;
            this.lblTextBloodsugarValidUnit.Text = "s";
            // 
            // chxLinkNightscout
            // 
            this.chxLinkNightscout.AutoSize = true;
            this.chxLinkNightscout.Location = new System.Drawing.Point(10, 200);
            this.chxLinkNightscout.Name = "chxLinkNightscout";
            this.chxLinkNightscout.Size = new System.Drawing.Size(258, 17);
            this.chxLinkNightscout.TabIndex = 32;
            this.chxLinkNightscout.Text = "Show link to nightscout on trayicon contextmenu.";
            this.chxLinkNightscout.UseVisualStyleBackColor = true;
            // 
            // groupBoxAlerts
            // 
            this.groupBoxAlerts.Controls.Add(this.chxAlarmHigh);
            this.groupBoxAlerts.Controls.Add(this.chxAlarmHigherThenNormal);
            this.groupBoxAlerts.Controls.Add(this.chxAlarmLowerThenNormal);
            this.groupBoxAlerts.Controls.Add(this.chxAlarmLow);
            this.groupBoxAlerts.Controls.Add(this.lblTextAlarmUnitsHigh);
            this.groupBoxAlerts.Controls.Add(this.numUpDownAlarmHigherThenNormal);
            this.groupBoxAlerts.Controls.Add(this.numUpDownAlarmHigh);
            this.groupBoxAlerts.Controls.Add(this.numUpDownAlarmLow);
            this.groupBoxAlerts.Controls.Add(this.numUpDownAlarmLowerThenNormal);
            this.groupBoxAlerts.Controls.Add(this.lblTextAlarmUnitsHigher);
            this.groupBoxAlerts.Controls.Add(this.lblTextAlarmUnitsLow);
            this.groupBoxAlerts.Controls.Add(this.lblTextAlarmUnitsLower);
            this.groupBoxAlerts.Location = new System.Drawing.Point(4, 227);
            this.groupBoxAlerts.Name = "groupBoxAlerts";
            this.groupBoxAlerts.Size = new System.Drawing.Size(360, 113);
            this.groupBoxAlerts.TabIndex = 33;
            this.groupBoxAlerts.TabStop = false;
            this.groupBoxAlerts.Text = "Alerts";
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 391);
            this.Controls.Add(this.groupBoxAlerts);
            this.Controls.Add(this.chxLinkNightscout);
            this.Controls.Add(this.lblTextBloodsugarValidUnit);
            this.Controls.Add(this.numUpDownSecondsBloodsugarValid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbTextDecimals);
            this.Controls.Add(this.lblTextBloodsugarUnits);
            this.Controls.Add(this.cbBloodsugarUnits);
            this.Controls.Add(this.numUpDownNumberDisplayRounding);
            this.Controls.Add(this.lblTextBloodsugar);
            this.Controls.Add(this.lblTextNetworkTimeoutUnit);
            this.Controls.Add(this.lblTextNetworkTimeout);
            this.Controls.Add(this.numUpDownNetworkTimeout);
            this.Controls.Add(this.lbTextApiSecret);
            this.Controls.Add(this.tbApiSecretSha1);
            this.Controls.Add(this.lbTextServerUrl);
            this.Controls.Add(this.tbServerUrl);
            this.Controls.Add(this.lblTextUpdateIntervalUnit);
            this.Controls.Add(this.numUpDownGlucoseUpdateInterval);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lbTextGlucoseUpdateInterval);
            this.Controls.Add(this.btnCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSettings";
            this.Text = "DayscoutSysicon settings";
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownGlucoseUpdateInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownNetworkTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownAlarmHigherThenNormal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownAlarmHigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownAlarmLow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownAlarmLowerThenNormal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownNumberDisplayRounding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownSecondsBloodsugarValid)).EndInit();
            this.groupBoxAlerts.ResumeLayout(false);
            this.groupBoxAlerts.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbTextGlucoseUpdateInterval;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.NumericUpDown numUpDownGlucoseUpdateInterval;
        private System.Windows.Forms.Label lblTextUpdateIntervalUnit;
        private System.Windows.Forms.TextBox tbServerUrl;
        private System.Windows.Forms.Label lbTextServerUrl;
        private System.Windows.Forms.TextBox tbApiSecretSha1;
        private System.Windows.Forms.Label lbTextApiSecret;
        private System.Windows.Forms.NumericUpDown numUpDownNetworkTimeout;
        private System.Windows.Forms.Label lblTextNetworkTimeout;
        private System.Windows.Forms.Label lblTextNetworkTimeoutUnit;
        private System.Windows.Forms.CheckBox chxAlarmHigherThenNormal;
        private System.Windows.Forms.CheckBox chxAlarmHigh;
        private System.Windows.Forms.CheckBox chxAlarmLow;
        private System.Windows.Forms.NumericUpDown numUpDownAlarmHigherThenNormal;
        private System.Windows.Forms.NumericUpDown numUpDownAlarmHigh;
        private System.Windows.Forms.NumericUpDown numUpDownAlarmLow;
        private System.Windows.Forms.CheckBox chxAlarmLowerThenNormal;
        private System.Windows.Forms.NumericUpDown numUpDownAlarmLowerThenNormal;
        private System.Windows.Forms.Label lblTextAlarmUnitsHigh;
        private System.Windows.Forms.Label lblTextAlarmUnitsHigher;
        private System.Windows.Forms.Label lblTextAlarmUnitsLower;
        private System.Windows.Forms.Label lblTextAlarmUnitsLow;
        private System.Windows.Forms.Label lblTextBloodsugar;
        private System.Windows.Forms.NumericUpDown numUpDownNumberDisplayRounding;
        private System.Windows.Forms.ComboBox cbBloodsugarUnits;
        private System.Windows.Forms.Label lblTextBloodsugarUnits;
        private System.Windows.Forms.Label lbTextDecimals;
        private System.Windows.Forms.ToolTip toolTipSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numUpDownSecondsBloodsugarValid;
        private System.Windows.Forms.Label lblTextBloodsugarValidUnit;
        private System.Windows.Forms.CheckBox chxLinkNightscout;
        private System.Windows.Forms.GroupBox groupBoxAlerts;
    }
}

