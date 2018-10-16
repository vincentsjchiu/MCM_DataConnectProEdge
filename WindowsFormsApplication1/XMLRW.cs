using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel;
using System.IO;
namespace XMLRW
{
    class XmlSerialize
    {
        public static void SerializeToXml(string FileName, object Object)
        {
            XmlSerializer xml = null;
            Stream stream = null;
            StreamWriter writer = null;
            try
            {
                xml = new XmlSerializer(Object.GetType());
                stream = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.Read);
                writer = new StreamWriter(stream, Encoding.UTF8);
                xml.Serialize(writer, Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                writer.Close();
                stream.Close();
            }
        }
        public static T DeserializeFromXml<T>(string FileName)
        {
            XmlSerializer xml = null;
            Stream stream = null;
            StreamReader reader = null;
            try
            {
                xml = new XmlSerializer(typeof(T));
                stream = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.None);
                reader = new StreamReader(stream, Encoding.UTF8);
                object obj = xml.Deserialize(reader);
                if (obj == null)
                    return default(T);
                else
                    return (T)obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                stream.Close();
                reader.Close();
            }
        }
    }
}
