using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaraokePayment.DAO.Interface;
using KaraokePayment.Data;

namespace KaraokePayment.Controllers
{
    public class BookPhongOrderPhong1Controller : Controller
    {
        private IBookPhongOrderPhongDAO _bookPhongOrderPhongDao;

        public BookPhongOrderPhong1Controller(IBookPhongOrderPhongDAO bookPhongOrderPhongDao)
        {
            _bookPhongOrderPhongDao = bookPhongOrderPhongDao;
        }
        //public IActionResult ThanhToanKaraoke(int bookPhongOrderPhongId)
        //{
        //    _bookPhongOrderPhongDao.ThanhToanPhong(bookPhongOrderPhongId);
        //    return View();
        //}
        //public IActionResult ThemHangHoaPhong(int bookPhongOrderPhongId,int hangHoaId,int soLuong)
        //{
        //    _bookPhongOrderPhongDao.ThemHangHoaPhong(bookPhongOrderPhongId,hangHoaId,soLuong);
        //    return View();
        //}
    }
}
