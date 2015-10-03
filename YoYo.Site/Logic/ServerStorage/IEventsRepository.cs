using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoYo.Site.Logic.ServerStorage
{
    public class Event
    {
        public EventType Type { get; set; }

        public long UserId { get; set; }

        public DateTime Timespan { get; set; }
    }

    public enum EventType
    {
        View,
        Conversion
    }
}
