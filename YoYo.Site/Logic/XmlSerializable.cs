using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebApplication4.Logic
{
    public class XmlSerializable <T>
    {
        static XmlSerializer x = new XmlSerializer(typeof(T));

        public static T Deserialize(Stream stream)
        {
            T result = (T)x.Deserialize(stream);
            return result;
        }

        public void Serialize(Stream stream)
        {
            x.Serialize(stream, this);
        }
    }
}