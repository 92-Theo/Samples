using CoupangSampleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoupangSampleApp.API.Response
{
    public class OrderInvoicesResponse : BaseResponse
    {
        [JsonProperty("data")]
        public OrderInvoicesData Data { get; set; }
    }
}
