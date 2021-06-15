using System.Text.Json.Serialization;

namespace Webbpay.Api.PaymentService.Entities.Enums
{


    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EWalletType
    {
        /// <summary>
        /// TNG-EWALLET.php
        /// </summary>
        TnG,
        /// <summary>
        /// BOOST.php
        /// </summary>
        Boost,
        /// <summary>
        /// GrabPay.php
        /// </summary>
        GrabPay,
        /// <summary>
        /// MB2U_QRPay-Push.php
        /// </summary>
        M2UQrPay,
        /// <summary>
        /// ShopeePay.php
        /// </summary>
        ShopeePay
    }
}
