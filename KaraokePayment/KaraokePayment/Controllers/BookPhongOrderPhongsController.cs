using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaraokePayment.DAO.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KaraokePayment.Data;
using KaraokePayment.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using KaraokePayment.Enums;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace KaraokePayment.Controllers
{
    [Authorize]
    public class BookPhongOrderPhongsController : Controller
    {
        private readonly KaraokeDbContext _context;
        private IBookPhongOrderPhongDAO _bookPhongOrderPhongDao;
        private IPhongDAO _phongDAO;        
        public BookPhongOrderPhongsController(KaraokeDbContext context, IBookPhongOrderPhongDAO bookPhongOrderPhongDao, IPhongDAO phongDAO)
        {
            _context = context;
            _bookPhongOrderPhongDao = bookPhongOrderPhongDao;
            _phongDAO = phongDAO;            
        }
        // GET: BookPhongOrderPhongs
        public async Task<IActionResult> Index()
        {
            var karaokeDbContext = _context.BookPhongOrderPhongs.Include(b => b.BookPhongOrder).Include(b => b.Phong);
            return View(await karaokeDbContext.ToListAsync());
        }

        // GET: BookPhongOrderPhongs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookPhongOrderPhong = await _context.BookPhongOrderPhongs
                .Include(b => b.BookPhongOrder)
                .Include(b => b.Phong)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookPhongOrderPhong == null)
            {
                return NotFound();
            }

            return View(bookPhongOrderPhong);
        }

        // GET: BookPhongOrderPhongs/Create
        public IActionResult Create()
        {
            var nv1 = _context.Users.Where(x => x.UserName == null && x.PasswordHash == null).Join(_context.NhanVienCaLvs, user => user.Id, nvCaLV => nvCaLV.NhanVienId, (user, nvCaLV) => new { User = user, NVCaLV = nvCaLV }).Select(x=>x.NVCaLV.Id);
            ViewData["NhanVienBook1Id"] = new SelectList(nv1);
            ViewData["NhanVienBook2Id"] = new SelectList(nv1);

            ViewData["BookPhongOrderId"] = new SelectList(_context.BookPhongOrders.Where(x=>x.TrangThai==BookPhongOrderStatus.NotPaid), "Id", "Id");
            ViewData["PhongId"] = new SelectList(_context.Phongs.Where(x=>x.TrangThai==PhongStatus.Empty), "Id", "TenPhong");
            var model = new BookPhongOrderPhong()
            {
                ThoiGianBatDau = DateTime.Now,
                ThoiGianKetThuc = DateTime.Now,
                NgayTao = DateTime.Now,
                NgaySua = DateTime.Now,
                TongTien=0
            };
            return View(model);
        }

        // POST: BookPhongOrderPhongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NhanVienBook1Id,NhanVienBook2Id,ThoiGianBatDau,ThoiGianKetThuc,PhuongThucTT,TrangThai,NgayTao,NgaySua,TongTien,BookPhongOrderId,PhongId")] BookPhongOrderPhong bookPhongOrderPhong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookPhongOrderPhong);
                await _context.SaveChangesAsync();
                //update phong status
                var getPhong =await _phongDAO.GetById(bookPhongOrderPhong.PhongId);
                getPhong.TrangThai = PhongStatus.Occupied;
                await _phongDAO.Update(getPhong);                
                return RedirectToAction(nameof(Index));
            }
            var nv1 = _context.Users.Where(x => x.UserName == null && x.PasswordHash == null).Join(_context.NhanVienCaLvs, user => user.Id, nvCaLV => nvCaLV.NhanVienId, (user, nvCaLV) => new { User = user, NVCaLV = nvCaLV }).Select(x => x.NVCaLV.Id);
            ViewData["NhanVienBook1Id"] = new SelectList(nv1);
            ViewData["NhanVienBook2Id"] = new SelectList(nv1);
            ViewData["BookPhongOrderId"] = new SelectList(_context.BookPhongOrders, "Id", "Id", bookPhongOrderPhong.BookPhongOrderId);
            ViewData["PhongId"] = new SelectList(_context.Phongs, "Id", "TenPhong", bookPhongOrderPhong.PhongId);
            return View(bookPhongOrderPhong);
        }

        // GET: BookPhongOrderPhongs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookPhongOrderPhong = await _context.BookPhongOrderPhongs.FindAsync(id);
            if (bookPhongOrderPhong == null)
            {
                return NotFound();
            }
            var nv1 = _context.Users.Where(x => x.UserName == null && x.PasswordHash == null).Join(_context.NhanVienCaLvs, user => user.Id, nvCaLV => nvCaLV.NhanVienId, (user, nvCaLV) => new { User = user, NVCaLV = nvCaLV }).Select(x => x.NVCaLV.Id);
            ViewData["NhanVienBook1Id"] = new SelectList(nv1);
            ViewData["NhanVienBook2Id"] = new SelectList(nv1);
            ViewData["BookPhongOrderId"] = new SelectList(_context.BookPhongOrders, "Id", "Id", bookPhongOrderPhong.BookPhongOrderId);
            ViewData["PhongId"] = new SelectList(_context.Phongs, "Id", "TenPhong", bookPhongOrderPhong.PhongId);
            return View(bookPhongOrderPhong);
        }

        // POST: BookPhongOrderPhongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NhanVienBook1Id,NhanVienBook2Id,ThoiGianBatDau,ThoiGianKetThuc,PhuongThucTT,TrangThai,NgayTao,NgaySua,TongTien,BookPhongOrderId,PhongId")] BookPhongOrderPhong bookPhongOrderPhong)
        {
            if (id != bookPhongOrderPhong.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookPhongOrderPhong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookPhongOrderPhongExists(bookPhongOrderPhong.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            var nv1 = _context.Users.Where(x => x.UserName == null && x.PasswordHash == null).Join(_context.NhanVienCaLvs, user => user.Id, nvCaLV => nvCaLV.NhanVienId, (user, nvCaLV) => new { User = user, NVCaLV = nvCaLV }).Select(x => x.NVCaLV.Id);
            ViewData["NhanVienBook1Id"] = new SelectList(nv1);
            ViewData["NhanVienBook2Id"] = new SelectList(nv1);
            ViewData["BookPhongOrderId"] = new SelectList(_context.BookPhongOrders, "Id", "Id", bookPhongOrderPhong.BookPhongOrderId);
            ViewData["PhongId"] = new SelectList(_context.Phongs, "Id", "TenPhong", bookPhongOrderPhong.PhongId);
            return View(bookPhongOrderPhong);
        }

        // GET: BookPhongOrderPhongs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookPhongOrderPhong = await _context.BookPhongOrderPhongs
                .Include(b => b.BookPhongOrder)
                .Include(b => b.Phong)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookPhongOrderPhong == null)
            {
                return NotFound();
            }

            return View(bookPhongOrderPhong);
        }

        // POST: BookPhongOrderPhongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookPhongOrderPhong = await _context.BookPhongOrderPhongs.FindAsync(id);
            _context.BookPhongOrderPhongs.Remove(bookPhongOrderPhong);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookPhongOrderPhongExists(int id)
        {
            return _context.BookPhongOrderPhongs.Any(e => e.Id == id);
        }
    }
}
