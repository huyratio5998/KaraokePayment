using KaraokePayment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using KaraokePayment.Data;
using KaraokePayment.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace KaraokePayment.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private KaraokeDbContext _context;
        public HomeController(ILogger<HomeController> logger, KaraokeDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            //var user = await _userManager.GetUserAsync(HttpContext.User);
            //if (user != null)
            //{
            //    ViewBag.UserName = user.Ho + " " + user.Ten;
            //}
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
