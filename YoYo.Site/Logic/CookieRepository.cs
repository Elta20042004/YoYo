using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Web;

namespace WebApplication4.Logic
{
    public class CookieRepository : IProductRepository
    {
        public CookieData GetCookieData()
        {
            var  session = HttpContext.Current.Session;
            var data = session["data"] as byte[];
            if (data==null || data.Length==0)
            {
                return new CookieData();
            }

            using (var repo = new MemoryStream(data))
            {
                repo.Seek(0, SeekOrigin.Begin);
                using (GZipStream bigStream = new GZipStream(repo, CompressionMode.Decompress))
                {
                    using (var unZipped = new MemoryStream())
                    {
                        bigStream.CopyTo(unZipped);
                        unZipped.Seek(0, SeekOrigin.Begin);
                        CookieData cdata = CookieData.Deserialize(unZipped);
                        return cdata;
                    }
                }
            }
        }

        public void PutCookieData(CookieData products)
        {
            byte[] value;
            using (var zipped = new MemoryStream())
            {
                using (GZipStream tinyStream = new GZipStream(zipped, CompressionMode.Compress))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        products.Serialize(ms);
                        ms.Seek(0, SeekOrigin.Begin);
                        ms.CopyTo(tinyStream);
                    }
                }
                value = zipped.ToArray();
            }
            
            var session = HttpContext.Current.Session;
            session["data"] = value;
        }
    }

}