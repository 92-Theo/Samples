using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoupangSampleApp.Models
{
    public class OrderInvoicesData
    {
        [JsonProperty("responseCode")]
        public int ResponseCode { get; set; }
        [JsonProperty("responseMessage")]
        public string ResponseMessage { get; set; }
        [JsonProperty("responseList")]
        public List<OrderInvoicesItem> ResponseList { get; set; }
    }
}
