using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoupangSampleApp.Models
{
    public class OverseaShippingInfoDto
    {
        [JsonProperty("personalCustomsClearanceCode")]
        public string PersonalCustomsClearanceCode { get; set; }
        [JsonProperty("ordererSsn")]
        public string OrdererSsn { get; set; }
        [JsonProperty("ordererPhoneNumber")]
        public string OrdererPhoneNumber { get; set; }
    }
}
