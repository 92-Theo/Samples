using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoupangSampleApp.Models
{
    public class Receiver
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("safeNumber")]
        public string SafeNumber { get; set; }
        [JsonProperty("receiverNumber")]
        public object ReceiverNumber { get; set; }
        [JsonProperty("addr1")]
        public string Addr1 { get; set; }
        [JsonProperty("addr2")]
        public string Addr2 { get; set; }
        [JsonProperty("postCode")]
        public string PostCode { get; set; }
    }
}
