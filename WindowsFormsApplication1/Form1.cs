using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Threading;
using ZedGraph;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using MCMDB;
using System.Text.RegularExpressions;
using ManagedAudioLibrary;
using Newtonsoft.Json.Linq;
using System.IO.Ports;
using Modbus.Data;
using Modbus.Device;
using Modbus.Serial;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Collections.Concurrent;
using Microsoft.Azure.Devices.Client;
namespace WindowsFormsApplication1
{
    public partial class Form1 : MetroForm
    {
        Form2 myForm2;
        public DateTime currentstartdate, startdate, enddate;
        BindingSource _Source = new BindingSource();
        program_config Config = new program_config();
        program_config Analyze = new program_config();
        MCMDataBase database = new MCMDataBase();
        MCMDataBase configdatabase = new MCMDataBase();
        MCMDataBase Analysisdatabase = new MCMDataBase();
        OpenFileDialog dlgopen = new OpenFileDialog();
        SaveFileDialog dlgsave = new SaveFileDialog();
        device_config daqcontrol = new device_config();
        spectrum_config spectrum = new spectrum_config();
        CallbackDelegate ai_buf_ready_cbdel;
        Thread thdtrend, DataQueue;
        public delegate void DisplayInvoke();
        public delegate void DisplayTrend(double[] datadate, double[] OAvaluecolum, double warning, double alarm, string OAUnit);
        PointPairList userCursorsList = new PointPairList();
        LineItem userCursorsCurve = new LineItem("userCursorsCurve");
        string RowDatafolderPath;
        DirectoryInfo dir;
        DriveInfo space;
        Stopwatch sw;
        public StreamWriter txtWtr;
        ManagedAudioLibrary.Spectrum spectrumdata, anaspectrumdata;
        HanningWindow windowfunc;
        //IContinueScaleDataWriter fooDW;
        //EDAQ.ContinueScale my2405daq;
        //InstanceHandle myHandle;
        JObject chname = new JObject();
        JObject chObject = new JObject();
        JObject topicName = new JObject();
        JObject chValue = new JObject();
        JObject chValues = new JObject();
        JObject rawdata = new JObject();
        JArray ch0rawdataarray = new JArray();
        JArray ch1rawdataarray = new JArray();
        JArray ch2rawdataarray = new JArray();
        JArray ch3rawdataarray = new JArray();
        private static DeviceClient _deviceClient;
        const int SENDING_CHANNELVALUEDEMO_TIMER = 5000; // ChannelValuedemo data sending timer, default 5 seconds
        string x1_val = "0.0000", x1_sts = "Normal", y2_val = "0.0000", y2_sts = "Normal", z3_val = "0.0000", z3_sts = "Normal";
        static SerialPort slave_port;
        static ModbusSlave slave;
        static byte unitId = 1; // UID shoule be designd by reading from INI/Config file
        const ushort line_offset = 100;
        const ushort line_name_offset = 1;
        const ushort line_unit_offset = 33;
        const ushort line_oa_offset = 41;
        const ushort line_sts_offset = 45;

        string RawDatafolderPath;
        string OutputDatafolderPath;

        DirectoryInfo dirRaw;
        List<string> filenames;
        string[] line;
        string[] totalline;
        string[] frequency;
        string[] unitname;
        string[] data;
        string nm;
        int count = 0;
        FileStream outputchraw;
        StreamWriter csvWtrraw;
        Thread thdcombine;
        MqttClient mqtt_client;
        ConcurrentQueue<Queuedata> myqueue = new ConcurrentQueue<Queuedata>();
        Queuedata qindata = new Queuedata();
        Queuedata qoutdata = new Queuedata();
        public class Queuedata
        {
            public DateTime logtime;
            public double[] RawData;          
        }
        public class program_config
        {
            //Monitoring Setting DataGirdColumn
            public string MonitorName { get; set; }
            public string MonitorStartFreq { get; set; }
            public string MonitorEndFreq { get; set; }
            public string MonitorAlarm { get; set; }
            public string MonitorWarning { get; set; }
            public string[] UIParameter;
            public string[] UIColumnName;
            public string[] UIColumnNameWithType;
            public string[,] ChannelParameter;
            public string[] ChannelColumnName;
            public string[] ChannelRow;
            public int ChanneCurRow;
            public int OATrendCurRow;
            public int OATrendAnalysisCurRow;
            public string[] ChannelColumnNameWithType;
            public string[,] MonitorParameterCh0;
            public string[,] MonitorParameterCh1;
            public string[,] MonitorParameterCh2;
            public string[,] MonitorParameterCh3;
            public string[] MonitorInsertparameter;
            public string[] MonitorRow;
            public string[] MonitorColumnName;
            public string[] MonitorColumnNameWithType;
            public string[] AlarmColumnName;
            public string[] AlarmColumnNameWithType;
            public string[] AlarmParameter;
            public string[] ConfigTableName;
            public string[] OATreandColumnName;
            public string[] OATreandParameter;
            public string[] OATreandColumnNameWithType;
            public string[] OATableColumnName;
            public string[] OATableColumnNameWithType;
            public string[,] OATableParameter;
            public string[] OATableName;
            public string ConfigFileName;
            public string ConfigFolder;
            public DateTime TrendDateTime;
            public uint averageindex;
            public bool averageenable;
            public double[] OAvaluecolum;
            public string[,] OAvalueParameter;
            public double[] datadate;
            public bool firstupdate;
            public bool firsttime;
            public double alarm;
            public double warning;
            public FileStream outputch;
            public StreamWriter csvWtr;
            public BinaryWriter binWtr;
            public string path;
            public int monitorlength0;
            public int monitorlength1;
            public int monitorlength2;
            public int monitorlength3;
            public bool Ch0alarm;
            public bool Ch1alarm;
            public bool Ch2alarm;
            public bool Ch3alarm;
            public uint Sysalarm;
            public uint Syswarning;
            public uint Sysnormal;
            public bool StorageAlarm;
            public long AvailableSpace;
            public long gb = 1000000000;
            public long HDspaces;
            public string OAUnit;
            public string[] DDSChannelname;
            public string[] Status;
            public string[] Analysistablename;
            public uint memsizereturn;
            public uint allchannelmemsize;
            public string[] ComPort;
            public bool Modbusenable;
            public bool Modbuserror;
            public bool DDSenble;
            public bool DDSerror;
            public bool Azureenable;
            public bool Azureerror;
            public bool Mqttenable;
            public bool Mqtterror;
            public string sysname;
            public string broker_ip;
        }
        public class device_config
        {
            public short result;
            public ushort Ch0config;
            public ushort[] Chconfig;
            public double samplerate;
            public uint numbchans;
            public ushort[] ai_chans;
            public ushort[] ai_chansenable;
            public ushort[] ai_chans_range;
            public IntPtr airowdata;
            public uint allchanlength;
            public uint perchanlength;
            public uint resolution;
            public uint AccessCnt;
            public double[] aivoltagedata;
            public double[] tempvoltagedata;
            public double[] ch0data;
            public double[] ch1data;
            public double[] ch2data;
            public double[] ch3data;
            public double[] ch0averagedata;
            public double[] ch1averagedata;
            public double[] ch2averagedata;
            public double[] ch3averagedata;
            public double[] dtx;
            public int callbackindex;

        }
        public class spectrum_config
        {
            public uint spectrumlength;
            public double[] ch0spectrumdata;
            public double[] ch1spectrumdata;
            public double[] ch2spectrumdata;
            public double[] ch3spectrumdata;
            public double[] ch0averagespectrumdata;
            public double[] ch1averagespectrumdata;
            public double[] ch2averagespectrumdata;
            public double[] ch3averagespectrumdata;
            public double[] dfx;
            public double df;
            public double OA;
            public double[] Analysisdfx;
            public double[] Anaspectrum;
            public double Analysisdfxresolution;

        }
        public Form1()
        {
            InitializeComponent();
            this.metroTabControl1.SelectedIndexChanged -= new System.EventHandler(this.metroTabControl1_SelectedIndexChanged);
            this.dataGridViewMonitorSetting.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMonitorSetting_CellValueChanged);
            this.dataGridViewChSetting.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewChSetting_CellValueChanged);
            this.dataGridViewChSetting.SelectionChanged -= new System.EventHandler(this.dataGridViewChSetting_SelectionChanged);

