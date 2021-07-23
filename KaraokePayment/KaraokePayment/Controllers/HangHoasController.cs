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
using KaraokePayment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace KaraokePayment.Controllers
{
    [Authorize]
    public class HangHoasController : Controller
    {
        private readonly KaraokeDbContext _context;
        public IHangHoaDAO _hangHoaDao;
        private IWebHostEnvironment _hostEnvironment;

        public HangHoasController(KaraokeDbContext context, IHangHoaDAO hangHoaDao, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hangHoaDao = hangHoaDao;
            _hostEnvironment = hostEnvironment;
        }
        //Image
        public async Task<string> CreateImage(IFormFile imageFile, string imageName, string saveFolder)
        {
            try
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (imageFile != null)
                {
                    imageName = imageFile.FileName;
                    //create save folder if not exist                                        
                    if (!Directory.Exists(wwwRootPath + saveFolder))
                    {
                        Directory.CreateDirectory(wwwRootPath + saveFolder);
                    }
                    string path = Path.Combine(wwwRootPath + saveFolder, imageName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }
                }
                return imageName;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public async Task<string> EditImage(IFormFile imageFile, string imageName, string saveFolder)
        {

            try
            {
                if (imageFile != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    var imagePath = Path.Combine(wwwRootPath + saveFolder, imageFile.FileName);
                    if (!System.IO.File.Exists(imagePath))
                    {
                        // create image when path not exist
                        imageName = imageFile.FileName;
                        if (!Directory.Exists(wwwRootPath + saveFolder))
                        {
                            Directory.CreateDirectory(wwwRootPath + saveFolder);
                        }
                        string path = Path.Combine(wwwRootPath + saveFolder, imageName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await imageFile.CopyToAsync(fileStream);
                        }
                    }
                    else
                    {
                        imageName = imageFile.FileName;
                    }
                }
                return imageName;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        // GET: HangHoas
        public async Task<IActionResult> Index()
        {
            return View(await _context.HangHoas.ToListAsync());
        }

        // GET: HangHoas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangHoa = await _context.HangHoas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hangHoa == null)
            {
                return NotFound();
            }

            return View(hangHoa);
        }

        // GET: HangHoas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HangHoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]        
        public async Task<IActionResult> Create(HangHoa hangHoa)
        {
            if (ModelState.IsValid)
            {
                hangHoa.HangHoaImage= await CreateImage(hangHoa.ImageFile, hangHoa.HangHoaImage, "/Karaoke-assest/Images/HangHoas/" + hangHoa.Ten);
                _context.Add(hangHoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hangHoa);
        }

        // GET: HangHoas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangHoa = await _context.HangHoas.FindAsync(id);
            if (hangHoa == null)
            {
                return NotFound();
            }
            return View(hangHoa);
        }

        // POST: HangHoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,HangHoa hangHoa)
        {
            if (id != hangHoa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    hangHoa.HangHoaImage = await EditImage(hangHoa.ImageFile, hangHoa.HangHoaImage, "/Karaoke-assest/Images/HangHoas/" + hangHoa.Ten);
                    _context.Update(hangHoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HangHoaExists(hangHoa.Id))
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
            return View(hangHoa);
        }

        // GET: HangHoas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangHoa = await _context.HangHoas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hangHoa == null)
            {
                return NotFound();
            }

            return View(hangHoa);
        }

        // POST: HangHoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hangHoa = await _context.HangHoas.FindAsync(id);
            _context.HangHoas.Remove(hangHoa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HangHoaExists(int id)
        {
            return _context.HangHoas.Any(e => e.Id == id);
        }
    }
}
