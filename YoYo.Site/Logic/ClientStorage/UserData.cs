using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YoYo.Common;

namespace YoYo.Site.Logic.ClientStorage
{
    public class UserData : XmlSerializable<UserData>
    {
        public List<int> Cart { get; set; }

        public List<int> RecentlyViewed { get; set; }
    }
}