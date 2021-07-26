using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaraokePayment.Models.VNPay
{
    public class UrlRequestApi
    {
        public UrlRequestApi(string vnp_TmnCode, string vnp_Amount, string vnp_OrderInfo, string vnp_ReturnUrl, string vnp_TxnRef)
        {
            this.vnp_Version = "2.0.1";
            this.vnp_Command = "pay";
            this.vnp_CurrCode = "VND";
            this.vnp_IpAddr = "::1";
            this.vnp_Locale = "vn";
            this.vnp_CreateDate= DateTime.Now.ToString("yyyyMMddHHmmss");
            //
            this.vnp_Version = vnp_Version;
            this.vnp_Command = vnp_Command;
            this.vnp_TmnCode = vnp_TmnCode;
            this.vnp_Amount = vnp_Amount;
            this.vnp_CurrCode = vnp_CurrCode;
            this.vnp_IpAddr = vnp_IpAddr;
            this.vnp_TmnCode = vnp_TmnCode;
            this.vnp_Amount = vnp_Amount;
            this.vnp_OrderInfo = vnp_OrderInfo;
            this.vnp_ReturnUrl = vnp_ReturnUrl;
            this.vnp_TxnRef = vnp_TxnRef;            
        }
        public string vnp_Version { get; set; }
        public string vnp_Command { get; set; }
        public string vnp_TmnCode { get; set; }
        public string vnp_Amount { get; set; }
        public string vnp_CreateDate { get; set; }
        public string vnp_CurrCode { get; set; }
        public string vnp_IpAddr { get; set; }
        public string vnp_Locale { get; set; }
        public string vnp_OrderInfo { get; set; }
        public string vnp_ReturnUrl { get; set; }
        public string vnp_TxnRef { get; set; }
        public string vnp_SecureHashType { get; set; }
        public string vnp_SecureHash { get; set; }        
    }
}
