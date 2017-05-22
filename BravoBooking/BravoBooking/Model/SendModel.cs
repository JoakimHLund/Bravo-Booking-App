using System;
using System.Collections.Generic;

using System.Linq;

using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ADALForForms.Model
{

    public partial class SendModel
    {
        public class value2
        {

            public value2(string su, string st, string en, string em, string name)
            {
                subject = su;
                Start = new start();
                Start.DateTime = st;
                Start.TimeZone = "UTC";
                End = new end();
                End.DateTime = en;
                End.TimeZone = "UTC";
                atendee a = new atendee(em, name);
                Attendees = new atendee[1];
                Attendees[0]=a;


            }

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
            [JsonProperty("attendees")]
            public atendee[] Attendees { get; set; }

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
                public atendee(string em, string name)
                {
                     email=new emailAddress();
                     email.address = em;
                     email.name = name;
                     type = "required";
                }

                [JsonProperty("emailAddress")]
                public emailAddress email { get; set; }

                [JsonProperty("type")]
                public string type { get; set; }

                public class emailAddress
                {
                    [JsonProperty("address")]
                    public string address { get; set; }
                    [JsonProperty("name")]
                    public string name { get; set; }
                }

                

                


            }
        }

    }

    public partial class SendModel
    {

        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }

        [JsonProperty("value")]
        public value2[] value { get; set; }
    }
}