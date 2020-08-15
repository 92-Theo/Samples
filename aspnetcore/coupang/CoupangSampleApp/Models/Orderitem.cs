using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoupangSampleApp.Models
{
    public class OrderItem
    {
        [JsonProperty("vendorItemPackageId")]
        public int VendorItemPackageId { get; set; }
        [JsonProperty("vendorItemPackageName")]
        public string VendorItemPackageName { get; set; }
        [JsonProperty("productId")]
        public int ProductId { get; set; }
        [JsonProperty("vendorItemId")]
        public object VendorItemId { get; set; }
        [JsonProperty("vendorItemName")]
        public string VendorItemName { get; set; }
        [JsonProperty("shippingCount")]
        public int ShippingCount { get; set; }
        [JsonProperty("salesPrice")]
        public int SalesPrice { get; set; }
        [JsonProperty("orderPrice")]
        public int OrderPrice { get; set; }
        [JsonProperty("discountPrice")]
        public int DiscountPrice { get; set; }
        [JsonProperty("instantCouponDiscount")]
        public int InstantCouponDiscount { get; set; }
        [JsonProperty("downloadableCouponDiscount")]
        public int DownloadableCouponDiscount { get; set; }
        [JsonProperty("coupangDiscount")]
        public int CoupangDiscount { get; set; }
        [JsonProperty("externalVendorSkuCode")]
        public string ExternalVendorSkuCode { get; set; }
        [JsonProperty("etcInfoHeader")]
        public object EtcInfoHeader { get; set; }
        [JsonProperty("etcInfoValue")]
        public object EtcInfoValue { get; set; }
        [JsonProperty("etcInfoValues")]
        public List<string> EtcInfoValues { get; set; }
        [JsonProperty("sellerProductId")]
        public int SellerProductId { get; set; }
        [JsonProperty("sellerProductName")]
        public string SellerProductName { get; set; }
        [JsonProperty("sellerProductItemName")]
        public string SellerProductItemName { get; set; }
        [JsonProperty("firstSellerProductItemName")]
        public string FirstSellerProductItemName { get; set; }
        [JsonProperty("cancelCount")]
        public int CancelCount { get; set; }
        [JsonProperty("holdCountForCancel")]
        public int HoldCountForCancel { get; set; }
        [JsonProperty("estimatedShippingDate")]
        public string EstimatedShippingDate { get; set; }
        [JsonProperty("plannedShippingDate")]
        public string PlannedShippingDate { get; set; }
        [JsonProperty("invoiceNumberUploadDate")]
        public string InvoiceNumberUploadDate { get; set; }
        [JsonProperty("extraProperties")]
        public ExtraProperties ExtraProperties { get; set; }
        [JsonProperty("pricingBadge")]
        public bool PricingBadge { get; set; }
        [JsonProperty("usedProduct")]
        public bool UsedProduct { get; set; }
        [JsonProperty("confirmDate")]
        public string ConfirmDate { get; set; }
        [JsonProperty("deliveryChargeTypeName")]
        public string DeliveryChargeTypeName { get; set; }
        [JsonProperty("canceled")]
        public bool Canceled { get; set; }
    }
}
