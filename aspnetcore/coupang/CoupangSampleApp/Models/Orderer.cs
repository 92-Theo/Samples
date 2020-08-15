using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoupangSampleApp.Models
{
    public class Orderer
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("safeNumber")]
        public string SafeNumber { get; set; }
        [JsonProperty("ordererNumber")]
        public object OrdererNumber { get; set; }
    }
}
