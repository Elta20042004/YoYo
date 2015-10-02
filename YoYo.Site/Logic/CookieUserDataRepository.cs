using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Web;

namespace YoYo.Site.Logic
{
    public class CookieUserDataRepository : IUserDataRepository
    {
        public UserData GetUserData()
        {
            var session = HttpContext.Current.Session;
            var data = session["data"] as byte[];
            if (data == null || data.Length == 0)
            {
                return new UserData();
            }

            using (var repo = new MemoryStream(data))
            {
                repo.Seek(0, SeekOrigin.Begin);
                using (var gzipDecompress = new GZipStream(repo, CompressionMode.Decompress))
                {
                    using (var decompressed = new MemoryStream())
                    {
                        gzipDecompress.CopyTo(decompressed);
                        decompressed.Seek(0, SeekOrigin.Begin);
                        var cookieData = UserData.Deserialize(decompressed);
                        return cookieData;
                    }
                }
            }
        }

        public void SaveUserData(UserData products)
        {
            byte[] value;
            using (var compressed = new MemoryStream())
            {
                using (var gzipCompress = new GZipStream(compressed, CompressionMode.Compress))
                {
                    using (var ms = new MemoryStream())
                    {
                        products.Serialize(ms);
                        ms.Seek(0, SeekOrigin.Begin);
                        ms.CopyTo(gzipCompress);
                    }
                }

                value = compressed.ToArray();
            }

            var session = HttpContext.Current.Session;
            session["data"] = value;
        }
    }
}