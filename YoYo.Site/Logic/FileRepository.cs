using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebApplication4.Logic
{
    public class FileRepository : IProductRepository
    {
        const string FileName =@"D:\ser.xml";

        public CookieData GetCookieData()
        {
            if (!File.Exists(FileName))
            {
                return new CookieData();
            }

            CookieData result;
            using (var str = File.OpenRead(FileName))
            {
                XmlSerializer x = new XmlSerializer((new CookieData()).GetType());
                result = x.Deserialize(str) as CookieData;
            }
            return result;
        }

        public void PutCookieData(CookieData products)
        {
            CookieData result;
            using (var str = File.Create(FileName))
            {
                XmlSerializer x = new XmlSerializer((new CookieData()).GetType());
                x.Serialize(str, products);
            }
        }
    }
}