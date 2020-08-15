using CoupangSampleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoupangSampleApp.API.Request
{
    public class OrderInvoicesRequest
    {
        [JsonProperty("vendorId")]
        public string VendorId { get; set; }

        [JsonProperty("orderSheetInvoiceApplyDtos")]
        public OrderSheetInvoiceApplyDto OrderSheetInvoiceApplyDto { get; set; }
    }
}
