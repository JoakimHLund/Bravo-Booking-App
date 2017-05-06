using System;
using System.Collections.Generic;

using System.Linq;

using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ADALForForms.Model
{

    //public partial class RomModel
    //{
    //    public class AssignedLicens
    //    {

    //        [JsonProperty("disabledPlans")]
    //        public object[] DisabledPlans { get; set; }

    //        [JsonProperty("skuId")]
    //        public string SkuId { get; set; }
    //    }
    //}

    //public partial class RomModel
    //{
    //    public class AssignedPlan
    //    {

    //        [JsonProperty("assignedTimestamp")]
    //        public string AssignedTimestamp { get; set; }

    //        [JsonProperty("capabilityStatus")]
    //        public string CapabilityStatus { get; set; }

    //        [JsonProperty("service")]
    //        public string Service { get; set; }

    //        [JsonProperty("servicePlanId")]
    //        public string ServicePlanId { get; set; }
    //    }
    //}

    //public partial class RomModel
    //{
    //    public class ProvisionedPlan
    //    {

    //        [JsonProperty("capabilityStatus")]
    //        public string CapabilityStatus { get; set; }

    //        [JsonProperty("provisioningStatus")]
    //        public string ProvisioningStatus { get; set; }

    //        [JsonProperty("service")]
    //        public string Service { get; set; }
    //    }
    //}
    public partial class Calendar
    {
        public class value2
        {
            //[JsonProperty("@odata.context")]
            //public string OdataContext { get; set; }

            //[JsonProperty("objectType")]
            //public string ObjectType { get; set; }

            [JsonProperty("Id")]
            public string Id { get; set; }
            
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

    public partial class Calendar
    {

        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }

        [JsonProperty("value")]
        public value2[] value { get; set; }
    }
}