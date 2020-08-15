using CoupangSampleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoupangSampleApp.API.Response
{
    public class OrderSheetsResponse : BaseResponse
    {
        [JsonProperty("data")]
        public List<Ordersheet> Data { get; set; }

        [JsonProperty("nextToken")]
        public string NextToken { get; set; }
    }
}
