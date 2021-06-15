using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Webbpay.Api.PaymentService.Entities;
using Webbpay.Api.PaymentService.Entities.Enums;

namespace Webbpay.Api.PaymentService.Models
{
    public class PaymentlinkCacheModel
    {
        public Guid Id { get; set; }

        public string ReferenceId { get; set; }

        public int Quantity { get; set; }
        public Decimal Amount { get; set; }
        public DateTime ExpiryDate { get; set; }

        public ProductModel Product { get; set; }

        public StoreModel Store { get; set; }

        public IEnumerable<PaymentChannelModel> PaymentChannels { get; set; }
    }

    public class StoreModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }

    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public Metadata[] MetaData { get; set; }
        public Image[] Images { get; set; }
        public Category[] Categories { get; set; }
    }

    public class Metadata
    {
        public string Key { get; set; }
        public string Content { get; set; }
    }

    public class Image
    {
        public string ImageId { get; set; }
        public string Url { get; set; }
        public string LargeUrl { get; set; }
        public string MediumUrl { get; set; }
        public string SmallUrl { get; set; }
    }

    public class Category
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
    }

    public class PaymentChannelModel
    {
        public Guid Id { get; set; }
        public GatewayType GatewayType { get; set; }
        public bool Enabled { get; set; }
        public string InternalName { get; set; }
        public Paydeesettings PaydeeSettings { get; set; }
        public Razersettings RazerSettings { get; set; }
    }

    public class Paydeesettings
    {
        public string MerchantId { get; set; }
    }

    public class Razersettings
    {
        public string MerchantId { get; set; }
        public string VerifyKey { get; set; }
        public string SecretKey { get; set; }
        public bool AllowTng { get; set; }
        public bool AllowBoost { get; set; }
        public bool AllowGrabPay { get; set; }
        public bool AllowM2u { get; set; }
        public bool AllowShopeePay { get; set; }
    }
}
