using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YoYo.Site.Logic
{
    public class UserData : XmlSerializable<UserData>
    {
        public List<int> Cart { get; set; }

        public List<int> RecentlyViewed { get; set; }
    }
}