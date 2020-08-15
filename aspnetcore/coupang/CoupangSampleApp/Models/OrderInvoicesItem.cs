using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoupangSampleApp.Models
{
    public class OrderInvoicesItem
    {
        [JsonProperty("shipmentBoxId")]
        public int ShipmentBoxId { get; set; }
        [JsonProperty("succeed")]
        public bool Succeed { get; set; }
        [JsonProperty("resultCode")]
        public string ResultCode { get; set; }
        [JsonProperty("retryRequired")]
        public bool RetryRequired { get; set; }
        [JsonProperty("resultMessage")]
        public object ResultMessage { get; set; }
    }
}
