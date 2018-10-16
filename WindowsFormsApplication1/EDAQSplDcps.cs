using DDS;
using DDS.OpenSplice.CustomMarshalers;
using DDS.OpenSplice.Database;
using DDS.OpenSplice.Kernel;
using System;
using System.Runtime.InteropServices;

namespace EDAQ
{
    #region __Command
    [StructLayout(LayoutKind.Sequential)]
    public struct __Command
    {
        public ushort bbg_id;
        public ushort daq_id;
        public ushort fc;
        public IntPtr msg;
        public byte start;
    }
    #endregion

    #region CommandMarshaler
    public sealed class CommandMarshaler : DDS.OpenSplice.CustomMarshalers.FooDatabaseMarshaler<Command>
    {
        public static readonly string fullyScopedName = "EDAQ::Command";

        public override void InitEmbeddedMarshalers(IDomainParticipant participant)
        {
        }

        public override V_COPYIN_RESULT CopyIn(System.IntPtr typePtr, System.IntPtr from, System.IntPtr to)
        {
            GCHandle tmpGCHandle = GCHandle.FromIntPtr(from);
            Command fromData = tmpGCHandle.Target as Command;
            return CopyIn(typePtr, fromData, to);
        }

        public V_COPYIN_RESULT CopyIn(System.IntPtr typePtr, Command from, System.IntPtr to)
        {
            __Command nativeImg = new __Command();
            V_COPYIN_RESULT result = CopyIn(typePtr, from, ref nativeImg);
            if (result == V_COPYIN_RESULT.OK)
            {
                Marshal.StructureToPtr(nativeImg, to, false);
            }
            return result;
        }

        public V_COPYIN_RESULT CopyIn(System.IntPtr typePtr, Command from, ref __Command to)
        {
            if (from == null) return V_COPYIN_RESULT.INVALID;
            to.bbg_id = from.bbg_id;
            to.daq_id = from.daq_id;
            to.fc = from.fc;
            if (from.msg == null) return V_COPYIN_RESULT.INVALID;
            // Unbounded string: bounds check not required...
            if (!Write(c.getBase(typePtr), ref to.msg, from.msg)) return V_COPYIN_RESULT.OUT_OF_MEMORY;
            to.start = from.start ? (byte) 1 : (byte) 0;
            return V_COPYIN_RESULT.OK;
        }

        public override void CopyOut(System.IntPtr from, System.IntPtr to)
        {
            __Command nativeImg = (__Command) Marshal.PtrToStructure(from, typeof(__Command));
            GCHandle tmpGCHandleTo = GCHandle.FromIntPtr(to);
            Command toObj = tmpGCHandleTo.Target as Command;
            CopyOut(ref nativeImg, ref toObj);
            tmpGCHandleTo.Target = toObj;
        }

        public override void CopyOut(System.IntPtr from, ref Command to)
        {
            __Command nativeImg = (__Command) Marshal.PtrToStructure(from, typeof(__Command));
            CopyOut(ref nativeImg, ref to);
        }

        public static void StaticCopyOut(System.IntPtr from, ref Command to)
        {
            __Command nativeImg = (__Command) Marshal.PtrToStructure(from, typeof(__Command));
            CopyOut(ref nativeImg, ref to);
        }

        public static void CopyOut(ref __Command from, ref Command to)
        {
            if (to == null) {
                to = new Command();
            }
            to.bbg_id = from.bbg_id;
            to.daq_id = from.daq_id;
            to.fc = from.fc;
            to.msg = ReadString(from.msg);
            to.start = from.start != 0 ? true : false;
        }

    }
    #endregion

    #region __ContinueData
    [StructLayout(LayoutKind.Sequential)]
    public struct __ContinueData
    {
        public ushort bbg_id;
        public ushort daq_id;
        public ushort check_count;
        public uint read_count;
        public double sample_rate;
        public byte is_32;
        public IntPtr payload;
    }
    #endregion

    #region ContinueDataMarshaler
    public sealed class ContinueDataMarshaler : DDS.OpenSplice.CustomMarshalers.FooDatabaseMarshaler<ContinueData>
    {
        public static readonly string fullyScopedName = "EDAQ::ContinueData";
        private IntPtr attr6Seq0Type = IntPtr.Zero;
        private static readonly int attr6Seq0Size = 1 * Marshal.SizeOf(typeof(ushort));

