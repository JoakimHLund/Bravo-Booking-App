﻿using System;
using System.Collections.Generic;

using System.Linq;

using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ADALForForms.Model
{

    public partial class CalendarModel
    {
        public class value2
        {
            start s;
            end e;
            atendee a;
            public value2(string su, string st, string en, string em, string name)
            {
                subject = su;
                s = new start();
                s.DateTime = st;
                e = new end();
                e.DateTime = en;
                a = new atendee();
                a.email = em;
                a.name = name;
            }
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
            [JsonProperty("atendee")]
            public atendee Atendee { get; set; }

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
            public class atendee
            {
                [JsonProperty("emailAdress")]
                public string email { get; set; }
                [JsonProperty("name")]
                public string name { get; set; }
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