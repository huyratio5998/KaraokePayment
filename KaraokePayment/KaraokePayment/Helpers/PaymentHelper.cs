using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using KaraokePayment.Data.Entity;

namespace KaraokePayment.Helpers
{
    public static class PaymentHelper
    {
        public static decimal GetTongTT(IEnumerable<BookPhongOrderPhong> bookPhongOrderPhongs)
        {
            decimal result = 0;
            bookPhongOrderPhongs.ToList().ForEach(x=>result+=x.TongTien);
            return result;
        }
        public static string ConvertCurrency(decimal money)
        {
            if (money == 0) return $"0 VND";
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            string result = money.ToString("#,###", cul.NumberFormat);
            return $"{result} VND";
        }
        public static bool ValidatePaymentSuccess(string vnp_Amount, string vnp_BankCode, string vnp_BankTranNo, string vnp_CardType,
            string vnp_OrderInfo, string vnp_PayDate, string vnp_ResponseCode, string vnp_TmnCode, string vnp_TransactionNo, string vnp_TxnRef,
            string vnp_SecureHashType, string vnp_SecureHash)
        {
            if (string.IsNullOrEmpty(vnp_Amount)) return false;
            if (string.IsNullOrEmpty(vnp_BankCode)) return false;
            if (string.IsNullOrEmpty(vnp_BankTranNo)) return false;
            if (string.IsNullOrEmpty(vnp_CardType)) return false;            
            if (string.IsNullOrEmpty(vnp_PayDate)) return false;
            if (string.IsNullOrEmpty(vnp_ResponseCode)) return false;
            if (string.IsNullOrEmpty(vnp_TransactionNo)) return false;
            if (string.IsNullOrEmpty(vnp_TxnRef)) return false;
            if (string.IsNullOrEmpty(vnp_SecureHashType)) return false;
            if (string.IsNullOrEmpty(vnp_SecureHash)) return false;
            if (string.IsNullOrEmpty(vnp_TmnCode)) return false;
            return (!string.IsNullOrEmpty(vnp_OrderInfo) && vnp_OrderInfo.Contains("Huyratio") && vnp_ResponseCode.Equals("00"))? true : false;            
        }        
    }
}