        public override void InitEmbeddedMarshalers(IDomainParticipant participant)
        {
        }

        public override V_COPYIN_RESULT CopyIn(System.IntPtr typePtr, System.IntPtr from, System.IntPtr to)
        {
            GCHandle tmpGCHandle = GCHandle.FromIntPtr(from);
            ContinueData fromData = tmpGCHandle.Target as ContinueData;
            return CopyIn(typePtr, fromData, to);
        }

        public V_COPYIN_RESULT CopyIn(System.IntPtr typePtr, ContinueData from, System.IntPtr to)
        {
            __ContinueData nativeImg = new __ContinueData();
            V_COPYIN_RESULT result = CopyIn(typePtr, from, ref nativeImg);
            if (result == V_COPYIN_RESULT.OK)
            {
                Marshal.StructureToPtr(nativeImg, to, false);
            }
            return result;
        }

        public V_COPYIN_RESULT CopyIn(System.IntPtr typePtr, ContinueData from, ref __ContinueData to)
        {
            if (from == null) return V_COPYIN_RESULT.INVALID;
            to.bbg_id = from.bbg_id;
            to.daq_id = from.daq_id;
            to.check_count = from.check_count;
            to.read_count = from.read_count;
            to.sample_rate = from.sample_rate;
            to.is_32 = from.is_32 ? (byte) 1 : (byte) 0;
            if (from.payload == null) return V_COPYIN_RESULT.INVALID;
            int attr6Seq0Length = from.payload.Length;
            // Unbounded sequence: bounds check not required...
            if (attr6Seq0Type == IntPtr.Zero) {
                IntPtr memberOwnerType = DDS.OpenSplice.Database.c.resolve(c.getBase(typePtr), fullyScopedName);
                IntPtr specifier = DDS.OpenSplice.Database.c.metaResolveSpecifier(memberOwnerType, "payload");
                IntPtr specifierType = DDS.OpenSplice.Database.c.specifierType(specifier);
                attr6Seq0Type = DDS.OpenSplice.Database.c.typeActualType(specifierType);
            }
            IntPtr attr6Seq0Buf = DDS.OpenSplice.Database.c.newSequence(attr6Seq0Type, attr6Seq0Length);
            if (attr6Seq0Buf == IntPtr.Zero) return V_COPYIN_RESULT.OUT_OF_MEMORY;
            Marshal.Copy((Int16[]) (Array) from.payload, 0, attr6Seq0Buf, attr6Seq0Length);
            return V_COPYIN_RESULT.OK;
        }

        public override void CopyOut(System.IntPtr from, System.IntPtr to)
        {
            __ContinueData nativeImg = (__ContinueData) Marshal.PtrToStructure(from, typeof(__ContinueData));
            GCHandle tmpGCHandleTo = GCHandle.FromIntPtr(to);
            ContinueData toObj = tmpGCHandleTo.Target as ContinueData;
            CopyOut(ref nativeImg, ref toObj);
            tmpGCHandleTo.Target = toObj;
        }

        public override void CopyOut(System.IntPtr from, ref ContinueData to)
        {
            __ContinueData nativeImg = (__ContinueData) Marshal.PtrToStructure(from, typeof(__ContinueData));
            CopyOut(ref nativeImg, ref to);
        }

        public static void StaticCopyOut(System.IntPtr from, ref ContinueData to)
        {
            __ContinueData nativeImg = (__ContinueData) Marshal.PtrToStructure(from, typeof(__ContinueData));
            CopyOut(ref nativeImg, ref to);
        }

        public static void CopyOut(ref __ContinueData from, ref ContinueData to)
        {
            if (to == null) {
                to = new ContinueData();
            }
            to.bbg_id = from.bbg_id;
            to.daq_id = from.daq_id;
            to.check_count = from.check_count;
            to.read_count = from.read_count;
            to.sample_rate = from.sample_rate;
            to.is_32 = from.is_32 != 0 ? true : false;
            IntPtr attr6Seq0Buf = from.payload;
            int attr6Seq0Length = DDS.OpenSplice.Database.c.arraySize(attr6Seq0Buf);
            if (to.payload == null || to.payload.Length != attr6Seq0Length) {
                to.payload = new ushort[attr6Seq0Length];
            }
            if(attr6Seq0Length > 0) Marshal.Copy(attr6Seq0Buf, (short[]) (Array) to.payload, 0, attr6Seq0Length);
        }

    }
    #endregion

