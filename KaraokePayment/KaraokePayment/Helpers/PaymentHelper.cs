﻿using System;
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
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            string result = money.ToString("#,###", cul.NumberFormat);
            return $"{result} VND";
        }
    }
}
