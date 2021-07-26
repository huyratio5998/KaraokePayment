using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KaraokePayment.Data;
using KaraokePayment.Data.Entity;
using KaraokePayment.Enums;
using Microsoft.AspNetCore.Authorization;
using KaraokePayment.Models;
using KaraokePayment.Helpers;
using Microsoft.AspNetCore.Identity;

namespace KaraokePayment.Controllers
{
    [Authorize]
    public class BookPhongOrdersController : Controller
    {
        private readonly KaraokeDbContext _context;
        private UserManager<IdentityUser> _userAdmin;
        public BookPhongOrdersController(KaraokeDbContext context, UserManager<IdentityUser> userAdmin)
        {
            _context = context;
            _userAdmin = userAdmin;
        }

        // GET: BookPhongOrders
        public async Task<IActionResult> Index()
        {
            var karaokeDbContext = _context.BookPhongOrders.Include(b => b.KhachHang).Include(b => b.NhanVienCaLV);
            var bookPhongOrders = new List<BookPhongOrderViewModel>();            
            foreach (var item in karaokeDbContext.ToList())
            {
                var model = new BookPhongOrderViewModel()
                {
                    Id = item.Id,
                    KhachHang = StringHelper.StringCapitalization($"{item.KhachHang.Ho} {item.KhachHang.Ten}"),
                    NhanVienAdmin = item.NhanVienAdminEmail,
                    TongTT = item.TongTT,
                    TrangThai = item.TrangThai
                };
                bookPhongOrders.Add(model);
            }
            
            return View(bookPhongOrders);
        }

        // GET: BookPhongOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookPhongOrder = await _context.BookPhongOrders
                .Include(b => b.KhachHang)
                .Include(b => b.NhanVienCaLV)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookPhongOrder == null)
            {
                return NotFound();
            }

            return View(bookPhongOrder);
        }

        // GET: BookPhongOrders/Create
        public IActionResult Create()
        {            
            ViewData["KhachHangId"] = new SelectList(_context.Set<KhachHang>(), "Id", "Ten");            
            return View();
        }

        // POST: BookPhongOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TongTT,TrangThai,KhachHangId")] BookPhongOrder bookPhongOrder)
        {
            if (ModelState.IsValid)
            {
                var currentUser = _userAdmin.GetUserAsync(User).Result;
                bookPhongOrder.NhanVienAdminEmail = currentUser.Email;
                var currentAdminCaLvId = _context.NhanVienCaLvs.FirstOrDefault(x => x.NhanVienId == currentUser.Id).Id;
                bookPhongOrder.NhanVienCaLVId = currentAdminCaLvId;
                _context.Add(bookPhongOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }            
            ViewData["KhachHangId"] = new SelectList(_context.Set<KhachHang>(), "Id", "Id", bookPhongOrder.KhachHangId);            
            return View(bookPhongOrder);
        }

        // GET: BookPhongOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookPhongOrder = await _context.BookPhongOrders.FindAsync(id);
            if (bookPhongOrder == null)
            {
                return NotFound();
            }
            ViewData["KhachHangId"] = new SelectList(_context.Set<KhachHang>(), "Id", "Id", bookPhongOrder.KhachHangId);            
            return View(bookPhongOrder);
        }

        // POST: BookPhongOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TongTT,TrangThai,KhachHangId")] BookPhongOrder bookPhongOrder)
        {
            if (id != bookPhongOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookPhongOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookPhongOrderExists(bookPhongOrder.Id))
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
            ViewData["KhachHangId"] = new SelectList(_context.Set<KhachHang>(), "Id", "Id", bookPhongOrder.KhachHangId);            
            return View(bookPhongOrder);
        }

        // GET: BookPhongOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookPhongOrder = await _context.BookPhongOrders
                .Include(b => b.KhachHang)
                .Include(b => b.NhanVienCaLV)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookPhongOrder == null)
            {
                return NotFound();
            }

            return View(bookPhongOrder);
        }

        // POST: BookPhongOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookPhongOrder = await _context.BookPhongOrders.FindAsync(id);
            _context.BookPhongOrders.Remove(bookPhongOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookPhongOrderExists(int id)
        {
            return _context.BookPhongOrders.Any(e => e.Id == id);
        }
    }
}
