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

        public PaymentLinkStatus Status { get; set; } = PaymentLinkStatus.Active;

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
        public bool AllowRazerPay { get; set; }

        public bool AllowFpxAmb { get; set; }

        public bool AllowFpxBimb { get; set; }

        public bool AllowFpxCimbClicks { get; set; }

        public bool AllowFpxHlb { get; set; }

        public bool AllowFpxMb2u { get; set; }

        public bool AllowFpxPbb { get; set; }

        public bool AllowFpxRhb { get; set; }

        public bool AllowFpxOcbc { get; set; }

        /// <summary>
        /// Standard Chartered
        /// </summary>
        public bool AllowFpxScb { get; set; }

        /// <summary>
        /// Affin
        /// </summary>
        public bool AllowFpxAbb { get; set; }

        /// <summary>
        /// Alliance Bank
        /// </summary>
        public bool AllowFpxAbmb { get; set; }

        public bool AllowFpxUob { get; set; }

        public bool AllowFpxBsn { get; set; }

        /// <summary>
        /// Kuwait Finance House
        /// </summary>
        public bool AllowFpxKfh { get; set; }

        /// <summary>
        /// Bank Kerjasama Rakyat
        /// </summary>
        public bool AllowFpxBkrm { get; set; }


        /// <summary>
        /// Bank Muamalat
        /// </summary>
        public bool AllowFpxBmmb { get; set; }

        public bool AllowFpxHsbc { get; set; }

        /// <summary>
        /// B2B Affin Bank
        /// </summary>
        public bool AllowFpxB2bAbb { get; set; }

        /// <summary>
        /// FPX B2B Ambank Berhad	
        /// </summary>
        public bool AllowFpxB2bAmb { get; set; }

        /// <summary>
        /// FPX B2B Bank Islam Malaysia Berhad (BIMB)	
        /// </summary>
        public bool AllowFpxB2bBimb { get; set; }

        /// <summary>
        /// FPX B2B BizChannel@CIMB (CIMB)	
        /// </summary>
        public bool AllowFpxB2bCimb { get; set; }

        /// <summary>
        /// FPX B2B HSBC	
        /// </summary>
        public bool AllowFpxB2bHsbc { get; set; }

        /// <summary>
        /// FPX B2B Public Bank	
        /// </summary>
        public bool AllowFpxB2bPbb { get; set; }

        /// <summary>
        /// FPX B2B RHB Reflex	
        /// </summary>
        public bool AllowFpxB2bRhb { get; set; }

        /// <summary>
        /// FPX B2B United Overseas Bank	
        /// </summary>
        public bool AllowFpxB2bUob { get; set; }

        /// <summary>
        /// FPX B2B Kuwait Finance House Overseas Bank	
        /// </summary>
        public bool AllowFpxB2bKfh { get; set; }

        /// <summary>
        /// FPX B2B Deutsche Bank	
        /// </summary>
        public bool AllowFpxB2bDeutsche { get; set; }

        /// <summary>
        /// FPX B2B Alliance Bank	
        /// </summary>
        public bool AllowFpxB2bAbmb { get; set; }

        /// <summary>
        /// FPX B2B Standard Chartered Bank	
        /// </summary>
        public bool AllowFpxB2bScb { get; set; }

        /// <summary>
        /// FPX B2B OCBC Bank	
        /// </summary>
        public bool AllowFpxB2bOcbc { get; set; }

        /// <summary>
        /// FPX B2B Bank Muamalat	
        /// </summary>
        public bool AllowFpxB2bBmmb { get; set; }

        /// <summary>
        /// FPX Maybank2e
        /// </summary>
        public bool AllowFpxB2bM2e { get; set; }
    }
}
