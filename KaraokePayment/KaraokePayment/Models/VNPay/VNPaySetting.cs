using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaraokePayment.Models.VNPay
{
    public static class VNPaySetting
    {
        public static string vnp_Url = "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html";
        public static string querydr = "http://sandbox.vnpayment.vn/merchant_webapi/merchant.html";
        public static string vnp_TmnCode = "W07Y4LVZ";
        public static string vnp_HashSecret = "ZSYBCCKTUOMWNNESZMQBNCPKVDPFDOEK";
        public static string vnp_Returnurl = "https://karaokepayment.local/ThanhToanKaraoke/ThanhToanPhongKaraoke";
    }
}