    #region __ContinueScale
    [StructLayout(LayoutKind.Sequential)]
    public struct __ContinueScale
    {
        public ushort bbg_id;
        public IntPtr sensorName;
        public IntPtr dateTime;
        public ushort check_count;
        public uint read_count;
        public double sample_rate;
        public IntPtr payload;
    }
    #endregion

    #region ContinueScaleMarshaler
    public sealed class ContinueScaleMarshaler : DDS.OpenSplice.CustomMarshalers.FooDatabaseMarshaler<ContinueScale>
    {
        public static readonly string fullyScopedName = "EDAQ::ContinueScale";
        private IntPtr attr6Seq0Type = IntPtr.Zero;
        private static readonly int attr6Seq0Size = 1 * Marshal.SizeOf(typeof(double));

        public override void InitEmbeddedMarshalers(IDomainParticipant participant)
        {
        }

        public override V_COPYIN_RESULT CopyIn(System.IntPtr typePtr, System.IntPtr from, System.IntPtr to)
        {
            GCHandle tmpGCHandle = GCHandle.FromIntPtr(from);
            ContinueScale fromData = tmpGCHandle.Target as ContinueScale;
            return CopyIn(typePtr, fromData, to);
        }

        public V_COPYIN_RESULT CopyIn(System.IntPtr typePtr, ContinueScale from, System.IntPtr to)
        {
            __ContinueScale nativeImg = new __ContinueScale();
            V_COPYIN_RESULT result = CopyIn(typePtr, from, ref nativeImg);
            if (result == V_COPYIN_RESULT.OK)
            {
                Marshal.StructureToPtr(nativeImg, to, false);
            }
            return result;
        }

        public V_COPYIN_RESULT CopyIn(System.IntPtr typePtr, ContinueScale from, ref __ContinueScale to)
        {
            if (from == null) return V_COPYIN_RESULT.INVALID;
            to.bbg_id = from.bbg_id;
            if (from.sensorName == null) return V_COPYIN_RESULT.INVALID;
            // Unbounded string: bounds check not required...
            if (!Write(c.getBase(typePtr), ref to.sensorName, from.sensorName)) return V_COPYIN_RESULT.OUT_OF_MEMORY;
            if (from.dateTime == null) return V_COPYIN_RESULT.INVALID;
            // Unbounded string: bounds check not required...
            if (!Write(c.getBase(typePtr), ref to.dateTime, from.dateTime)) return V_COPYIN_RESULT.OUT_OF_MEMORY;
            to.check_count = from.check_count;
            to.read_count = from.read_count;
            to.sample_rate = from.sample_rate;
            if (from.payload == null) return V_COPYIN_RESULT.INVALID;
            int attr6Seq0Length = from.payload.Length;
            // Unbounded sequence: bounds check not required...
            if (attr6Seq0Type == IntPtr.Zero) {
                IntPtr memberOwnerType = DDS.OpenSplice.Database.c.resolve(c.getBase(typePtr), fullyScopedName);
                IntPtr specifier = DDS.OpenSplice.Database.c.metaResolveSpecifier(memberOwnerType, "payload");
                IntPtr specifierType = DDS.OpenSplice.Database.c.specifierType(specifier);
                attr6Seq0Type = DDS.OpenSplice.Database.c.typeActualType(specifierType);
            }
            to.payload = DDS.OpenSplice.Database.c.newSequence(attr6Seq0Type, attr6Seq0Length);
            if (to.payload == IntPtr.Zero) return V_COPYIN_RESULT.OUT_OF_MEMORY;
            Marshal.Copy(from.payload, 0, to.payload, attr6Seq0Length);
            return V_COPYIN_RESULT.OK;
        }

        public override void CopyOut(System.IntPtr from, System.IntPtr to)
        {
            __ContinueScale nativeImg = (__ContinueScale) Marshal.PtrToStructure(from, typeof(__ContinueScale));
            GCHandle tmpGCHandleTo = GCHandle.FromIntPtr(to);
            ContinueScale toObj = tmpGCHandleTo.Target as ContinueScale;
            CopyOut(ref nativeImg, ref toObj);
            tmpGCHandleTo.Target = toObj;
        }

