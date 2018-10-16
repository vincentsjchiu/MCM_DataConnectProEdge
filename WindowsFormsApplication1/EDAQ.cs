using DDS;
using System.Runtime.InteropServices;

namespace EDAQ
{
    #region Command
    [StructLayout(LayoutKind.Sequential)]
    public sealed class Command
    {
        public ushort bbg_id;
        public ushort daq_id;
        public ushort fc;
        public string msg = string.Empty;
        public bool start;
    };
    #endregion

    #region ContinueData
    [StructLayout(LayoutKind.Sequential)]
    public sealed class ContinueData
    {
        public ushort bbg_id;
        public ushort daq_id;
        public ushort check_count;
        public uint read_count;
        public double sample_rate;
        public bool is_32;
        public ushort[] payload = new ushort[0];
    };
    #endregion

    #region ContinueScale
    [StructLayout(LayoutKind.Sequential)]
    public sealed class ContinueScale
    {
        public ushort bbg_id;
        public string sensorName = string.Empty;
        public string dateTime = string.Empty;
        public ushort check_count;
        public uint read_count;
        public double sample_rate;
        public double[] payload = new double[0];
    };
    #endregion

    #region SensorData
    [StructLayout(LayoutKind.Sequential)]
    public sealed class SensorData
    {
        public ushort bbg_id;
        public string sensorName = string.Empty;
        public string dateTime = string.Empty;
        public double _value;
    };
    #endregion

}

namespace HB
{
    #region Networking
    [StructLayout(LayoutKind.Sequential)]
    public sealed class Networking
    {
        public ushort bbg_id;
        public string ipv4 = string.Empty;
        public string mac = string.Empty;
    };
    #endregion

}