            ConfigureDataGrid();
            this.dataGridViewMonitorSetting.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMonitorSetting_CellValueChanged);
            this.dataGridViewChSetting.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewChSetting_CellValueChanged);
            this.dataGridViewChSetting.SelectionChanged += new System.EventHandler(this.dataGridViewChSetting_SelectionChanged);



            InitialDAQ();
            InuZedgraphcolor();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (ProgramIsRunning(@"C:\mcm\mcm.exe"))
            {
                ProgramKill(@"C:\mcm\mcm.exe");
            }
            if (ProgramIsRunning(@"C:\Program Files\nodejs\node.exe"))
            {
                ProgramKill(@"C:\Program Files\nodejs\node.exe");
            }
            //ProgramRun(@"C:\mcm\mcm.exe");
            //this.Location = new Point(0, 0);
            //this.Size = Screen.PrimaryScreen.WorkingArea.Size;          
            Config.Modbusenable = false;
            Config.DDSenble = false;
            Config.Azureenable = false;
            Config.Mqttenable = false;
            Config.Modbuserror = false;
            Config.DDSerror = false;
            Config.Azureerror = false;
            Config.Mqtterror = false;
            spectrumdata = new ManagedAudioLibrary.Spectrum();
            anaspectrumdata = new ManagedAudioLibrary.Spectrum();
            windowfunc = new HanningWindow();
            spectrumdata.SetWindowFunction(windowfunc);
            anaspectrumdata.SetWindowFunction(windowfunc);
            richTextBoxAlarm.BackColor = Color.YellowGreen;
            Config.StorageAlarm = false;
            sw = Stopwatch.StartNew();
            ai_buf_ready_cbdel = new CallbackDelegate(ai_buf_ready_cbfunc);
            CreateIfMissing("c:\\ADLINK\\MCM\\DataBase");
            CreateIfMissing("c:\\ADLINK\\MCM\\INI");
            bool filecheck = File.Exists("c:\\ADLINK\\MCM\\INI\\DBPath.ini");
            if (!filecheck)
            {
                txtWtr = new StreamWriter("c:\\ADLINK\\MCM\\INI\\DBPath.ini", false);
                txtWtr.Write("c:\\ADLINK\\MCM\\DataBase\\MCM.db");
                txtWtr.Close();
                Config.ConfigFolder = File.ReadAllText("c:\\ADLINK\\MCM\\INI\\DBPath.ini", Encoding.UTF8);
            }
            else
            {
                Config.ConfigFolder = File.ReadAllText("c:\\ADLINK\\MCM\\INI\\DBPath.ini", Encoding.UTF8);
                filecheck = File.Exists(Config.ConfigFolder);
                if (!filecheck)
                {
                    InitialOpenFilebyDialog();
                }
            }
            space = new DriveInfo("c");
            Config.Ch0alarm = false; Config.Ch1alarm = false; Config.Ch2alarm = false; Config.Ch3alarm = false;
            thdtrend = new Thread(trend);
            DataQueue = new Thread(ProcessQueue);
            thdcombine = new Thread(filecount);
            Config.ConfigFileName = Config.ConfigFolder.Substring(Config.ConfigFolder.LastIndexOf("\\") + 1, (Config.ConfigFolder.IndexOf(".db") - Config.ConfigFolder.LastIndexOf("\\") - 1));
            CreateIfMissing("c:\\ADLINK\\MCM\\Data\\All FFTData\\" + Config.ConfigFileName + "\\" + DateTime.Now.ToString("yyyy-MM-dd"));
            CreateIfMissing("c:\\ADLINK\\MCM\\Data\\All RAWData\\" + Config.ConfigFileName + "\\" + DateTime.Now.ToString("yyyy-MM-dd"));
            CreateIfMissing("c:\\ADLINK\\MCM\\Data\\Alarm RAWData\\" + Config.ConfigFileName + "\\" + DateTime.Now.ToString("yyyy-MM-dd"));
            metroTextBoxConfigfile.Text = Config.ConfigFileName;
            Config.averageindex = 0;
            Config.averageenable = false;
            Config.firstupdate = true;
            Config.firsttime = true;
            metroTabControl1.SelectedTab = machinestatus;
            getBrokerIP();
            InitialProcess();
            MCMInitialOATrendArray();
            
            if (this.metroCheckBoxAzure.Checked)
            {
                Azure();
            }           
            UpateDeviceConfig();
            if ((Config.allchannelmemsize < Config.memsizereturn) && !(Config.DDSerror || Config.Azureerror || Config.Modbuserror || Config.Mqtterror))
            {
                UpateSpectrumConfig();
                Configuredaq();
                thdtrend.Start();
                DataQueue.Start();

            }
            else
            {
                if ((Config.allchannelmemsize > Config.memsizereturn))
                {
                    MessageBox.Show("Please increase buffer allocated of USB-2405 to 8192KB by USBUtil.exe(C:\\ADLINK\\UDASK\\Utility\\USBUtil.exe) then reboot your computer");
                    Process.GetCurrentProcess().Kill();
                }
                metroTabControl1.SelectedTab = Setting;
            }
            this.metroTabControl1.SelectedIndexChanged += new System.EventHandler(this.metroTabControl1_SelectedIndexChanged);
            this.zedGraphAnalysishistory.IsShowPointValues = true;
            this.zedGraphhistory.IsShowPointValues = true;

        }
        private void InitialProcess()
        {

            this.dataGridViewMonitorSetting.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMonitorSetting_CellValueChanged);
            this.dataGridViewChSetting.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewChSetting_CellValueChanged);
            this.dataGridViewChSetting.SelectionChanged -= new System.EventHandler(this.dataGridViewChSetting_SelectionChanged);
            MCMIniDB();
            MCMInitialUI();
            MCMInitialChsetting();
            MCMInitialMonitor(Config.MonitorParameterCh0);
            ButtonDisable();
            this.dataGridViewMonitorSetting.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMonitorSetting_CellValueChanged);
            this.dataGridViewChSetting.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewChSetting_CellValueChanged);
            this.dataGridViewChSetting.SelectionChanged += new System.EventHandler(this.dataGridViewChSetting_SelectionChanged);
        }
        private void MCMIniDB()
        {
            try
            {
                //Connect ConfigureDB
                database.Connect(Config.ConfigFolder);
                Config.ConfigTableName = new string[] { "UI", "Channel", "MonitorCh0", "MonitorCh1", "MonitorCh2", "MonitorCh3", "OATable", "AlarmLog" };
                //Load UI ini
                database.InitialColumn("c:\\ADLINK\\MCM\\INI", "UI");
                Config.UIColumnName = new string[database.ColumnNamelist.GetLongLength(0)];
                Config.UIColumnNameWithType = new string[database.ColumnNameWithType.GetLongLength(0)];
                Array.Copy(database.ColumnNamelist, Config.UIColumnName, database.ColumnNamelist.GetLongLength(0));
                Array.Copy(database.ColumnNameWithType, Config.UIColumnNameWithType, database.ColumnNamelist.GetLongLength(0));

                //Load Channel ini
                database.InitialColumn("c:\\ADLINK\\MCM\\INI", "Channel");
                Config.ChannelColumnName = new string[database.ColumnNamelist.GetLongLength(0)];
                Config.ChannelColumnNameWithType = new string[database.ColumnNameWithType.GetLongLength(0)];
                Array.Copy(database.ColumnNamelist, Config.ChannelColumnName, database.ColumnNamelist.GetLongLength(0));
                Array.Copy(database.ColumnNameWithType, Config.ChannelColumnNameWithType, database.ColumnNamelist.GetLongLength(0));

                //Load Monitor ini
                database.InitialColumn("c:\\ADLINK\\MCM\\INI", "Monitor");
                Config.MonitorColumnName = new string[database.ColumnNamelist.GetLongLength(0)];
                Config.MonitorColumnNameWithType = new string[database.ColumnNameWithType.GetLongLength(0)];
                Array.Copy(database.ColumnNamelist, Config.MonitorColumnName, database.ColumnNamelist.GetLongLength(0));
                Array.Copy(database.ColumnNameWithType, Config.MonitorColumnNameWithType, database.ColumnNamelist.GetLongLength(0));
                //Load OATableName ini
                database.InitialColumn("c:\\ADLINK\\MCM\\INI", "OAName");
                Config.OATableColumnName = new string[database.ColumnNamelist.GetLongLength(0)];
                Config.OATableColumnNameWithType = new string[database.ColumnNameWithType.GetLongLength(0)];
                Array.Copy(database.ColumnNamelist, Config.OATableColumnName, database.ColumnNamelist.GetLongLength(0));
                Array.Copy(database.ColumnNameWithType, Config.OATableColumnNameWithType, database.ColumnNamelist.GetLongLength(0));

                //Load OATrandTable ini
                //Trenddatabase.Connect("c:\\MCM\\DataBase",DBName + "TrendData");
                Analysisdatabase.Connect(Config.ConfigFolder); ;
                database.InitialColumn("c:\\ADLINK\\MCM\\INI", "OA");
                Config.OATreandColumnName = new string[database.ColumnNamelist.GetLongLength(0)];
                Config.OATreandParameter = new string[database.ColumnNamelist.GetLongLength(0)];
                Config.OATreandColumnNameWithType = new string[database.ColumnNameWithType.GetLongLength(0)];
                Array.Copy(database.ColumnNamelist, Config.OATreandColumnName, database.ColumnNamelist.GetLongLength(0));
                Array.Copy(database.ColumnNameWithType, Config.OATreandColumnNameWithType, database.ColumnNamelist.GetLongLength(0));

                database.InitialColumn("c:\\ADLINK\\MCM\\INI", "AlarmLog");
                Config.AlarmColumnName = new string[database.ColumnNamelist.GetLongLength(0)];
                Config.AlarmColumnNameWithType = new string[database.ColumnNameWithType.GetLongLength(0)];
                Config.AlarmParameter = new string[database.ColumnNamelist.GetLongLength(0)];
                Array.Copy(database.ColumnNamelist, Config.AlarmColumnName, database.ColumnNamelist.GetLongLength(0));
                Array.Copy(database.ColumnNameWithType, Config.AlarmColumnNameWithType, database.ColumnNamelist.GetLongLength(0));

                Config.MonitorInsertparameter = new string[6] { "New", "g rms", "10", "1000", "1", "2" };

                //Initial Table if ConfigureDB doesn't exist 
                if (database.filecheck == false)
                {
                    //Initial UI Table when Table is empty
                    database.CreateTable(Config.ConfigTableName[0], Config.UIColumnNameWithType);
                    Config.UIParameter = new string[]
                   {

                    "False","False","False","False","True","False","False","False","False","False","60","1","True","10","10K","4Hz"

                   };
                    //Initial UI Table when Table is empty
                    database.InsertTable(Config.ConfigTableName[0], Config.UIColumnName, Config.UIParameter);
                    //Initial Channel Table when Table is empty     
                    database.CreateTable(Config.ConfigTableName[1], Config.ChannelColumnNameWithType);
                    Config.ChannelParameter = new string[,]
                    {
                    {"CH0","True","Accelermeter","1000","0.00","AC" },{"CH1","False","Accelermeter","1000","0.00","AC"},{"CH2","False","Accelermeter","1000","0.00","AC" },{"CH3","False","Accelermeter","1000","0.00","AC"}
                    };
                    database.InsertTable2D(Config.ConfigTableName[1], Config.ChannelColumnName, Config.ChannelParameter);
                    //Initial Monitor Table when Table is empty
                    database.CreateTable(Config.ConfigTableName[2], Config.MonitorColumnNameWithType);
                    //Initial Monitor Table when Table is empty
                    database.CreateTable(Config.ConfigTableName[3], Config.MonitorColumnNameWithType);
                    //Initial Monitor Table when Table is empty
                    database.CreateTable(Config.ConfigTableName[4], Config.MonitorColumnNameWithType);
                    //Initial Monitor Table when Table is empty
                    database.CreateTable(Config.ConfigTableName[5], Config.MonitorColumnNameWithType);
                    //Initial OA Table when Table is empty
                    database.CreateTable(Config.ConfigTableName[6], Config.OATableColumnNameWithType);
                    //Initial AlarmLog Table when Table is empty
                    database.CreateTable(Config.ConfigTableName[7], Config.AlarmColumnNameWithType);

                }
                UpdateUIArray();
                UpdateOANameArray();
                UpdateChannelArray();
                UpdateMonitorCh0Array();
                UpdateMonitorCh1Array();
                UpdateMonitorCh2Array();
                UpdateMonitorCh3Array();

            }
            catch (Exception ex)
            {

                MessageBox.Show("MCMIniDB Error!" + "\n" + ex.Message);
            }

        }
        private void MCMAlarmlog()
        {
            Analysisdatabase.SelectTable(Config.ConfigTableName[7]);
            this.dataGridViewAlarmLog.DataSource = Analysisdatabase.data;
            this.dataGridViewAlarmLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAlarmLog.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewAlarmLog.Columns[0].HeaderText = "Index";
            this.dataGridViewAlarmLog.Columns[0].ReadOnly = true;
            this.dataGridViewAlarmLog.Columns[0].Width = 40;
            this.dataGridViewAlarmLog.Columns[1].HeaderText = "Information";
            this.dataGridViewAlarmLog.Columns[1].ReadOnly = true;
            this.dataGridViewAlarmLog.Columns[2].HeaderText = "Time";
            this.dataGridViewAlarmLog.Columns[2].ReadOnly = true;
            this.dataGridViewAlarmLog.Columns[2].Width = 110;

            this.dataGridViewAlarmLog.DefaultCellStyle.BackColor = Color.Black;
            this.dataGridViewAlarmLog.DefaultCellStyle.ForeColor = Color.White;
            this.dataGridViewAlarmLog.EnableHeadersVisualStyles = false;
            this.dataGridViewAlarmLog.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            this.dataGridViewAlarmLog.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dataGridViewAlarmLog.RowHeadersDefaultCellStyle.BackColor = Color.Black;
        }
        private void UpdateStatusColor()
        {

            for (int i = 0; i < Config.OAvalueParameter.GetLength(0); i++)
            {
                if (Convert.ToDouble(Config.OAvalueParameter[i, 3]) > Convert.ToDouble(Config.OAvalueParameter[i, 5]))
                {
                    dataGridViewOATrend.Rows[i].Cells[2].Style.BackColor = Color.Red;
                }
                else if (Convert.ToDouble(Config.OAvalueParameter[i, 3]) < Convert.ToDouble(Config.OAvalueParameter[i, 5]) && Convert.ToDouble(Config.OAvalueParameter[i, 3]) > Convert.ToDouble(Config.OAvalueParameter[i, 6]))
                {

                    dataGridViewOATrend.Rows[i].Cells[2].Style.BackColor = Color.DarkOrange;
                }
                else
                {

                    dataGridViewOATrend.Rows[i].Cells[2].Style.BackColor = Color.YellowGreen;
                }


            }
        }
        private void UpdateAlarmLog()
        {
            Config.Ch0alarm = false; Config.Ch1alarm = false; Config.Ch2alarm = false; Config.Ch3alarm = false;
            Config.Sysalarm = 0; Config.Syswarning = 0; Config.Sysnormal = 0;
            for (int i = 0; i < Config.OAvalueParameter.GetLength(0); i++)
            {
                if (Convert.ToDouble(Config.OAvalueParameter[i, 3]) > Convert.ToDouble(Config.OAvalueParameter[i, 5]))
                {
                    Config.Status[i] = "Danger";
                    Config.Sysalarm = 4;
                    Config.AlarmParameter[0] = Config.OAvalueParameter[i, 1] + "_" + Config.OAvalueParameter[i, 2] + "_" + Config.OAvalueParameter[i, 3] + "_" + Config.OAvalueParameter[i, 4];
                    Config.AlarmParameter[1] = Config.TrendDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                    database.InsertTable(Config.ConfigTableName[7], Config.AlarmColumnName, Config.AlarmParameter);
                    if (Config.OAvalueParameter[i, 1] == "CH0")
                    {
                        Config.Ch0alarm = true;
                    }
                    if (Config.OAvalueParameter[i, 1] == "CH1")
                    {
                        Config.Ch1alarm = true;
                    }

                    if (Config.OAvalueParameter[i, 1] == "CH2")
                    {
                        Config.Ch2alarm = true;
                    }

                    if (Config.OAvalueParameter[i, 1] == "CH3")
                    {
                        Config.Ch3alarm = true;
                    }

                }
                else if (Convert.ToDouble(Config.OAvalueParameter[i, 3]) < Convert.ToDouble(Config.OAvalueParameter[i, 5]) && Convert.ToDouble(Config.OAvalueParameter[i, 3]) > Convert.ToDouble(Config.OAvalueParameter[i, 6]))
                {
                    Config.Status[i] = "Warning";
                    Config.Syswarning = 2;
                }
                else if (Convert.ToDouble(Config.OAvalueParameter[i, 3]) < Convert.ToDouble(Config.OAvalueParameter[i, 6]) && Convert.ToDouble(Config.OAvalueParameter[i, 3]) > Convert.ToDouble(0.05))
                {
                    Config.Status[i] = "Normal";
                    Config.Sysnormal = 1;
                }
                else
                {
                    Config.Status[i] = "Shutdown";
                }

            }


        }
        private void DIOcontrol()
        {
            if (Config.Sysalarm + Config.Syswarning + Config.Sysnormal >= 4)
            {
                daqcontrol.result = USBDASK.UD_DO_WritePort(0, 1, 0);
                daqcontrol.result = USBDASK.UD_DO_WritePort(0, 0, 0);

            }
            else if (Config.Sysalarm + Config.Syswarning + Config.Sysnormal > 1 && Config.Sysalarm + Config.Syswarning + Config.Sysnormal < 4)
            {
                daqcontrol.result = USBDASK.UD_DO_WritePort(0, 1, 1);
                daqcontrol.result = USBDASK.UD_DO_WritePort(0, 0, 0);
            }
            else
            {
                daqcontrol.result = USBDASK.UD_DO_WritePort(0, 1, 0);
                daqcontrol.result = USBDASK.UD_DO_WritePort(0, 0, 1);
            }
        }
        private void MCMInitialMonitor(string[,] MonitorParameter)
        {
            try
            {
                int height = MonitorParameter.GetLength(0);
                int width = MonitorParameter.GetLength(1);
                this.dataGridViewMonitorSetting.Rows.Clear();
                this.dataGridViewMonitorSetting.ColumnCount = width - 2;
                for (int r = 0; r < height; r++)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.dataGridViewMonitorSetting);

                    for (int c = 0; c < width - 2; c++)
                    {
                        row.Cells[c].Value = MonitorParameter[r, c + 2];
                    }

                    this.dataGridViewMonitorSetting.Rows.Add(row);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("MCMInitialMonitor Error!" + "\n" + ex.Message);
            }


        }
        private void InuZedgraphcolor()
        {
            this.zedGraphhistory.GraphPane.Fill = new Fill(Color.Black);
            this.zedGraphhistory.GraphPane.Chart.Fill = new Fill(Color.Black);
            this.zedGraphhistory.GraphPane.Chart.Border.Color = Color.White;
            this.zedGraphhistory.GraphPane.Title.FontSpec.FontColor = Color.White;
            this.zedGraphhistory.GraphPane.YAxis.Title.FontSpec.FontColor = Color.White;
            this.zedGraphhistory.GraphPane.XAxis.Title.FontSpec.FontColor = Color.White;
            this.zedGraphhistory.GraphPane.YAxis.Scale.FontSpec.FontColor = Color.White;
            this.zedGraphhistory.GraphPane.XAxis.Scale.FontSpec.FontColor = Color.White;
            this.zedGraphhistory.GraphPane.XAxis.MajorGrid.Color = Color.White;
            this.zedGraphhistory.GraphPane.YAxis.MajorGrid.Color = Color.White;
            this.zedGraphfft.GraphPane.Fill = new Fill(Color.Black);
            this.zedGraphfft.GraphPane.Chart.Fill = new Fill(Color.Black);
            this.zedGraphfft.GraphPane.Chart.Border.Color = Color.White;
            this.zedGraphfft.GraphPane.Title.FontSpec.FontColor = Color.White;
            this.zedGraphfft.GraphPane.YAxis.Title.FontSpec.FontColor = Color.White;
            this.zedGraphfft.GraphPane.XAxis.Title.FontSpec.FontColor = Color.White;
            this.zedGraphfft.GraphPane.YAxis.Scale.FontSpec.FontColor = Color.White;
            this.zedGraphfft.GraphPane.XAxis.Scale.FontSpec.FontColor = Color.White;
            this.zedGraphfft.GraphPane.XAxis.MajorGrid.Color = Color.White;
            this.zedGraphfft.GraphPane.YAxis.MajorGrid.Color = Color.White;
            this.zedGraphtime.GraphPane.Fill = new Fill(Color.Black);
            this.zedGraphtime.GraphPane.Chart.Fill = new Fill(Color.Black);
            this.zedGraphtime.GraphPane.Chart.Border.Color = Color.White;
            this.zedGraphtime.GraphPane.Title.FontSpec.FontColor = Color.White;
            this.zedGraphtime.GraphPane.YAxis.Title.FontSpec.FontColor = Color.White;
            this.zedGraphtime.GraphPane.XAxis.Title.FontSpec.FontColor = Color.White;
            this.zedGraphtime.GraphPane.YAxis.Scale.FontSpec.FontColor = Color.White;
            this.zedGraphtime.GraphPane.XAxis.Scale.FontSpec.FontColor = Color.White;
            this.zedGraphtime.GraphPane.XAxis.MajorGrid.Color = Color.White;
            this.zedGraphtime.GraphPane.YAxis.MajorGrid.Color = Color.White;

            this.zedGraphAnalysishistory.GraphPane.Fill = new Fill(Color.Black);
            this.zedGraphAnalysishistory.GraphPane.Chart.Fill = new Fill(Color.Black);
            this.zedGraphAnalysishistory.GraphPane.Chart.Border.Color = Color.White;
            this.zedGraphAnalysishistory.GraphPane.Title.FontSpec.FontColor = Color.White;
            this.zedGraphAnalysishistory.GraphPane.YAxis.Title.FontSpec.FontColor = Color.White;
            this.zedGraphAnalysishistory.GraphPane.XAxis.Title.FontSpec.FontColor = Color.White;
            this.zedGraphAnalysishistory.GraphPane.YAxis.Scale.FontSpec.FontColor = Color.White;
            this.zedGraphAnalysishistory.GraphPane.XAxis.Scale.FontSpec.FontColor = Color.White;
            this.zedGraphAnalysishistory.GraphPane.XAxis.MajorGrid.Color = Color.White;
            this.zedGraphAnalysishistory.GraphPane.YAxis.MajorGrid.Color = Color.White;
            this.zedGraphfftAnalysis.GraphPane.Fill = new Fill(Color.Black);
            this.zedGraphfftAnalysis.GraphPane.Chart.Fill = new Fill(Color.Black);
            this.zedGraphfftAnalysis.GraphPane.Chart.Border.Color = Color.White;
            this.zedGraphfftAnalysis.GraphPane.Title.FontSpec.FontColor = Color.White;
            this.zedGraphfftAnalysis.GraphPane.YAxis.Title.FontSpec.FontColor = Color.White;
            this.zedGraphfftAnalysis.GraphPane.XAxis.Title.FontSpec.FontColor = Color.White;
            this.zedGraphfftAnalysis.GraphPane.YAxis.Scale.FontSpec.FontColor = Color.White;
            this.zedGraphfftAnalysis.GraphPane.XAxis.Scale.FontSpec.FontColor = Color.White;
            this.zedGraphfftAnalysis.GraphPane.XAxis.MajorGrid.Color = Color.White;
            this.zedGraphfftAnalysis.GraphPane.YAxis.MajorGrid.Color = Color.White;

            this.zedGraphtimeAnalysis.GraphPane.Fill = new Fill(Color.Black);
            this.zedGraphtimeAnalysis.GraphPane.Chart.Fill = new Fill(Color.Black);
            this.zedGraphtimeAnalysis.GraphPane.Chart.Border.Color = Color.White;
            this.zedGraphtimeAnalysis.GraphPane.Title.FontSpec.FontColor = Color.White;
            this.zedGraphtimeAnalysis.GraphPane.YAxis.Title.FontSpec.FontColor = Color.White;
            this.zedGraphtimeAnalysis.GraphPane.XAxis.Title.FontSpec.FontColor = Color.White;
            this.zedGraphtimeAnalysis.GraphPane.YAxis.Scale.FontSpec.FontColor = Color.White;
            this.zedGraphtimeAnalysis.GraphPane.XAxis.Scale.FontSpec.FontColor = Color.White;
            this.zedGraphtimeAnalysis.GraphPane.XAxis.MajorGrid.Color = Color.White;
            this.zedGraphtimeAnalysis.GraphPane.YAxis.MajorGrid.Color = Color.White;
        }
        private void MCMInitialUI()
        {

            this.radioButtonFFTCh0.CheckedChanged -= new System.EventHandler(this.radioButtonFFTCh0_CheckedChanged);
            this.radioButtonFFTCh1.CheckedChanged -= new System.EventHandler(this.radioButtonFFTCh1_CheckedChanged);
            this.radioButtonFFTCh2.CheckedChanged -= new System.EventHandler(this.radioButtonFFTCh2_CheckedChanged);
            this.radioButtonFFTCh3.CheckedChanged -= new System.EventHandler(this.radioButtonFFTCh3_CheckedChanged);
            this.checkBoxNormalDataRecord.CheckedChanged -= new System.EventHandler(this.checkBoxNormalDataRecord_CheckedChanged);
            this.checkBoxTextDataRecord.CheckedChanged -= new System.EventHandler(this.checkBoxTextDataRecord_CheckedChanged);
            
            this.metroCheckBoxAzure.CheckedChanged -= new System.EventHandler(this.metroCheckBoxAzure_CheckedChanged);           
            this.TextBoxHDspace.TextChanged -= new System.EventHandler(this.TextBoxHDspace_TextChanged);
            this.TextBoxNormalAverages.TextChanged -= new System.EventHandler(this.TextBoxNormalAverages_TextChanged);
            this.TextBoxNormalSechedule.TextChanged -= new System.EventHandler(this.TextBoxNormalSechedule_TextChanged);
            this.ComboBoxBandWidth.SelectedIndexChanged -= new System.EventHandler(this.ComboBoxBandWidth_SelectedIndexChanged);
            this.ComboBoxFreqResolution.SelectedIndexChanged -= new System.EventHandler(this.ComboBoxFreqResolution_SelectedIndexChanged);

            this.metroCheckBoxAzure.Checked = Convert.ToBoolean(Config.UIParameter[0]);          
            this.radioButtonFFTCh0.Checked = Convert.ToBoolean(Config.UIParameter[4]);
            this.radioButtonFFTCh1.Checked = Convert.ToBoolean(Config.UIParameter[5]);
            this.radioButtonFFTCh2.Checked = Convert.ToBoolean(Config.UIParameter[6]);
            this.radioButtonFFTCh3.Checked = Convert.ToBoolean(Config.UIParameter[7]);
            this.checkBoxNormalDataRecord.Checked = Convert.ToBoolean(Config.UIParameter[8]);
            this.checkBoxTextDataRecord.Checked = Convert.ToBoolean(Config.UIParameter[9]);
            this.TextBoxNormalSechedule.Text = Config.UIParameter[10];
            this.TextBoxNormalAverages.Text = Config.UIParameter[11];
            this.TextBoxHDspace.Text = Config.UIParameter[13];
            this.ComboBoxBandWidth.SelectedItem = Config.UIParameter[14];
            this.ComboBoxFreqResolution.SelectedItem = Config.UIParameter[15];
            this.radioButtonFFTCh0.CheckedChanged += new System.EventHandler(this.radioButtonFFTCh0_CheckedChanged);
            this.radioButtonFFTCh1.CheckedChanged += new System.EventHandler(this.radioButtonFFTCh1_CheckedChanged);
            this.radioButtonFFTCh2.CheckedChanged += new System.EventHandler(this.radioButtonFFTCh2_CheckedChanged);
            this.radioButtonFFTCh3.CheckedChanged += new System.EventHandler(this.radioButtonFFTCh3_CheckedChanged);
            this.checkBoxNormalDataRecord.CheckedChanged += new System.EventHandler(this.checkBoxNormalDataRecord_CheckedChanged);
            this.checkBoxTextDataRecord.CheckedChanged += new System.EventHandler(this.checkBoxTextDataRecord_CheckedChanged);
           
            this.metroCheckBoxAzure.CheckedChanged += new System.EventHandler(this.metroCheckBoxAzure_CheckedChanged);           
            this.TextBoxHDspace.TextChanged += new System.EventHandler(this.TextBoxHDspace_TextChanged);
            this.TextBoxNormalAverages.TextChanged += new System.EventHandler(this.TextBoxNormalAverages_TextChanged);
            this.TextBoxNormalSechedule.TextChanged += new System.EventHandler(this.TextBoxNormalSechedule_TextChanged);
            this.ComboBoxBandWidth.SelectedIndexChanged += new System.EventHandler(this.ComboBoxBandWidth_SelectedIndexChanged);
            this.ComboBoxFreqResolution.SelectedIndexChanged += new System.EventHandler(this.ComboBoxFreqResolution_SelectedIndexChanged);
        }
        private void ConfigureAnalysis()
        {
            Analysisdatabase.SelectTable(Config.ConfigTableName[6]);
            if (Analysisdatabase.data.Rows.Count > 0)
            {

                this.dataGridViewOATrendAnalysis.SelectionChanged -= new System.EventHandler(this.dataGridViewOATrendAnalysis_SelectionChanged);
                this.dataGridViewOATrendAnalysis.Rows.Clear();

                Config.Analysistablename = new string[Analysisdatabase.data.Rows.Count];
                for (int i = 0; i < Analysisdatabase.data.Rows.Count; i++)
                {
                    Config.Analysistablename[i] = Convert.ToString(Analysisdatabase.data.Rows[i]["OAName"]);
                }
                int height = Config.Analysistablename.GetLength(0);
                this.dataGridViewOATrendAnalysis.ColumnCount = 1;
                this.dataGridViewOATrendAnalysis.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                this.dataGridViewOATrendAnalysis.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                this.dataGridViewOATrendAnalysis.Columns[0].HeaderText = "Name";
                this.dataGridViewOATrendAnalysis.Columns[0].ReadOnly = true;

                this.dataGridViewOATrendAnalysis.DefaultCellStyle.BackColor = Color.Black;
                this.dataGridViewOATrendAnalysis.DefaultCellStyle.ForeColor = Color.White;
                this.dataGridViewOATrendAnalysis.EnableHeadersVisualStyles = false;
                this.dataGridViewOATrendAnalysis.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                this.dataGridViewOATrendAnalysis.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                this.dataGridViewOATrendAnalysis.RowHeadersDefaultCellStyle.BackColor = Color.Black;

                for (int r = 0; r < height; r++)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.dataGridViewOATrendAnalysis);
                    row.Cells[0].Value = Config.Analysistablename[r].Substring(0, Config.Analysistablename[r].LastIndexOf("_"));
                    this.dataGridViewOATrendAnalysis.Rows.Add(row);
                }

                this.dataGridViewOATrendAnalysis.SelectionChanged += new System.EventHandler(this.dataGridViewOATrendAnalysis_SelectionChanged);
                this.dataGridViewOATrendAnalysis.Rows[0].Selected = true;
            }
        }
        private void ConfigureDataGrid()
        {
            this.dataGridViewChSetting.Rows.Clear();
            this.dataGridViewMonitorSetting.Rows.Clear();
            this.dataGridViewOATrend.Rows.Clear();
            this.dataGridViewAlarmLog.Rows.Clear();
            DataGridViewComboBoxColumn MonitorComBoboxcolumn = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn ChannelComBoboxcolumn = new DataGridViewComboBoxColumn();
            DataGridViewCheckBoxColumn CheckBoxlColumn = new DataGridViewCheckBoxColumn();

            this.dataGridViewMonitorSetting.AutoGenerateColumns = false;
            this.dataGridViewMonitorSetting.AllowUserToAddRows = false;
            this.dataGridViewMonitorSetting.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMonitorSetting.ColumnCount = 6;
            this.dataGridViewMonitorSetting.Columns[0].HeaderText = "Name";

            MonitorComBoboxcolumn.Items.AddRange("g pk", "g rms", "mm/s pk", "mm/s rms", "um pp");
            MonitorComBoboxcolumn.DisplayStyleForCurrentCellOnly = true;
            this.dataGridViewMonitorSetting.Columns.Insert(1, MonitorComBoboxcolumn);
            this.dataGridViewMonitorSetting.Columns[1].HeaderText = "Unit";
            this.dataGridViewMonitorSetting.Columns[2].HeaderText = "Start Frequency";
            this.dataGridViewMonitorSetting.Columns[3].HeaderText = "Stop Frequency";
            this.dataGridViewMonitorSetting.Columns[4].HeaderText = "Warning";
            this.dataGridViewMonitorSetting.Columns[5].HeaderText = "Alarm";
            this.dataGridViewMonitorSetting.Columns.RemoveAt(6);

            this.dataGridViewMonitorSetting.DefaultCellStyle.BackColor = Color.Black;
            this.dataGridViewMonitorSetting.DefaultCellStyle.ForeColor = Color.White;
            this.dataGridViewMonitorSetting.EnableHeadersVisualStyles = false;
            this.dataGridViewMonitorSetting.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            this.dataGridViewMonitorSetting.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dataGridViewMonitorSetting.RowHeadersDefaultCellStyle.BackColor = Color.Black;


            this.dataGridViewChSetting.AutoGenerateColumns = false;
            this.dataGridViewChSetting.AllowUserToAddRows = false;
            this.dataGridViewChSetting.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewChSetting.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewChSetting.ColumnCount = 6;
            this.dataGridViewChSetting.Columns[0].HeaderText = "Channel";
            this.dataGridViewChSetting.Columns[0].ReadOnly = true;

            this.dataGridViewChSetting.Columns.Insert(1, CheckBoxlColumn);
            this.dataGridViewChSetting.Columns[1].HeaderText = "Enabled";
            this.dataGridViewChSetting.Columns[2].HeaderText = "Type";
            this.dataGridViewChSetting.Columns[2].Width = 120;
            this.dataGridViewChSetting.Columns[3].HeaderText = "Sensitivity mv/g";
            this.dataGridViewChSetting.Columns[4].HeaderText = "High Pass Filter";
            this.dataGridViewChSetting.Columns[4].Visible = false;
            this.dataGridViewChSetting.Columns[4].Width = 0;
            ChannelComBoboxcolumn.Items.AddRange("AC", "DC", "IEPE");
            ChannelComBoboxcolumn.DisplayStyleForCurrentCellOnly = true;
            this.dataGridViewChSetting.Columns.Insert(5, ChannelComBoboxcolumn);
            this.dataGridViewChSetting.Columns[5].HeaderText = "Model";
            this.dataGridViewChSetting.Columns.RemoveAt(6);
            this.dataGridViewChSetting.Columns.RemoveAt(6);

            this.dataGridViewChSetting.DefaultCellStyle.BackColor = Color.Black;
            this.dataGridViewChSetting.DefaultCellStyle.ForeColor = Color.White;
            this.dataGridViewChSetting.EnableHeadersVisualStyles = false;
            this.dataGridViewChSetting.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            this.dataGridViewChSetting.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dataGridViewChSetting.RowHeadersDefaultCellStyle.BackColor = Color.Black;


            this.dataGridViewOATrend.AutoGenerateColumns = false;
            this.dataGridViewOATrend.AllowUserToAddRows = false;
            this.dataGridViewOATrend.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOATrend.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewOATrend.ColumnCount = 4;
            this.dataGridViewOATrend.Columns[0].HeaderText = "Channel";
            this.dataGridViewOATrend.Columns[0].ReadOnly = true;
            this.dataGridViewOATrend.Columns[1].HeaderText = "Name";
            this.dataGridViewOATrend.Columns[1].ReadOnly = true;
            this.dataGridViewOATrend.Columns[2].HeaderText = "Value";
            this.dataGridViewOATrend.Columns[2].ReadOnly = true;
            this.dataGridViewOATrend.Columns[3].HeaderText = "Unit";
            this.dataGridViewOATrend.Columns[3].ReadOnly = true;

            this.dataGridViewOATrend.DefaultCellStyle.BackColor = Color.Black;
            this.dataGridViewOATrend.DefaultCellStyle.ForeColor = Color.White;
            this.dataGridViewOATrend.EnableHeadersVisualStyles = false;
            this.dataGridViewOATrend.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            this.dataGridViewOATrend.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dataGridViewOATrend.RowHeadersDefaultCellStyle.BackColor = Color.Black;

            this.dataGridViewOATrendAnalysis.AllowUserToAddRows = false;
            this.dataGridViewfileAnalysis.AllowUserToAddRows = false;
            this.dataGridViewfileAnalysis.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewfileAnalysis.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewfileAnalysis.Columns.Add("Filename", "Filename");
            this.dataGridViewfileAnalysis.Columns[0].ReadOnly = true;

            this.dataGridViewfileAnalysis.DefaultCellStyle.BackColor = Color.Black;
            this.dataGridViewfileAnalysis.DefaultCellStyle.ForeColor = Color.White;
            this.dataGridViewfileAnalysis.EnableHeadersVisualStyles = false;
            this.dataGridViewfileAnalysis.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            this.dataGridViewfileAnalysis.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dataGridViewfileAnalysis.RowHeadersDefaultCellStyle.BackColor = Color.Black;

        }
        private void UpdateUIArray()
        {
            // Select UI Data from Table when Table already have had data 
            database.SelectTable(Config.ConfigTableName[0]);
            Config.UIParameter = new string[database.data.Columns.Count - 1];
            for (int i = 0; i < database.data.Columns.Count - 1; i++)
            {
                Config.UIParameter[i] = Convert.ToString(database.data.Rows[0][i + 1]);
            }
        }
        private void UpdateChannelArray()
        {
            // Select Channel Data from Table when Table already have had data 
            database.SelectTable(Config.ConfigTableName[1]);
            Config.ChannelParameter = new string[database.data.Rows.Count, database.data.Columns.Count];

            for (int i = 0; i < database.data.Rows.Count; i++)
            {
                for (int j = 0; j < database.data.Columns.Count; j++)
                {
                    Config.ChannelParameter[i, j] = Convert.ToString(database.data.Rows[i][j]);
                }
            }

        }
        private void UpdateMonitorCh0Array()
        {
            //Select MonitorParameterCh0 Data from Table when Table already have had data
            database.SelectTable(Config.ConfigTableName[2]);
            Config.MonitorParameterCh0 = new string[database.data.Rows.Count, database.data.Columns.Count];

            for (int i = 0; i < database.data.Rows.Count; i++)
            {
                for (int j = 0; j < database.data.Columns.Count; j++)
                {
                    Config.MonitorParameterCh0[i, j] = Convert.ToString(database.data.Rows[i][j]);
                }
            }
        }
        private void UpdateMonitorCh1Array()
        {
            //Select MonitorParameterCh1 Data from Table when Table already have had data
            database.SelectTable(Config.ConfigTableName[3]);
            Config.MonitorParameterCh1 = new string[database.data.Rows.Count, database.data.Columns.Count];
            for (int i = 0; i < database.data.Rows.Count; i++)
            {
                for (int j = 0; j < database.data.Columns.Count; j++)
                {
                    Config.MonitorParameterCh1[i, j] = Convert.ToString(database.data.Rows[i][j]);
                }
            }
        }
        private void UpdateMonitorCh2Array()
        {
            //Select MonitorParameterCh2 Data from Table when Table already have had data
            database.SelectTable(Config.ConfigTableName[4]);
            Config.MonitorParameterCh2 = new string[database.data.Rows.Count, database.data.Columns.Count];

            for (int i = 0; i < database.data.Rows.Count; i++)
            {
                for (int j = 0; j < database.data.Columns.Count; j++)
                {
                    Config.MonitorParameterCh2[i, j] = Convert.ToString(database.data.Rows[i][j]);
                }
            }
        }
        private void UpdateMonitorCh3Array()
        {
            //Select MonitorParameterCh3 Data from Table when Table already have had data
            database.SelectTable(Config.ConfigTableName[5]);
            Config.MonitorParameterCh3 = new string[database.data.Rows.Count, database.data.Columns.Count];

            for (int i = 0; i < database.data.Rows.Count; i++)
            {
                for (int j = 0; j < database.data.Columns.Count; j++)
                {
                    Config.MonitorParameterCh3[i, j] = Convert.ToString(database.data.Rows[i][j]);
                }
            }
        }
        private void UpdateOANameArray()
        {
            database.SelectTable(Config.ConfigTableName[6]);
            Config.OATableParameter = new string[database.data.Rows.Count, database.data.Columns.Count];

            for (int i = 0; i < database.data.Rows.Count; i++)
            {
                for (int j = 0; j < database.data.Columns.Count; j++)
                {
                    Config.OATableParameter[i, j] = Convert.ToString(database.data.Rows[i][j]);
                }
            }
        }
        private void MCMUIUpdate()
        {
            //Load Data From UI
            Config.UIParameter[0] = Convert.ToString(this.metroCheckBoxAzure.Checked);
            Config.UIParameter[1] = "False";//Convert.ToString(this.metroCheckBoxModbus.Checked);
            Config.UIParameter[2] = "False";//Convert.ToString(this.metroCheckBoxMqtt.Checked);
            Config.UIParameter[3] = "False";//Convert.ToString(this.metroCheckBoxMqttRaw.Checked);
            Config.UIParameter[4] = Convert.ToString(this.radioButtonFFTCh0.Checked);
            Config.UIParameter[5] = Convert.ToString(this.radioButtonFFTCh1.Checked);
            Config.UIParameter[6] = Convert.ToString(this.radioButtonFFTCh2.Checked);
            Config.UIParameter[7] = Convert.ToString(this.radioButtonFFTCh3.Checked);
            Config.UIParameter[8] = Convert.ToString(this.checkBoxNormalDataRecord.Checked);
            Config.UIParameter[9] = Convert.ToString(this.checkBoxTextDataRecord.Checked);
            Config.UIParameter[10] = this.TextBoxNormalSechedule.Text;
            Config.UIParameter[11] = this.TextBoxNormalAverages.Text;
            Config.UIParameter[12] = "False";//Convert.ToString(this.checkBoxDDS.Checked);
            Config.UIParameter[13] = this.TextBoxHDspace.Text;
            Config.UIParameter[14] = Convert.ToString(this.ComboBoxBandWidth.SelectedItem);
            Config.UIParameter[15] = Convert.ToString(this.ComboBoxFreqResolution.SelectedItem);
            //Update Data From UI
            database.UpdateTable(Config.ConfigTableName[0], Config.UIColumnName, Config.UIParameter, 1);

        }
        private void MCMInitialOATrendArray()
        {
            Config.monitorlength0 = Config.MonitorParameterCh0.GetLength(0) * Convert.ToUInt16(Convert.ToBoolean(Config.ChannelParameter[0, 2]));
            Config.monitorlength1 = Config.MonitorParameterCh1.GetLength(0) * Convert.ToUInt16(Convert.ToBoolean(Config.ChannelParameter[1, 2]));
            Config.monitorlength2 = Config.MonitorParameterCh2.GetLength(0) * Convert.ToUInt16(Convert.ToBoolean(Config.ChannelParameter[2, 2]));
            Config.monitorlength3 = Config.MonitorParameterCh3.GetLength(0) * Convert.ToUInt16(Convert.ToBoolean(Config.ChannelParameter[3, 2]));
            int OAtrendrow = Config.monitorlength0 + Config.monitorlength1 + Config.monitorlength2 + Config.monitorlength3;
            int OAtrenColumn = 9;
            Config.OAvalueParameter = new string[OAtrendrow, OAtrenColumn];
            Config.Status = new string[OAtrendrow];
            Config.DDSChannelname = new string[OAtrendrow];
            for (int i = 0; i < OAtrendrow; i++)
            {
                for (int j = 0; j < OAtrenColumn; j++)
                {
                    if (i < Config.monitorlength0)
                    {
                        if (j == 0)
                        {
                            Config.OAvalueParameter[i, j] = Config.MonitorParameterCh0[i, 1];

                        }
                        else if (j == 1)
                        {
                            Config.OAvalueParameter[i, j] = Config.ChannelParameter[0, 1];

                        }
                        else if (j == 2)
                        {
                            Config.OAvalueParameter[i, j] = Config.MonitorParameterCh0[i, 2];

                        }
                        else if (j == 3)
                        {
                            Config.OAvalueParameter[i, j] = Convert.ToString(0.0);
                        }
                        else if (j == 4)
                        {
                            Config.OAvalueParameter[i, j] = Config.MonitorParameterCh0[i, 3];
                        }
                        else if (j == 5)
                        {
                            Config.OAvalueParameter[i, j] = Config.MonitorParameterCh0[i, 7];
                        }
                        else if (j == 6)
                        {
                            Config.OAvalueParameter[i, j] = Config.MonitorParameterCh0[i, 6];
                        }
                        else if (j == 7)
                        {
                            Config.OAvalueParameter[i, j] = Config.MonitorParameterCh0[i, 4];
                        }
                        else
                        {
                            Config.OAvalueParameter[i, j] = Config.MonitorParameterCh0[i, 5];
                        }

                    }
                    else if (i >= Config.monitorlength0 && i < Config.monitorlength0 + Config.monitorlength1)
                    {
                        if (j == 0)
                        {
                            Config.OAvalueParameter[i, j] = Config.MonitorParameterCh1[i - Config.monitorlength0, 1];

                        }
                        else if (j == 1)
                        {
                            Config.OAvalueParameter[i, j] = Config.ChannelParameter[1, 1];

                        }
                        else if (j == 2)
                        {
                            Config.OAvalueParameter[i, j] = Config.MonitorParameterCh1[i - Config.monitorlength0, 2];

                        }
                        else if (j == 3)
                        {
                            Config.OAvalueParameter[i, j] = Convert.ToString(0.0);
                        }
                        else if (j == 4)
                        {
                            Config.OAvalueParameter[i, j] = Config.MonitorParameterCh1[i - Config.monitorlength0, 3];
                        }
                        else if (j == 5)
                        {
                            Config.OAvalueParameter[i, j] = Config.MonitorParameterCh1[i - Config.monitorlength0, 7];
                        }
                        else if (j == 6)
                        {
                            Config.OAvalueParameter[i, j] = Config.MonitorParameterCh1[i - Config.monitorlength0, 6];
                        }
                        else if (j == 7)
                        {
                            Config.OAvalueParameter[i, j] = Config.MonitorParameterCh1[i - Config.monitorlength0, 4];
                        }
                        else
                        {
                            Config.OAvalueParameter[i, j] = Config.MonitorParameterCh1[i - Config.monitorlength0, 5];
                        }
                    }
                    else if (i >= Config.monitorlength0 + Config.monitorlength1 && i < Config.monitorlength0 + Config.monitorlength1 + Config.monitorlength2)
                    {

                        if (j == 0)
                        {
                            Config.OAvalueParameter[i, j] = Config.MonitorParameterCh2[i - Config.monitorlength0 - Config.monitorlength1, 1];

                        }
                        else if (j == 1)
                        {
                            Config.OAvalueParameter[i, j] = Config.ChannelParameter[2, 1];

                        }
                        else if (j == 2)
                        {
                            Config.OAvalueParameter[i, j] = Config.MonitorParameterCh2[i - Config.monitorlength0 - Config.monitorlength1, 2];

                        }
                        else if (j == 3)
                        {
                            Config.OAvalueParameter[i, j] = Convert.ToString(0.0);
                        }
                        else if (j == 4)
                        {
                            Config.OAvalueParameter[i, j] = Config.MonitorParameterCh2[i - Config.monitorlength0 - Config.monitorlength1, 3];
                        }
                        else if (j == 5)
                        {
                            Config.OAvalueParameter[i, j] = Config.MonitorParameterCh2[i - Config.monitorlength0 - Config.monitorlength1, 7];
                        }
                        else if (j == 6)
                        {
                            Config.OAvalueParameter[i, j] = Config.MonitorParameterCh2[i - Config.monitorlength0 - Config.monitorlength1, 6];
                        }
                        else if (j == 7)
                        {
                            Config.OAvalueParameter[i, j] = Config.MonitorParameterCh2[i - Config.monitorlength0 - Config.monitorlength1, 4];
                        }
                        else
                        {
                            Config.OAvalueParameter[i, j] = Config.MonitorParameterCh2[i - Config.monitorlength0 - Config.monitorlength1, 5];
                        }
                    }
                    else
                    {
                        if (j == 0)
                        {
                            Config.OAvalueParameter[i, j] = Config.MonitorParameterCh3[i - Config.monitorlength0 - Config.monitorlength1 - Config.monitorlength2, 1];

                        }
                        else if (j == 1)
                        {
                            Config.OAvalueParameter[i, j] = Config.ChannelParameter[3, 1];

                        }
                        else if (j == 2)
                        {
                            Config.OAvalueParameter[i, j] = Config.MonitorParameterCh3[i - Config.monitorlength0 - Config.monitorlength1 - Config.monitorlength2, 2];

                        }
                        else if (j == 3)
                        {
                            Config.OAvalueParameter[i, j] = Convert.ToString(0.0);
                        }
                        else if (j == 4)
                        {
                            Config.OAvalueParameter[i, j] = Config.MonitorParameterCh3[i - Config.monitorlength0 - Config.monitorlength1 - Config.monitorlength2, 3];
                        }
                        else if (j == 5)
                        {
                            Config.OAvalueParameter[i, j] = Config.MonitorParameterCh3[i - Config.monitorlength0 - Config.monitorlength1 - Config.monitorlength2, 7];
                        }
                        else if (j == 6)
                        {
                            Config.OAvalueParameter[i, j] = Config.MonitorParameterCh3[i - Config.monitorlength0 - Config.monitorlength1 - Config.monitorlength2, 6];
                        }
                        else if (j == 7)
                        {
                            Config.OAvalueParameter[i, j] = Config.MonitorParameterCh3[i - Config.monitorlength0 - Config.monitorlength1 - Config.monitorlength2, 4];
                        }
                        else
                        {
                            Config.OAvalueParameter[i, j] = Config.MonitorParameterCh3[i - Config.monitorlength0 - Config.monitorlength1 - Config.monitorlength2, 5];
                        }
                    }
                }
            }

        }
        private void MCMInitialOATrend()
        {
            this.dataGridViewOATrend.SelectionChanged -= new System.EventHandler(this.dataGridViewOATrend_SelectionChanged);
            int height = Config.OAvalueParameter.GetLength(0);
            int width = Config.OAvalueParameter.GetLength(1);
            this.dataGridViewOATrend.Rows.Clear();
            this.dataGridViewOATrend.Refresh();
            for (int r = 0; r < height; r++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dataGridViewOATrend);

                for (int c = 0; c < width - 5; c++)
                {

                    row.Cells[c].Value = Config.OAvalueParameter[r, c + 1];

                }

                this.dataGridViewOATrend.Rows.Add(row);
            }
            UpdateStatusColor();
            this.dataGridViewOATrend.SelectionChanged += new System.EventHandler(this.dataGridViewOATrend_SelectionChanged);
        }
        private void UpdateOATrend()
        {
            int height = Config.OAvalueParameter.GetLength(0);
            for (int i = 0; i < height; i++)
            {
                this.dataGridViewOATrend.Rows[i].Cells[2].Value = Config.OAvalueParameter[i, 3];
            }
            UpdateStatusColor();
        }
        private void MCMInitialChsetting()
        {

            int height = Config.ChannelParameter.GetLength(0);
            int width = Config.ChannelParameter.GetLength(1);
            this.dataGridViewChSetting.Rows.Clear();
            this.dataGridViewChSetting.Refresh();
            for (int r = 0; r < height; r++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dataGridViewChSetting);

                for (int c = 0; c < width - 1; c++)
                {
                    row.Cells[c].Value = Config.ChannelParameter[r, c + 1];
                }

                this.dataGridViewChSetting.Rows.Add(row);
            }

            dataGridViewChSetting.Height = dataGridViewChSetting.Rows.GetRowsHeight(DataGridViewElementStates.None) + dataGridViewChSetting.ColumnHeadersHeight + 2;
            dataGridViewChSetting.Width = dataGridViewChSetting.Columns.GetColumnsWidth(DataGridViewElementStates.None) + dataGridViewChSetting.RowHeadersWidth + 2;
        }
        private void checkBoxDDS_CheckedChanged(object sender, EventArgs e)
        {
            MCMUIUpdate();
        }

        private void radioButtonFFTCh0_CheckedChanged(object sender, EventArgs e)
        {
            MCMUIUpdate();
        }

        private void radioButtonFFTCh1_CheckedChanged(object sender, EventArgs e)
        {
            MCMUIUpdate();
        }

        private void radioButtonFFTCh2_CheckedChanged(object sender, EventArgs e)
        {
            MCMUIUpdate();
        }

        private void radioButtonFFTCh3_CheckedChanged(object sender, EventArgs e)
        {
            MCMUIUpdate();
        }
        private void checkBoxNormalDataRecord_CheckedChanged(object sender, EventArgs e)
        {
            /*if (checkBoxNormalDataRecord.Checked == true)
            {
                checkBoxTextDataRecord.Checked = false;
            }*/
            MCMUIUpdate();
        }
        private void checkBoxTextDataRecord_CheckedChanged(object sender, EventArgs e)
        {

            MCMUIUpdate();
        }
        private void metroCheckBoxAzure_CheckedChanged(object sender, EventArgs e)
        {
            MCMUIUpdate();
        }
        private void metroCheckBoxModbus_CheckedChanged(object sender, EventArgs e)
        {
            MCMUIUpdate();
        }
        private void metroCheckBoxMqtt_CheckedChanged(object sender, EventArgs e)
        {
            MCMUIUpdate();
        }
        private void metroCheckBoxMqttRaw_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void TextBoxNormalSechedule_TextChanged(object sender, EventArgs e)
        {
            MCMUIUpdate();
        }
        private void TextBoxNormalAverages_TextChanged(object sender, EventArgs e)
        {
            MCMUIUpdate();
        }
        private void TextBoxAlarmSechedule_TextChanged(object sender, EventArgs e)
        {
            MCMUIUpdate();
        }
        private void TextBoxHDspace_TextChanged(object sender, EventArgs e)
        {
            MCMUIUpdate();
        }
        private void ComboBoxBandWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)ComboBoxBandWidth.SelectedItem == "40K" || (string)ComboBoxBandWidth.SelectedItem == "20K")
            {
                if (ComboBoxFreqResolution.SelectedIndex != 2)
                    ComboBoxFreqResolution.SelectedIndex = 2;
            }

            MCMUIUpdate();
            if (StopBandCheck() == true)
            {
                MessageBox.Show("Please check all of your Stop Frequency must  < Bandwidth");
            }


        }
        private void ComboBoxFreqResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)ComboBoxBandWidth.SelectedItem == "40K" || (string)ComboBoxBandWidth.SelectedItem == "20K")
            {
                if (ComboBoxFreqResolution.SelectedIndex != 2)
                {
                    MessageBox.Show("If Band Width = 40K or 20K,we suggest that Frequency Resolution is 4Hz ");
                    ComboBoxFreqResolution.SelectedIndex = 2;
                }
            }

            //MCMUIUpdate();

        }
        private void dataGridViewChSetting_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            ChannelTableUpdate();
        }
        private void dataGridViewMonitorSetting_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            MonitorandTrendTableUpdate();
        }
        private void buttonRemoveMonitor_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewMonitorSetting.RowCount > 0)
            {
                if (Config.ChanneCurRow == 0)
                {
                    database.DeleteRowbyOAName(Config.ConfigTableName[6], Config.MonitorParameterCh0[this.dataGridViewMonitorSetting.CurrentRow.Index, 1]);
                    database.DeleteRowbyIndexnumber(Config.ConfigTableName[2], Convert.ToInt16(Config.MonitorParameterCh0[this.dataGridViewMonitorSetting.CurrentRow.Index, 0]));
                    database.DropTable(Config.MonitorParameterCh0[this.dataGridViewMonitorSetting.CurrentRow.Index, 1]);
                    UpdateOANameArray();
                    UpdateMonitorCh0Array();
                }
                else if (Config.ChanneCurRow == 1)
                {
                    database.DeleteRowbyOAName(Config.ConfigTableName[6], Config.MonitorParameterCh1[this.dataGridViewMonitorSetting.CurrentRow.Index, 1]);
                    database.DeleteRowbyIndexnumber(Config.ConfigTableName[3], Convert.ToInt16(Config.MonitorParameterCh1[this.dataGridViewMonitorSetting.CurrentRow.Index, 0]));
                    database.DropTable(Config.MonitorParameterCh1[this.dataGridViewMonitorSetting.CurrentRow.Index, 1]);
                    UpdateOANameArray();
                    UpdateMonitorCh1Array();
                }
                else if (Config.ChanneCurRow == 2)
                {
                    database.DeleteRowbyOAName(Config.ConfigTableName[6], Config.MonitorParameterCh2[this.dataGridViewMonitorSetting.CurrentRow.Index, 1]);
                    database.DeleteRowbyIndexnumber(Config.ConfigTableName[4], Convert.ToInt16(Config.MonitorParameterCh2[this.dataGridViewMonitorSetting.CurrentRow.Index, 0]));
                    database.DropTable(Config.MonitorParameterCh2[this.dataGridViewMonitorSetting.CurrentRow.Index, 1]);
                    UpdateOANameArray();
                    UpdateMonitorCh2Array();
                }
                else
                {
                    database.DeleteRowbyOAName(Config.ConfigTableName[6], Config.MonitorParameterCh3[this.dataGridViewMonitorSetting.CurrentRow.Index, 1]);
                    database.DeleteRowbyIndexnumber(Config.ConfigTableName[5], Convert.ToInt16(Config.MonitorParameterCh3[this.dataGridViewMonitorSetting.CurrentRow.Index, 0]));
                    database.DropTable(Config.MonitorParameterCh3[this.dataGridViewMonitorSetting.CurrentRow.Index, 1]);
                    UpdateOANameArray();
                    UpdateMonitorCh3Array();
                }

                this.dataGridViewMonitorSetting.Rows.RemoveAt(this.dataGridViewMonitorSetting.CurrentRow.Index);
            }
        }
        private void ChannelTableUpdate()
        {
            int chenableindex = 0;
            for (int i = 0; i < 4; i++)
            {
                if (dataGridViewChSetting.Rows[i].Cells[1].Value.ToString() == "True")
                    chenableindex = chenableindex + 1;
            }
            if (chenableindex == 0)
            {
                dataGridViewChSetting.Rows[0].Cells[1].Value = true;
                database.UpdateColumnbyIndex(Config.ConfigTableName[1], "ChannelEnable", Convert.ToString("True"), Convert.ToInt16(Config.ChannelParameter[0, 0]));
            }
            database.UpdateColumnbyIndex(Config.ConfigTableName[1], Config.ChannelColumnName[this.dataGridViewChSetting.CurrentCell.ColumnIndex], Convert.ToString(this.dataGridViewChSetting.CurrentCell.Value), Convert.ToInt16(Config.ChannelParameter[this.dataGridViewChSetting.CurrentRow.Index, 0]));
            UpdateChannelArray();

        }
        private void MonitorandTrendTableUpdate()
        {

            string index = null;

            Config.MonitorRow = new string[Config.MonitorColumnName.GetLength(0)];

            if (Config.ChanneCurRow == 0)
            {
                index = Config.MonitorParameterCh0[this.dataGridViewMonitorSetting.CurrentRow.Index, 1];
                Config.MonitorRow[0] = (string)this.dataGridViewChSetting.Rows[dataGridViewChSetting.CurrentRow.Index].Cells[0].Value + "_" +
                  (string)this.dataGridViewMonitorSetting.Rows[dataGridViewMonitorSetting.CurrentRow.Index].Cells[0].Value + "_" +
                  index.Substring(index.LastIndexOf("_") + 1);
                database.UpdateColumnbyIndex(Config.ConfigTableName[2], Config.MonitorColumnName[(this.dataGridViewMonitorSetting.CurrentCell.ColumnIndex) + 1], Convert.ToString(this.dataGridViewMonitorSetting.CurrentCell.Value), Convert.ToInt16(Config.MonitorParameterCh0[this.dataGridViewMonitorSetting.CurrentRow.Index, 0]));

                if (Config.MonitorParameterCh0[this.dataGridViewMonitorSetting.CurrentRow.Index, 1] != Config.MonitorRow[0])
                {
                    database.UpdateColumnbyOAName(Config.ConfigTableName[2], Config.MonitorColumnName[0], Config.MonitorRow[0], Config.MonitorParameterCh0[this.dataGridViewMonitorSetting.CurrentRow.Index, 1]);
                    database.RenameTable(Config.MonitorParameterCh0[this.dataGridViewMonitorSetting.CurrentRow.Index, 1], Config.MonitorRow[0]);
                    database.UpdateColumnbyOAName(Config.ConfigTableName[6], Config.OATableColumnName[0], Config.MonitorRow[0], Config.MonitorParameterCh0[this.dataGridViewMonitorSetting.CurrentRow.Index, 1]);
                    UpdateOANameArray();
                }

                UpdateMonitorCh0Array();
            }
            else if (Config.ChanneCurRow == 1)
            {
                index = Config.MonitorParameterCh1[this.dataGridViewMonitorSetting.CurrentRow.Index, 1];
                Config.MonitorRow[0] = (string)this.dataGridViewChSetting.Rows[dataGridViewChSetting.CurrentRow.Index].Cells[0].Value + "_" +
                  (string)this.dataGridViewMonitorSetting.Rows[dataGridViewMonitorSetting.CurrentRow.Index].Cells[0].Value + "_" +
                  index.Substring(index.LastIndexOf("_") + 1);
                database.UpdateColumnbyIndex(Config.ConfigTableName[3], Config.MonitorColumnName[(this.dataGridViewMonitorSetting.CurrentCell.ColumnIndex) + 1], Convert.ToString(this.dataGridViewMonitorSetting.CurrentCell.Value), Convert.ToInt16(Config.MonitorParameterCh1[this.dataGridViewMonitorSetting.CurrentRow.Index, 0]));

                if (Config.MonitorParameterCh1[this.dataGridViewMonitorSetting.CurrentRow.Index, 1] != Config.MonitorRow[0])
                {
                    database.UpdateColumnbyOAName(Config.ConfigTableName[3], Config.MonitorColumnName[0], Config.MonitorRow[0], Config.MonitorParameterCh1[this.dataGridViewMonitorSetting.CurrentRow.Index, 1]);
                    database.RenameTable(Config.MonitorParameterCh1[this.dataGridViewMonitorSetting.CurrentRow.Index, 1], Config.MonitorRow[0]);
                    database.UpdateColumnbyOAName(Config.ConfigTableName[6], Config.OATableColumnName[0], Config.MonitorRow[0], Config.MonitorParameterCh1[this.dataGridViewMonitorSetting.CurrentRow.Index, 1]);
                    UpdateOANameArray();
                }

                UpdateMonitorCh1Array();
            }
            else if (Config.ChanneCurRow == 2)
            {
                index = Config.MonitorParameterCh2[this.dataGridViewMonitorSetting.CurrentRow.Index, 1];
                Config.MonitorRow[0] = (string)this.dataGridViewChSetting.Rows[dataGridViewChSetting.CurrentRow.Index].Cells[0].Value + "_" +
                  (string)this.dataGridViewMonitorSetting.Rows[dataGridViewMonitorSetting.CurrentRow.Index].Cells[0].Value + "_" +
                  index.Substring(index.LastIndexOf("_") + 1);
                database.UpdateColumnbyIndex(Config.ConfigTableName[4], Config.MonitorColumnName[(this.dataGridViewMonitorSetting.CurrentCell.ColumnIndex) + 1], Convert.ToString(this.dataGridViewMonitorSetting.CurrentCell.Value), Convert.ToInt16(Config.MonitorParameterCh2[this.dataGridViewMonitorSetting.CurrentRow.Index, 0]));

                if (Config.MonitorParameterCh2[this.dataGridViewMonitorSetting.CurrentRow.Index, 1] != Config.MonitorRow[0])
                {
                    database.UpdateColumnbyOAName(Config.ConfigTableName[4], Config.MonitorColumnName[0], Config.MonitorRow[0], Config.MonitorParameterCh2[this.dataGridViewMonitorSetting.CurrentRow.Index, 1]);
                    database.RenameTable(Config.MonitorParameterCh2[this.dataGridViewMonitorSetting.CurrentRow.Index, 1], Config.MonitorRow[0]);
                    database.UpdateColumnbyOAName(Config.ConfigTableName[6], Config.OATableColumnName[0], Config.MonitorRow[0], Config.MonitorParameterCh2[this.dataGridViewMonitorSetting.CurrentRow.Index, 1]);
                    UpdateOANameArray();
                }
                UpdateMonitorCh2Array();
            }
            else
            {
                index = Config.MonitorParameterCh3[this.dataGridViewMonitorSetting.CurrentRow.Index, 1];
                Config.MonitorRow[0] = (string)this.dataGridViewChSetting.Rows[dataGridViewChSetting.CurrentRow.Index].Cells[0].Value + "_" +
                  (string)this.dataGridViewMonitorSetting.Rows[dataGridViewMonitorSetting.CurrentRow.Index].Cells[0].Value + "_" +
                  index.Substring(index.LastIndexOf("_") + 1);
                database.UpdateColumnbyIndex(Config.ConfigTableName[5], Config.MonitorColumnName[(this.dataGridViewMonitorSetting.CurrentCell.ColumnIndex) + 1], Convert.ToString(this.dataGridViewMonitorSetting.CurrentCell.Value), Convert.ToInt16(Config.MonitorParameterCh3[this.dataGridViewMonitorSetting.CurrentRow.Index, 0]));

                if (Config.MonitorParameterCh3[this.dataGridViewMonitorSetting.CurrentRow.Index, 1] != Config.MonitorRow[0])
                {
                    database.UpdateColumnbyOAName(Config.ConfigTableName[5], Config.MonitorColumnName[0], Config.MonitorRow[0], Config.MonitorParameterCh3[this.dataGridViewMonitorSetting.CurrentRow.Index, 1]);
                    database.RenameTable(Config.MonitorParameterCh3[this.dataGridViewMonitorSetting.CurrentRow.Index, 1], Config.MonitorRow[0]);
                    database.UpdateColumnbyOAName(Config.ConfigTableName[6], Config.OATableColumnName[0], Config.MonitorRow[0], Config.MonitorParameterCh3[this.dataGridViewMonitorSetting.CurrentRow.Index, 1]);
                    UpdateOANameArray();
                }
                UpdateMonitorCh3Array();
            }

        }
        private void dataGridViewChSetting_SelectionChanged(object sender, EventArgs e)
        {
            Config.ChanneCurRow = dataGridViewChSetting.CurrentRow.Index;
            if (Config.ChanneCurRow == 0)
            {
                MCMInitialMonitor(Config.MonitorParameterCh0);
            }
            else if (Config.ChanneCurRow == 1)
            {
                MCMInitialMonitor(Config.MonitorParameterCh1);
            }
            else if (Config.ChanneCurRow == 2)
            {
                MCMInitialMonitor(Config.MonitorParameterCh2);
            }
            else
            {
                MCMInitialMonitor(Config.MonitorParameterCh3);
            }


        }
        private void buttonAddMonitor_Click(object sender, EventArgs e)
        {

            this.dataGridViewMonitorSetting.Rows.Add(Config.MonitorInsertparameter);
            CombinOATableName();
            if (Config.ChanneCurRow == 0)
            {
                if (Config.MonitorParameterCh0.GetLongLength(0) == 0)
                    database.ResetTableIndex(Config.ConfigTableName[2]);
                database.InsertTable(Config.ConfigTableName[2], Config.MonitorColumnName, Config.MonitorRow);
                UpdateMonitorCh0Array();
            }
            else if (Config.ChanneCurRow == 1)
            {
                if (Config.MonitorParameterCh1.GetLongLength(0) == 0)
                    database.ResetTableIndex(Config.ConfigTableName[3]);
                database.InsertTable(Config.ConfigTableName[3], Config.MonitorColumnName, Config.MonitorRow);
                UpdateMonitorCh1Array();
            }
            else if (Config.ChanneCurRow == 2)
            {
                if (Config.MonitorParameterCh2.GetLongLength(0) == 0)
                    database.ResetTableIndex(Config.ConfigTableName[4]);
                database.InsertTable(Config.ConfigTableName[4], Config.MonitorColumnName, Config.MonitorRow);
                UpdateMonitorCh2Array();
            }
            else
            {
                if (Config.MonitorParameterCh3.GetLongLength(0) == 0)
                    database.ResetTableIndex(Config.ConfigTableName[5]);
                database.InsertTable(Config.ConfigTableName[5], Config.MonitorColumnName, Config.MonitorRow);
                UpdateMonitorCh3Array();
            }


            database.InsertTable(Config.ConfigTableName[6], Config.OATableColumnName, Config.OATableName);
            UpdateOANameArray();
            database.CreateTable(Config.OATableName[0], Config.OATreandColumnNameWithType);

        }
        private void CombinOATableName()
        {
            Config.MonitorRow = new string[7] { "", "New", "g rms", "10", "1000", "1", "2" };
            if (Config.OATableParameter.GetLength(0) == 0)
            {
                Config.OATableName = new string[1] { (string)this.dataGridViewChSetting.Rows[dataGridViewChSetting.CurrentRow.Index].Cells[0].Value+"_"+
                Config.MonitorInsertparameter[0]+"_"+
                Convert.ToString(1) };
                database.ResetTableIndex(Config.ConfigTableName[6]);

            }
            else
            {
                Config.OATableName = new string[1] { (string)this.dataGridViewChSetting.Rows[dataGridViewChSetting.CurrentRow.Index].Cells[0].Value+"_"+
                Config.MonitorInsertparameter[0]+"_"+
                Convert.ToString(Convert.ToInt16(Config.OATableParameter[Config.OATableParameter.GetLength(0)-1, 0])+1) };
            }

            Config.MonitorRow[0] = Config.OATableName[0];

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (metroTabControl1.SelectedTab == Setting && StopBandCheck() == true)
            {
                e.Cancel = true;
                MessageBox.Show("Please check all of your Stop Frequency must < Bandwidth before close");
            }
            else
            {
                try
                {
                    if (ProgramIsRunning(@"C:\mcm\mcm.exe"))
                    {
                        ProgramKill(@"C:\mcm\mcm.exe");
                    }
                    if (ProgramIsRunning(@"C:\Program Files\nodejs\node.exe"))
                    {
                        ProgramKill(@"C:\Program Files\nodejs\node.exe");
                    }
                    daqcontrol.result = USBDASK.UD_AI_AsyncClear(0, out daqcontrol.AccessCnt);
                    if (DataQueue.IsAlive)
                    {
                        if (false == thdtrend.Join(200))
                        {
                            DataQueue.Abort();
                        }
                    }
                    if (thdtrend.IsAlive)
                    {
                        if (false == thdtrend.Join(200))
                        {
                            thdtrend.Abort();
                        }
                    }
                    if (thdcombine.IsAlive)
                    {
                        if (false == thdcombine.Join(200))
                        {
                            thdcombine.Abort();
                        }
                    }
                    daqcontrol.result = USBDASK.UD_Release_Card(0);
                    txtWtr = new StreamWriter("c:\\ADLINK\\MCM\\INI\\DBPath.ini", false);
                    txtWtr.WriteLine(Config.ConfigFolder);
                    txtWtr.Close();
                    Thread.Sleep(1000);
                    if (Config.Modbusenable)
                    {
                        slave.Dispose();
                    }
                    if (Config.DDSenble)
                    {
                        //DisposeDDS();
                    }
                    if (Config.Mqttenable)
                    {
                        try
                        {
                            mqtt_client.Disconnect();
                        }
                        catch
                        {
                            Process.GetCurrentProcess().Kill();
                        }

                    }

                    Process.GetCurrentProcess().Kill();
                }
                catch
                {
                    Process.GetCurrentProcess().Kill();
                }
            }
        }
        private void buttonLoadConfig_Click(object sender, EventArgs e)
        {
            OpenFilebyDialog();

        }
        private string InitialOpenFilebyDialog()
        {

            //移動上層在指定下層路徑
            dlgopen.RestoreDirectory = true;
            dlgopen.InitialDirectory = "c:\\ADLINK\\MCM\\DataBase";
            dlgopen.Title = "Open Config File";

            // Set filter for file extension and default file extension
            dlgopen.Filter = "db|*.db";

            // Display OpenFileDialog by calling ShowDialog method ->ShowDialog()
            // Get the selected file name and display in a TextBox
            if (dlgopen.ShowDialog() == System.Windows.Forms.DialogResult.OK && dlgopen.FileName != null)
            {
                // Open document
                //Config.ConfigFileName = System.IO.Path.GetFileName(dlgopen.FileName);
                Config.ConfigFolder = dlgopen.FileName;
                //Config.ConfigFileName = Config.ConfigFileName.TrimEnd('.', 'm', 'd', 'b');
                InitialProcess();
                dlgopen.FileName = null;
                return null;
            }
            else
            {
                txtWtr = new StreamWriter("c:\\ADLINK\\MCM\\INI\\DBPath.ini", false);
                txtWtr.WriteLine("c:\\ADLINK\\MCM\\DataBase\\MCM.db");
                txtWtr.Close();
                Config.ConfigFolder = "c:\\ADLINK\\MCM\\DataBase\\MCM.db";
                MessageBox.Show("The Default configuation C:\\ADLINK\\MCM\\DataBase\\MCM.db will be used");
                return null;
            }

        }
        private string OpenFilebyDialog()
        {

            //移動上層在指定下層路徑
            dlgopen.RestoreDirectory = true;
            dlgopen.InitialDirectory = "c:\\ADLINK\\MCM\\DataBase";
            dlgopen.Title = "Open Config File";

            // Set filter for file extension and default file extension
            dlgopen.Filter = "db|*.db";

            // Display OpenFileDialog by calling ShowDialog method ->ShowDialog()
            // Get the selected file name and display in a TextBox
            if (dlgopen.ShowDialog() == System.Windows.Forms.DialogResult.OK && dlgopen.FileName != null)
            {
                // Open document
                //Config.ConfigFileName = System.IO.Path.GetFileName(dlgopen.FileName);
                database.Close();
                Analysisdatabase.Close();
                Config.ConfigFolder = dlgopen.FileName;
                //Config.ConfigFileName = Config.ConfigFileName.TrimEnd('.', 'm', 'd', 'b');
                InitialProcess();
                Config.firsttime = true;
                dlgopen.FileName = null;
                txtWtr = new StreamWriter("c:\\ADLINK\\MCM\\INI\\DBPath.ini", false);
                txtWtr.WriteLine(Config.ConfigFolder);
                txtWtr.Close();
                Config.ConfigFileName = Config.ConfigFolder.Substring(Config.ConfigFolder.LastIndexOf("\\") + 1, (Config.ConfigFolder.IndexOf(".db") - Config.ConfigFolder.LastIndexOf("\\") - 1));
                CreateIfMissing("c:\\ADLINK\\MCM\\Data\\All FFTData\\" + Config.ConfigFileName + "\\" + DateTime.Now.ToString("yyyy-MM-dd"));
                CreateIfMissing("c:\\ADLINK\\MCM\\Data\\All RAWData\\" + Config.ConfigFileName + "\\" + DateTime.Now.ToString("yyyy-MM-dd"));
                CreateIfMissing("c:\\ADLINK\\MCM\\Data\\Alarm RAWData\\" + Config.ConfigFileName + "\\" + DateTime.Now.ToString("yyyy-MM-dd"));
                metroTextBoxConfigfile.Text = Config.ConfigFileName;
                return null;
            }
            else
            {
                return null;
            }

        }
        private string SaveFilebyDialog()
        {

            //移動上層在指定下層路徑
            dlgsave.RestoreDirectory = true;
            dlgsave.InitialDirectory = "c:\\ADLINK\\MCM\\DataBase";
            dlgsave.Title = "Saven Config File";

            // Set filter for file extension and default file extension
            dlgsave.Filter = "db|*.db";

            // Display OpenFileDialog by calling ShowDialog method ->ShowDialog()
            // Get the selected file name and display in a TextBox
            if (dlgsave.ShowDialog() == System.Windows.Forms.DialogResult.OK && dlgsave.FileName != null)
            {
                // Open document
                if (Config.ConfigFolder != dlgsave.FileName)
                {
                    System.IO.File.Copy(Config.ConfigFolder, dlgsave.FileName, true);
                    //dlgsave.FileName = System.IO.Path.GetFileName(dlgsave.FileName);

                    configdatabase.Connect(dlgsave.FileName);
                    for (int i = 0; i < Config.OATableParameter.GetLongLength(0); i++)
                    {
                        configdatabase.EmptyTable(Config.OATableParameter[i, 1]);
                        configdatabase.ResetTableIndex(Config.OATableParameter[i, 1]);
                    }
                    configdatabase.EmptyTable(Config.ConfigTableName[7]);
                    configdatabase.ResetTableIndex(Config.ConfigTableName[7]);
                    configdatabase.VACUUM();
                    dlgsave.FileName = null;
                    return null;
                }
                else
                {
                    MessageBox.Show("Current Data be used please select another file!!");
                    dlgsave.FileName = null;
                    return null;
                }
            }
            else
            {
                dlgsave.FileName = null;
                return null;
            }

        }
        private void buttonSaveAsConfig_Click(object sender, EventArgs e)
        {
            SaveFilebyDialog();


        }
        private void UpateDeviceConfig()
        {

            daqcontrol.numbchans = 0;
            daqcontrol.Chconfig = new ushort[Config.ChannelParameter.GetLength(0)];
            daqcontrol.ai_chansenable = new ushort[Config.ChannelParameter.GetLength(0)];
            for (ushort i = 0; i < Config.ChannelParameter.GetLength(0); i++)
            {
                if (Convert.ToBoolean(Config.ChannelParameter[i, 2]))
                {
                    daqcontrol.ai_chansenable[daqcontrol.numbchans] = i;
                    daqcontrol.numbchans++;
                }

                if (Config.ChannelParameter[i, 6] == "DC")
                {
                    daqcontrol.Chconfig[i] = USBDASK.P2405_AI_Differential | USBDASK.P2405_AI_Coupling_None | USBDASK.P2405_AI_DisableIEPE;
                }
                else if (Config.ChannelParameter[i, 6] == "AC")
                {
                    daqcontrol.Chconfig[i] = USBDASK.P2405_AI_Differential | USBDASK.P2405_AI_Coupling_AC | USBDASK.P2405_AI_DisableIEPE;
                }
                else
                {
                    daqcontrol.Chconfig[i] = USBDASK.P2405_AI_Differential | USBDASK.P2405_AI_Coupling_AC | USBDASK.P2405_AI_EnableIEPE;
                }

            }
            if ((string)this.ComboBoxFreqResolution.SelectedItem == "1Hz")
            {
                daqcontrol.resolution = 1;
            }
            else if ((string)this.ComboBoxFreqResolution.SelectedItem == "2Hz")
            {
                daqcontrol.resolution = 2;
            }
            else
            {
                daqcontrol.resolution = 4;
            }
            daqcontrol.ai_chans = new ushort[daqcontrol.numbchans];
            daqcontrol.ai_chans_range = new ushort[daqcontrol.numbchans];
            for (int i = 0; i < daqcontrol.ai_chans.GetLength(0); i++)
            {
                daqcontrol.ai_chans[i] = daqcontrol.ai_chansenable[i];
                daqcontrol.ai_chans_range[i] = USBDASK.AD_B_10_V;
            }
            if ((string)this.ComboBoxBandWidth.SelectedItem == "40K")
            {
                daqcontrol.samplerate = 40000 * 2.56;
            }
            else if ((string)this.ComboBoxBandWidth.SelectedItem == "20K")
            {
                daqcontrol.samplerate = 20000 * 2.56;
            }
            else if ((string)this.ComboBoxBandWidth.SelectedItem == "10K")
            {
                daqcontrol.samplerate = 10000 * 2.56;
            }
            else if ((string)this.ComboBoxBandWidth.SelectedItem == "5K")
            {
                daqcontrol.samplerate = 5000 * 2.56;
            }
            else if ((string)this.ComboBoxBandWidth.SelectedItem == "2K")
            {
                daqcontrol.samplerate = 2000 * 2.56;
            }
            else if ((string)this.ComboBoxBandWidth.SelectedItem == "1K")
            {
                daqcontrol.samplerate = 1000 * 2.56;
            }
            else
            {
                daqcontrol.samplerate = 500 * 2.56;
            }
            daqcontrol.perchanlength = (uint)(daqcontrol.samplerate / daqcontrol.resolution);
            daqcontrol.allchanlength = daqcontrol.perchanlength * daqcontrol.numbchans * daqcontrol.resolution;
            daqcontrol.airowdata = Marshal.AllocHGlobal((int)(sizeof(uint) * daqcontrol.allchanlength));
            Config.allchannelmemsize = 2 * sizeof(uint) * daqcontrol.allchanlength;
            daqcontrol.aivoltagedata = new double[daqcontrol.allchanlength];
            daqcontrol.tempvoltagedata = new double[daqcontrol.allchanlength];
            daqcontrol.ch0data = new double[daqcontrol.perchanlength];
            daqcontrol.ch1data = new double[daqcontrol.perchanlength];
            daqcontrol.ch2data = new double[daqcontrol.perchanlength];
            daqcontrol.ch3data = new double[daqcontrol.perchanlength];
            //my2405daq.payload = new double[daqcontrol.perchanlength];
            daqcontrol.dtx = new double[daqcontrol.perchanlength];
            daqcontrol.ch0averagedata = new double[daqcontrol.perchanlength * Convert.ToInt16(Config.UIParameter[11])];
            daqcontrol.ch1averagedata = new double[daqcontrol.perchanlength * Convert.ToInt16(Config.UIParameter[11])];
            daqcontrol.ch2averagedata = new double[daqcontrol.perchanlength * Convert.ToInt16(Config.UIParameter[11])];
            daqcontrol.ch3averagedata = new double[daqcontrol.perchanlength * Convert.ToInt16(Config.UIParameter[11])];
            for (int i = 0; i < daqcontrol.perchanlength; i++)
            {
                if (i == 0)
                {
                    daqcontrol.dtx[i] = 0;
                }
                else
                {
                    daqcontrol.dtx[i] = daqcontrol.dtx[i - 1] + (1 / daqcontrol.samplerate);
                }
            }
        }
        private void UpateSpectrumConfig()
        {
            spectrum.spectrumlength = daqcontrol.perchanlength;
            spectrum.ch0spectrumdata = new double[spectrum.spectrumlength];
            spectrum.ch1spectrumdata = new double[spectrum.spectrumlength];
            spectrum.ch2spectrumdata = new double[spectrum.spectrumlength];
            spectrum.ch3spectrumdata = new double[spectrum.spectrumlength];
            spectrum.ch0averagespectrumdata = new double[spectrum.spectrumlength];
            spectrum.ch1averagespectrumdata = new double[spectrum.spectrumlength];
            spectrum.ch2averagespectrumdata = new double[spectrum.spectrumlength];
            spectrum.ch3averagespectrumdata = new double[spectrum.spectrumlength];
            spectrum.dfx = new double[spectrum.spectrumlength / 2];

            for (int x = 0; x < spectrum.spectrumlength / 2; x++)
            {
                if (x == 0)
                {
                    spectrum.dfx[x] = 0;
                }
                else
                {
                    spectrum.dfx[x] = spectrum.dfx[x - 1] + (daqcontrol.samplerate / daqcontrol.perchanlength);
                }
            }

        }
        private void Configuredaq()
        {


            daqcontrol.callbackindex = 0;
            daqcontrol.result = USBDASK.UD_DIO_2405_Config(0, USBDASK.P2405_DIGITAL_OUTPUT, USBDASK.P2405_DIGITAL_OUTPUT);
            if (daqcontrol.result != USBDASK.NoError)
            {
                MessageBox.Show("UD_DIO_2405_Config Fail, Code:" + daqcontrol.result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            daqcontrol.result = USBDASK.UD_DO_WritePort(0, 1, 0);
            daqcontrol.result = USBDASK.UD_DO_WritePort(0, 0, 1);
            daqcontrol.result = USBDASK.UD_AI_2405_Chan_Config(0, daqcontrol.Chconfig[0], daqcontrol.Chconfig[1], daqcontrol.Chconfig[2], daqcontrol.Chconfig[3]);
            if (daqcontrol.result != USBDASK.NoError)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Falied to perform UD_AI_2405_Chan_Config(), error: " + daqcontrol.result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Process.GetCurrentProcess().Kill();
                return;
            }
            daqcontrol.result = USBDASK.UD_AI_2405_Trig_Config(0, USBDASK.P2405_AI_CONVSRC_INT, USBDASK.UD_AI_TRGMOD_POST, 0, 0, 0, 0, 0);
            if (daqcontrol.result != USBDASK.NoError)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Falied to perform UD_AI_2405_Trig_Config(), error: " + daqcontrol.result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Process.GetCurrentProcess().Kill();
                return;
            }
            daqcontrol.result = USBDASK.UD_AI_AsyncDblBufferMode(0, true);
            if (daqcontrol.result != USBDASK.NoError)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Falied to perform UD_AI_AsyncDblBufferMode(), error: " + daqcontrol.result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Process.GetCurrentProcess().Kill();
                return;
            }
            daqcontrol.result = USBDASK.UD_AI_EventCallBack_x64(0, 1/*add*/, USBDASK.DBEvent/*EventType*/, ai_buf_ready_cbdel);
            if (daqcontrol.result != USBDASK.NoError)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Falied to perform UD_AI_EventCallBack(), error: " + daqcontrol.result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Process.GetCurrentProcess().Kill();
                return;
            }
            daqcontrol.result = USBDASK.UD_AI_ContReadMultiChannels(0, (ushort)daqcontrol.numbchans, daqcontrol.ai_chans, daqcontrol.ai_chans_range, daqcontrol.airowdata, daqcontrol.allchanlength * 2, daqcontrol.samplerate, USBDASK.ASYNCH_OP);
            if (daqcontrol.result != USBDASK.NoError)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Falied to perform UD_AI_ContReadMultiChannels(), error: " + daqcontrol.result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Process.GetCurrentProcess().Kill();
                return;
            }
        }
        uint m_dwOverrunCnt = 0;
        void ai_buf_ready_cbfunc()
        {
            qindata = new Queuedata();
            qindata.logtime = DateTime.Now;
            daqcontrol.callbackindex++;
            daqcontrol.result = USBDASK.UD_AI_AsyncDblBufferTransfer32(0, daqcontrol.airowdata);
            if (daqcontrol.result != USBDASK.NoError)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Falied to perform UD_AI_AsyncDblBufferTransfer32s(), error: " + daqcontrol.result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Process.GetCurrentProcess().Kill();
                return;
            }

            daqcontrol.result = USBDASK.UD_AI_ContVScale32(0, USBDASK.AD_B_10_V, 0/*inType*/, daqcontrol.airowdata, daqcontrol.aivoltagedata, (int)(daqcontrol.allchanlength / daqcontrol.resolution));
            if (daqcontrol.result != USBDASK.NoError)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Falied to perform UD_AI_ContVScale32(), error: " + daqcontrol.result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Process.GetCurrentProcess().Kill();
                return;
            }
            qindata.RawData = MVAFW.TestItemColls.GenericCopier<double[]>.DeepCopy(daqcontrol.aivoltagedata);
            myqueue.Enqueue(qindata);
            MethodInvoker mi = new MethodInvoker(this.UpdateUI);
            ushort OverrunFlag;
            USBDASK.UD_AI_AsyncDblBufferHandled(0);
            USBDASK.UD_AI_AsyncDblBufferOverrun(0, 0, out OverrunFlag);

            if (OverrunFlag == 1)
            {
                m_dwOverrunCnt = m_dwOverrunCnt + 1;
                USBDASK.UD_AI_AsyncDblBufferOverrun(0, 1, out OverrunFlag);
                this.BeginInvoke(mi, null);
            }

            


            this.BeginInvoke(mi, null);
        }
        private void UpdateUI()
        {
            textBox1daqtime.Text = Convert.ToString(m_dwOverrunCnt);
        }
        private void Displayaidata()
        {
            GraphPane[] tmp_ai_wave_raw_pane = new GraphPane[1] { this.zedGraphtime.GraphPane };
            tmp_ai_wave_raw_pane[0].CurveList.Clear();
            LineItem[] tmp_ai_wave_raw_curve = new LineItem[4];
            if (radioButtonFFTCh0.Checked == true)
            {
                tmp_ai_wave_raw_curve[0] = tmp_ai_wave_raw_pane[0].AddCurve("CH0", daqcontrol.dtx, daqcontrol.ch0data, Color.Red, SymbolType.None);

            }
            if (radioButtonFFTCh1.Checked == true)
            {
                tmp_ai_wave_raw_curve[1] = tmp_ai_wave_raw_pane[0].AddCurve("CH1", daqcontrol.dtx, daqcontrol.ch1data, Color.Blue, SymbolType.None);

            }
            if (radioButtonFFTCh2.Checked == true)
            {
                tmp_ai_wave_raw_curve[2] = tmp_ai_wave_raw_pane[0].AddCurve("CH2", daqcontrol.dtx, daqcontrol.ch2data, Color.DarkOrange, SymbolType.None);

            }
            if (radioButtonFFTCh3.Checked == true)
            {
                tmp_ai_wave_raw_curve[3] = tmp_ai_wave_raw_pane[0].AddCurve("CH3", daqcontrol.dtx, daqcontrol.ch3data, Color.DeepPink, SymbolType.None);
            }
            tmp_ai_wave_raw_pane[0].YAxis.Title.Text = "g";
            tmp_ai_wave_raw_pane[0].XAxis.Title.Text = "Sec";
            tmp_ai_wave_raw_pane[0].YAxis.MajorGrid.IsVisible = true;
            tmp_ai_wave_raw_pane[0].XAxis.MajorGrid.IsVisible = true;
            tmp_ai_wave_raw_pane[0].XAxis.MinorGrid.Color = Color.White;
            this.zedGraphtime.GraphPane.Title.Text = "Data";
            this.zedGraphtime.AxisChange();
            this.zedGraphtime.Refresh();
        }
        private void DisplayFFTdata()
        {
            GraphPane[] tmp_ai_wave_fft_pane = new GraphPane[1] { this.zedGraphfft.GraphPane };
            tmp_ai_wave_fft_pane[0].CurveList.Clear();
            LineItem[] tmp_ai_wave_fft_curve = new LineItem[4];
            if (radioButtonFFTCh0.Checked == true)
            {
                tmp_ai_wave_fft_curve[0] = tmp_ai_wave_fft_pane[0].AddCurve("CH0", spectrum.dfx, spectrum.ch0spectrumdata, Color.Red, SymbolType.None);

            }
            if (radioButtonFFTCh1.Checked == true)
            {
                tmp_ai_wave_fft_curve[1] = tmp_ai_wave_fft_pane[0].AddCurve("CH1", spectrum.dfx, spectrum.ch1spectrumdata, Color.Blue, SymbolType.None);

            }
            if (radioButtonFFTCh2.Checked == true)
            {
                tmp_ai_wave_fft_curve[2] = tmp_ai_wave_fft_pane[0].AddCurve("CH2", spectrum.dfx, spectrum.ch2spectrumdata, Color.DarkOrange, SymbolType.None);

            }
            if (radioButtonFFTCh3.Checked == true)
            {
                tmp_ai_wave_fft_curve[3] = tmp_ai_wave_fft_pane[0].AddCurve("CH3", spectrum.dfx, spectrum.ch3spectrumdata, Color.DeepPink, SymbolType.None);
            }
            tmp_ai_wave_fft_pane[0].YAxis.Title.Text = "g rms";
            tmp_ai_wave_fft_pane[0].XAxis.Title.Text = "Hz";
            tmp_ai_wave_fft_pane[0].YAxis.MajorGrid.IsVisible = true;
            tmp_ai_wave_fft_pane[0].XAxis.MajorGrid.IsVisible = true;

            this.zedGraphfft.GraphPane.Title.Text = "FFT";
            this.zedGraphfft.AxisChange();
            this.zedGraphfft.Refresh();
        }
        private void Updatetrenddata(string tablename)
        {

            database.SelectOAValueBetweenDate(tablename, currentstartdate.ToString("yyyy-MM-dd HH:mm:ss"), enddate.ToString("yyyy-MM-dd HH:mm:ss"));
            Config.OAvaluecolum = new double[database.data.Rows.Count];
            Config.datadate = new double[database.data.Rows.Count];
            for (int i = 0; i < database.data.Rows.Count; i++)
            {

                Config.datadate[i] = (double)new XDate(Convert.ToDateTime(database.data.Rows[i]["Datadate"]));
                Config.OAvaluecolum[i] = Convert.ToDouble(database.data.Rows[i]["OAvalue"]);

            }
            database.SelectAlarm(tablename);
            while (database.reader.Read())
            {
                Config.alarm = Convert.ToDouble(database.reader[0]);
            }
            database.reader.Close();
            database.SelectWarning(tablename);
            while (database.reader.Read())
            {
                Config.warning = Convert.ToDouble(database.reader[0]);
            }
            database.reader.Close();
            database.SelectUnit(tablename);
            while (database.reader.Read())
            {
                Config.OAUnit = Convert.ToString(database.reader[0]);
            }
            database.reader.Close();

        }
        private void Updateselecttrenddata(string tablename)
        {

            Analysisdatabase.SelectOAValueBetweenDate(tablename, currentstartdate.ToString("yyyy-MM-dd HH:mm:ss"), enddate.ToString("yyyy-MM-dd HH:mm:ss"));
            //Trenddatabase.SelectTableorderbydate(tablename);
            Analyze.OAvaluecolum = new double[Analysisdatabase.data.Rows.Count];
            Analyze.datadate = new double[Analysisdatabase.data.Rows.Count];

            for (int i = 0; i < Analysisdatabase.data.Rows.Count; i++)
            {

                Analyze.datadate[i] = (double)new XDate(Convert.ToDateTime(Analysisdatabase.data.Rows[i]["Datadate"]));
                Analyze.OAvaluecolum[i] = Convert.ToDouble(Analysisdatabase.data.Rows[i]["OAvalue"]);

            }
            Analysisdatabase.SelectAlarm(tablename);
            while (Analysisdatabase.reader.Read())
            {
                Analyze.alarm = Convert.ToDouble(Analysisdatabase.reader[0]);
            }
            Analysisdatabase.reader.Close();
            Analysisdatabase.SelectWarning(tablename);
            while (Analysisdatabase.reader.Read())
            {
                Analyze.warning = Convert.ToDouble(Analysisdatabase.reader[0]);
            }
            Analysisdatabase.reader.Close();
            Analysisdatabase.SelectUnit(tablename);
            while (Analysisdatabase.reader.Read())
            {
                Analyze.OAUnit = Convert.ToString(Analysisdatabase.reader[0]);
            }
            Analysisdatabase.reader.Close();
        }
        private void UpdateAnalysistrenddata(string tablename)
        {
            Analysisdatabase.SelectTableorderbydate(tablename);
            Analyze.OAvaluecolum = new double[Analysisdatabase.data.Rows.Count];
            Analyze.datadate = new double[Analysisdatabase.data.Rows.Count];
            for (int i = 0; i < Analysisdatabase.data.Rows.Count; i++)
            {
                Analyze.datadate[i] = (double)new XDate(Convert.ToDateTime(Analysisdatabase.data.Rows[i]["Datadate"]));
                Analyze.OAvaluecolum[i] = Convert.ToDouble(Analysisdatabase.data.Rows[i]["OAvalue"]);
            }
            if (Analysisdatabase.data.Rows.Count > 0)
            {
                Analysisdatabase.SelectAlarm(tablename);
                while (Analysisdatabase.reader.Read())
                {
                    Analyze.alarm = Convert.ToDouble(Analysisdatabase.reader[0]);
                }
                Analysisdatabase.reader.Close();
                Analysisdatabase.SelectWarning(tablename);
                while (Analysisdatabase.reader.Read())
                {
                    Analyze.warning = Convert.ToDouble(Analysisdatabase.reader[0]);
                }
                Analysisdatabase.reader.Close();
                Analysisdatabase.SelectUnit(tablename);
                while (Analysisdatabase.reader.Read())
                {
                    Analyze.OAUnit = Convert.ToString(Analysisdatabase.reader[0]);
                }
                Analysisdatabase.reader.Close();
            }

        }
        public void UpdatetrenddataBetweenDate(string tablename, string startdate, string enddate)
        {
            Analysisdatabase.SelectOAValueBetweenDate(tablename, startdate, enddate);
            Analyze.OAvaluecolum = new double[Analysisdatabase.data.Rows.Count];
            Analyze.datadate = new double[Analysisdatabase.data.Rows.Count];
            for (int i = 0; i < Analysisdatabase.data.Rows.Count; i++)
            {
                Analyze.datadate[i] = (double)new XDate(Convert.ToDateTime(Analysisdatabase.data.Rows[i]["Datadate"]));
                Analyze.OAvaluecolum[i] = Convert.ToDouble(Analysisdatabase.data.Rows[i]["OAvalue"]);
            }
            if (Analysisdatabase.data.Rows.Count > 0)
            {
                Analysisdatabase.SelectAlarm(tablename);
                while (Analysisdatabase.reader.Read())
                {
                    Analyze.alarm = Convert.ToDouble(Analysisdatabase.reader[0]);
                }
                Analysisdatabase.reader.Close();
                Analysisdatabase.SelectWarning(tablename);
                while (Analysisdatabase.reader.Read())
                {
                    Analyze.warning = Convert.ToDouble(Analysisdatabase.reader[0]);
                }
                Analysisdatabase.reader.Close();
                Analysisdatabase.SelectUnit(tablename);
                while (Analysisdatabase.reader.Read())
                {
                    Analyze.OAUnit = Convert.ToString(Analysisdatabase.reader[0]);
                }
                Analysisdatabase.reader.Close();
            }

        }
        private void DiaplayTrendData(double[] datadate, double[] OAvaluecolum, double warning, double alarm, string OAUnit)
        {
            GraphPane[] tmp_ai_wave_trend__pane = new GraphPane[1] { this.zedGraphhistory.GraphPane };
            GraphPane myPane = zedGraphhistory.GraphPane;
            PointPairList userClickrListwarning = new PointPairList();
            PointPairList userClickrListalarm = new PointPairList();
            LineItem userClickCurvewarning = new LineItem("userClickCurvewarning");
            LineItem userClickCurvealarm = new LineItem("userClickCurvealarm");
            tmp_ai_wave_trend__pane[0].CurveList.Clear();
            LineItem[] tmp_ai_wave_trend_curve = new LineItem[1];
            tmp_ai_wave_trend_curve[0] = tmp_ai_wave_trend__pane[0].AddCurve("Over All Value", datadate, OAvaluecolum, Color.YellowGreen, SymbolType.Circle);
            XDate start, end;

            start = new XDate(datadate[0]);
            end = new XDate(DateTime.Now);

            userClickrListwarning.Add(end, warning);
            userClickrListwarning.Add(start, warning);
            userClickCurvewarning = myPane.AddCurve(" ", userClickrListwarning, Color.DarkOrange, SymbolType.None);
            userClickCurvewarning.Line.Width = 4;
            userClickrListalarm.Add(end, alarm);
            userClickrListalarm.Add(start, alarm);
            userClickCurvealarm = myPane.AddCurve(" ", userClickrListalarm, Color.Red, SymbolType.None);
            userClickCurvealarm.Line.Width = 4;
            this.zedGraphhistory.GraphPane.YAxis.Scale.MaxAuto = true;
            this.zedGraphhistory.GraphPane.YAxis.Scale.Min = 0;
            this.zedGraphhistory.GraphPane.XAxis.Type = AxisType.Date;
            this.zedGraphhistory.GraphPane.XAxis.Scale.Max = end;
            this.zedGraphhistory.GraphPane.XAxis.Scale.Min = start;
            this.zedGraphhistory.GraphPane.XAxis.Scale.MinorUnit = DateUnit.Second;         // set the minimum x unit to time/seconds
            this.zedGraphhistory.GraphPane.XAxis.Scale.MajorUnit = DateUnit.Year;         // set the maximum x unit to time/minutes
            this.zedGraphhistory.GraphPane.XAxis.Scale.Format = "dd.MM.yyyy HH:mm:ss";
            this.zedGraphhistory.GraphPane.Title.Text = "Over All Value History";
            tmp_ai_wave_trend_curve[0].Line.IsVisible = true;
            tmp_ai_wave_trend__pane[0].XAxis.Title.Text = "Time";
            tmp_ai_wave_trend__pane[0].YAxis.Title.Text = OAUnit;
            tmp_ai_wave_trend__pane[0].YAxis.MajorGrid.IsVisible = true;
            tmp_ai_wave_trend__pane[0].XAxis.MajorGrid.IsVisible = true;
            this.zedGraphhistory.AxisChange();
            this.zedGraphhistory.Refresh();

        }
        public void DisplayAnalysisTrendData(DateTime startdate, DateTime enddate, string format, string Unit)
        {
            if (Analyze.datadate.GetLength(0) > 0)
            {
                GraphPane[] tmp_ai_wave_trend__pane = new GraphPane[1] { this.zedGraphAnalysishistory.GraphPane };
                GraphPane myPane = this.zedGraphAnalysishistory.GraphPane;
                PointPairList userClickrListwarning = new PointPairList();
                PointPairList userClickrListalarm = new PointPairList();
                LineItem userClickCurvewarning = new LineItem("userClickCurvewarning");
                LineItem userClickCurvealarm = new LineItem("userClickCurvealarm");
                tmp_ai_wave_trend__pane[0].CurveList.Clear();
                LineItem[] tmp_ai_wave_trend_curve = new LineItem[1];
                tmp_ai_wave_trend_curve[0] = tmp_ai_wave_trend__pane[0].AddCurve("Trend Data", Analyze.datadate, Analyze.OAvaluecolum, Color.YellowGreen, SymbolType.Circle);
                userClickrListwarning.Add(new XDate(enddate), Analyze.warning);
                userClickrListwarning.Add(new XDate(Analyze.datadate[0]), Analyze.warning);
                userClickCurvewarning = myPane.AddCurve(" ", userClickrListwarning, Color.DarkOrange, SymbolType.None);
                userClickCurvewarning.Line.Width = 4;
                userClickrListalarm.Add(new XDate(enddate), Analyze.alarm);
                userClickrListalarm.Add(new XDate(Analyze.datadate[0]), Analyze.alarm);
                userClickCurvealarm = myPane.AddCurve(" ", userClickrListalarm, Color.Red, SymbolType.None);
                userClickCurvealarm.Line.Width = 4;
                this.zedGraphAnalysishistory.GraphPane.YAxis.Scale.MaxAuto = true;
                this.zedGraphAnalysishistory.GraphPane.YAxis.Scale.Min = 0;
                this.zedGraphAnalysishistory.GraphPane.XAxis.Type = AxisType.Date;
                this.zedGraphAnalysishistory.GraphPane.XAxis.Scale.Max = new XDate(enddate);
                this.zedGraphAnalysishistory.GraphPane.XAxis.Scale.Min = new XDate(Analyze.datadate[0]);
                switch (Unit)
                {
                    case "default":
                        this.zedGraphAnalysishistory.GraphPane.XAxis.Scale.MinorUnit = DateUnit.Second;
                        this.zedGraphAnalysishistory.GraphPane.XAxis.Scale.MajorUnit = DateUnit.Year;
                        break;
                    case "hours":
                        this.zedGraphAnalysishistory.GraphPane.XAxis.Scale.MinorUnit = DateUnit.Hour;
                        this.zedGraphAnalysishistory.GraphPane.XAxis.Scale.MajorUnit = DateUnit.Day;
                        break;
                    case "days":
                        this.zedGraphAnalysishistory.GraphPane.XAxis.Scale.MinorUnit = DateUnit.Day;
                        this.zedGraphAnalysishistory.GraphPane.XAxis.Scale.MajorUnit = DateUnit.Month;
                        break;
                    case "months":
                        this.zedGraphAnalysishistory.GraphPane.XAxis.Scale.MinorUnit = DateUnit.Month;
                        this.zedGraphAnalysishistory.GraphPane.XAxis.Scale.MajorUnit = DateUnit.Year;
                        break;
                    case "years":
                        this.zedGraphAnalysishistory.GraphPane.XAxis.Scale.MinorUnit = DateUnit.Month;
                        this.zedGraphAnalysishistory.GraphPane.XAxis.Scale.MajorUnit = DateUnit.Year;
                        break;
                }

                this.zedGraphAnalysishistory.GraphPane.XAxis.MinorGrid.IsVisible = true;
                this.zedGraphAnalysishistory.GraphPane.XAxis.Scale.Format = format;//"dd.MM.yyyy HH:mm:ss"
                this.zedGraphAnalysishistory.GraphPane.Title.Text = "Trend";
                tmp_ai_wave_trend_curve[0].Line.IsVisible = true;
                tmp_ai_wave_trend__pane[0].XAxis.Title.Text = "Time";
                tmp_ai_wave_trend__pane[0].YAxis.Title.Text = Analyze.OAUnit;
                tmp_ai_wave_trend__pane[0].YAxis.MajorGrid.IsVisible = true;
                tmp_ai_wave_trend__pane[0].XAxis.MajorGrid.IsVisible = true;
                this.zedGraphAnalysishistory.AxisChange();
                this.zedGraphAnalysishistory.Refresh();
            }
        }
        private void DisplayAnalysisaidata(double[] dtx, double[] data)
        {
            GraphPane[] tmp_ai_wave_raw_pane = new GraphPane[1] { this.zedGraphtimeAnalysis.GraphPane };
            tmp_ai_wave_raw_pane[0].CurveList.Clear();
            LineItem[] tmp_ai_wave_raw_curve = new LineItem[4];
            tmp_ai_wave_raw_curve[0] = tmp_ai_wave_raw_pane[0].AddCurve("Data", dtx, data, Color.Red, SymbolType.None);
            tmp_ai_wave_raw_pane[0].YAxis.Title.Text = "g";
            tmp_ai_wave_raw_pane[0].XAxis.Title.Text = "Sec";
            tmp_ai_wave_raw_pane[0].YAxis.MajorGrid.IsVisible = true;
            tmp_ai_wave_raw_pane[0].XAxis.MajorGrid.IsVisible = true;
            this.zedGraphtimeAnalysis.GraphPane.Title.Text = "Data";
            this.zedGraphtimeAnalysis.AxisChange();
            this.zedGraphtimeAnalysis.Refresh();
        }
        private void DisplayAnalysisFFTdata(double[] dfx, double[] spectrum)
        {
            GraphPane[] tmp_ai_wave_fft_pane = new GraphPane[1] { this.zedGraphfftAnalysis.GraphPane };
            tmp_ai_wave_fft_pane[0].CurveList.Clear();
            LineItem[] tmp_ai_wave_fft_curve = new LineItem[4];
            tmp_ai_wave_fft_curve[0] = tmp_ai_wave_fft_pane[0].AddCurve("FFT", dfx, spectrum, Color.Red, SymbolType.None);
            tmp_ai_wave_fft_pane[0].YAxis.Title.Text = "g rms";
            tmp_ai_wave_fft_pane[0].XAxis.Title.Text = "Hz";
            tmp_ai_wave_fft_pane[0].YAxis.MajorGrid.IsVisible = true;
            tmp_ai_wave_fft_pane[0].XAxis.MajorGrid.IsVisible = true;
            this.zedGraphfftAnalysis.GraphPane.Title.Text = "FFT";
            this.zedGraphfftAnalysis.AxisChange();
            this.zedGraphfftAnalysis.Refresh();
        }
        private void ClearTrendata()
        {

            GraphPane[] tmp_ai_wave_trend__pane = new GraphPane[1] { this.zedGraphhistory.GraphPane };
            tmp_ai_wave_trend__pane[0].CurveList.Clear();
        }
        private void individualChannelData()
        {
            uint ch0index = 0, ch1index = 0, ch2index = 0, ch3index = 0;
            ch0index = 0;
            ch1index = 0;
            ch2index = 0;
            ch3index = 0;

            for (int j = 0; j < (int)(daqcontrol.allchanlength / daqcontrol.resolution); j++)
            {
                if ((j % daqcontrol.numbchans) == 0)
                {
                    if (daqcontrol.ai_chansenable[0] == 0)
                    {
                        daqcontrol.ch0data[ch0index] = qoutdata.RawData[j] / (0.001 * Convert.ToDouble(Config.ChannelParameter[0, 4]));

                        ch0index++;
                    }
                    else if (daqcontrol.ai_chansenable[0] == 1)
                    {
                        daqcontrol.ch1data[ch1index] = qoutdata.RawData[j] / (0.001 * Convert.ToDouble(Config.ChannelParameter[1, 4]));
                        ch1index++;
                    }
                    else if (daqcontrol.ai_chansenable[0] == 2)
                    {
                        daqcontrol.ch2data[ch2index] = qoutdata.RawData[j] / (0.001 * Convert.ToDouble(Config.ChannelParameter[2, 4]));
                        ch2index++;
                    }
                    else
                    {
                        daqcontrol.ch3data[ch3index] = qoutdata.RawData[j] / (0.001 * Convert.ToDouble(Config.ChannelParameter[3, 4]));
                        ch3index++;
                    }

                }
                else if ((j % daqcontrol.numbchans) == 1)
                {
                    if (daqcontrol.ai_chansenable[1] == 1)
                    {
                        daqcontrol.ch1data[ch1index] = qoutdata.RawData[j] / (0.001 * Convert.ToDouble(Config.ChannelParameter[1, 4]));
                        ch1index++;
                    }
                    else if (daqcontrol.ai_chansenable[1] == 2)
                    {
                        daqcontrol.ch2data[ch2index] = qoutdata.RawData[j] / (0.001 * Convert.ToDouble(Config.ChannelParameter[2, 4]));
                        ch2index++;
                    }
                    else
                    {
                        daqcontrol.ch3data[ch3index] = qoutdata.RawData[j] / (0.001 * Convert.ToDouble(Config.ChannelParameter[3, 4]));
                        ch3index++;
                    }
                }
                else if ((j % daqcontrol.numbchans) == 2)
                {
                    if (daqcontrol.ai_chansenable[2] == 2)
                    {
                        daqcontrol.ch2data[ch2index] = qoutdata.RawData[j] / (0.001 * Convert.ToDouble(Config.ChannelParameter[2, 4]));
                        ch2index++;
                    }
                    else
                    {
                        daqcontrol.ch3data[ch3index] = qoutdata.RawData[j] / (0.001 * Convert.ToDouble(Config.ChannelParameter[3, 4]));
                        ch3index++;
                    }
                }
                else
                {
                    daqcontrol.ch3data[ch3index] = qoutdata.RawData[j] / (0.001 * Convert.ToDouble(Config.ChannelParameter[3, 4]));
                    ch3index++;

                }

            }
        }
        private double[] Analysispectrum(double[] Analysisdata, double samplerate)
        {
            double[] Analysisspectrumdata = new double[Analysisdata.GetLength(0)];
            anaspectrumdata.ApplyFFT(Analysisdata, (uint)Analysisspectrumdata.GetLongLength(0));
            anaspectrumdata.GetPowerSpectrum(Analysisspectrumdata);
            for (int l = 0; l < Analysisspectrumdata.GetLength(0) / 2; l++)
            {
                Analysisspectrumdata[l] = Math.Pow(2, 0.5) * Math.Pow(Analysisspectrumdata[l], 0.5) / (Analysisspectrumdata.GetLength(0) / 2);

            }
            return Analysisspectrumdata;
        }
        private void realtimespectrum()
        {

            if (Convert.ToBoolean(Config.ChannelParameter[0, 2]))
            {
                spectrumdata.ApplyFFT(daqcontrol.ch0data, (uint)daqcontrol.ch0data.GetLongLength(0));
                spectrumdata.GetPowerSpectrum(spectrum.ch0spectrumdata);

                for (int l = 0; l < spectrum.spectrumlength / 2; l++)
                {
                    if (l == 0)
                    {
                        spectrum.ch0spectrumdata[l] = Math.Pow(spectrum.ch0spectrumdata[l], 0.5) / (spectrum.spectrumlength / 2);
                    }
                    else
                    {
                        spectrum.ch0spectrumdata[l] = Math.Pow(2, 0.5) * Math.Pow(spectrum.ch0spectrumdata[l], 0.5) / (spectrum.spectrumlength / 2);
                    }

                }
            }
            //FFT变换           
            if (Convert.ToBoolean(Config.ChannelParameter[1, 2]))
            {
                spectrumdata.ApplyFFT(daqcontrol.ch1data, (uint)daqcontrol.ch1data.GetLongLength(0));
                spectrumdata.GetPowerSpectrum(spectrum.ch1spectrumdata);
                for (int l = 0; l < spectrum.spectrumlength / 2; l++)
                {
                    if (l == 0)
                    {
                        spectrum.ch1spectrumdata[l] = Math.Pow(spectrum.ch1spectrumdata[l], 0.5) / (spectrum.spectrumlength / 2);
                    }
                    else
                    {
                        spectrum.ch1spectrumdata[l] = Math.Pow(2, 0.5) * Math.Pow(spectrum.ch1spectrumdata[l], 0.5) / (spectrum.spectrumlength / 2);
                    }

                }

            }//FFT变换
            if (Convert.ToBoolean(Config.ChannelParameter[2, 2]))
            {
                spectrumdata.ApplyFFT(daqcontrol.ch2data, (uint)daqcontrol.ch2data.GetLongLength(0));
                spectrumdata.GetPowerSpectrum(spectrum.ch2spectrumdata);
                for (int l = 0; l < spectrum.spectrumlength / 2; l++)
                {
                    if (l == 0)
                    {
                        spectrum.ch2spectrumdata[l] = Math.Pow(spectrum.ch2spectrumdata[l], 0.5) / (spectrum.spectrumlength / 2);
                    }
                    else
                    {
                        spectrum.ch2spectrumdata[l] = Math.Pow(2, 0.5) * Math.Pow(spectrum.ch2spectrumdata[l], 0.5) / (spectrum.spectrumlength / 2);
                    }

                }
            }//FFT变换
            if (Convert.ToBoolean(Config.ChannelParameter[3, 2]))
            {
                spectrumdata.ApplyFFT(daqcontrol.ch3data, (uint)daqcontrol.ch3data.GetLongLength(0));
                spectrumdata.GetPowerSpectrum(spectrum.ch3spectrumdata);
                for (int l = 0; l < spectrum.spectrumlength / 2; l++)
                {
                    if (l == 0)
                    {
                        spectrum.ch3spectrumdata[l] = Math.Pow(spectrum.ch3spectrumdata[l], 0.5) / (spectrum.spectrumlength / 2);
                    }
                    else
                    {
                        spectrum.ch3spectrumdata[l] = Math.Pow(2, 0.5) * Math.Pow(spectrum.ch3spectrumdata[l], 0.5) / (spectrum.spectrumlength / 2);
                    }


                }
            }//FFT变换

        }
        private void OAProcess()
        {

            if ((Config.monitorlength0 + Config.monitorlength1 + Config.monitorlength2 + Config.monitorlength3) > 0 && Config.averageenable == false)
            {


                if (Convert.ToBoolean(Config.ChannelParameter[0, 2]) && Config.MonitorParameterCh0.GetLength(0) > 0)
                {
                    DataToTrend(0);
                }
                if (Convert.ToBoolean(Config.ChannelParameter[1, 2]) && Config.MonitorParameterCh1.GetLength(0) > 0)
                {
                    DataToTrend(1);
                }
                if (Convert.ToBoolean(Config.ChannelParameter[2, 2]) && Config.MonitorParameterCh2.GetLength(0) > 0)
                {
                    DataToTrend(2);
                }
                if (Convert.ToBoolean(Config.ChannelParameter[3, 2]) && Config.MonitorParameterCh3.GetLength(0) > 0)
                {
                    DataToTrend(3);
                }
                if (Config.firstupdate)
                {

                    MethodInvoker grid = new MethodInvoker(this.MCMInitialOATrend);
                    this.BeginInvoke(grid, null);
                    if (Convert.ToBoolean(Config.UIParameter[12]))
                    {
                        //WriteDDS(infodata("ChannelsInfo", Config.OAvalueParameter));

                    }
                    if (Convert.ToBoolean(Config.UIParameter[0]))
                    {
                        sendChannelsInfodemo();
                    }
                    if (Convert.ToBoolean(Config.UIParameter[2]))
                    {
                        WriteMqtt("ChannelsInfo", infodata("ChannelsInfo", Config.OAvalueParameter), true);

                    }
                    Config.firstupdate = false;

                }
                else
                {
                    MethodInvoker grid = new MethodInvoker(this.UpdateOATrend);
                    this.BeginInvoke(grid, null);

                }
                database.SelectMaxdate(Config.OAvalueParameter[Config.OATrendCurRow, 0]);
                while (database.reader.Read())
                {
                    enddate = Convert.ToDateTime(database.reader[0]);
                }
                currentstartdate = enddate.AddHours(-24);
                database.reader.Close();
                Updatetrenddata(Config.OAvalueParameter[Config.OATrendCurRow, 0]);


                DisplayTrend displaytrendInvoke = new DisplayTrend(DiaplayTrendData);
                BeginInvoke(displaytrendInvoke, new object[] { Config.datadate, Config.OAvaluecolum, Config.warning, Config.alarm, Config.OAUnit });
                UpdateAlarmLog();
                DIOcontrol();
                if (Convert.ToBoolean(Config.UIParameter[12]))
                {
                    //WriteDDS(OAdata(Config.DDSChannelname, Config.OAvalueParameter));
                }
                if (Convert.ToBoolean(Config.UIParameter[0]))
                {
                    //sendChannelsValuedemo(Config.OAvalueParameter);
                    sendChannelsValuedemo(OAdata(Config.DDSChannelname, Config.OAvalueParameter));
                }
                if (Convert.ToBoolean(Config.UIParameter[1]))
                {
                    ModBusdata(Config.OAvalueParameter);
                }
                if (Convert.ToBoolean(Config.UIParameter[2]) || Convert.ToBoolean(Config.UIParameter[3]))
                {
                    WriteMqtt("ChannelsValue", MqttRawandOAdata(Config.DDSChannelname, Config.OAvalueParameter), false);
                    ch0rawdataarray.Clear();
                    ch1rawdataarray.Clear();
                    ch2rawdataarray.Clear();
                    ch3rawdataarray.Clear();
                }
                if (Convert.ToBoolean(Config.UIParameter[9]))
                {
                    copyfile();
                }

            }
        }

        private void ProcessQueue()
        {
            while (true)
            {
                Thread.Sleep(10);
                if (myqueue.Count > 0)
                {
                    myqueue.TryDequeue(out qoutdata);
                    individualChannelData();
                    realtimespectrum();
                    DisplayInvoke displayInvoke = new DisplayInvoke(Displayaidata);
                    DisplayInvoke displayFFTInvoke = new DisplayInvoke(DisplayFFTdata);
                    BeginInvoke(displayInvoke);
                    BeginInvoke(displayFFTInvoke);
                    if (Config.averageenable)
                    {
                        averagedata();
                    }

                }
            }

        }
        private void trend()
        {

            while (true)
            {
                MethodInvoker t = new MethodInvoker(this.time);
                Config.averageenable = true;
                //sw.Reset();
                while (Config.averageenable)
                {
                    Thread.Sleep(10);
                    //Task.Delay(10);
                }
                //sw.Start();
                OAProcess();

                //sw.Stop();
                this.BeginInvoke(t, null);
                double estime = (Convert.ToDouble(Config.UIParameter[10]) * 1000) - 50;
                if (estime < 0)
                {
                    estime = 0;
                }
                while (Convert.ToDateTime(DateTime.Now) < Config.TrendDateTime.AddMilliseconds(estime))
                {
                    Thread.Sleep(10);
                }

                //Thread.Sleep(estime);
                spectrum.ch0averagespectrumdata = Enumerable.Repeat(0.0, (int)spectrum.spectrumlength).ToArray();
                spectrum.ch1averagespectrumdata = Enumerable.Repeat(0.0, (int)spectrum.spectrumlength).ToArray();
                spectrum.ch2averagespectrumdata = Enumerable.Repeat(0.0, (int)spectrum.spectrumlength).ToArray();
                spectrum.ch3averagespectrumdata = Enumerable.Repeat(0.0, (int)spectrum.spectrumlength).ToArray();
                Config.averageindex = 0;


            }
        }
        private void time()
        {
            //textBoxtime.Text = Convert.ToString(sw.Elapsed.TotalMilliseconds);
            if (Config.StorageAlarm)
            {
                richTextBoxAlarm.BackColor = Color.Red;

                richTextBoxAlarm.Text = "Storage is not enough";
            }
            else
            {
                richTextBoxAlarm.BackColor = Color.YellowGreen;

                richTextBoxAlarm.Text = null;
            }

        }
        private void writedata(int ch, uint fileindex)
        {

            Config.path = @"c:\\ADLINK\\MCM\\Data\\All RAWData\\" + Config.ConfigFileName + "\\" + Config.TrendDateTime.ToString("yyyy-MM-dd HH_mm_ss");
            switch (ch)
            {
                case 0:

                    Config.outputch = new FileStream(Config.path + "_" + ((daqcontrol.samplerate).ToString("f0")) + "_CH0" + "_" + Convert.ToString(fileindex) + ".dat", FileMode.Create, FileAccess.ReadWrite);
                    Config.binWtr = new BinaryWriter(Config.outputch);
                    for (int i = 0; i < daqcontrol.perchanlength; i++)
                    {
                        Config.binWtr.Write(daqcontrol.ch0data[i]);
                    }
                    Config.binWtr.Close();
                    break;

                case 1:

                    Config.outputch = new FileStream(Config.path + "_" + ((daqcontrol.samplerate).ToString("f0")) + "_CH1" + "_" + Convert.ToString(fileindex) + ".dat", FileMode.Create, FileAccess.ReadWrite);
                    Config.binWtr = new BinaryWriter(Config.outputch);
                    for (int i = 0; i < daqcontrol.perchanlength; i++)
                    {
                        Config.binWtr.Write(daqcontrol.ch1data[i]);
                    }
                    Config.binWtr.Close();
                    break;
                case 2:

                    Config.outputch = new FileStream(Config.path + "_" + ((daqcontrol.samplerate).ToString("f0")) + "_CH2" + "_" + Convert.ToString(fileindex) + ".dat", FileMode.Create, FileAccess.ReadWrite);
                    Config.binWtr = new BinaryWriter(Config.outputch);
                    for (int i = 0; i < daqcontrol.perchanlength; i++)
                    {
                        Config.binWtr.Write(daqcontrol.ch2data[i]);
                    }
                    Config.binWtr.Close();
                    break;

                case 3:

                    Config.outputch = new FileStream(Config.path + "_" + ((daqcontrol.samplerate).ToString("f0")) + "_CH3" + "_" + Convert.ToString(fileindex) + ".dat", FileMode.Create, FileAccess.ReadWrite);
                    Config.binWtr = new BinaryWriter(Config.outputch);
                    for (int i = 0; i < daqcontrol.perchanlength; i++)
                    {
                        Config.binWtr.Write(daqcontrol.ch3data[i]);
                    }
                    Config.binWtr.Close();
                    break;

            }

        }
        private void WritedataJson(int chn)
        {
            switch (chn)
            {
                case 0:
                    ch0rawdataarray.Add(JArray.FromObject(daqcontrol.ch0data));
                    rawdata["CH0"] = ch0rawdataarray;
                    break;
                case 1:
                    ch1rawdataarray.Add(JArray.FromObject(daqcontrol.ch1data));
                    rawdata["CH1"] = ch1rawdataarray;
                    break;
                case 2:
                    ch2rawdataarray.Add(JArray.FromObject(daqcontrol.ch2data));
                    rawdata["CH2"] = ch2rawdataarray;
                    break;
                case 3:
                    ch3rawdataarray.Add(JArray.FromObject(daqcontrol.ch3data));
                    rawdata["CH3"] = ch3rawdataarray;
                    break;

            }
        }

        private void writedataCsv(int ch, uint fileindex)
        {
            //string path = null;
            CreateIfMissing("c:\\ADLINK\\MCM\\Data\\All RAWData\\" + Config.ConfigFileName + "\\" + Config.TrendDateTime.ToString("yyyy-MM-dd"));
            Config.path = @"c:\\ADLINK\\MCM\\Data\\All RAWData\\" + Config.ConfigFileName + "\\" + Config.TrendDateTime.ToString("yyyy-MM-dd") + "\\" + Config.TrendDateTime.ToString("yyyy-MM-dd HH_mm_ss");

            switch (ch)
            {
                case 0:
                    //path = Config.path + "_Ch0" + "_" + Convert.ToString(fileindex) + "_" + ((daqcontrol.samplerate).ToString("f0")) + ".csv";
                    Config.outputch = new FileStream(Config.path + "_" + ((daqcontrol.samplerate).ToString("f0")) + "_CH0" + "_" + Convert.ToString(fileindex) + ".csv", FileMode.Create, FileAccess.ReadWrite);
                    Config.csvWtr = new StreamWriter(Config.outputch);
                    for (int i = 0; i < daqcontrol.perchanlength; i++)
                    {
                        Config.csvWtr.WriteLine(daqcontrol.ch0data[i]);

                    }
                    Config.csvWtr.Close();

                    File.WriteAllLines(Config.path, daqcontrol.ch0data.Select(d => d.ToString()).ToArray());
                    break;

                case 1:
                    //path = Config.path + "_Ch1" + "_" + Convert.ToString(fileindex) + "_" + ((daqcontrol.samplerate).ToString("f0")) + ".csv";
                    Config.outputch = new FileStream(Config.path + "_" + ((daqcontrol.samplerate).ToString("f0")) + "_CH1" + "_" + Convert.ToString(fileindex) + ".csv", FileMode.Create, FileAccess.ReadWrite);
                    Config.csvWtr = new StreamWriter(Config.outputch);

                    for (int i = 0; i < daqcontrol.perchanlength; i++)
                    {
                        Config.csvWtr.WriteLine(daqcontrol.ch1data[i]);

                    }
                    Config.csvWtr.Close();

                    //File.WriteAllLines(path, daqcontrol.ch1data.Select(d => d.ToString()).ToArray());
                    break;
                case 2:
                    //path = Config.path + "_Ch2" + "_" + Convert.ToString(fileindex) + "_" + ((daqcontrol.samplerate).ToString("f0")) + ".csv";
                    Config.outputch = new FileStream(Config.path + "_" + ((daqcontrol.samplerate).ToString("f0")) + "_CH2" + "_" + Convert.ToString(fileindex) + ".csv", FileMode.Create, FileAccess.ReadWrite);
                    Config.csvWtr = new StreamWriter(Config.outputch);
                    for (int i = 0; i < daqcontrol.perchanlength; i++)
                    {
                        Config.csvWtr.WriteLine(daqcontrol.ch2data[i]);
                    }
                    Config.csvWtr.Close();

                    //File.WriteAllLines(path, daqcontrol.ch2data.Select(d => d.ToString()).ToArray());
                    break;

                case 3:
                    //path = Config.path + "_Ch3" + "_" + Convert.ToString(fileindex) + "_" + ((daqcontrol.samplerate).ToString("f0")) + ".csv";
                    Config.outputch = new FileStream(Config.path + "_" + ((daqcontrol.samplerate).ToString("f0")) + "_CH3" + "_" + Convert.ToString(fileindex) + ".csv", FileMode.Create, FileAccess.ReadWrite);
                    Config.csvWtr = new StreamWriter(Config.outputch);

                    for (int i = 0; i < daqcontrol.perchanlength; i++)
                    {
                        Config.csvWtr.WriteLine(daqcontrol.ch3data[i]);
                    }

                    Config.csvWtr.Close();

                    //File.WriteAllLines(path, daqcontrol.ch3data.Select(d => d.ToString()).ToArray());
                    break;

            }

        }
        private void writefftdataCsv(int ch, uint fileindex)
        {
            //string path = null;
            CreateIfMissing("c:\\ADLINK\\MCM\\Data\\All FFTData\\" + Config.ConfigFileName + "\\" + Config.TrendDateTime.ToString("yyyy-MM-dd"));
            Config.path = @"c:\\ADLINK\\MCM\\Data\All FFTData\\" + Config.ConfigFileName + "\\" + Config.TrendDateTime.ToString("yyyy-MM-dd") + "\\" + Config.TrendDateTime.ToString("yyyy-MM-dd HH_mm_ss");
            switch (ch)
            {
                case 0:
                    //path = Config.path + "_Ch0" + "_" + Convert.ToString(fileindex) + "_" + ((daqcontrol.samplerate).ToString("f0")) + ".csv";
                    Config.outputch = new FileStream(Config.path + "_" + ((daqcontrol.samplerate).ToString("f0")) + "_CH0" + "_" + Convert.ToString(fileindex) + "_" + "FFT" + ".csv", FileMode.Create, FileAccess.ReadWrite);
                    Config.csvWtr = new StreamWriter(Config.outputch);
                    Config.csvWtr.WriteLine(null + "," + Config.TrendDateTime.ToString("yyyy-MM-dd HH_mm_ss") + "_" + ((daqcontrol.samplerate).ToString("f0")) + "_CH0" + "_" + Convert.ToString(fileindex) + "_" + "FFT" + ".csv");
                    Config.csvWtr.WriteLine(null + "," + "g rms");
                    for (int i = 0; i < spectrum.spectrumlength / 2; i++)
                    {
                        Config.csvWtr.WriteLine(spectrum.dfx[i] + "," + spectrum.ch0spectrumdata[i]);
                    }
                    Config.csvWtr.Close();

                    //File.WriteAllLines(path, daqcontrol.ch0data.Select(d => d.ToString()).ToArray());
                    break;

                case 1:
                    //path = Config.path + "_Ch1" + "_" + Convert.ToString(fileindex) + "_" + ((daqcontrol.samplerate).ToString("f0")) + ".csv";
                    Config.outputch = new FileStream(Config.path + "_" + ((daqcontrol.samplerate).ToString("f0")) + "_CH1" + "_" + Convert.ToString(fileindex) + "_" + "FFT" + ".csv", FileMode.Create, FileAccess.ReadWrite);
                    Config.csvWtr = new StreamWriter(Config.outputch);
                    Config.csvWtr.WriteLine(null + "," + Config.TrendDateTime.ToString("yyyy-MM-dd HH_mm_ss") + "_" + ((daqcontrol.samplerate).ToString("f0")) + "_CH1" + "_" + Convert.ToString(fileindex) + "_" + "FFT" + ".csv");
                    Config.csvWtr.WriteLine(null + "," + "g rms");
                    for (int i = 0; i < spectrum.spectrumlength / 2; i++)
                    {
                        Config.csvWtr.WriteLine(spectrum.dfx[i] + "," + spectrum.ch1spectrumdata[i]);

                    }
                    Config.csvWtr.Close();

                    //File.WriteAllLines(path, daqcontrol.ch1data.Select(d => d.ToString()).ToArray());
                    break;
                case 2:
                    //path = Config.path + "_Ch2" + "_" + Convert.ToString(fileindex) + "_" + ((daqcontrol.samplerate).ToString("f0")) + ".csv";
                    Config.outputch = new FileStream(Config.path + "_" + ((daqcontrol.samplerate).ToString("f0")) + "_CH2" + "_" + Convert.ToString(fileindex) + "_" + "FFT" + ".csv", FileMode.Create, FileAccess.ReadWrite);
                    Config.csvWtr = new StreamWriter(Config.outputch);
                    Config.csvWtr.WriteLine(null + "," + Config.TrendDateTime.ToString("yyyy-MM-dd HH_mm_ss") + "_" + ((daqcontrol.samplerate).ToString("f0")) + "_CH2" + "_" + Convert.ToString(fileindex) + "_" + "FFT" + ".csv");
                    Config.csvWtr.WriteLine(null + "," + "g rms");
                    for (int i = 0; i < spectrum.spectrumlength / 2; i++)
                    {
                        Config.csvWtr.WriteLine(spectrum.dfx[i] + "," + spectrum.ch2spectrumdata[i]);

                    }
                    Config.csvWtr.Close();

                    //File.WriteAllLines(path, daqcontrol.ch2data.Select(d => d.ToString()).ToArray());
                    break;

                case 3:
                    //path = Config.path + "_Ch3" + "_" + Convert.ToString(fileindex) + "_" + ((daqcontrol.samplerate).ToString("f0")) + ".csv";
                    Config.outputch = new FileStream(Config.path + "_" + ((daqcontrol.samplerate).ToString("f0")) + "_CH3" + "_" + Convert.ToString(fileindex) + "_" + "FFT" + ".csv", FileMode.Create, FileAccess.ReadWrite);
                    Config.csvWtr = new StreamWriter(Config.outputch);
                    Config.csvWtr.WriteLine(null + "," + Config.TrendDateTime.ToString("yyyy-MM-dd HH_mm_ss") + "_" + ((daqcontrol.samplerate).ToString("f0")) + "_CH3" + "_" + Convert.ToString(fileindex) + "_" + "FFT" + ".csv");
                    Config.csvWtr.WriteLine(null + "," + "g rms");
                    for (int i = 0; i < spectrum.spectrumlength / 2; i++)
                    {
                        Config.csvWtr.WriteLine(spectrum.dfx[i] + "," + spectrum.ch3spectrumdata[i]);

                    }

                    Config.csvWtr.Close();
                    //File.WriteAllLines(path, daqcontrol.ch3data.Select(d => d.ToString()).ToArray());
                    break;

            }

        }
        private void DataToTrend(int ch)
        {
            switch (ch)
            {

                case 0:
                    for (int i = 0; i < Config.MonitorParameterCh0.GetLength(0); i++)
                    {
                        OA(Config.MonitorParameterCh0[i, 3], spectrum.ch0averagespectrumdata, Convert.ToInt32(Config.MonitorParameterCh0[i, 4]), Convert.ToInt32(Config.MonitorParameterCh0[i, 5]));
                        Config.OATreandParameter[0] = Config.ChannelParameter[0, 3];
                        Config.OATreandParameter[1] = Config.MonitorParameterCh0[i, 2];
                        Config.OATreandParameter[2] = Convert.ToString(spectrum.OA);
                        Config.OATreandParameter[3] = Config.MonitorParameterCh0[i, 3];
                        Config.OATreandParameter[4] = Config.MonitorParameterCh0[i, 4];
                        Config.OATreandParameter[5] = Config.MonitorParameterCh0[i, 5];
                        Config.OATreandParameter[6] = Config.MonitorParameterCh0[i, 6];
                        Config.OATreandParameter[7] = Config.MonitorParameterCh0[i, 7];
                        Config.OATreandParameter[8] = Config.TrendDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                        database.InsertTable(Config.MonitorParameterCh0[i, 1], Config.OATreandColumnName, Config.OATreandParameter);
                        Config.OAvalueParameter[i, 3] = spectrum.OA.ToString("f4");
                    }
                    break;
                case 1:
                    for (int i = 0; i < Config.MonitorParameterCh1.GetLength(0); i++)
                    {
                        OA(Config.MonitorParameterCh1[i, 3], spectrum.ch1averagespectrumdata, Convert.ToInt32(Config.MonitorParameterCh1[i, 4]), Convert.ToInt32(Config.MonitorParameterCh1[i, 5]));
                        Config.OATreandParameter[0] = Config.ChannelParameter[1, 3];
                        Config.OATreandParameter[1] = Config.MonitorParameterCh1[i, 2];
                        Config.OATreandParameter[2] = Convert.ToString(spectrum.OA);
                        Config.OATreandParameter[3] = Config.MonitorParameterCh1[i, 3];
                        Config.OATreandParameter[4] = Config.MonitorParameterCh1[i, 4];
                        Config.OATreandParameter[5] = Config.MonitorParameterCh1[i, 5];
                        Config.OATreandParameter[6] = Config.MonitorParameterCh1[i, 6];
                        Config.OATreandParameter[7] = Config.MonitorParameterCh1[i, 7];
                        Config.OATreandParameter[8] = Config.TrendDateTime.ToString("yyyy-MM-dd HH:mm:ss"); ;
                        database.InsertTable(Config.MonitorParameterCh1[i, 1], Config.OATreandColumnName, Config.OATreandParameter);
                        Config.OAvalueParameter[i + Config.monitorlength0, 3] = spectrum.OA.ToString("f4");
                    }
                    break;
                case 2:
                    for (int i = 0; i < Config.MonitorParameterCh2.GetLength(0); i++)
                    {
                        OA(Config.MonitorParameterCh2[i, 3], spectrum.ch2averagespectrumdata, Convert.ToInt32(Config.MonitorParameterCh2[i, 4]), Convert.ToInt32(Config.MonitorParameterCh2[i, 5]));
                        Config.OATreandParameter[0] = Config.ChannelParameter[2, 3];
                        Config.OATreandParameter[1] = Config.MonitorParameterCh2[i, 2];
                        Config.OATreandParameter[2] = Convert.ToString(spectrum.OA);
                        Config.OATreandParameter[3] = Config.MonitorParameterCh2[i, 3];
                        Config.OATreandParameter[4] = Config.MonitorParameterCh2[i, 4];
                        Config.OATreandParameter[5] = Config.MonitorParameterCh2[i, 5];
                        Config.OATreandParameter[6] = Config.MonitorParameterCh2[i, 6];
                        Config.OATreandParameter[7] = Config.MonitorParameterCh2[i, 7];
                        Config.OATreandParameter[8] = Config.TrendDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                        database.InsertTable(Config.MonitorParameterCh2[i, 1], Config.OATreandColumnName, Config.OATreandParameter);
                        Config.OAvalueParameter[i + Config.monitorlength0 + Config.monitorlength1, 3] = spectrum.OA.ToString("f4");
                    }
                    break;
                case 3:
                    for (int i = 0; i < Config.MonitorParameterCh3.GetLength(0); i++)
                    {
                        OA(Config.MonitorParameterCh3[i, 3], spectrum.ch3averagespectrumdata, Convert.ToInt32(Config.MonitorParameterCh3[i, 4]), Convert.ToInt32(Config.MonitorParameterCh3[i, 5]));
                        Config.OATreandParameter[0] = Config.ChannelParameter[3, 3];
                        Config.OATreandParameter[1] = Config.MonitorParameterCh3[i, 2];
                        Config.OATreandParameter[2] = Convert.ToString(spectrum.OA);
                        Config.OATreandParameter[3] = Config.MonitorParameterCh3[i, 3];
                        Config.OATreandParameter[4] = Config.MonitorParameterCh3[i, 4];
                        Config.OATreandParameter[5] = Config.MonitorParameterCh3[i, 5];
                        Config.OATreandParameter[6] = Config.MonitorParameterCh3[i, 6];
                        Config.OATreandParameter[7] = Config.MonitorParameterCh3[i, 7];
                        Config.OATreandParameter[8] = Config.TrendDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                        database.InsertTable(Config.MonitorParameterCh3[i, 1], Config.OATreandColumnName, Config.OATreandParameter);
                        Config.OAvalueParameter[i + Config.monitorlength0 + Config.monitorlength1 + Config.monitorlength2, 3] = spectrum.OA.ToString("f4");
                    }
                    break;
            }

        }
        private void OA(string type, double[] spectrumdata, int start, int end)
        {
            spectrum.OA = 0;
            double disp = 0;
            start = (int)(start / daqcontrol.resolution);
            if (start < 2)
            {
                start = 2;
            }
            end = (int)(end / daqcontrol.resolution);
            switch (type)
            {

                case "g rms":
                    for (int l = start; l <= end; l++)
                    {
                        spectrum.OA = spectrum.OA + Math.Pow(spectrumdata[l], 2);
                    }
                    spectrum.OA = Math.Sqrt(spectrum.OA / 1.5);
                    break;
                case "g pk":
                    for (int l = start; l <= end; l++)
                    {
                        spectrum.OA = spectrum.OA + Math.Pow(spectrumdata[l], 2);
                    }
                    spectrum.OA = Math.Sqrt(2) * Math.Sqrt(spectrum.OA / 1.5);
                    break;
                case "mm/s rms":
                    for (int l = start; l <= end; l++)
                    {
                        spectrum.OA = spectrum.OA + Math.Pow((spectrumdata[l] / (2 * 3.14 * spectrum.dfx[l])), 2);
                    }
                    spectrum.OA = 1000 * 9.81 * Math.Sqrt(spectrum.OA / 1.5);
                    break;
                case "mm/s pk":
                    for (int l = start; l <= end; l++)
                    {
                        spectrum.OA = spectrum.OA + Math.Pow((spectrumdata[l] / (2 * 3.14 * spectrum.dfx[l])), 2);
                    }
                    spectrum.OA = Math.Sqrt(2) * 1000 * 9.81 * Math.Sqrt(spectrum.OA / 1.5);
                    break;
                case "um pp":
                    for (int l = start; l <= end; l++)
                    {
                        //spectrum.OA = spectrum.OA + Math.Pow((spectrumdata[l] / (Math.Pow((2 * 3.14 * spectrum.dfx[l]), 2))), 2);                        
                        disp = (2 * 3.1415926 * spectrum.dfx[l]) * (2 * 3.1415926 * spectrum.dfx[l]);
                        spectrum.OA = spectrum.OA + Math.Pow((spectrumdata[l] / disp), 2);
                    }
                    spectrum.OA = 2 * Math.Sqrt(2) * 1000000 * 9.81 * Math.Sqrt(spectrum.OA / 1.5);
                    break;
            }
        }
        private void averagedata()
        {
            if (Config.averageenable == true && Config.averageindex < Convert.ToInt16(Config.UIParameter[11]))
            {
                Config.averageindex++;
                Config.AvailableSpace = space.AvailableFreeSpace;
                Config.HDspaces = (Convert.ToUInt32(Config.UIParameter[13]) * Config.gb);
                if (Config.averageindex == 1)
                {
                    Config.TrendDateTime = qoutdata.logtime;// Convert.ToDateTime(DateTime.Now);
                    rawdata = new JObject();
                    ch0rawdataarray = new JArray();
                    ch1rawdataarray = new JArray();
                    ch2rawdataarray = new JArray();
                    ch3rawdataarray = new JArray();

                }
                if (Config.AvailableSpace > Config.HDspaces)
                {
                    Config.StorageAlarm = false;
                }
                else
                {
                    Config.StorageAlarm = true;

                }
                if (Convert.ToBoolean(Config.ChannelParameter[0, 2]) && Config.MonitorParameterCh0.GetLength(0) > 0)
                {
                    if (Convert.ToBoolean(Config.UIParameter[8]))
                    {
                        writefftdataCsv(0, Config.averageindex);
                        if (Config.StorageAlarm)
                        {
                            Deleteoldfile(@"C:\\ADLINK\\MCM\\Data\All FFTData\\" + Config.ConfigFileName + "\\");
                        }
                    }
                    if (Convert.ToBoolean(Config.UIParameter[9]))
                    {
                        writedataCsv(0, Config.averageindex);
                        if (Config.StorageAlarm)
                        {
                            Deleteoldfile(@"C:\\ADLINK\\MCM\\Data\All RAWData\\" + Config.ConfigFileName + "\\");
                        }
                    }
                    if (Convert.ToBoolean(Config.UIParameter[3]))
                    {
                        WritedataJson(0);
                    }
                    if (Config.StorageAlarm)
                    {
                        Deleteoldfile(@"C:\\ADLINK\\MCM\\Data\Alarm RAWData\\" + Config.ConfigFileName + "\\");
                    }

                }
                if (Convert.ToBoolean(Config.ChannelParameter[1, 2]) && Config.MonitorParameterCh1.GetLength(0) > 0)
                {
                    if (Convert.ToBoolean(Config.UIParameter[8]))
                    {
                        writefftdataCsv(1, Config.averageindex);
                        if (Config.StorageAlarm)
                        {
                            Deleteoldfile(@"C:\\ADLINK\\MCM\\Data\All FFTData\\" + Config.ConfigFileName + "\\");
                        }
                    }
                    if (Convert.ToBoolean(Config.UIParameter[9]))
                    {
                        writedataCsv(1, Config.averageindex);
                        if (Config.StorageAlarm)
                        {
                            Deleteoldfile(@"C:\\ADLINK\\MCM\\Data\All RAWData\\" + Config.ConfigFileName + "\\");
                        }
                    }
                    if (Convert.ToBoolean(Config.UIParameter[3]))
                    {
                        WritedataJson(1);
                    }
                    if (Config.StorageAlarm)
                    {
                        Deleteoldfile(@"C:\\ADLINK\\MCM\\Data\Alarm RAWData\\" + Config.ConfigFileName + "\\");
                    }
                }
                if (Convert.ToBoolean(Config.ChannelParameter[2, 2]) && Config.MonitorParameterCh2.GetLength(0) > 0)
                {
                    if (Convert.ToBoolean(Config.UIParameter[8]))
                    {
                        writefftdataCsv(2, Config.averageindex);
                        if (Config.StorageAlarm)
                        {
                            Deleteoldfile(@"C:\\ADLINK\\MCM\\Data\All FFTData\\" + Config.ConfigFileName + "\\");
                        }
                    }
                    if (Convert.ToBoolean(Config.UIParameter[9]))
                    {
                        writedataCsv(2, Config.averageindex);
                        if (Config.StorageAlarm)
                        {
                            Deleteoldfile(@"C:\\ADLINK\\MCM\\Data\All RAWData\\" + Config.ConfigFileName + "\\");
                        }
                    }
                    if (Convert.ToBoolean(Config.UIParameter[3]))
                    {
                        WritedataJson(2);
                    }
                    if (Config.StorageAlarm)
                    {
                        Deleteoldfile(@"C:\\ADLINK\\MCM\\Data\Alarm RAWData\\" + Config.ConfigFileName + "\\");
                    }
                }
                if (Convert.ToBoolean(Config.ChannelParameter[3, 2]) && Config.MonitorParameterCh3.GetLength(0) > 0)
                {
                    if (Convert.ToBoolean(Config.UIParameter[8]))
                    {
                        writefftdataCsv(3, Config.averageindex);
                        if (Config.StorageAlarm)
                        {
                            Deleteoldfile(@"C:\\ADLINK\\MCM\\Data\All FFTData\\" + Config.ConfigFileName + "\\");
                        }
                    }
                    if (Convert.ToBoolean(Config.UIParameter[9]))
                    {
                        writedataCsv(3, Config.averageindex);
                        if (Config.StorageAlarm)
                        {
                            Deleteoldfile(@"C:\\ADLINK\\MCM\\Data\All RAWData\\" + Config.ConfigFileName + "\\");
                        }
                    }
                    if (Convert.ToBoolean(Config.UIParameter[3]))
                    {
                        WritedataJson(3);
                    }
                    if (Config.StorageAlarm)
                    {
                        Deleteoldfile(@"C:\\ADLINK\\MCM\\Data\Alarm RAWData\\" + Config.ConfigFileName + "\\");
                    }
                }


                for (int i = 0; i < spectrum.spectrumlength / 2; i++)
                {
                    if (Convert.ToBoolean(Config.ChannelParameter[0, 2]))
                        spectrum.ch0averagespectrumdata[i] = spectrum.ch0averagespectrumdata[i] + spectrum.ch0spectrumdata[i];
                    if (Convert.ToBoolean(Config.ChannelParameter[1, 2]))
                        spectrum.ch1averagespectrumdata[i] = spectrum.ch1averagespectrumdata[i] + spectrum.ch1spectrumdata[i];
                    if (Convert.ToBoolean(Config.ChannelParameter[2, 2]))
                        spectrum.ch2averagespectrumdata[i] = spectrum.ch2averagespectrumdata[i] + spectrum.ch2spectrumdata[i];
                    if (Convert.ToBoolean(Config.ChannelParameter[3, 2]))
                        spectrum.ch3averagespectrumdata[i] = spectrum.ch3averagespectrumdata[i] + spectrum.ch3spectrumdata[i];
                }
                if (Config.averageindex == Convert.ToInt16(Convert.ToInt16(Config.UIParameter[11])))
                {
                    for (int i = 0; i < spectrum.spectrumlength / 2; i++)
                    {
                        if (Convert.ToBoolean(Config.ChannelParameter[0, 2]))
                            spectrum.ch0averagespectrumdata[i] = spectrum.ch0averagespectrumdata[i] / Config.averageindex;
                        if (Convert.ToBoolean(Config.ChannelParameter[1, 2]))
                            spectrum.ch1averagespectrumdata[i] = spectrum.ch1averagespectrumdata[i] / Config.averageindex;
                        if (Convert.ToBoolean(Config.ChannelParameter[2, 2]))
                            spectrum.ch2averagespectrumdata[i] = spectrum.ch2averagespectrumdata[i] / Config.averageindex;
                        if (Convert.ToBoolean(Config.ChannelParameter[3, 2]))
                            spectrum.ch3averagespectrumdata[i] = spectrum.ch3averagespectrumdata[i] / Config.averageindex;

                    }

                    Config.averageenable = false;
                }

            }

        }
        private void metroTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroTabControl1.SelectedTab == machinestatus && thdtrend.IsAlive == false)
            {
                if (StopBandCheck() == false)
                {
                    MCMUIUpdate();
                    Config.OATrendCurRow = 0;
                    thdtrend = new Thread(trend);
                    DataQueue = new Thread(ProcessQueue);
                    Config.averageindex = 0;
                    Config.averageenable = false;
                    Config.firstupdate = true;
                    //InitialProcess();
                    MCMInitialOATrendArray();

                    InitialDAQ();
                    Config.Modbuserror = false;
                    Config.DDSerror = false;
                    Config.Azureerror = false;
                    Config.Mqtterror = false;
                    
                    if (this.metroCheckBoxAzure.Checked)
                    {
                        Azure();
                    }                  
                    UpateDeviceConfig();
                    UpateSpectrumConfig();

                    if ((Config.allchannelmemsize < Config.memsizereturn) && !(Config.DDSerror || Config.Azureerror || Config.Modbuserror || Config.Mqtterror))
                    {
                        Configuredaq();
                        DataQueue.Start();
                        thdtrend.Start();
                        //IniModBus();
                        if ((Config.monitorlength0 + Config.monitorlength1 + Config.monitorlength2 + Config.monitorlength3) == 0)
                        {
                            this.dataGridViewOATrend.Rows.Clear();
                            ClearTrendata();
                        }
                    }
                    else
                    {
                        daqcontrol.result = USBDASK.UD_Release_Card(0);
                        metroTabControl1.SelectedTab = Setting;
                        if (Config.allchannelmemsize > Config.memsizereturn)
                        {
                            MessageBox.Show("Initial Memory Allocated is not enough ,Please reduce bandwidth or reboot your computer with USB-2405");
                        }
                    }
                }
                else
                {
                    metroTabControl1.SelectedTab = Setting;
                    MessageBox.Show("Please check all of your Stop Frequency must  < Bandwidth");
                }

            }
            if (metroTabControl1.SelectedTab == Analysis)
            {
                if (StopBandCheck() == false)
                {
                    ConfigureAnalysis();
                }
                else
                {
                    metroTabControl1.SelectedTab = Setting;
                    MessageBox.Show("Please check all of your Stop Frequency must  < Bandwidth");
                }
            }
            if (metroTabControl1.SelectedTab == Setting)
            {
                daqcontrol.result = USBDASK.UD_AI_AsyncClear(0, out daqcontrol.AccessCnt);


                daqcontrol.result = USBDASK.UD_Release_Card(0);
                //slave.Dispose();
                if (DataQueue.IsAlive)
                {
                    if (false == thdtrend.Join(200))
                    {
                        DataQueue.Abort();
                    }
                }
                if (thdtrend.IsAlive)
                {
                    if (false == thdtrend.Join(200))
                    {
                        thdtrend.Abort();
                    }
                }
                
                if (Config.Modbusenable)
                {
                    slave.Dispose();
                }
                if (Config.DDSenble)
                {
                    //DisposeDDS();
                }
                if (Config.Mqttenable)
                {
                    try
                    {
                        mqtt_client.Disconnect();
                    }
                    catch
                    {

                    }
                }
                Config.Modbusenable = false;
                Config.DDSenble = false;
                Config.Azureenable = false;
                Config.Mqttenable = false;

            }


        }
        private void dataGridViewOATrend_SelectionChanged(object sender, EventArgs e)
        {
            if ((Config.monitorlength0 + Config.monitorlength1 + Config.monitorlength2 + Config.monitorlength3) > 0 && Config.firstupdate == false)
            {
                Config.OATrendCurRow = dataGridViewOATrend.CurrentRow.Index;
                Updateselecttrenddata(Config.OAvalueParameter[Config.OATrendCurRow, 0]);
                DiaplayTrendData(Analyze.datadate, Analyze.OAvaluecolum, Analyze.warning, Analyze.alarm, Analyze.OAUnit);
            }
        }
        private void CreateIfMissing(string path)
        {
            bool folderExists = Directory.Exists(path);
            if (!folderExists)
                Directory.CreateDirectory(path);
        }
        private void buttonquery_Click(object sender, EventArgs e)
        {
            MCMAlarmlog();

        }
        private void buttonAnalysisquery_Click(object sender, EventArgs e)
        {
            myForm2 = new Form2();
            myForm2.FormClosed += new FormClosedEventHandler(form2_FormClosed);
            myForm2.startD = startdate;
            myForm2.endD = enddate;
            myForm2.tablename = Config.Analysistablename[dataGridViewOATrendAnalysis.CurrentRow.Index];
            myForm2.ShowDialog();
        }

        private void dataGridViewOATrendAnalysis_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewOATrendAnalysis.Rows.Count > 0)
            {
                if (Config.firsttime)
                {
                    ButtonEnable();
                    Config.firsttime = false;
                    startdate = new DateTime();
                    enddate = new DateTime();
                }
                UpdateAnalysistrenddata(Config.Analysistablename[dataGridViewOATrendAnalysis.CurrentRow.Index]);
                Datafromdatetime("HH:mm:ss", "hours");
            }

        }

        private void zedGraphAnalysishistory_MouseClick(object sender, MouseEventArgs e)
        {
            GraphPane myPane = zedGraphAnalysishistory.GraphPane;
            CurveItem n_curve = null;

            int index = 0;
            string time = null;
            string day = null;
            string channel = Convert.ToString(Config.Analysistablename[dataGridViewOATrendAnalysis.CurrentRow.Index]);
            DateTime t;
            FileInfo[] files;
            string[] filenames;

            myPane.FindNearestPoint(e.Location, out n_curve, out index);
            RowDatafolderPath = @"C:\\ADLINK\\MCM\\Data\All RAWData\\" + Config.ConfigFileName;
            if (index >= 0 && Analyze.datadate.GetLongLength(0) > index)
            {

                t = new XDate(Analyze.datadate[index]).DateTime;
                time = t.ToString("yyyy-MM-dd HH_mm_ss");
                day = t.ToString("yyyy-MM-dd");
                RowDatafolderPath = @"C:\\ADLINK\\MCM\\Data\All RAWData\\" + Config.ConfigFileName + "\\" + day;
                dir = new DirectoryInfo(RowDatafolderPath);
                channel = channel.Substring(0, channel.IndexOf("_"));
                files = dir.GetFiles(time + "_" + "*" + "_" + channel + "*", SearchOption.AllDirectories);
                RowDatafolderPath = @"C:\\ADLINK\\MCM\\Data\All RAWData\\" + Config.ConfigFileName;
                if (files.Length > 0)
                {
                    RowDatafolderPath = files[0].Directory.ToString();
                    filenames = files.Select(f => f.Name).ToArray();
                    RowDatafolderPath = @"C:\\ADLINK\\MCM\\Data\All RAWData\\" + Config.ConfigFileName;
                    this.dataGridViewfileAnalysis.SelectionChanged -= new System.EventHandler(this.dataGridViewfileAnalysis_SelectionChanged);
                    this.dataGridViewfileAnalysis.Rows.Clear();

                    for (int i = 0; i < filenames.Length; i++)
                    {
                        dataGridViewfileAnalysis.Rows.Add(new object[] { filenames[i] });
                    }
                    this.dataGridViewfileAnalysis.SelectionChanged += new System.EventHandler(this.dataGridViewfileAnalysis_SelectionChanged);
                    dataGridViewfileAnalysis.CurrentRow.Selected = true;
                }
            }

        }

        private void dataGridViewfileAnalysis_SelectionChanged(object sender, EventArgs e)
        {
            string filename = Convert.ToString(dataGridViewfileAnalysis.CurrentRow.Cells[0].Value);
            string format;
            string Analysissamplingrate;
            format = (filename.Substring(filename.LastIndexOf(".") + 1));
            double[] data;
            if (format == "dat")
            {
                FileStream fs = File.OpenRead(RowDatafolderPath + "\\" + filename.Substring(0, filename.IndexOf(" ")) + "\\" + filename);
                BinaryReader br = new BinaryReader(fs);
                long numberEntries = fs.Length / sizeof(double);
                data = new double[numberEntries];
                for (int i = 0; i < numberEntries; ++i)
                {
                    data[i] = br.ReadDouble();
                }

            }
            else
            {
                data = File.ReadAllLines(RowDatafolderPath + "\\" + filename.Substring(0, filename.IndexOf(" ")) + "\\" + filename, Encoding.UTF8).Select(double.Parse).ToArray();


            }
            Analysissamplingrate = (filename.Substring(20, filename.LastIndexOf("CH") - 21));
            double[] Analysisdtx = new double[data.GetLength(0)];
            spectrum.Analysisdfx = new double[data.GetLength(0) / 2];
            for (int i = 0; i < data.GetLength(0); i++)
            {
                if (i == 0)
                {
                    Analysisdtx[i] = 0;
                }
                else
                {
                    Analysisdtx[i] = Analysisdtx[i - 1] + (1 / Convert.ToDouble(Analysissamplingrate));
                }
            }
            DisplayAnalysisaidata(Analysisdtx, data);
            spectrum.Anaspectrum = Analysispectrum(data, Convert.ToDouble(Analysissamplingrate));
            for (int x = 0; x < spectrum.Anaspectrum.GetLength(0) / 2; x++)
            {
                if (x == 0)
                {
                    spectrum.Analysisdfx[x] = 0;
                }
                else
                {
                    spectrum.Analysisdfx[x] = spectrum.Analysisdfx[x - 1] + (Convert.ToDouble(Analysissamplingrate) / data.GetLength(0));
                }
            }
            DisplayAnalysisFFTdata(spectrum.Analysisdfx, spectrum.Anaspectrum);
        }


        public void Datafromdatetime(string format, string Unit)
        {
            if (Analysisdatabase.data.Rows.Count > 0)
            {
                Analysisdatabase.SelectMaxdate(Config.Analysistablename[dataGridViewOATrendAnalysis.CurrentRow.Index]);
                while (Analysisdatabase.reader.Read())
                {
                    enddate = Convert.ToDateTime(Analysisdatabase.reader[0]);
                }
                Analysisdatabase.reader.Close();
                switch (Unit)
                {
                    case "default":

                        break;
                    case "hours":
                        startdate = enddate.AddHours(-1);
                        break;
                    case "days":
                        startdate = enddate.AddDays(-1);
                        break;
                    case "months":
                        startdate = enddate.AddMonths(-1);
                        break;
                    case "years":
                        startdate = enddate.AddYears(-1);
                        break;
                }

                UpdatetrenddataBetweenDate(Config.Analysistablename[dataGridViewOATrendAnalysis.CurrentRow.Index], startdate.ToString("yyyy-MM-dd HH:mm:ss"), enddate.ToString("yyyy-MM-dd HH:mm:ss"));
                DisplayAnalysisTrendData(startdate, enddate, format, Unit);
            }
        }

        private void metroButtonhours_Click(object sender, EventArgs e)
        {
            Datafromdatetime("MM-dd HH:mm:ss", "hours");
        }

        private void metroButtondays_Click(object sender, EventArgs e)
        {
            Datafromdatetime("MM-dd HH:mm:ss", "days");
        }

        private void metroButtonmonths_Click(object sender, EventArgs e)
        {
            Datafromdatetime("yyyy-MM-dd HH:mm:ss", "months");
        }

        private void metroButtonyears_Click(object sender, EventArgs e)
        {
            Datafromdatetime("yyyy-MM-dd HH:mm:ss", "years");
        }

        private void zedGraphAnalysishistory_MouseMove(object sender, MouseEventArgs e)
        {
            GraphPane myPane = zedGraphAnalysishistory.GraphPane;
            CurveItem n_curve = null;
            int index = 0;
            userCursorsList.Clear();
            userCursorsCurve.Clear();
            myPane.Legend.IsVisible = false;
            myPane.FindNearestPoint(e.Location, out n_curve, out index);
            if (index >= 0 && Analyze.datadate.GetLongLength(0) > index)
            {
                userCursorsList.Add(Analyze.datadate[index], myPane.YAxis.Scale.Max);
                userCursorsList.Add(Analyze.datadate[index], myPane.YAxis.Scale.Min);
                userCursorsCurve = myPane.AddCurve(" ", userCursorsList, Color.White, SymbolType.None);
                zedGraphAnalysishistory.Refresh();
                this.Cursor = Cursors.Default;
            }
        }

        private void dataGridViewChSetting_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string columnName = this.dataGridViewChSetting.Columns[e.ColumnIndex].HeaderText;

            // Check for the column to validate
            if (columnName.Equals("Senseivity mv/g") || columnName.Equals("Type"))
            {
                // Check if the input is empty
                if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    MessageBox.Show("Senseivity or Type could not be empty.");
                    e.Cancel = true;
                }
                if (columnName.Equals("Type"))
                {
                    Regex datePattern = new Regex(@"^\w+$");
                    if (!datePattern.IsMatch(e.FormattedValue.ToString()))
                    {
                        MessageBox.Show("English alphabet and Number or underline only");
                        e.Cancel = true;
                    }
                }
                if (columnName.Equals("Senseivity mv/g"))
                {
                    // Check if the input format is correct
                    Regex datePattern = new Regex(@"^[0-9]*[.][0-9]*|^([+]?[0-9]+\d*)$");
                    if (!datePattern.IsMatch(e.FormattedValue.ToString()))
                    {
                        MessageBox.Show("Senseivity must be a none zero Floating number.");
                        e.Cancel = true;
                    }
                }

            }
        }

        private void dataGridViewMonitorSetting_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string columnName = this.dataGridViewMonitorSetting.Columns[e.ColumnIndex].HeaderText;

            // Check for the column to validate
            if (columnName.Equals("Name") || columnName.Equals("Start Frequency") || columnName.Equals("Stop Frequency") || columnName.Equals("Warning") || columnName.Equals("Alarm"))
            {
                // Check if the input is empty
                if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    MessageBox.Show("Name/Start Frequency/Stop Frequency/Warning/Alarm could not be empty.");
                    e.Cancel = true;
                }
                if (columnName.Equals("Name"))
                {
                    Regex datePattern = new Regex(@"^\w+$");
                    if (!datePattern.IsMatch(e.FormattedValue.ToString()))
                    {
                        MessageBox.Show("English alphabet and Number or underline only");
                        e.Cancel = true;
                    }
                }
                if (columnName.Equals("Start Frequency") || columnName.Equals("Stop Frequency"))
                {
                    // Check if the input format is correct
                    Regex datePattern = new Regex(@"^([+]?[1-9]+\d*)$");
                    if (!datePattern.IsMatch(e.FormattedValue.ToString()))
                    {
                        MessageBox.Show("Start Frequency/Stop Frequency must be a none zero Integer number.");
                        e.Cancel = true;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(e.FormattedValue.ToString()))
                        {
                            int newValue = int.Parse(e.FormattedValue.ToString());
                            int col3Value = (e.ColumnIndex == 2) ? newValue : Convert.ToInt32(dataGridViewMonitorSetting[2, e.RowIndex].Value);
                            int col4Value = (e.ColumnIndex == 3) ? newValue : Convert.ToInt32(dataGridViewMonitorSetting[3, e.RowIndex].Value);
                            if (col3Value >= col4Value)
                            {
                                MessageBox.Show(" Stop Frequency  must > Start Frequency");
                                e.Cancel = true;
                            }
                            string bandwidth = Config.UIParameter[14];
                            int bandstop;
                            if (bandwidth != "500")
                            {
                                bandwidth = bandwidth.Substring(0, bandwidth.IndexOf("K"));
                                bandstop = Convert.ToInt32(bandwidth) * 1000;
                            }
                            else
                            {
                                bandstop = 500;
                            }

                            if (columnName.Equals("Stop Frequency") && col4Value > bandstop)
                            {
                                MessageBox.Show(" Stop Frequency  must  <  Bandwidth");
                                e.Cancel = true;
                            }
                        }
                    }

                }
                if (columnName.Equals("Warning") || columnName.Equals("Alarm"))
                {
                    // Check if the input format is correct
                    Regex datePattern = new Regex(@"^[0-9]*[.][0-9]*|^([+]?[0-9]+\d*)$");//"^[0-9]*[.][0-9]*$"
                    if (!datePattern.IsMatch(e.FormattedValue.ToString()))
                    {
                        MessageBox.Show("Warning/Alarm must be a none zero Floating number.");
                        e.Cancel = true;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(e.FormattedValue.ToString()))
                        {
                            double newValue = double.Parse(e.FormattedValue.ToString());
                            double col4Value = (e.ColumnIndex == 4) ? newValue : Convert.ToDouble(dataGridViewMonitorSetting[4, e.RowIndex].Value);
                            double col5Value = (e.ColumnIndex == 5) ? newValue : Convert.ToDouble(dataGridViewMonitorSetting[5, e.RowIndex].Value);
                            if (col4Value >= col5Value)
                            {
                                MessageBox.Show(" Alarm must > Warning");
                                e.Cancel = true;
                            }
                        }
                    }
                }

            }
        }

        private void TextBoxNormalSechedule_Validating(object sender, CancelEventArgs e)
        {
            Regex datePattern = new Regex(@"^([+]?[1-9]+\d*)$");
            if (!datePattern.IsMatch(TextBoxNormalSechedule.Text))
            {
                MessageBox.Show("Schedule must be a none zero Integer number.");
                e.Cancel = true;
            }
            if (Convert.ToInt16(TextBoxNormalSechedule.Text) < Convert.ToInt16(TextBoxNormalAverages.Text))
            {
                MessageBox.Show("Schedule must >= Average times.");
                e.Cancel = true;
            }
        }

        private void TextBoxNormalAverages_Validating(object sender, CancelEventArgs e)
        {
            Regex datePattern = new Regex(@"^([+]?[1-9]+\d*)$");
            if (!datePattern.IsMatch(TextBoxNormalAverages.Text))
            {
                MessageBox.Show("Average times must be a none zero Integer number.");
                e.Cancel = true;
            }
            if (Convert.ToInt16(TextBoxNormalSechedule.Text) < Convert.ToInt16(TextBoxNormalAverages.Text))
            {
                MessageBox.Show(" Average times must <= Schedule .");
                e.Cancel = true;
            }
        }
        private void TextBoxHDspace_Validating(object sender, CancelEventArgs e)
        {
            Regex datePattern = new Regex(@"^([+]?[1-9]+\d*)$");
            if (!datePattern.IsMatch(TextBoxHDspace.Text))
            {
                MessageBox.Show("Keep HD Spaces must be a none zero Integer number.");
                e.Cancel = true;
            }
            if (Convert.ToInt16(TextBoxHDspace.Text) < 2)
            {
                MessageBox.Show(" Keep HD Space must >= 2GB .");
                e.Cancel = true;
            }
        }
        void form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            startdate = myForm2.startD;
            enddate = myForm2.endD;
            //Datafromdatetime("yyyy-MM-dd HH:mm:ss", "default");
            UpdatetrenddataBetweenDate(Config.Analysistablename[dataGridViewOATrendAnalysis.CurrentRow.Index], startdate.ToString("yyyy-MM-dd HH:mm:ss"), enddate.ToString("yyyy-MM-dd HH:mm:ss"));
            DisplayAnalysisTrendData(startdate, enddate, "yyyy-MM-dd HH:mm:ss", "default");
            myForm2.FormClosed -= new FormClosedEventHandler(form2_FormClosed);
        }
        private bool StopBandCheck()
        {
            string bandwidth = Config.UIParameter[14];
            int bandstop;
            int checkindex = 0;
            if (bandwidth != "500")
            {
                bandwidth = bandwidth.Substring(0, bandwidth.IndexOf("K"));
                bandstop = Convert.ToInt32(bandwidth) * 1000;
            }
            else
            {
                bandstop = 500;
            }
            for (int i = 0; i < Config.MonitorParameterCh0.GetLength(0); i++)
            {
                if (Convert.ToInt32(Config.MonitorParameterCh0[i, 5]) > bandstop)
                    checkindex++;
            }
            for (int i = 0; i < Config.MonitorParameterCh1.GetLength(0); i++)
            {
                if (Convert.ToInt32(Config.MonitorParameterCh1[i, 5]) > bandstop)
                    checkindex++;
            }
            for (int i = 0; i < Config.MonitorParameterCh2.GetLength(0); i++)
            {
                if (Convert.ToInt32(Config.MonitorParameterCh2[i, 5]) > bandstop)
                    checkindex++;
            }
            for (int i = 0; i < Config.MonitorParameterCh3.GetLength(0); i++)
            {
                if (Convert.ToInt32(Config.MonitorParameterCh3[i, 5]) > bandstop)
                    checkindex++;
            }

            if (checkindex > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void copyfile()
        {
            try
            {

                FileInfo[] Alarmfiles;
                DirectoryInfo diralarm;
                CreateIfMissing("c:\\ADLINK\\MCM\\Data\\Alarm RAWData\\" + Config.ConfigFileName + "\\" + Config.TrendDateTime.ToString("yyyy-MM-dd"));
                string destinationDirectory = "c:\\ADLINK\\MCM\\Data\\Alarm RAWData\\" + Config.ConfigFileName + "\\" + Config.TrendDateTime.ToString("yyyy-MM-dd") + "\\";
                string sourceDirectory = "c:\\ADLINK\\MCM\\Data\\All RAWData\\" + Config.ConfigFileName + "\\" + Config.TrendDateTime.ToString("yyyy-MM-dd") + "\\";
                string alramdatetime = Config.TrendDateTime.ToString("yyyy-MM-dd HH_mm_ss");
                diralarm = new DirectoryInfo(sourceDirectory);
                if (Config.Ch0alarm)
                {
                    Alarmfiles = diralarm.GetFiles(alramdatetime + "_" + ((daqcontrol.samplerate).ToString("f0")) + "_" + "CH0" + "*", SearchOption.AllDirectories);
                    for (int i = 0; i < Alarmfiles.GetLength(0); i++)
                    {
                        File.Copy(sourceDirectory + Path.GetFileName(Alarmfiles[i].ToString()), destinationDirectory + Path.GetFileName(Alarmfiles[i].ToString()));
                    }
                }
                if (Config.Ch1alarm)
                {
                    Alarmfiles = diralarm.GetFiles(alramdatetime + "_" + ((daqcontrol.samplerate).ToString("f0")) + "_" + "CH1" + "*", SearchOption.AllDirectories);
                    for (int i = 0; i < Alarmfiles.GetLength(0); i++)
                    {
                        File.Copy(sourceDirectory + Path.GetFileName(Alarmfiles[i].ToString()), destinationDirectory + Path.GetFileName(Alarmfiles[i].ToString()));
                    }
                }
                if (Config.Ch2alarm)
                {
                    Alarmfiles = diralarm.GetFiles(alramdatetime + "_" + ((daqcontrol.samplerate).ToString("f0")) + "_" + "CH2" + "*", SearchOption.AllDirectories);
                    for (int i = 0; i < Alarmfiles.GetLength(0); i++)
                    {
                        File.Copy(sourceDirectory + Path.GetFileName(Alarmfiles[i].ToString()), destinationDirectory + Path.GetFileName(Alarmfiles[i].ToString()));
                    }
                }
                if (Config.Ch3alarm)
                {
                    Alarmfiles = diralarm.GetFiles(alramdatetime + "_" + ((daqcontrol.samplerate).ToString("f0")) + "_" + "CH3" + "*", SearchOption.AllDirectories);
                    for (int i = 0; i < Alarmfiles.GetLength(0); i++)
                    {
                        File.Copy(sourceDirectory + Path.GetFileName(Alarmfiles[i].ToString()), destinationDirectory + Path.GetFileName(Alarmfiles[i].ToString()));
                    }
                }
            }
            catch
            {

            }
        }



        private void ButtonDisable()
        {
            metroButtonhours.Enabled = false;
            metroButtondays.Enabled = false;
            metroButtonmonths.Enabled = false;
            metroButtonyears.Enabled = false;
            buttonAnalysisquery.Enabled = false;
        }
        private void ButtonEnable()
        {
            metroButtonhours.Enabled = true;
            metroButtondays.Enabled = true;
            metroButtonmonths.Enabled = true;
            metroButtonyears.Enabled = true;
            buttonAnalysisquery.Enabled = true;
        }
        /*private void IniDDS(string partitionname, string Topicname)
        {
            try
            {
                DomainParticipantFactory dpFactory = DomainParticipantFactory.Instance;

                DomainParticipantQos pQos;
                pQos = new DomainParticipantQos();
                dpFactory.GetDefaultParticipantQos(ref pQos);

                IDomainParticipant pExternal = dpFactory.CreateParticipant(DDS.DomainId.Default, pQos, null, 0);


                ContinueScaleTypeSupport mydaqTS = new ContinueScaleTypeSupport();
                string Typename = mydaqTS.TypeName;
                mydaqTS.RegisterType(pExternal, Typename);


                TopicQos tQos = new TopicQos();
                pExternal.GetDefaultTopicQos(ref tQos);

                tQos.Durability.Kind = DurabilityQosPolicyKind.VolatileDurabilityQos;
                //tQos.Reliability.Kind = ReliabilityQosPolicyKind.ReliableReliabilityQos;


                ITopic fooTopic = pExternal.CreateTopic(Topicname, Typename, tQos);
                //ITopic fooTopic = pExternal.CreateTopic("D", Typename, tQos);
                PublisherQos pubQos = new PublisherQos();
                pExternal.GetDefaultPublisherQos(ref pubQos);
                pubQos.Partition.Name = new String[1];
                pubQos.Partition.Name[0] = partitionname;


                //pubQos.Presentation.AccessScope = PresentationQosPolicyAccessScopeKind.TopicPresentationQos;
                // pubQos.Presentation.CoherentAccess = true;
                IPublisher myPub = pExternal.CreatePublisher(pubQos); //pubQos


                DataWriterQos dataqos = new DataWriterQos();
                myPub.GetDefaultDataWriterQos(ref dataqos);
                dataqos.Reliability.Kind = ReliabilityQosPolicyKind.ReliableReliabilityQos;
                dataqos.Reliability.MaxBlockingTime = new Duration(10, 0);
                dataqos.History.Kind = HistoryQosPolicyKind.KeepLastHistoryQos;
                dataqos.History.Depth = 10;
                IDataWriter aDW = myPub.CreateDataWriter(fooTopic, dataqos);// DatawriterQosUseTopicQos.value
                fooDW = aDW as IContinueScaleDataWriter;
                my2405daq = new ContinueScale();
                myHandle = new InstanceHandle();
                Config.DDSenble = true;
                Config.DDSerror = false;
            }
            catch
            {
                Config.DDSenble = false;
                Config.DDSerror = true;
                MessageBox.Show("DDS connect fail!!Please check DDS driver or disable OA Value of Web Service");
                metroTabControl1.SelectedTab = Setting;

            }
        }*/

        private void dataGridViewfileAnalysis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /*private void WriteDDS(string Chnameinfo)
        {
            try
            {

                my2405daq.dateTime = Config.TrendDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                my2405daq.sensorName = Chnameinfo;
                my2405daq.check_count = (ushort)daqcontrol.ch0data.GetLongLength(0);
                my2405daq.read_count = (ushort)daqcontrol.ch0data.GetLongLength(0);
                my2405daq.sample_rate = daqcontrol.samplerate;
                Array.Copy(daqcontrol.ch0data, my2405daq.payload, daqcontrol.perchanlength);
                myHandle = fooDW.RegisterInstance(my2405daq);
                fooDW.Write(my2405daq, myHandle);
            }
            catch (Exception e)
            {

            }
        }*/
        /*private void DisposeDDS()
        {
            try
            {
                fooDW.Dispose(my2405daq, myHandle);
                fooDW.UnregisterInstance(my2405daq, myHandle);
            }
            catch (Exception e)
            {

            }
        }*/
        private string infodata(string information, string[,] OAdata)
        {
            chname = new JObject();
            topicName = new JObject();
            chObject = new JObject();
            for (int i = 0; i < OAdata.GetLongLength(0); i++)
            {
                chValue = new JObject();
                Config.DDSChannelname[i] = OAdata[i, 0].Substring(OAdata[i, 0].IndexOf("_") + 1);
                chValue["Unit"] = OAdata[i, 4];
                chValue["StartBand"] = OAdata[i, 7];
                chValue["EndBand"] = OAdata[i, 8];
                chname[Config.DDSChannelname[i]] = chValue;
                chObject[OAdata[i, 1]] = chname;
                if (i + 1 < OAdata.GetLongLength(0))
                {
                    if (OAdata[i, 1] != OAdata[i + 1, 1])
                    {
                        chname = new JObject();
                    }
                }
            }
            topicName["ID"] = Config.sysname;
            topicName["ChannelsInfo"] = chObject;

            //Config.outputch = new FileStream(@"D:\\ChannelsInfo.txt", FileMode.Create, FileAccess.ReadWrite);
            //Config.csvWtr = new StreamWriter(Config.outputch);
            //Config.csvWtr.WriteLine(topicName.ToString());
            //Config.csvWtr.Close();
            return topicName.ToString();

        }



        private string OAdata(string[] chname, string[,] OAunitvalue)
        {
            topicName = new JObject();
            chValues = new JObject();
            topicName["ID"] = Config.sysname;
            topicName["Time"] = Config.TrendDateTime.ToString("yyyy-MM-dd HH_mm_ss");
            topicName["Sampling rate"] = daqcontrol.samplerate;

            for (int i = 0; i < OAunitvalue.GetLongLength(0); i++)
            {
                chValue = new JObject();
                chValue["Value"] = OAunitvalue[i, 3];
                chValue["Status"] = Config.Status[i];
                chValues[chname[i]] = chValue;
            }

            topicName["ChannelsValue"] = chValues;
            return topicName.ToString();


        }
        private string MqttRawandOAdata(string[] chname, string[,] OAunitvalue)
        {
            topicName = new JObject();
            chValues = new JObject();
            topicName["ID"] = Config.sysname;
            topicName["Time"] = Config.TrendDateTime.ToString("yyyy-MM-dd HH_mm_ss");
            topicName["Sampling rate"] = daqcontrol.samplerate;
            if (Convert.ToBoolean(Config.UIParameter[2]))
            {

                for (int i = 0; i < OAunitvalue.GetLongLength(0); i++)
                {
                    chValue = new JObject();
                    chValue["Value"] = OAunitvalue[i, 3];
                    chValue["Status"] = Config.Status[i];
                    chValues[chname[i]] = chValue;
                }

                topicName["ChannelsValue"] = chValues;
            }

            if (Convert.ToBoolean(Config.UIParameter[3]))
            {
                topicName["ChannelsRawdata"] = rawdata;
            }

            return topicName.ToString();


        }

        private void Deleteoldfile(string path)
        {
            try
            {
                dir = new DirectoryInfo(path);
                string Oldfolder = dir.GetDirectories().OrderBy(p => p.CreationTime).FirstOrDefault().ToString();
                dir = new DirectoryInfo(path + "\\" + Oldfolder);
                if (dir.GetFiles().Length == 0)
                {
                    Directory.Delete(path + "\\" + Oldfolder);
                }
                else
                {
                    string Oldfiles = dir.GetFiles().OrderBy(p => p.CreationTime).FirstOrDefault().ToString();
                    Oldfiles = Oldfiles.Substring(0, Oldfiles.LastIndexOf("CH"));
                    FileInfo[] Deletefiles;
                    Deletefiles = dir.GetFiles(Oldfiles + "*", SearchOption.AllDirectories);

                    for (int i = 0; i < 1; i++)
                    {
                        File.Delete(path + "\\" + Oldfolder + "\\" + Deletefiles[i].ToString());
                    }
                }
            }
            catch (Exception e)
            {

            }
        }
        private void InitialDAQ()
        {
            daqcontrol.result = USBDASK.UD_Release_Card(0);
            daqcontrol.result = USBDASK.UD_Register_Card(USBDASK.USB_2405, 0);
            if (daqcontrol.result < 0)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Please Connect USB-2405 to your PC");
                Process.GetCurrentProcess().Kill();
                return;
            }

            daqcontrol.result = USBDASK.UD_AI_InitialMemoryAllocated(0, out Config.memsizereturn);
            Config.memsizereturn = Config.memsizereturn * 1024;
        }
        private void sendChannelsInfodemo()
        {
           
        }
        private static int getStatusStringToInt(string statusString)
        {
            int intValue = 0;

            switch (statusString)
            {
                case "Danger":
                    intValue = 0;
                    break;
                case "Shutdown":
                    intValue = 1;
                    break;
                case "Warning":
                    intValue = 2;
                    break;
                case "Normal":
                    intValue = 3;
                    break;
            }

            return intValue;
        }
        private static double getValueStringToDouble(string valueString)
        {
            double doubleValue = 0.0;

            doubleValue = Convert.ToDouble(valueString);

            return doubleValue;
        }
        private void sendChannelsValuedemo(string OAunitvalue)
        {

            
        }
        private void Azure()
        {
            // String containing Hostname, Device Id & Device Key in one of the following formats:
            //  "HostName=<iothub_host_name>;DeviceId=<device_id>;SharedAccessKey=<device_key>"

           

        }
        private void ModBusdata(string[,] OAdata)
        {
            slave.DataStore.InputRegisters[1] = Convert.ToUInt16(OAdata.GetLongLength(0));
            for (int i = 0; i < OAdata.GetLongLength(0); ++i)
            {

                ushort[] oa_name_ushort_array = fnStringToUshortArray(OAdata[i, 0].Substring(OAdata[i, 0].IndexOf("_") + 1));
                ushort tmp = 0;
                for (ushort vj = (ushort)(line_offset * (i + 1) + line_name_offset); vj < (ushort)(line_offset * (i + 1) + line_unit_offset); ++vj)
                {
                    if (tmp < oa_name_ushort_array.Length)
                        slave.DataStore.InputRegisters[vj] = oa_name_ushort_array[tmp++];
                    else
                        slave.DataStore.InputRegisters[vj] = 0;
                }

                ushort[] oa_unit_ushort_array = fnStringToUshortArray(OAdata[i, 4]);
                tmp = 0;
                for (ushort vj = (ushort)(line_offset * (i + 1) + line_unit_offset); vj < (ushort)(line_offset * (i + 1) + line_oa_offset); ++vj)
                {
                    if (tmp < oa_unit_ushort_array.Length)
                        slave.DataStore.InputRegisters[vj] = oa_unit_ushort_array[tmp++];
                    else
                        slave.DataStore.InputRegisters[vj] = 0;
                }
                ushort[] oa_value_ushort_array = fnfloatToUshortArray(Convert.ToDouble(OAdata[i, 3]));
                slave.DataStore.InputRegisters[line_offset * (i + 1) + line_oa_offset] = oa_value_ushort_array[0];
                slave.DataStore.InputRegisters[line_offset * (i + 1) + line_oa_offset + 1] = oa_value_ushort_array[1];
                slave.DataStore.InputRegisters[line_offset * (i + 1) + line_oa_offset + 2] = oa_value_ushort_array[2];
                slave.DataStore.InputRegisters[line_offset * (i + 1) + line_oa_offset + 3] = oa_value_ushort_array[3];
                slave.DataStore.InputRegisters[line_offset * (i + 1) + line_sts_offset] = StatusforModbus(Config.Status[i]);
            }

        }
        private ushort StatusforModbus(string status)
        {
            ushort stautscode = 0;
            switch (status)
            {
                case "Danger":
                    stautscode = 1 << 3;
                    break;
                case "Warning":
                    stautscode = 1 << 2;
                    break;
                case "Shutdown":
                    stautscode = 1 << 1;
                    break;
                case "Normal":
                    stautscode = 1 << 0;
                    break;
            }

            return stautscode;
        }
        private void IniModBus()
        {
            try
            {

                slave_port = new SerialPort(Config.ComPort[0]); // "COM1"
                slave_port.BaudRate = Convert.ToInt32(Config.ComPort[1]); // 9600;
                slave_port.DataBits = Convert.ToInt32(Config.ComPort[2]); // 8;
                slave_port.Parity = fnParity(Config.ComPort[3]); // Parity.None;
                slave_port.StopBits = fnStopBits(Config.ComPort[4]); // StopBits.One;
                slave_port.Open();

                // Create RTU Modbus Slave
                SerialPortAdapter adapter = new SerialPortAdapter(slave_port);
                unitId = Convert.ToByte(Config.ComPort[5]); // 1
                slave = ModbusSerialSlave.CreateRtu(unitId, adapter);

                // Create RTU Modbus Slave Registers
                slave.DataStore = DataStoreFactory.CreateDefaultDataStore();

                // Add RTU Modbus Slave Request Received Event Handler
                // It is not necessary and can be used for debugging


                // Start RTU Modbus Slave Listening
                slave.ListenAsync();
                Config.Modbusenable = true;
                Config.Modbuserror = false;
            }
            catch
            {
                Config.Modbusenable = false;
                Config.Modbuserror = true;
                MessageBox.Show("Modbus connect fail!!Please check COM Port or disable OA Value of Modbus");
                metroTabControl1.SelectedTab = Setting;

            }
        }
        #region Format Transformation Functions
        //
        // ushort array to double
        //
        static double fnUshortArrayToDouble(ushort b3, ushort b2, ushort b1, ushort b0)
        {
            byte[] byte_array = BitConverter.GetBytes(b0)
                .Concat(BitConverter.GetBytes(b1))
                .Concat(BitConverter.GetBytes(b2))
                .Concat(BitConverter.GetBytes(b3))
                .ToArray();

            return BitConverter.ToDouble(byte_array, 0);
        }

        private void buttonfilecombine_Click(object sender, EventArgs e)
        {
            if (Analyze.datadate.GetLength(0) > 0)
            {
                string time = null;
                string day = null;
                string daytemp = null;
                DateTime t;
                FileInfo[] files;
                string[] allfiles;
                filenames = new List<string>();
                string selectchannel = Convert.ToString(Config.Analysistablename[dataGridViewOATrendAnalysis.CurrentRow.Index]);
                OutputDatafolderPath = "C:\\ADLINK\\MCM\\Data\\" + selectchannel + "_" + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss") + ".csv";
                selectchannel = selectchannel.Substring(0, selectchannel.IndexOf("_"));
                t = new XDate(Analyze.datadate[0]).DateTime;
                day = t.ToString("yyyy-MM-dd");
                daytemp = day;
                RawDatafolderPath = "C:\\ADLINK\\MCM\\Data\\All FFTData\\" + Config.ConfigFileName + "\\" + day;
                dirRaw = new DirectoryInfo(RawDatafolderPath);
                for (int i = 0; i < Analyze.datadate.GetLength(0); i++)
                {
                    t = new XDate(Analyze.datadate[i]).DateTime;
                    time = t.ToString("yyyy-MM-dd HH_mm_ss");
                    day = t.ToString("yyyy-MM-dd");
                    if (day != daytemp)
                    {
                        RawDatafolderPath = "C:\\ADLINK\\MCM\\Data\\All FFTData\\" + Config.ConfigFileName + "\\" + day;
                        dirRaw = new DirectoryInfo(RawDatafolderPath);
                    }
                    files = dirRaw.GetFiles(time + "_" + "*" + "_" + selectchannel + "*", SearchOption.AllDirectories);
                    allfiles = files.Select(f => f.Name).ToArray();
                    if (files.Length > 0)
                    {
                        for (int j = 0; j < allfiles.GetLength(0); j++)
                        {
                            filenames.Add(allfiles[j]);
                        }
                    }
                    daytemp = day;
                }
                if (filenames.ToArray().GetLength(0) > 0)
                {
                    RawDatafolderPath = "C:\\ADLINK\\MCM\\Data\\All FFTData\\" + Config.ConfigFileName;
                    thdcombine.Abort();
                    thdcombine = new Thread(filecount);
                    outputchraw = new FileStream(OutputDatafolderPath, FileMode.Create, FileAccess.ReadWrite);
                    csvWtrraw = new StreamWriter(outputchraw);
                    freq(filenames.ElementAt(0));
                    thdcombine.Start();
                    buttonfilecombine.Enabled = false;
                }
                else
                {
                    MessageBox.Show("There is no FFT Data between start date and End date at C:\\ADLINK\\MCM\\Data\\All FFTData\\" + Config.ConfigFileName + "\\");
                }
            }
        }
        private void combinfirstdata(string firstfilename)
        {
            data = File.ReadAllLines(RawDatafolderPath + "\\" + firstfilename.Substring(0, firstfilename.IndexOf(" ")) + "\\" + firstfilename, Encoding.UTF8);
            nameunit(firstfilename);
            for (int i = 0; i < data.GetLength(0); i++)
            {

                line = data[i].Split(new char[] { ',' });
                if (i < 2)
                {
                    totalline[i] = frequency[i] + "," + unitname[i];
                }
                else
                {
                    totalline[i] = frequency[i] + "," + line[1];
                }

            }
        }
        private void combinotherdata(string otherfilename)
        {
            data = File.ReadAllLines(RawDatafolderPath + "\\" + otherfilename.Substring(0, otherfilename.IndexOf(" ")) + "\\" + otherfilename, Encoding.UTF8);
            nameunit(otherfilename);
            for (int i = 0; i < data.GetLength(0); i++)
            {

                line = data[i].Split(new char[] { ',' });
                if (i < 2)
                {
                    totalline[i] = totalline[i] + "," + unitname[i];
                }
                else
                {
                    totalline[i] = totalline[i] + "," + line[1];
                }

            }
        }
        private void freq(string firstfilename)
        {

            data = File.ReadAllLines(RawDatafolderPath + "\\" + firstfilename.Substring(0, firstfilename.IndexOf(" ")) + "\\" + firstfilename, Encoding.UTF8);
            frequency = new string[data.GetLength(0)];
            totalline = new string[data.GetLength(0)];
            for (int i = 0; i < data.GetLength(0); i++)
            {

                line = data[i].Split(new char[] { ',' });
                if (i < 2)
                {
                    frequency[i] = null;
                }
                else
                {
                    frequency[i] = line[0];
                }

            }

        }
        private void nameunit(string otherfilename)
        {
            unitname = new string[2];
            data = File.ReadAllLines(RawDatafolderPath + "\\" + otherfilename.Substring(0, otherfilename.IndexOf(" ")) + "\\" + otherfilename, Encoding.UTF8);
            for (int i = 0; i < 2; i++)
            {

                line = data[i].Split(new char[] { ',' });
                if (i == 0)
                {
                    unitname[i] = otherfilename;
                }
                else
                {
                    unitname[i] = line[1];
                }

            }
        }
        private void filecount()
        {
            MethodInvoker mi = new MethodInvoker(this.UpdateCount);
            MethodInvoker en = new MethodInvoker(this.enbutton);
            try
            {

                for (int i = 0; i < filenames.ToArray().GetLength(0); i++)
                {
                    count = filenames.ToArray().GetLength(0) - i - 1;
                    this.BeginInvoke(mi, null);
                    if (i == 0)
                    {
                        combinfirstdata(filenames.ElementAt(i).ToString());
                    }
                    else
                    {
                        combinotherdata(filenames.ElementAt(i).ToString());
                    }

                }
                for (int i = 0; i < totalline.GetLength(0); i++)
                {
                    csvWtrraw.WriteLine(totalline[i]);
                }
                csvWtrraw.Close();
                this.BeginInvoke(en, null);
                MessageBox.Show("Output a total data file to" + OutputDatafolderPath);
            }
            catch
            {
                MessageBox.Show("Error:Make sure all of the resolution of FFT files are the same");
                csvWtrraw.Close();
                this.BeginInvoke(en, null);
            }

        }
        private void UpdateCount()
        {
            textBoxcount.Text = count.ToString();
        }
        private void enbutton()
        {
            buttonfilecombine.Enabled = true;
        }
        private void CreateIfFolderMissing(string path)
        {
            bool folderExists = Directory.Exists(path);
            if (!folderExists)
                Directory.CreateDirectory(path);
        }


        private void metroTextBoxmainFreq_Validating(object sender, CancelEventArgs e)
        {

            Regex datePattern = new Regex(@"^([+]?[1-9]+\d*)$");
            if (!datePattern.IsMatch(metroTextBoxmainFreq.Text))
            {
                MessageBox.Show("Frequency must be a none zero Integer number.");
                e.Cancel = true;
            }

        }

        private void buttonmainwithharmonic_Click(object sender, EventArgs e)
        {
            Showmfrequency();
        }

        private void zedGraphfftAnalysis_Resize(object sender, EventArgs e)
        {
            Showmfrequency();
        }
        private void Showmfrequency()
        {
            if (spectrum.Analysisdfx != null)
            {
                GraphPane myPane = zedGraphfftAnalysis.GraphPane;
                userCursorsList.Clear();
                userCursorsCurve.Clear();
                myPane.Legend.IsVisible = false;
                int idx = 0;
                spectrum.Analysisdfxresolution = spectrum.Analysisdfx[1] - spectrum.Analysisdfx[0];
                double Mainfreqvalue = Convert.ToDouble(metroTextBoxmainFreq.Text);
                double closest = 0;

                if (Mainfreqvalue < spectrum.Analysisdfx[spectrum.Analysisdfx.GetLength(0) - 1])
                {
                    idx = Array.BinarySearch(spectrum.Analysisdfx, Mainfreqvalue);
                    closest = idx < 0 ? spectrum.Analysisdfx[~idx] : spectrum.Analysisdfx[idx];
                    idx = Array.BinarySearch(spectrum.Analysisdfx, closest);
                    for (int i = idx; i < spectrum.Analysisdfx.GetLength(0) - Convert.ToInt32(Math.Ceiling(Mainfreqvalue / spectrum.Analysisdfxresolution)) + 1; i = i + Convert.ToInt32(Math.Ceiling(Mainfreqvalue / spectrum.Analysisdfxresolution)))
                    {
                        idx = Array.BinarySearch(spectrum.Analysisdfx, i * spectrum.Analysisdfxresolution);
                        userCursorsList.Add(spectrum.Analysisdfx[idx], spectrum.Anaspectrum[idx]);
                    }
                    userCursorsCurve = myPane.AddCurve(" ", userCursorsList, Color.White, SymbolType.Circle);
                    userCursorsCurve.Line.IsVisible = false;
                    this.zedGraphfftAnalysis.AxisChange();
                    this.zedGraphfftAnalysis.Refresh();

                }
                else
                {
                    MessageBox.Show("Main frequency need less then" + Convert.ToString(spectrum.Analysisdfx[spectrum.Analysisdfx.GetLength(0) - 1]) + "HZ");
                }

            }
        }



        //
        // double to ushort array
        //
        static ushort[] fnfloatToUshortArray(double d)
        {
            ushort[] ushort_array = new ushort[4];

            byte[] byte_array = BitConverter.GetBytes(d);
            ushort_array[0] = BitConverter.ToUInt16(byte_array, 0);
            ushort_array[1] = BitConverter.ToUInt16(byte_array, 2);
            ushort_array[2] = BitConverter.ToUInt16(byte_array, 4);
            ushort_array[3] = BitConverter.ToUInt16(byte_array, 6);

            return ushort_array;
        }
        //
        // ushort array to uint
        //
        static uint fnUshortArrayToUInt(ushort b1, ushort b0)
        {
            byte[] byte_array = BitConverter.GetBytes(b0)
                .Concat(BitConverter.GetBytes(b1))
                .ToArray();

            return BitConverter.ToUInt32(byte_array, 0);
        }
        //
        // uint to ushort array
        //
        static ushort[] fnUIntToUshortArray(uint u)
        {
            ushort[] ushort_array = new ushort[2];

            byte[] byte_array = BitConverter.GetBytes(u);
            ushort_array[0] = BitConverter.ToUInt16(byte_array, 0);
            ushort_array[1] = BitConverter.ToUInt16(byte_array, 2);

            return ushort_array;
        }


        //
        // ushort array to string
        //
        static string fnUshortArrayToString(ushort[] ushort_array)
        {
            byte[] byte_array = new byte[ushort_array.Length * 2];
            Buffer.BlockCopy(ushort_array, 0, byte_array, 0, ushort_array.Length * 2);

            return Encoding.Default.GetString(byte_array);
        }
        //
        // string to ushort array
        //
        static ushort[] fnStringToUshortArray(string s)
        {
            byte[] byte_array = Encoding.UTF8.GetBytes(s);

            ushort[] ushort_array = new ushort[(byte_array.Length + 1) / 2];
            Buffer.BlockCopy(byte_array, 0, ushort_array, 0, byte_array.Length);

            return ushort_array;
        }
        #endregion

        #region Serial Port Configurations
        //
        // Serial Port Parity
        //
        static Parity fnParity(string p)
        {
            switch (p)
            {
                case "None":
                    return Parity.None;
                case "Odd":
                    return Parity.Odd;
                case "Even":
                    return Parity.Even;
                case "Mark":
                    return Parity.Mark;
                case "Space":
                    return Parity.Space;
                default:
                    return Parity.None;
            }
        }



        //
        // Serial Port Stop Bits
        //
        static StopBits fnStopBits(string sb)
        {
            switch (sb)
            {
                case "1":
                    return StopBits.One;
                case "2":
                    return StopBits.Two;
                case "1.5":
                    return StopBits.OnePointFive;
                default:
                    return StopBits.One;
            }
        }
        #endregion
       

        private void Comportconfigure()
        {
            bool filecheck = File.Exists("c:\\ADLINK\\MCM\\INI\\ComPort.ini");
            if (!filecheck)
            {
                txtWtr = new StreamWriter("c:\\ADLINK\\MCM\\INI\\ComPort.ini", false);
                txtWtr.WriteLine("COM1");
                txtWtr.WriteLine("9600");
                txtWtr.WriteLine("8");
                txtWtr.WriteLine("None");
                txtWtr.WriteLine("1");
                txtWtr.WriteLine("1");
                txtWtr.Close();
                Config.ComPort = File.ReadAllLines("c:\\ADLINK\\MCM\\INI\\ComPort.ini", Encoding.UTF8);
            }
            else
            {
                Config.ComPort = File.ReadAllLines("c:\\ADLINK\\MCM\\INI\\ComPort.ini", Encoding.UTF8);
            }
        }
        private void getBrokerIP()
        {
            string[] sr;
            bool filecheck = File.Exists("C:\\ADLINK\\MCM\\INI\\MqttSettings.ini");
            if (!filecheck)
            {
                txtWtr = new StreamWriter("C:\\ADLINK\\MCM\\INI\\MqttSettings.ini", false);
                Config.sysname = System.Environment.MachineName;
                txtWtr.WriteLine("BrokerIP : 127.0.0.1");
                txtWtr.WriteLine("MCMID :" + Config.sysname);
                txtWtr.Close();
                sr = File.ReadAllLines(@"C:\ADLINK\MCM\INI\MqttSettings.ini", Encoding.UTF8);
            }
            else
            {
                sr = File.ReadAllLines(@"C:\ADLINK\MCM\INI\MqttSettings.ini", Encoding.UTF8);
            }


            if (sr[0].Split(':')[0].Trim() == "BrokerIP")
            {

                Config.broker_ip = sr[0].Split(':')[1].Trim();
            }
            if (sr[1].Split(':')[0].Trim() == "MCMID")
            {
                Config.sysname = sr[1].Split(':')[1].Trim();
            }

            //return Config.broker_ip;

        }
        private void IniMqtt()
        {
            try
            {
                //Config.broker_ip = getBrokerIP();
                mqtt_client = new MqttClient(IPAddress.Parse(Config.broker_ip));
                string clientid = Guid.NewGuid().ToString();
                mqtt_client.Connect(clientid);
                Config.Mqttenable = true;
                Config.Mqtterror = false;
            }
            catch
            {
                Config.Mqttenable = false;
                Config.Mqtterror = true;
                MessageBox.Show("MQTT connect to broker fail!!Please open broker or disable MQTT");
                metroTabControl1.SelectedTab = Setting;

                //Process.GetCurrentProcess().Kill();
            }
        }
        private void WriteMqtt(string topic, string data, bool retain)
        {
            try
            {
                mqtt_client.Publish(topic, Encoding.UTF8.GetBytes(data), MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, retain);
            }
            catch
            {

            }

        }
        private bool ProgramIsRunning(string FullPath)
        {
            string FilePath = Path.GetDirectoryName(FullPath);
            string FileName = Path.GetFileNameWithoutExtension(FullPath).ToLower();
            bool isRunning = false;

            Process[] pList = Process.GetProcessesByName(FileName);
            foreach (Process p in pList)
                if (p.MainModule.FileName.StartsWith(FilePath, StringComparison.InvariantCultureIgnoreCase))
                {
                    isRunning = true;
                    break;
                }

            return isRunning;

        }
        private void ProgramKill(string path)
        {
            string FileName = Path.GetFileNameWithoutExtension(path).ToLower();
            Process[] proc = Process.GetProcessesByName(FileName);
            proc[0].Kill();
        }
        private void ProgramRun(string path)
        {

            Process proc = Process.Start(path);

        }
       
    }
}