        public override void CopyOut(System.IntPtr from, ref ContinueScale to)
        {
            __ContinueScale nativeImg = (__ContinueScale) Marshal.PtrToStructure(from, typeof(__ContinueScale));
            CopyOut(ref nativeImg, ref to);
        }

        public static void StaticCopyOut(System.IntPtr from, ref ContinueScale to)
        {
            __ContinueScale nativeImg = (__ContinueScale) Marshal.PtrToStructure(from, typeof(__ContinueScale));
            CopyOut(ref nativeImg, ref to);
        }

        public static void CopyOut(ref __ContinueScale from, ref ContinueScale to)
        {
            if (to == null) {
                to = new ContinueScale();
            }
            to.bbg_id = from.bbg_id;
            to.sensorName = ReadString(from.sensorName);
            to.dateTime = ReadString(from.dateTime);
            to.check_count = from.check_count;
            to.read_count = from.read_count;
            to.sample_rate = from.sample_rate;
            IntPtr attr6Seq0Buf = from.payload;
            int attr6Seq0Length = DDS.OpenSplice.Database.c.arraySize(attr6Seq0Buf);
            if (to.payload == null || to.payload.Length != attr6Seq0Length) {
                to.payload = new double[attr6Seq0Length];
            }
            if(attr6Seq0Length > 0) Marshal.Copy(attr6Seq0Buf, to.payload, 0, attr6Seq0Length);
        }

    }
    #endregion

    #region __SensorData
    [StructLayout(LayoutKind.Sequential)]
    public struct __SensorData
    {
        public ushort bbg_id;
        public IntPtr sensorName;
        public IntPtr dateTime;
        public double _value;
    }
    #endregion

    #region SensorDataMarshaler
    public sealed class SensorDataMarshaler : DDS.OpenSplice.CustomMarshalers.FooDatabaseMarshaler<SensorData>
    {
        public static readonly string fullyScopedName = "EDAQ::SensorData";

        public override void InitEmbeddedMarshalers(IDomainParticipant participant)
        {
        }

        public override V_COPYIN_RESULT CopyIn(System.IntPtr typePtr, System.IntPtr from, System.IntPtr to)
        {
            GCHandle tmpGCHandle = GCHandle.FromIntPtr(from);
            SensorData fromData = tmpGCHandle.Target as SensorData;
            return CopyIn(typePtr, fromData, to);
        }

        public V_COPYIN_RESULT CopyIn(System.IntPtr typePtr, SensorData from, System.IntPtr to)
        {
            __SensorData nativeImg = new __SensorData();
            V_COPYIN_RESULT result = CopyIn(typePtr, from, ref nativeImg);
            if (result == V_COPYIN_RESULT.OK)
            {
                Marshal.StructureToPtr(nativeImg, to, false);
            }
            return result;
        }

        public V_COPYIN_RESULT CopyIn(System.IntPtr typePtr, SensorData from, ref __SensorData to)
        {
            if (from == null) return V_COPYIN_RESULT.INVALID;
            to.bbg_id = from.bbg_id;
            if (from.sensorName == null) return V_COPYIN_RESULT.INVALID;
            // Unbounded string: bounds check not required...
            if (!Write(c.getBase(typePtr), ref to.sensorName, from.sensorName)) return V_COPYIN_RESULT.OUT_OF_MEMORY;
            if (from.dateTime == null) return V_COPYIN_RESULT.INVALID;
            // Unbounded string: bounds check not required...
            if (!Write(c.getBase(typePtr), ref to.dateTime, from.dateTime)) return V_COPYIN_RESULT.OUT_OF_MEMORY;
            to._value = from._value;
            return V_COPYIN_RESULT.OK;
        }

        public override void CopyOut(System.IntPtr from, System.IntPtr to)
        {
            __SensorData nativeImg = (__SensorData) Marshal.PtrToStructure(from, typeof(__SensorData));
            GCHandle tmpGCHandleTo = GCHandle.FromIntPtr(to);
            SensorData toObj = tmpGCHandleTo.Target as SensorData;
            CopyOut(ref nativeImg, ref toObj);
            tmpGCHandleTo.Target = toObj;
        }

