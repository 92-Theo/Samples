using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CoupangSampleApp.Models
{
    public class OrderSheetInvoiceApplyDto
    {
        [JsonProperty("shipmentBoxId")]
        public long ShipmentBoxId { get; set; }
        [JsonProperty("orderId")]
        public long OrderId { get; set; }
        [JsonProperty("vendorItemId")]
        public long VendorItemId { get; set; }
        [JsonProperty("deliveryCompanyCode")]
        public string DeliveryCompanyCode { get; set; }
        [JsonProperty("invoiceNumber")]
        public string InvoiceNumber { get; set; }
        [JsonProperty("splitShipping")]
        public string SplitShipping { get; set; }
        [JsonProperty("preSplitShipped")]
        public string PreSplitShipped { get; set; }
        [JsonProperty("estimatedShippingDate")]
        public string EstimatedShippingDate { get; set; }
    }
}
