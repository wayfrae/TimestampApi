using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace TimestampApi.Models
{
    public class Timestamp
    {        
        public long Unix { get; set; }
        public string Utc { get; set; }
        [JsonIgnore]
        protected DateTime DateAndTime { get; set; }

        public Timestamp()
        {
            DateAndTime = DateTime.Now;
            Unix = ((DateTimeOffset)DateAndTime).ToUnixTimeMilliseconds();
            Utc = DateAndTime.ToUniversalTime().ToString("r", DateTimeFormatInfo.InvariantInfo);
        }

        public Timestamp(DateTime userDate)
        {
            DateAndTime = userDate;
            Unix = ((DateTimeOffset)DateAndTime).ToUnixTimeMilliseconds();
            Utc = DateAndTime.ToString("r", DateTimeFormatInfo.InvariantInfo);
        }
    }
}
