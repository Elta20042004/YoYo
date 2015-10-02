using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace YoYo.Site.Logic
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
                result = CookieData.Deserialize(str);
            }
            return result;
        }

        public void PutCookieData(CookieData products)
        {
            CookieData result;
            using (var stream = File.Create(FileName))
            {
                products.Serialize(stream);
            }
        }
    }
}