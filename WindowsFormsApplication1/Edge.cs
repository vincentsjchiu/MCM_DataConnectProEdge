using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace Edge
{
    public class CSharp
    {
        const string dllFileName = @"EdgeCSharp.dll";
        [DllImport(dllFileName, EntryPoint = "AddData", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddData(string name, double value);

        [DllImport(dllFileName, EntryPoint = "AddStrData", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddData(string name, string value);

        [DllImport(dllFileName, EntryPoint = "AddArrayData", CallingConvention = CallingConvention.Cdecl)]
        public static extern void AddData(string name, double[] value, int length);

        [DllImport(dllFileName, EntryPoint = "SentData", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SentData(string tagGroupName);

        [DllImport(dllFileName, EntryPoint = "ReceiveData", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr ReceiveData(string tagGroupName);
    }
}
