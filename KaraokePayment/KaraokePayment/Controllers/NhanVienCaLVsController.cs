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
    public class NhanVienCaLVsController : Controller
    {
        private readonly KaraokeDbContext _context;

        public NhanVienCaLVsController(KaraokeDbContext context)
        {
            _context = context;
        }

        // GET: NhanVienCaLVs
        public async Task<IActionResult> Index()
        {
            var karaokeDbContext = _context.NhanVienCaLvs.Include(n => n.CaLv).Include(n => n.NhanVien);
            return View(await karaokeDbContext.ToListAsync());
        }

        // GET: NhanVienCaLVs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVienCaLV = await _context.NhanVienCaLvs
                .Include(n => n.CaLv)
                .Include(n => n.NhanVien)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nhanVienCaLV == null)
            {
                return NotFound();
            }

            return View(nhanVienCaLV);
        }

        // GET: NhanVienCaLVs/Create
        public IActionResult Create()
        {
            ViewData["CaLvId"] = new SelectList(_context.CaLvs, "Id", "Id");
            ViewData["NhanVienId"] = new SelectList(_context.Set<NhanVien>(), "Id", "Id");
            return View();
        }

        // POST: NhanVienCaLVs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NgayLV,NhanVienId,CaLvId")] NhanVienCaLV nhanVienCaLV)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanVienCaLV);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CaLvId"] = new SelectList(_context.CaLvs, "Id", "Id", nhanVienCaLV.CaLvId);
            ViewData["NhanVienId"] = new SelectList(_context.Set<NhanVien>(), "Id", "Id", nhanVienCaLV.NhanVienId);
            return View(nhanVienCaLV);
        }

        // GET: NhanVienCaLVs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVienCaLV = await _context.NhanVienCaLvs.FindAsync(id);
            if (nhanVienCaLV == null)
            {
                return NotFound();
            }
            ViewData["CaLvId"] = new SelectList(_context.CaLvs, "Id", "Id", nhanVienCaLV.CaLvId);
            ViewData["NhanVienId"] = new SelectList(_context.Set<NhanVien>(), "Id", "Id", nhanVienCaLV.NhanVienId);
            return View(nhanVienCaLV);
        }

        // POST: NhanVienCaLVs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NgayLV,NhanVienId,CaLvId")] NhanVienCaLV nhanVienCaLV)
        {
            if (id != nhanVienCaLV.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanVienCaLV);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanVienCaLVExists(nhanVienCaLV.Id))
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
            ViewData["CaLvId"] = new SelectList(_context.CaLvs, "Id", "Id", nhanVienCaLV.CaLvId);
            ViewData["NhanVienId"] = new SelectList(_context.Set<NhanVien>(), "Id", "Id", nhanVienCaLV.NhanVienId);
            return View(nhanVienCaLV);
        }

        // GET: NhanVienCaLVs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVienCaLV = await _context.NhanVienCaLvs
                .Include(n => n.CaLv)
                .Include(n => n.NhanVien)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nhanVienCaLV == null)
            {
                return NotFound();
            }

            return View(nhanVienCaLV);
        }

        // POST: NhanVienCaLVs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhanVienCaLV = await _context.NhanVienCaLvs.FindAsync(id);
            _context.NhanVienCaLvs.Remove(nhanVienCaLV);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanVienCaLVExists(int id)
        {
            return _context.NhanVienCaLvs.Any(e => e.Id == id);
        }
    }
}
