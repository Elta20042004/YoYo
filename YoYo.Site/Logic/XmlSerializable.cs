using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace YoYo.Site.Logic
{
    public class XmlSerializable <T>
    {
        static private readonly XmlSerializer Serializer = new XmlSerializer(typeof(T));

        public static T Deserialize(Stream stream)
        {
            T result = (T)Serializer.Deserialize(stream);
            return result;
        }

        public void Serialize(Stream stream)
        {
            Serializer.Serialize(stream, this);
        }
    }
}