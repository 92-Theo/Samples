using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoupangSampleApp.Models
{
    public class Ordersheet
    {
        [JsonProperty("shipmentBoxId")]
        public int ShipmentBoxId { get; set; }
        [JsonProperty("orderId")]
        public object OrderId { get; set; }
        [JsonProperty("orderedAt")]
        public DateTime OrderedAt { get; set; }
        [JsonProperty("orderer")]
        public Orderer Orderer { get; set; }
        [JsonProperty("paidAt")]
        public DateTime PaidAt { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("shippingPrice")]
        public int ShippingPrice { get; set; }
        [JsonProperty("remotePrice")]
        public object RemotePrice { get; set; }
        [JsonProperty("remoteArea")]
        public bool RemoteArea { get; set; }
        [JsonProperty("parcelPrintMessage")]
        public string ParcelPrintMessage { get; set; }
        [JsonProperty("splitShipping")]
        public bool SplitShipping { get; set; }
        [JsonProperty("ableSplitShipping")]
        public bool AbleSplitShipping { get; set; }
        [JsonProperty("receiver")]
        public Receiver Receiver { get; set; }
        [JsonProperty("orderItems")]
        public List<OrderItem> OrderItems { get; set; }
        [JsonProperty("overseaShippingInfoDto")]
        public OverseaShippingInfoDto OverseaShippingInfoDto { get; set; }
        [JsonProperty("deliveryCompanyName")]
        public string DeliveryCompanyName { get; set; }
        [JsonProperty("invoiceNumber")]
        public string InvoiceNumber { get; set; }
        [JsonProperty("inTrasitDateTime")]
        public string InTrasitDateTime { get; set; }
        [JsonProperty("deliveredDate")]
        public string DeliveredDate { get; set; }
        [JsonProperty("refer")]
        public string Refer { get; set; }
    }
}
