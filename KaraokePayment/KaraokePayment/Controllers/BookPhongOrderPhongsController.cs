using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KaraokePayment.Data;
using KaraokePayment.Data.Entity;

namespace KaraokePayment.Controllers
{
    public class BookPhongOrderPhongsController : Controller
    {
        private readonly KaraokeDbContext _context;

        public BookPhongOrderPhongsController(KaraokeDbContext context)
        {
            _context = context;
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
            ViewData["BookPhongOrderId"] = new SelectList(_context.BookPhongOrders, "Id", "Id");
            ViewData["PhongId"] = new SelectList(_context.Phongs, "Id", "Id");
            return View();
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookPhongOrderId"] = new SelectList(_context.BookPhongOrders, "Id", "Id", bookPhongOrderPhong.BookPhongOrderId);
            ViewData["PhongId"] = new SelectList(_context.Phongs, "Id", "Id", bookPhongOrderPhong.PhongId);
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
            ViewData["BookPhongOrderId"] = new SelectList(_context.BookPhongOrders, "Id", "Id", bookPhongOrderPhong.BookPhongOrderId);
            ViewData["PhongId"] = new SelectList(_context.Phongs, "Id", "Id", bookPhongOrderPhong.PhongId);
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
            ViewData["BookPhongOrderId"] = new SelectList(_context.BookPhongOrders, "Id", "Id", bookPhongOrderPhong.BookPhongOrderId);
            ViewData["PhongId"] = new SelectList(_context.Phongs, "Id", "Id", bookPhongOrderPhong.PhongId);
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
