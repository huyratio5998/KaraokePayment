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
    public class CaLVsController : Controller
    {
        private readonly KaraokeDbContext _context;

        public CaLVsController(KaraokeDbContext context)
        {
            _context = context;
        }

        // GET: CaLVs
        public async Task<IActionResult> Index()
        {
            return View(await _context.CaLvs.ToListAsync());
        }

        // GET: CaLVs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caLV = await _context.CaLvs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caLV == null)
            {
                return NotFound();
            }

            return View(caLV);
        }

        // GET: CaLVs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CaLVs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenCa,Tu,Den,HeSoLuong")] CaLV caLV)
        {
            if (ModelState.IsValid)
            {
                _context.Add(caLV);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(caLV);
        }

        // GET: CaLVs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caLV = await _context.CaLvs.FindAsync(id);
            if (caLV == null)
            {
                return NotFound();
            }
            return View(caLV);
        }

        // POST: CaLVs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenCa,Tu,Den,HeSoLuong")] CaLV caLV)
        {
            if (id != caLV.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caLV);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaLVExists(caLV.Id))
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
            return View(caLV);
        }

        // GET: CaLVs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caLV = await _context.CaLvs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (caLV == null)
            {
                return NotFound();
            }

            return View(caLV);
        }

        // POST: CaLVs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var caLV = await _context.CaLvs.FindAsync(id);
            _context.CaLvs.Remove(caLV);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaLVExists(int id)
        {
            return _context.CaLvs.Any(e => e.Id == id);
        }
    }
}
