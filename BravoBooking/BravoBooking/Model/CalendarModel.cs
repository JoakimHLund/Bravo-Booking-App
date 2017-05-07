using System;
using System.Collections.Generic;

using System.Linq;

using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BravoBooking.Model
{

    public partial class CalendarModel
    {
        public class value2
        {
            [JsonProperty("@odata.context")]
            public string OdataContext { get; set; }

            [JsonProperty("subject")]
            public string subject { get; set; }

            //[JsonProperty("objectType")]
            //public string ObjectType { get; set; }

            //[JsonProperty("Id")]
            //public string Id { get; set; }
            [JsonProperty("start")]
            public start Start { get; set; }

            [JsonProperty("end")]
            public end End { get; set; }

            public class start
            {
                [JsonProperty("DateTime")]
                public string DateTime { get; set; }
                [JsonProperty("TimeZone")]
                public string TimeZone { get; set; }
            }
            public class end
            {
                [JsonProperty("DateTime")]
                public string DateTime { get; set; }
                [JsonProperty("TimeZone")]
                public string TimeZone { get; set; }
            }
        }
        
    }

    public partial class CalendarModel
    {

        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }

        [JsonProperty("value")]
        public value2[] value { get; set; }
    }
}