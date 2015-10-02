using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YoYo.Site.Logic
{
    public class CookieData : XmlSerializable<CookieData>
    {
        public List<int> Cart { get; set; }

        public List<int> RecentlyViewed { get; set; }
    }
}