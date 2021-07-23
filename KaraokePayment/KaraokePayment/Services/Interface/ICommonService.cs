using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaraokePayment.Services.Interface
{
    public interface ICommonService
    {
        FileResult PrintDocument(string gridHtml);
    }
}
