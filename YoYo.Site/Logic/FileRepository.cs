using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace YoYo.Site.Logic
{
    public class FileUserDataRepository : IUserDataRepository
    {
        const string FileName =@"D:\ser.xml";

        public UserData GetUserData()
        {
            if (!File.Exists(FileName))
            {
                return new UserData();
            }

            UserData result;
            using (var str = File.OpenRead(FileName))
            {
                result = UserData.Deserialize(str);
            }

            return result;
        }

        public void SaveUserData(UserData products)
        {
            using (var stream = File.Create(FileName))
            {
                products.Serialize(stream);
            }
        }
    }
}