        public override void CopyOut(System.IntPtr from, ref SensorData to)
        {
            __SensorData nativeImg = (__SensorData) Marshal.PtrToStructure(from, typeof(__SensorData));
            CopyOut(ref nativeImg, ref to);
        }

        public static void StaticCopyOut(System.IntPtr from, ref SensorData to)
        {
            __SensorData nativeImg = (__SensorData) Marshal.PtrToStructure(from, typeof(__SensorData));
            CopyOut(ref nativeImg, ref to);
        }

        public static void CopyOut(ref __SensorData from, ref SensorData to)
        {
            if (to == null) {
                to = new SensorData();
            }
            to.bbg_id = from.bbg_id;
            to.sensorName = ReadString(from.sensorName);
            to.dateTime = ReadString(from.dateTime);
            to._value = from._value;
        }

    }
    #endregion

}

namespace HB
{
    #region __Networking
    [StructLayout(LayoutKind.Sequential)]
    public struct __Networking
    {
        public ushort bbg_id;
        public IntPtr ipv4;
        public IntPtr mac;
    }
    #endregion

    #region NetworkingMarshaler
    public sealed class NetworkingMarshaler : DDS.OpenSplice.CustomMarshalers.FooDatabaseMarshaler<Networking>
    {
        public static readonly string fullyScopedName = "HB::Networking";

        public override void InitEmbeddedMarshalers(IDomainParticipant participant)
        {
        }

        public override V_COPYIN_RESULT CopyIn(System.IntPtr typePtr, System.IntPtr from, System.IntPtr to)
        {
            GCHandle tmpGCHandle = GCHandle.FromIntPtr(from);
            Networking fromData = tmpGCHandle.Target as Networking;
            return CopyIn(typePtr, fromData, to);
        }

        public V_COPYIN_RESULT CopyIn(System.IntPtr typePtr, Networking from, System.IntPtr to)
        {
            __Networking nativeImg = new __Networking();
            V_COPYIN_RESULT result = CopyIn(typePtr, from, ref nativeImg);
            if (result == V_COPYIN_RESULT.OK)
            {
                Marshal.StructureToPtr(nativeImg, to, false);
            }
            return result;
        }

        public V_COPYIN_RESULT CopyIn(System.IntPtr typePtr, Networking from, ref __Networking to)
        {
            if (from == null) return V_COPYIN_RESULT.INVALID;
            to.bbg_id = from.bbg_id;
            if (from.ipv4 == null) return V_COPYIN_RESULT.INVALID;
            // Unbounded string: bounds check not required...
            if (!Write(c.getBase(typePtr), ref to.ipv4, from.ipv4)) return V_COPYIN_RESULT.OUT_OF_MEMORY;
            if (from.mac == null) return V_COPYIN_RESULT.INVALID;
            // Unbounded string: bounds check not required...
            if (!Write(c.getBase(typePtr), ref to.mac, from.mac)) return V_COPYIN_RESULT.OUT_OF_MEMORY;
            return V_COPYIN_RESULT.OK;
        }

        public override void CopyOut(System.IntPtr from, System.IntPtr to)
        {
            __Networking nativeImg = (__Networking) Marshal.PtrToStructure(from, typeof(__Networking));
            GCHandle tmpGCHandleTo = GCHandle.FromIntPtr(to);
            Networking toObj = tmpGCHandleTo.Target as Networking;
            CopyOut(ref nativeImg, ref toObj);
            tmpGCHandleTo.Target = toObj;
        }

        public override void CopyOut(System.IntPtr from, ref Networking to)
        {
            __Networking nativeImg = (__Networking) Marshal.PtrToStructure(from, typeof(__Networking));
            CopyOut(ref nativeImg, ref to);
        }

        public static void StaticCopyOut(System.IntPtr from, ref Networking to)
        {
            __Networking nativeImg = (__Networking) Marshal.PtrToStructure(from, typeof(__Networking));
            CopyOut(ref nativeImg, ref to);
        }

        public static void CopyOut(ref __Networking from, ref Networking to)
        {
            if (to == null) {
                to = new Networking();
            }
            to.bbg_id = from.bbg_id;
            to.ipv4 = ReadString(from.ipv4);
            to.mac = ReadString(from.mac);
        }

    }
    #endregion

}

