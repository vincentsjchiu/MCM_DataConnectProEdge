namespace WindowsFormsApplication1
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
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.machinestatus = new MetroFramework.Controls.MetroTabPage();
            this.radioButtonFFTCh3 = new System.Windows.Forms.RadioButton();
            this.radioButtonFFTCh2 = new System.Windows.Forms.RadioButton();
            this.radioButtonFFTCh1 = new System.Windows.Forms.RadioButton();
            this.radioButtonFFTCh0 = new System.Windows.Forms.RadioButton();
            this.buttonquery = new System.Windows.Forms.Button();
            this.dataGridViewAlarmLog = new System.Windows.Forms.DataGridView();
            this.dataGridViewOATrend = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.zedGraphtime = new ZedGraph.ZedGraphControl();
            this.zedGraphfft = new ZedGraph.ZedGraphControl();
            this.zedGraphhistory = new ZedGraph.ZedGraphControl();
            this.Setting = new MetroFramework.Controls.MetroTabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.metroCheckBoxAzure = new MetroFramework.Controls.MetroCheckBox();
            this.groupBoxModbus = new System.Windows.Forms.GroupBox();
            this.metroCheckBoxModbus = new MetroFramework.Controls.MetroCheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.textBoxMCMID = new System.Windows.Forms.TextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.ipAddressControlText = new IPAddressControlLib.IPAddressControl();
            this.metroCheckBoxMqttRaw = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBoxMqtt = new MetroFramework.Controls.MetroCheckBox();
            this.groupBoxDDS = new System.Windows.Forms.GroupBox();
            this.checkBoxDDS = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBoxConfigfile = new MetroFramework.Controls.MetroTextBox();
            this.ComboBoxFreqResolution = new MetroFramework.Controls.MetroComboBox();
            this.buttonSaveAsConfig = new System.Windows.Forms.Button();
            this.buttonLoadConfig = new System.Windows.Forms.Button();
            this.buttonRemoveMonitor = new System.Windows.Forms.Button();
            this.buttonAddMonitor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel22 = new MetroFramework.Controls.MetroLabel();
            this.label16 = new System.Windows.Forms.Label();
            this.TextBoxHDspace = new MetroFramework.Controls.MetroTextBox();
            this.TextBoxNormalAverages = new MetroFramework.Controls.MetroTextBox();
            this.TextBoxNormalSechedule = new MetroFramework.Controls.MetroTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBoxTextDataRecord = new MetroFramework.Controls.MetroCheckBox();
            this.checkBoxNormalDataRecord = new MetroFramework.Controls.MetroCheckBox();
            this.ComboBoxBandWidth = new MetroFramework.Controls.MetroComboBox();
            this.dataGridViewMonitorSetting = new System.Windows.Forms.DataGridView();
            this.dataGridViewChSetting = new System.Windows.Forms.DataGridView();
            this.Analysis = new MetroFramework.Controls.MetroTabPage();
            this.buttonmainwithharmonic = new System.Windows.Forms.Button();
            this.metroTextBoxmainFreq = new MetroFramework.Controls.MetroTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxcount = new System.Windows.Forms.TextBox();
            this.buttonfilecombine = new System.Windows.Forms.Button();
            this.metroButtonhours = new MetroFramework.Controls.MetroButton();
            this.metroButtondays = new MetroFramework.Controls.MetroButton();
            this.metroButtonmonths = new MetroFramework.Controls.MetroButton();
            this.metroButtonyears = new MetroFramework.Controls.MetroButton();
            this.buttonAnalysisquery = new System.Windows.Forms.Button();
            this.zedGraphtimeAnalysis = new ZedGraph.ZedGraphControl();
            this.zedGraphfftAnalysis = new ZedGraph.ZedGraphControl();
            this.zedGraphAnalysishistory = new ZedGraph.ZedGraphControl();
            this.dataGridViewfileAnalysis = new System.Windows.Forms.DataGridView();
            this.dataGridViewOATrendAnalysis = new System.Windows.Forms.DataGridView();
            this.textBox1daqtime = new System.Windows.Forms.TextBox();
            this.richTextBoxAlarm = new System.Windows.Forms.RichTextBox();
            this.metroTabControl1.SuspendLayout();
            this.machinestatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlarmLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOATrend)).BeginInit();
            this.Setting.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxModbus.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxDDS.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMonitorSetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChSetting)).BeginInit();
            this.Analysis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewfileAnalysis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOATrendAnalysis)).BeginInit();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroTabControl1.Controls.Add(this.machinestatus);
            this.metroTabControl1.Controls.Add(this.Setting);
            this.metroTabControl1.Controls.Add(this.Analysis);
            this.metroTabControl1.Location = new System.Drawing.Point(23, 63);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 1;
            this.metroTabControl1.Size = new System.Drawing.Size(1026, 566);
            this.metroTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.metroTabControl1.Style = MetroFramework.MetroColorStyle.Purple;
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTabControl1.UseSelectable = true;
            this.metroTabControl1.SelectedIndexChanged += new System.EventHandler(this.metroTabControl1_SelectedIndexChanged);
            // 
            // machinestatus
            // 
            this.machinestatus.BackColor = System.Drawing.SystemColors.WindowText;
            this.machinestatus.Controls.Add(this.radioButtonFFTCh3);
            this.machinestatus.Controls.Add(this.radioButtonFFTCh2);
            this.machinestatus.Controls.Add(this.radioButtonFFTCh1);
            this.machinestatus.Controls.Add(this.radioButtonFFTCh0);
            this.machinestatus.Controls.Add(this.buttonquery);
            this.machinestatus.Controls.Add(this.dataGridViewAlarmLog);
            this.machinestatus.Controls.Add(this.dataGridViewOATrend);
            this.machinestatus.Controls.Add(this.label6);
            this.machinestatus.Controls.Add(this.label13);
            this.machinestatus.Controls.Add(this.zedGraphtime);
            this.machinestatus.Controls.Add(this.zedGraphfft);
            this.machinestatus.Controls.Add(this.zedGraphhistory);
            this.machinestatus.HorizontalScrollbarBarColor = true;
            this.machinestatus.HorizontalScrollbarHighlightOnWheel = false;
            this.machinestatus.HorizontalScrollbarSize = 10;
            this.machinestatus.Location = new System.Drawing.Point(4, 39);
            this.machinestatus.Name = "machinestatus";
            this.machinestatus.Size = new System.Drawing.Size(1018, 523);
            this.machinestatus.Style = MetroFramework.MetroColorStyle.Blue;
            this.machinestatus.TabIndex = 0;
            this.machinestatus.Text = "Machine Status";
            this.machinestatus.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.machinestatus.VerticalScrollbarBarColor = true;
            this.machinestatus.VerticalScrollbarHighlightOnWheel = false;
            this.machinestatus.VerticalScrollbarSize = 10;
            // 
            // radioButtonFFTCh3
            // 
            this.radioButtonFFTCh3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonFFTCh3.AutoSize = true;
            this.radioButtonFFTCh3.BackColor = System.Drawing.SystemColors.Desktop;
            this.radioButtonFFTCh3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radioButtonFFTCh3.Location = new System.Drawing.Point(271, 398);
            this.radioButtonFFTCh3.Name = "radioButtonFFTCh3";
            this.radioButtonFFTCh3.Size = new System.Drawing.Size(45, 16);
            this.radioButtonFFTCh3.TabIndex = 27;
            this.radioButtonFFTCh3.TabStop = true;
            this.radioButtonFFTCh3.Text = "CH3";
            this.radioButtonFFTCh3.UseVisualStyleBackColor = false;
            this.radioButtonFFTCh3.CheckedChanged += new System.EventHandler(this.radioButtonFFTCh3_CheckedChanged);
            // 
            // radioButtonFFTCh2
            // 
            this.radioButtonFFTCh2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonFFTCh2.AutoSize = true;
            this.radioButtonFFTCh2.BackColor = System.Drawing.SystemColors.Desktop;
            this.radioButtonFFTCh2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radioButtonFFTCh2.Location = new System.Drawing.Point(271, 351);
            this.radioButtonFFTCh2.Name = "radioButtonFFTCh2";
            this.radioButtonFFTCh2.Size = new System.Drawing.Size(45, 16);
            this.radioButtonFFTCh2.TabIndex = 26;
            this.radioButtonFFTCh2.TabStop = true;
            this.radioButtonFFTCh2.Text = "CH2";
            this.radioButtonFFTCh2.UseVisualStyleBackColor = false;
            this.radioButtonFFTCh2.CheckedChanged += new System.EventHandler(this.radioButtonFFTCh2_CheckedChanged);
            // 
            // radioButtonFFTCh1
            // 
            this.radioButtonFFTCh1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonFFTCh1.AutoSize = true;
            this.radioButtonFFTCh1.BackColor = System.Drawing.SystemColors.Desktop;
            this.radioButtonFFTCh1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radioButtonFFTCh1.Location = new System.Drawing.Point(272, 304);
            this.radioButtonFFTCh1.Name = "radioButtonFFTCh1";
            this.radioButtonFFTCh1.Size = new System.Drawing.Size(45, 16);
            this.radioButtonFFTCh1.TabIndex = 25;
            this.radioButtonFFTCh1.TabStop = true;
            this.radioButtonFFTCh1.Text = "CH1";
            this.radioButtonFFTCh1.UseVisualStyleBackColor = false;
            this.radioButtonFFTCh1.CheckedChanged += new System.EventHandler(this.radioButtonFFTCh1_CheckedChanged);
            // 
            // radioButtonFFTCh0
            // 
            this.radioButtonFFTCh0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonFFTCh0.AutoSize = true;
            this.radioButtonFFTCh0.BackColor = System.Drawing.SystemColors.Desktop;
            this.radioButtonFFTCh0.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radioButtonFFTCh0.Location = new System.Drawing.Point(272, 255);
            this.radioButtonFFTCh0.Name = "radioButtonFFTCh0";
            this.radioButtonFFTCh0.Size = new System.Drawing.Size(45, 16);
            this.radioButtonFFTCh0.TabIndex = 24;
            this.radioButtonFFTCh0.TabStop = true;
            this.radioButtonFFTCh0.Text = "CH0";
            this.radioButtonFFTCh0.UseVisualStyleBackColor = false;
            this.radioButtonFFTCh0.CheckedChanged += new System.EventHandler(this.radioButtonFFTCh0_CheckedChanged);
            // 
            // buttonquery
            // 
            this.buttonquery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonquery.Location = new System.Drawing.Point(0, 460);
            this.buttonquery.Name = "buttonquery";
            this.buttonquery.Size = new System.Drawing.Size(266, 23);
            this.buttonquery.TabIndex = 22;
            this.buttonquery.Text = "Query";
            this.buttonquery.UseVisualStyleBackColor = true;
            this.buttonquery.Click += new System.EventHandler(this.buttonquery_Click);
            // 
            // dataGridViewAlarmLog
            // 
            this.dataGridViewAlarmLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewAlarmLog.BackgroundColor = System.Drawing.SystemColors.Desktop;
            this.dataGridViewAlarmLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAlarmLog.Location = new System.Drawing.Point(0, 258);
            this.dataGridViewAlarmLog.Name = "dataGridViewAlarmLog";
            this.dataGridViewAlarmLog.RowTemplate.Height = 24;
            this.dataGridViewAlarmLog.Size = new System.Drawing.Size(266, 195);
            this.dataGridViewAlarmLog.TabIndex = 21;
            // 
            // dataGridViewOATrend
            // 
            this.dataGridViewOATrend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewOATrend.BackgroundColor = System.Drawing.SystemColors.Desktop;
            this.dataGridViewOATrend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOATrend.Location = new System.Drawing.Point(0, 30);
            this.dataGridViewOATrend.Name = "dataGridViewOATrend";
            this.dataGridViewOATrend.RowTemplate.Height = 24;
            this.dataGridViewOATrend.Size = new System.Drawing.Size(266, 212);
            this.dataGridViewOATrend.TabIndex = 17;
            this.dataGridViewOATrend.SelectionChanged += new System.EventHandler(this.dataGridViewOATrend_SelectionChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Desktop;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(1, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "Over All Value Monitoring";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.Desktop;
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label13.Location = new System.Drawing.Point(-2, 243);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 12);
            this.label13.TabIndex = 14;
            this.label13.Text = "Alarm log";
            // 
            // zedGraphtime
            // 
            this.zedGraphtime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphtime.AutoSize = true;
            this.zedGraphtime.BackColor = System.Drawing.SystemColors.WindowText;
            this.zedGraphtime.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zedGraphtime.ForeColor = System.Drawing.SystemColors.GrayText;
            this.zedGraphtime.Location = new System.Drawing.Point(656, 255);
            this.zedGraphtime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zedGraphtime.Name = "zedGraphtime";
            this.zedGraphtime.ScrollGrace = 0D;
            this.zedGraphtime.ScrollMaxX = 0D;
            this.zedGraphtime.ScrollMaxY = 0D;
            this.zedGraphtime.ScrollMaxY2 = 0D;
            this.zedGraphtime.ScrollMinX = 0D;
            this.zedGraphtime.ScrollMinY = 0D;
            this.zedGraphtime.ScrollMinY2 = 0D;
            this.zedGraphtime.Size = new System.Drawing.Size(349, 231);
            this.zedGraphtime.TabIndex = 8;
            // 
            // zedGraphfft
            // 
            this.zedGraphfft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphfft.AutoSize = true;
            this.zedGraphfft.BackColor = System.Drawing.SystemColors.WindowText;
            this.zedGraphfft.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zedGraphfft.ForeColor = System.Drawing.SystemColors.GrayText;
            this.zedGraphfft.Location = new System.Drawing.Point(320, 255);
            this.zedGraphfft.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zedGraphfft.Name = "zedGraphfft";
            this.zedGraphfft.ScrollGrace = 0D;
            this.zedGraphfft.ScrollMaxX = 0D;
            this.zedGraphfft.ScrollMaxY = 0D;
            this.zedGraphfft.ScrollMaxY2 = 0D;
            this.zedGraphfft.ScrollMinX = 0D;
            this.zedGraphfft.ScrollMinY = 0D;
            this.zedGraphfft.ScrollMinY2 = 0D;
            this.zedGraphfft.Size = new System.Drawing.Size(328, 231);
            this.zedGraphfft.TabIndex = 9;
            // 
            // zedGraphhistory
            // 
            this.zedGraphhistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphhistory.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.zedGraphhistory.BackColor = System.Drawing.SystemColors.WindowText;
            this.zedGraphhistory.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zedGraphhistory.ForeColor = System.Drawing.SystemColors.Window;
            this.zedGraphhistory.Location = new System.Drawing.Point(273, 30);
            this.zedGraphhistory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zedGraphhistory.Name = "zedGraphhistory";
            this.zedGraphhistory.ScrollGrace = 0D;
            this.zedGraphhistory.ScrollMaxX = 0D;
            this.zedGraphhistory.ScrollMaxY = 0D;
            this.zedGraphhistory.ScrollMaxY2 = 0D;
            this.zedGraphhistory.ScrollMinX = 0D;
            this.zedGraphhistory.ScrollMinY = 0D;
            this.zedGraphhistory.ScrollMinY2 = 0D;
            this.zedGraphhistory.Size = new System.Drawing.Size(732, 212);
            this.zedGraphhistory.TabIndex = 7;
            // 
            // Setting
            // 
            this.Setting.BackColor = System.Drawing.SystemColors.Control;
            this.Setting.Controls.Add(this.groupBox1);
            this.Setting.Controls.Add(this.groupBoxModbus);
            this.Setting.Controls.Add(this.groupBox2);
            this.Setting.Controls.Add(this.groupBoxDDS);
            this.Setting.Controls.Add(this.metroLabel2);
            this.Setting.Controls.Add(this.metroTextBoxConfigfile);
            this.Setting.Controls.Add(this.ComboBoxFreqResolution);
            this.Setting.Controls.Add(this.buttonSaveAsConfig);
            this.Setting.Controls.Add(this.buttonLoadConfig);
            this.Setting.Controls.Add(this.buttonRemoveMonitor);
            this.Setting.Controls.Add(this.buttonAddMonitor);
            this.Setting.Controls.Add(this.label1);
            this.Setting.Controls.Add(this.label27);
            this.Setting.Controls.Add(this.label26);
            this.Setting.Controls.Add(this.label25);
            this.Setting.Controls.Add(this.groupBox6);
            this.Setting.Controls.Add(this.ComboBoxBandWidth);
            this.Setting.Controls.Add(this.dataGridViewMonitorSetting);
            this.Setting.Controls.Add(this.dataGridViewChSetting);
            this.Setting.HorizontalScrollbarBarColor = true;
            this.Setting.HorizontalScrollbarHighlightOnWheel = false;
            this.Setting.HorizontalScrollbarSize = 10;
            this.Setting.Location = new System.Drawing.Point(4, 39);
            this.Setting.Name = "Setting";
            this.Setting.Size = new System.Drawing.Size(1018, 523);
            this.Setting.Style = MetroFramework.MetroColorStyle.Purple;
            this.Setting.TabIndex = 1;
            this.Setting.Text = "Setting";
            this.Setting.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Setting.VerticalScrollbarBarColor = true;
            this.Setting.VerticalScrollbarHighlightOnWheel = false;
            this.Setting.VerticalScrollbarSize = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Desktop;
            this.groupBox1.Controls.Add(this.metroCheckBoxAzure);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Location = new System.Drawing.Point(736, 390);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 58);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Azure";
            // 
            // metroCheckBoxAzure
            // 
            this.metroCheckBoxAzure.AutoSize = true;
            this.metroCheckBoxAzure.Location = new System.Drawing.Point(6, 21);
            this.metroCheckBoxAzure.Name = "metroCheckBoxAzure";
            this.metroCheckBoxAzure.Size = new System.Drawing.Size(57, 17);
            this.metroCheckBoxAzure.TabIndex = 24;
            this.metroCheckBoxAzure.Text = "Azure";
            this.metroCheckBoxAzure.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroCheckBoxAzure.UseSelectable = true;
            this.metroCheckBoxAzure.CheckedChanged += new System.EventHandler(this.metroCheckBoxAzure_CheckedChanged);
            // 
            // groupBoxModbus
            // 
            this.groupBoxModbus.BackColor = System.Drawing.SystemColors.Desktop;
            this.groupBoxModbus.Controls.Add(this.metroCheckBoxModbus);
            this.groupBoxModbus.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBoxModbus.Location = new System.Drawing.Point(736, 316);
            this.groupBoxModbus.Name = "groupBoxModbus";
            this.groupBoxModbus.Size = new System.Drawing.Size(206, 55);
            this.groupBoxModbus.TabIndex = 29;
            this.groupBoxModbus.TabStop = false;
            this.groupBoxModbus.Text = "Modbus";
            // 
            // metroCheckBoxModbus
            // 
            this.metroCheckBoxModbus.AutoSize = true;
            this.metroCheckBoxModbus.Location = new System.Drawing.Point(6, 21);
            this.metroCheckBoxModbus.Name = "metroCheckBoxModbus";
            this.metroCheckBoxModbus.Size = new System.Drawing.Size(78, 17);
            this.metroCheckBoxModbus.TabIndex = 24;
            this.metroCheckBoxModbus.Text = "OA Value";
            this.metroCheckBoxModbus.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroCheckBoxModbus.UseSelectable = true;
            this.metroCheckBoxModbus.CheckedChanged += new System.EventHandler(this.metroCheckBoxModbus_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Desktop;
            this.groupBox2.Controls.Add(this.metroLabel4);
            this.groupBox2.Controls.Add(this.textBoxMCMID);
            this.groupBox2.Controls.Add(this.metroLabel3);
            this.groupBox2.Controls.Add(this.ipAddressControlText);
            this.groupBox2.Controls.Add(this.metroCheckBoxMqttRaw);
            this.groupBox2.Controls.Add(this.metroCheckBoxMqtt);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Location = new System.Drawing.Point(736, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 208);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MQTT";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(6, 151);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(63, 20);
            this.metroLabel4.TabIndex = 34;
            this.metroLabel4.Text = "Local ID";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // textBoxMCMID
            // 
            this.textBoxMCMID.BackColor = System.Drawing.SystemColors.Desktop;
            this.textBoxMCMID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxMCMID.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.textBoxMCMID.Location = new System.Drawing.Point(5, 174);
            this.textBoxMCMID.Name = "textBoxMCMID";
            this.textBoxMCMID.Size = new System.Drawing.Size(128, 22);
            this.textBoxMCMID.TabIndex = 33;
            this.textBoxMCMID.TextChanged += new System.EventHandler(this.textBoxMCMID_TextChanged);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(6, 105);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(127, 20);
            this.metroLabel3.TabIndex = 24;
            this.metroLabel3.Text = "Broker IP Address";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // ipAddressControlText
            // 
            this.ipAddressControlText.AllowInternalTab = false;
            this.ipAddressControlText.AutoHeight = true;
            this.ipAddressControlText.BackColor = System.Drawing.SystemColors.Desktop;
            this.ipAddressControlText.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ipAddressControlText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ipAddressControlText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ipAddressControlText.Location = new System.Drawing.Point(6, 128);
            this.ipAddressControlText.MinimumSize = new System.Drawing.Size(87, 22);
            this.ipAddressControlText.Name = "ipAddressControlText";
            this.ipAddressControlText.ReadOnly = false;
            this.ipAddressControlText.Size = new System.Drawing.Size(127, 22);
            this.ipAddressControlText.TabIndex = 32;
            this.ipAddressControlText.Text = "...";
            this.ipAddressControlText.TextChanged += new System.EventHandler(this.ipAddressControlText_TextChanged);
            // 
            // metroCheckBoxMqttRaw
            // 
            this.metroCheckBoxMqttRaw.AutoSize = true;
            this.metroCheckBoxMqttRaw.Location = new System.Drawing.Point(6, 64);
            this.metroCheckBoxMqttRaw.Name = "metroCheckBoxMqttRaw";
            this.metroCheckBoxMqttRaw.Size = new System.Drawing.Size(79, 17);
            this.metroCheckBoxMqttRaw.TabIndex = 31;
            this.metroCheckBoxMqttRaw.Text = "Raw Data";
            this.metroCheckBoxMqttRaw.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroCheckBoxMqttRaw.UseSelectable = true;
            this.metroCheckBoxMqttRaw.CheckedChanged += new System.EventHandler(this.metroCheckBoxMqttRaw_CheckedChanged);
            // 
            // metroCheckBoxMqtt
            // 
            this.metroCheckBoxMqtt.AutoSize = true;
            this.metroCheckBoxMqtt.Location = new System.Drawing.Point(6, 27);
            this.metroCheckBoxMqtt.Name = "metroCheckBoxMqtt";
            this.metroCheckBoxMqtt.Size = new System.Drawing.Size(78, 17);
            this.metroCheckBoxMqtt.TabIndex = 27;
            this.metroCheckBoxMqtt.Text = "OA Value";
            this.metroCheckBoxMqtt.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroCheckBoxMqtt.UseSelectable = true;
            this.metroCheckBoxMqtt.CheckedChanged += new System.EventHandler(this.metroCheckBoxMqtt_CheckedChanged);
            // 
            // groupBoxDDS
            // 
            this.groupBoxDDS.BackColor = System.Drawing.SystemColors.Desktop;
            this.groupBoxDDS.Controls.Add(this.checkBoxDDS);
            this.groupBoxDDS.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBoxDDS.Location = new System.Drawing.Point(736, 22);
            this.groupBoxDDS.Name = "groupBoxDDS";
            this.groupBoxDDS.Size = new System.Drawing.Size(200, 52);
            this.groupBoxDDS.TabIndex = 22;
            this.groupBoxDDS.TabStop = false;
            this.groupBoxDDS.Text = "Web Service";
            // 
            // checkBoxDDS
            // 
            this.checkBoxDDS.AutoSize = true;
            this.checkBoxDDS.ForeColor = System.Drawing.SystemColors.Desktop;
            this.checkBoxDDS.Location = new System.Drawing.Point(7, 21);
            this.checkBoxDDS.Name = "checkBoxDDS";
            this.checkBoxDDS.Size = new System.Drawing.Size(78, 17);
            this.checkBoxDDS.TabIndex = 23;
            this.checkBoxDDS.Text = "OA Value";
            this.checkBoxDDS.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.checkBoxDDS.UseSelectable = true;
            this.checkBoxDDS.CheckedChanged += new System.EventHandler(this.checkBoxDDS_CheckedChanged);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(0, 4);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(130, 20);
            this.metroLabel2.TabIndex = 26;
            this.metroLabel2.Text = "Configuration File";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroTextBoxConfigfile
            // 
            this.metroTextBoxConfigfile.Lines = new string[0];
            this.metroTextBoxConfigfile.Location = new System.Drawing.Point(133, 3);
            this.metroTextBoxConfigfile.MaxLength = 32767;
            this.metroTextBoxConfigfile.Name = "metroTextBoxConfigfile";
            this.metroTextBoxConfigfile.PasswordChar = '\0';
            this.metroTextBoxConfigfile.ReadOnly = true;
            this.metroTextBoxConfigfile.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxConfigfile.SelectedText = "";
            this.metroTextBoxConfigfile.Size = new System.Drawing.Size(387, 23);
            this.metroTextBoxConfigfile.TabIndex = 25;
            this.metroTextBoxConfigfile.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTextBoxConfigfile.UseSelectable = true;
            // 
            // ComboBoxFreqResolution
            // 
            this.ComboBoxFreqResolution.FormattingEnabled = true;
            this.ComboBoxFreqResolution.ItemHeight = 24;
            this.ComboBoxFreqResolution.Items.AddRange(new object[] {
            "1Hz",
            "2Hz",
            "4Hz"});
            this.ComboBoxFreqResolution.Location = new System.Drawing.Point(560, 161);
            this.ComboBoxFreqResolution.Name = "ComboBoxFreqResolution";
            this.ComboBoxFreqResolution.Size = new System.Drawing.Size(139, 30);
            this.ComboBoxFreqResolution.TabIndex = 22;
            this.ComboBoxFreqResolution.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ComboBoxFreqResolution.UseSelectable = true;
            this.ComboBoxFreqResolution.SelectedIndexChanged += new System.EventHandler(this.ComboBoxFreqResolution_SelectedIndexChanged);
            // 
            // buttonSaveAsConfig
            // 
            this.buttonSaveAsConfig.Location = new System.Drawing.Point(560, 38);
            this.buttonSaveAsConfig.Name = "buttonSaveAsConfig";
            this.buttonSaveAsConfig.Size = new System.Drawing.Size(139, 42);
            this.buttonSaveAsConfig.TabIndex = 21;
            this.buttonSaveAsConfig.Text = "Save As Config";
            this.buttonSaveAsConfig.UseVisualStyleBackColor = true;
            this.buttonSaveAsConfig.Click += new System.EventHandler(this.buttonSaveAsConfig_Click);
            // 
            // buttonLoadConfig
            // 
            this.buttonLoadConfig.Location = new System.Drawing.Point(325, 35);
            this.buttonLoadConfig.Name = "buttonLoadConfig";
            this.buttonLoadConfig.Size = new System.Drawing.Size(139, 42);
            this.buttonLoadConfig.TabIndex = 20;
            this.buttonLoadConfig.Text = "Load Configuration";
            this.buttonLoadConfig.UseVisualStyleBackColor = true;
            this.buttonLoadConfig.Click += new System.EventHandler(this.buttonLoadConfig_Click);
            // 
            // buttonRemoveMonitor
            // 
            this.buttonRemoveMonitor.Location = new System.Drawing.Point(450, 482);
            this.buttonRemoveMonitor.Name = "buttonRemoveMonitor";
            this.buttonRemoveMonitor.Size = new System.Drawing.Size(170, 38);
            this.buttonRemoveMonitor.TabIndex = 19;
            this.buttonRemoveMonitor.Text = "Remove Monitor Setting";
            this.buttonRemoveMonitor.UseVisualStyleBackColor = true;
            this.buttonRemoveMonitor.Click += new System.EventHandler(this.buttonRemoveMonitor_Click);
            // 
            // buttonAddMonitor
            // 
            this.buttonAddMonitor.Location = new System.Drawing.Point(65, 481);
            this.buttonAddMonitor.Name = "buttonAddMonitor";
            this.buttonAddMonitor.Size = new System.Drawing.Size(170, 38);
            this.buttonAddMonitor.TabIndex = 19;
            this.buttonAddMonitor.Text = "Add Monitor Setting";
            this.buttonAddMonitor.UseVisualStyleBackColor = true;
            this.buttonAddMonitor.Click += new System.EventHandler(this.buttonAddMonitor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Desktop;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(558, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "Frequency Resolution";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.SystemColors.Desktop;
            this.label27.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label27.Location = new System.Drawing.Point(323, 138);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(59, 12);
            this.label27.TabIndex = 16;
            this.label27.Text = "BandWidth";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.SystemColors.Desktop;
            this.label26.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label26.Location = new System.Drawing.Point(1, 334);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(166, 12);
            this.label26.TabIndex = 16;
            this.label26.Text = "Over All Value Monitoring Setting";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.SystemColors.Desktop;
            this.label25.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label25.Location = new System.Drawing.Point(1, 202);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(79, 12);
            this.label25.TabIndex = 16;
            this.label25.Text = "Channel Setting";
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.SystemColors.Desktop;
            this.groupBox6.Controls.Add(this.metroLabel1);
            this.groupBox6.Controls.Add(this.metroLabel22);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.TextBoxHDspace);
            this.groupBox6.Controls.Add(this.TextBoxNormalAverages);
            this.groupBox6.Controls.Add(this.TextBoxNormalSechedule);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.checkBoxTextDataRecord);
            this.groupBox6.Controls.Add(this.checkBoxNormalDataRecord);
            this.groupBox6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox6.Location = new System.Drawing.Point(3, 22);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(314, 169);
            this.groupBox6.TabIndex = 16;
            this.groupBox6.TabStop = false;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(213, 135);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(28, 20);
            this.metroLabel1.TabIndex = 21;
            this.metroLabel1.Text = "GB";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel22
            // 
            this.metroLabel22.AutoSize = true;
            this.metroLabel22.Location = new System.Drawing.Point(217, 38);
            this.metroLabel22.Name = "metroLabel22";
            this.metroLabel22.Size = new System.Drawing.Size(15, 20);
            this.metroLabel22.TabIndex = 21;
            this.metroLabel22.Text = "s";
            this.metroLabel22.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 139);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(78, 12);
            this.label16.TabIndex = 16;
            this.label16.Text = "Keep HD Space";
            // 
            // TextBoxHDspace
            // 
            this.TextBoxHDspace.Lines = new string[] {
        "5"};
            this.TextBoxHDspace.Location = new System.Drawing.Point(89, 134);
            this.TextBoxHDspace.MaxLength = 32767;
            this.TextBoxHDspace.Name = "TextBoxHDspace";
            this.TextBoxHDspace.PasswordChar = '\0';
            this.TextBoxHDspace.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxHDspace.SelectedText = "";
            this.TextBoxHDspace.Size = new System.Drawing.Size(122, 23);
            this.TextBoxHDspace.TabIndex = 21;
            this.TextBoxHDspace.Text = "5";
            this.TextBoxHDspace.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TextBoxHDspace.UseSelectable = true;
            this.TextBoxHDspace.TextChanged += new System.EventHandler(this.TextBoxHDspace_TextChanged);
            this.TextBoxHDspace.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxHDspace_Validating);
            // 
            // TextBoxNormalAverages
            // 
            this.TextBoxNormalAverages.Lines = new string[] {
        "10"};
            this.TextBoxNormalAverages.Location = new System.Drawing.Point(89, 84);
            this.TextBoxNormalAverages.MaxLength = 32767;
            this.TextBoxNormalAverages.Name = "TextBoxNormalAverages";
            this.TextBoxNormalAverages.PasswordChar = '\0';
            this.TextBoxNormalAverages.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxNormalAverages.SelectedText = "";
            this.TextBoxNormalAverages.Size = new System.Drawing.Size(122, 23);
            this.TextBoxNormalAverages.TabIndex = 20;
            this.TextBoxNormalAverages.Text = "10";
            this.TextBoxNormalAverages.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TextBoxNormalAverages.UseSelectable = true;
            this.TextBoxNormalAverages.TextChanged += new System.EventHandler(this.TextBoxNormalAverages_TextChanged);
            this.TextBoxNormalAverages.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxNormalAverages_Validating);
            // 
            // TextBoxNormalSechedule
            // 
            this.TextBoxNormalSechedule.Lines = new string[] {
        "60"};
            this.TextBoxNormalSechedule.Location = new System.Drawing.Point(89, 36);
            this.TextBoxNormalSechedule.MaxLength = 32767;
            this.TextBoxNormalSechedule.Name = "TextBoxNormalSechedule";
            this.TextBoxNormalSechedule.PasswordChar = '\0';
            this.TextBoxNormalSechedule.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxNormalSechedule.SelectedText = "";
            this.TextBoxNormalSechedule.Size = new System.Drawing.Size(122, 23);
            this.TextBoxNormalSechedule.TabIndex = 19;
            this.TextBoxNormalSechedule.Text = "60";
            this.TextBoxNormalSechedule.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TextBoxNormalSechedule.UseSelectable = true;
            this.TextBoxNormalSechedule.TextChanged += new System.EventHandler(this.TextBoxNormalSechedule_TextChanged);
            this.TextBoxNormalSechedule.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxNormalSechedule_Validating);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 89);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 12);
            this.label15.TabIndex = 16;
            this.label15.Text = "Average times";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 12);
            this.label11.TabIndex = 16;
            this.label11.Text = "Schedule";
            // 
            // checkBoxTextDataRecord
            // 
            this.checkBoxTextDataRecord.AutoSize = true;
            this.checkBoxTextDataRecord.Location = new System.Drawing.Point(154, 12);
            this.checkBoxTextDataRecord.Name = "checkBoxTextDataRecord";
            this.checkBoxTextDataRecord.Size = new System.Drawing.Size(155, 17);
            this.checkBoxTextDataRecord.TabIndex = 20;
            this.checkBoxTextDataRecord.Text = "RAW Data Record(csv)";
            this.checkBoxTextDataRecord.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.checkBoxTextDataRecord.UseSelectable = true;
            this.checkBoxTextDataRecord.CheckedChanged += new System.EventHandler(this.checkBoxTextDataRecord_CheckedChanged);
            // 
            // checkBoxNormalDataRecord
            // 
            this.checkBoxNormalDataRecord.AutoSize = true;
            this.checkBoxNormalDataRecord.BackColor = System.Drawing.SystemColors.Desktop;
            this.checkBoxNormalDataRecord.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBoxNormalDataRecord.Location = new System.Drawing.Point(5, 12);
            this.checkBoxNormalDataRecord.Name = "checkBoxNormalDataRecord";
            this.checkBoxNormalDataRecord.Size = new System.Drawing.Size(146, 17);
            this.checkBoxNormalDataRecord.TabIndex = 19;
            this.checkBoxNormalDataRecord.Text = "FFT Data Record(csv)";
            this.checkBoxNormalDataRecord.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.checkBoxNormalDataRecord.UseSelectable = true;
            this.checkBoxNormalDataRecord.CheckedChanged += new System.EventHandler(this.checkBoxNormalDataRecord_CheckedChanged);
            // 
            // ComboBoxBandWidth
            // 
            this.ComboBoxBandWidth.BackColor = System.Drawing.SystemColors.Control;
            this.ComboBoxBandWidth.FormattingEnabled = true;
            this.ComboBoxBandWidth.ItemHeight = 24;
            this.ComboBoxBandWidth.Items.AddRange(new object[] {
            "40K",
            "20K",
            "10K",
            "5K",
            "2K",
            "1K",
            "500"});
            this.ComboBoxBandWidth.Location = new System.Drawing.Point(325, 161);
            this.ComboBoxBandWidth.Name = "ComboBoxBandWidth";
            this.ComboBoxBandWidth.Size = new System.Drawing.Size(139, 30);
            this.ComboBoxBandWidth.TabIndex = 18;
            this.ComboBoxBandWidth.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ComboBoxBandWidth.UseSelectable = true;
            this.ComboBoxBandWidth.SelectedIndexChanged += new System.EventHandler(this.ComboBoxBandWidth_SelectedIndexChanged);
            // 
            // dataGridViewMonitorSetting
            // 
            this.dataGridViewMonitorSetting.BackgroundColor = System.Drawing.SystemColors.Desktop;
            this.dataGridViewMonitorSetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMonitorSetting.Location = new System.Drawing.Point(0, 351);
            this.dataGridViewMonitorSetting.Name = "dataGridViewMonitorSetting";
            this.dataGridViewMonitorSetting.RowTemplate.Height = 24;
            this.dataGridViewMonitorSetting.Size = new System.Drawing.Size(702, 125);
            this.dataGridViewMonitorSetting.TabIndex = 16;
            this.dataGridViewMonitorSetting.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewMonitorSetting_CellValidating);
            this.dataGridViewMonitorSetting.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMonitorSetting_CellValueChanged);
            // 
            // dataGridViewChSetting
            // 
            this.dataGridViewChSetting.AccessibleName = "";
            this.dataGridViewChSetting.BackgroundColor = System.Drawing.SystemColors.Desktop;
            this.dataGridViewChSetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewChSetting.Location = new System.Drawing.Point(0, 219);
            this.dataGridViewChSetting.Name = "dataGridViewChSetting";
            this.dataGridViewChSetting.RowTemplate.Height = 24;
            this.dataGridViewChSetting.Size = new System.Drawing.Size(702, 104);
            this.dataGridViewChSetting.TabIndex = 16;
            this.dataGridViewChSetting.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewChSetting_CellValidating);
            this.dataGridViewChSetting.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewChSetting_CellValueChanged);
            this.dataGridViewChSetting.SelectionChanged += new System.EventHandler(this.dataGridViewChSetting_SelectionChanged);
            // 
            // Analysis
            // 
            this.Analysis.Controls.Add(this.buttonmainwithharmonic);
            this.Analysis.Controls.Add(this.metroTextBoxmainFreq);
            this.Analysis.Controls.Add(this.label2);
            this.Analysis.Controls.Add(this.textBoxcount);
            this.Analysis.Controls.Add(this.buttonfilecombine);
            this.Analysis.Controls.Add(this.metroButtonhours);
            this.Analysis.Controls.Add(this.metroButtondays);
            this.Analysis.Controls.Add(this.metroButtonmonths);
            this.Analysis.Controls.Add(this.metroButtonyears);
            this.Analysis.Controls.Add(this.buttonAnalysisquery);
            this.Analysis.Controls.Add(this.zedGraphtimeAnalysis);
            this.Analysis.Controls.Add(this.zedGraphfftAnalysis);
            this.Analysis.Controls.Add(this.zedGraphAnalysishistory);
            this.Analysis.Controls.Add(this.dataGridViewfileAnalysis);
            this.Analysis.Controls.Add(this.dataGridViewOATrendAnalysis);
            this.Analysis.HorizontalScrollbarBarColor = true;
            this.Analysis.HorizontalScrollbarHighlightOnWheel = false;
            this.Analysis.HorizontalScrollbarSize = 10;
            this.Analysis.Location = new System.Drawing.Point(4, 39);
            this.Analysis.Name = "Analysis";
            this.Analysis.Size = new System.Drawing.Size(1018, 523);
            this.Analysis.Style = MetroFramework.MetroColorStyle.Purple;
            this.Analysis.TabIndex = 2;
            this.Analysis.Text = "Analysis";
            this.Analysis.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Analysis.VerticalScrollbarBarColor = true;
            this.Analysis.VerticalScrollbarHighlightOnWheel = false;
            this.Analysis.VerticalScrollbarSize = 10;
            // 
            // buttonmainwithharmonic
            // 
            this.buttonmainwithharmonic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonmainwithharmonic.Location = new System.Drawing.Point(231, 500);
            this.buttonmainwithharmonic.Name = "buttonmainwithharmonic";
            this.buttonmainwithharmonic.Size = new System.Drawing.Size(182, 23);
            this.buttonmainwithharmonic.TabIndex = 28;
            this.buttonmainwithharmonic.Text = "Main with Harmonic Frequency";
            this.buttonmainwithharmonic.UseVisualStyleBackColor = true;
            this.buttonmainwithharmonic.Click += new System.EventHandler(this.buttonmainwithharmonic_Click);
            // 
            // metroTextBoxmainFreq
            // 
            this.metroTextBoxmainFreq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroTextBoxmainFreq.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.metroTextBoxmainFreq.Lines = new string[] {
        "1"};
            this.metroTextBoxmainFreq.Location = new System.Drawing.Point(415, 501);
            this.metroTextBoxmainFreq.MaxLength = 32767;
            this.metroTextBoxmainFreq.Name = "metroTextBoxmainFreq";
            this.metroTextBoxmainFreq.PasswordChar = '\0';
            this.metroTextBoxmainFreq.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxmainFreq.SelectedText = "";
            this.metroTextBoxmainFreq.Size = new System.Drawing.Size(45, 23);
            this.metroTextBoxmainFreq.TabIndex = 27;
            this.metroTextBoxmainFreq.Text = "1";
            this.metroTextBoxmainFreq.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxmainFreq.UseSelectable = true;
            this.metroTextBoxmainFreq.Validating += new System.ComponentModel.CancelEventHandler(this.metroTextBoxmainFreq_Validating);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Desktop;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(463, 506);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 12);
            this.label2.TabIndex = 26;
            this.label2.Text = "Hz";
            // 
            // textBoxcount
            // 
            this.textBoxcount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxcount.BackColor = System.Drawing.SystemColors.Desktop;
            this.textBoxcount.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxcount.Location = new System.Drawing.Point(177, 247);
            this.textBoxcount.Name = "textBoxcount";
            this.textBoxcount.Size = new System.Drawing.Size(54, 22);
            this.textBoxcount.TabIndex = 13;
            // 
            // buttonfilecombine
            // 
            this.buttonfilecombine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonfilecombine.Location = new System.Drawing.Point(72, 247);
            this.buttonfilecombine.Name = "buttonfilecombine";
            this.buttonfilecombine.Size = new System.Drawing.Size(100, 23);
            this.buttonfilecombine.TabIndex = 12;
            this.buttonfilecombine.Text = "File Combination";
            this.buttonfilecombine.UseVisualStyleBackColor = true;
            this.buttonfilecombine.Click += new System.EventHandler(this.buttonfilecombine_Click);
            // 
            // metroButtonhours
            // 
            this.metroButtonhours.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.metroButtonhours.BackColor = System.Drawing.SystemColors.Highlight;
            this.metroButtonhours.Location = new System.Drawing.Point(391, 248);
            this.metroButtonhours.Name = "metroButtonhours";
            this.metroButtonhours.Size = new System.Drawing.Size(123, 23);
            this.metroButtonhours.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButtonhours.TabIndex = 11;
            this.metroButtonhours.Text = "Hours";
            this.metroButtonhours.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroButtonhours.UseSelectable = true;
            this.metroButtonhours.Click += new System.EventHandler(this.metroButtonhours_Click);
            // 
            // metroButtondays
            // 
            this.metroButtondays.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.metroButtondays.BackColor = System.Drawing.SystemColors.Highlight;
            this.metroButtondays.Location = new System.Drawing.Point(520, 247);
            this.metroButtondays.Name = "metroButtondays";
            this.metroButtondays.Size = new System.Drawing.Size(123, 23);
            this.metroButtondays.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButtondays.TabIndex = 10;
            this.metroButtondays.Text = "Days";
            this.metroButtondays.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroButtondays.UseSelectable = true;
            this.metroButtondays.Click += new System.EventHandler(this.metroButtondays_Click);
            // 
            // metroButtonmonths
            // 
            this.metroButtonmonths.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.metroButtonmonths.BackColor = System.Drawing.SystemColors.Highlight;
            this.metroButtonmonths.Location = new System.Drawing.Point(649, 247);
            this.metroButtonmonths.Name = "metroButtonmonths";
            this.metroButtonmonths.Size = new System.Drawing.Size(123, 23);
            this.metroButtonmonths.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButtonmonths.TabIndex = 9;
            this.metroButtonmonths.Text = "Months";
            this.metroButtonmonths.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroButtonmonths.UseSelectable = true;
            this.metroButtonmonths.Click += new System.EventHandler(this.metroButtonmonths_Click);
            // 
            // metroButtonyears
            // 
            this.metroButtonyears.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.metroButtonyears.BackColor = System.Drawing.SystemColors.Highlight;
            this.metroButtonyears.Location = new System.Drawing.Point(778, 247);
            this.metroButtonyears.Name = "metroButtonyears";
            this.metroButtonyears.Size = new System.Drawing.Size(123, 23);
            this.metroButtonyears.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButtonyears.TabIndex = 8;
            this.metroButtonyears.Text = "Years";
            this.metroButtonyears.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroButtonyears.UseSelectable = true;
            this.metroButtonyears.Click += new System.EventHandler(this.metroButtonyears_Click);
            // 
            // buttonAnalysisquery
            // 
            this.buttonAnalysisquery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAnalysisquery.Location = new System.Drawing.Point(1, 247);
            this.buttonAnalysisquery.Name = "buttonAnalysisquery";
            this.buttonAnalysisquery.Size = new System.Drawing.Size(70, 23);
            this.buttonAnalysisquery.TabIndex = 7;
            this.buttonAnalysisquery.Text = "Search";
            this.buttonAnalysisquery.UseVisualStyleBackColor = true;
            this.buttonAnalysisquery.Click += new System.EventHandler(this.buttonAnalysisquery_Click);
            // 
            // zedGraphtimeAnalysis
            // 
            this.zedGraphtimeAnalysis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphtimeAnalysis.Location = new System.Drawing.Point(632, 276);
            this.zedGraphtimeAnalysis.Name = "zedGraphtimeAnalysis";
            this.zedGraphtimeAnalysis.ScrollGrace = 0D;
            this.zedGraphtimeAnalysis.ScrollMaxX = 0D;
            this.zedGraphtimeAnalysis.ScrollMaxY = 0D;
            this.zedGraphtimeAnalysis.ScrollMaxY2 = 0D;
            this.zedGraphtimeAnalysis.ScrollMinX = 0D;
            this.zedGraphtimeAnalysis.ScrollMinY = 0D;
            this.zedGraphtimeAnalysis.ScrollMinY2 = 0D;
            this.zedGraphtimeAnalysis.Size = new System.Drawing.Size(383, 223);
            this.zedGraphtimeAnalysis.TabIndex = 6;
            // 
            // zedGraphfftAnalysis
            // 
            this.zedGraphfftAnalysis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphfftAnalysis.IsShowPointValues = true;
            this.zedGraphfftAnalysis.IsSynchronizeXAxes = true;
            this.zedGraphfftAnalysis.Location = new System.Drawing.Point(232, 277);
            this.zedGraphfftAnalysis.Name = "zedGraphfftAnalysis";
            this.zedGraphfftAnalysis.ScrollGrace = 0D;
            this.zedGraphfftAnalysis.ScrollMaxX = 0D;
            this.zedGraphfftAnalysis.ScrollMaxY = 0D;
            this.zedGraphfftAnalysis.ScrollMaxY2 = 0D;
            this.zedGraphfftAnalysis.ScrollMinX = 0D;
            this.zedGraphfftAnalysis.ScrollMinY = 0D;
            this.zedGraphfftAnalysis.ScrollMinY2 = 0D;
            this.zedGraphfftAnalysis.Size = new System.Drawing.Size(394, 223);
            this.zedGraphfftAnalysis.TabIndex = 5;
            this.zedGraphfftAnalysis.Resize += new System.EventHandler(this.zedGraphfftAnalysis_Resize);
            // 
            // zedGraphAnalysishistory
            // 
            this.zedGraphAnalysishistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphAnalysishistory.Location = new System.Drawing.Point(232, 3);
            this.zedGraphAnalysishistory.Name = "zedGraphAnalysishistory";
            this.zedGraphAnalysishistory.ScrollGrace = 0D;
            this.zedGraphAnalysishistory.ScrollMaxX = 0D;
            this.zedGraphAnalysishistory.ScrollMaxY = 0D;
            this.zedGraphAnalysishistory.ScrollMaxY2 = 0D;
            this.zedGraphAnalysishistory.ScrollMinX = 0D;
            this.zedGraphAnalysishistory.ScrollMinY = 0D;
            this.zedGraphAnalysishistory.ScrollMinY2 = 0D;
            this.zedGraphAnalysishistory.Size = new System.Drawing.Size(783, 238);
            this.zedGraphAnalysishistory.TabIndex = 4;
            this.zedGraphAnalysishistory.MouseClick += new System.Windows.Forms.MouseEventHandler(this.zedGraphAnalysishistory_MouseClick);
            this.zedGraphAnalysishistory.MouseMove += new System.Windows.Forms.MouseEventHandler(this.zedGraphAnalysishistory_MouseMove);
            // 
            // dataGridViewfileAnalysis
            // 
            this.dataGridViewfileAnalysis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewfileAnalysis.BackgroundColor = System.Drawing.SystemColors.Desktop;
            this.dataGridViewfileAnalysis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewfileAnalysis.Location = new System.Drawing.Point(3, 276);
            this.dataGridViewfileAnalysis.Name = "dataGridViewfileAnalysis";
            this.dataGridViewfileAnalysis.RowTemplate.Height = 24;
            this.dataGridViewfileAnalysis.Size = new System.Drawing.Size(223, 224);
            this.dataGridViewfileAnalysis.TabIndex = 3;
            this.dataGridViewfileAnalysis.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewfileAnalysis_CellContentClick);
            this.dataGridViewfileAnalysis.SelectionChanged += new System.EventHandler(this.dataGridViewfileAnalysis_SelectionChanged);
            // 
            // dataGridViewOATrendAnalysis
            // 
            this.dataGridViewOATrendAnalysis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewOATrendAnalysis.BackgroundColor = System.Drawing.SystemColors.Desktop;
            this.dataGridViewOATrendAnalysis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOATrendAnalysis.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewOATrendAnalysis.Name = "dataGridViewOATrendAnalysis";
            this.dataGridViewOATrendAnalysis.RowTemplate.Height = 24;
            this.dataGridViewOATrendAnalysis.Size = new System.Drawing.Size(220, 238);
            this.dataGridViewOATrendAnalysis.TabIndex = 2;
            this.dataGridViewOATrendAnalysis.SelectionChanged += new System.EventHandler(this.dataGridViewOATrendAnalysis_SelectionChanged);
            // 
            // textBox1daqtime
            // 
            this.textBox1daqtime.Location = new System.Drawing.Point(1061, 141);
            this.textBox1daqtime.Name = "textBox1daqtime";
            this.textBox1daqtime.Size = new System.Drawing.Size(54, 22);
            this.textBox1daqtime.TabIndex = 21;
            // 
            // richTextBoxAlarm
            // 
            this.richTextBoxAlarm.BackColor = System.Drawing.Color.YellowGreen;
            this.richTextBoxAlarm.Location = new System.Drawing.Point(23, 25);
            this.richTextBoxAlarm.Name = "richTextBoxAlarm";
            this.richTextBoxAlarm.Size = new System.Drawing.Size(165, 32);
            this.richTextBoxAlarm.TabIndex = 23;
            this.richTextBoxAlarm.Text = "";
            this.richTextBoxAlarm.ZoomFactor = 1.5F;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 631);
            this.Controls.Add(this.richTextBoxAlarm);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.textBox1daqtime);
            this.Name = "Form1";
            this.Style = MetroFramework.MetroColorStyle.Purple;
            this.Text = "Machine Condition Monitoring";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TransparencyKey = System.Drawing.Color.LawnGreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.machinestatus.ResumeLayout(false);
            this.machinestatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlarmLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOATrend)).EndInit();
            this.Setting.ResumeLayout(false);
            this.Setting.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxModbus.ResumeLayout(false);
            this.groupBoxModbus.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxDDS.ResumeLayout(false);
            this.groupBoxDDS.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMonitorSetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChSetting)).EndInit();
            this.Analysis.ResumeLayout(false);
            this.Analysis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewfileAnalysis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOATrendAnalysis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage machinestatus;
        private MetroFramework.Controls.MetroTabPage Setting;
        private ZedGraph.ZedGraphControl zedGraphfft;
        private ZedGraph.ZedGraphControl zedGraphtime;
        private ZedGraph.ZedGraphControl zedGraphhistory;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dataGridViewOATrend;
        private MetroFramework.Controls.MetroCheckBox checkBoxTextDataRecord;
        private System.Windows.Forms.GroupBox groupBox6;
        private MetroFramework.Controls.MetroCheckBox checkBoxNormalDataRecord;
        private MetroFramework.Controls.MetroComboBox ComboBoxBandWidth;
        private System.Windows.Forms.DataGridView dataGridViewMonitorSetting;
        private System.Windows.Forms.DataGridView dataGridViewChSetting;
        private MetroFramework.Controls.MetroTextBox TextBoxHDspace;
        private System.Windows.Forms.Label label16;
        private MetroFramework.Controls.MetroLabel metroLabel22;
        private MetroFramework.Controls.MetroTextBox TextBoxNormalAverages;
        private MetroFramework.Controls.MetroTextBox TextBoxNormalSechedule;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button buttonRemoveMonitor;
        private System.Windows.Forms.Button buttonAddMonitor;
        private System.Windows.Forms.Button buttonLoadConfig;
        private System.Windows.Forms.Button buttonSaveAsConfig;
        private System.Windows.Forms.TextBox textBox1daqtime;
        private System.Windows.Forms.DataGridView dataGridViewAlarmLog;
        private System.Windows.Forms.Button buttonquery;
        private MetroFramework.Controls.MetroComboBox ComboBoxFreqResolution;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroTabPage Analysis;
        private ZedGraph.ZedGraphControl zedGraphtimeAnalysis;
        private ZedGraph.ZedGraphControl zedGraphfftAnalysis;
        private ZedGraph.ZedGraphControl zedGraphAnalysishistory;
        private System.Windows.Forms.DataGridView dataGridViewfileAnalysis;
        private System.Windows.Forms.DataGridView dataGridViewOATrendAnalysis;
        private System.Windows.Forms.Button buttonAnalysisquery;
        private MetroFramework.Controls.MetroButton metroButtonhours;
        private MetroFramework.Controls.MetroButton metroButtondays;
        private MetroFramework.Controls.MetroButton metroButtonmonths;
        private MetroFramework.Controls.MetroButton metroButtonyears;
        private System.Windows.Forms.RichTextBox richTextBoxAlarm;
        private MetroFramework.Controls.MetroCheckBox checkBoxDDS;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.RadioButton radioButtonFFTCh0;
        private System.Windows.Forms.RadioButton radioButtonFFTCh1;
        private System.Windows.Forms.RadioButton radioButtonFFTCh2;
        private System.Windows.Forms.RadioButton radioButtonFFTCh3;
        private MetroFramework.Controls.MetroCheckBox metroCheckBoxAzure;
        private MetroFramework.Controls.MetroCheckBox metroCheckBoxModbus;
        private System.Windows.Forms.Button buttonfilecombine;
        private System.Windows.Forms.TextBox textBoxcount;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroTextBox metroTextBoxmainFreq;
        private System.Windows.Forms.Button buttonmainwithharmonic;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox metroTextBoxConfigfile;
        private MetroFramework.Controls.MetroCheckBox metroCheckBoxMqtt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBoxModbus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBoxDDS;
        private MetroFramework.Controls.MetroCheckBox metroCheckBoxMqttRaw;
        private IPAddressControlLib.IPAddressControl ipAddressControlText;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private System.Windows.Forms.TextBox textBoxMCMID;
        private MetroFramework.Controls.MetroLabel metroLabel3;
    }
}

