using System;
using System.Collections.Generic;

using System.Linq;

using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ADALForForms.Model
{

   
    public partial class RomModel
    {
        public class value2
        {
            
            [JsonProperty("Id")]
            public string Id { get; set; }

            

            [JsonProperty("displayName")]
            public string DisplayName { get; set; }
            

            [JsonProperty("givenName")]
            public string GivenName { get; set; }
            

            [JsonProperty("mail")]
            public string Mail { get; set; }
            
            [JsonProperty("mobilePhone")]
            public string Capasity { get; set; }

            [JsonProperty("surname")]
            public string Surname { get; set; }
            
        }
    }

    public partial class RomModel
    {

        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }

        [JsonProperty("value")]
        public value2[] value { get; set; }
    }
}