using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Datas;
using MVC.Models;

namespace MVC.Controllers
{
    public class BookPhongController : Controller
    {
        private readonly RestaurantContext _context;

        public BookPhongController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: BookPhong
        public async Task<IActionResult> Index()
        {
            var restaurantContext = _context.BookPhongs.Include(b => b.Phong).Include(b => b.Tiec);
            return View(await restaurantContext.ToListAsync());
        }

        // GET: BookPhong/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookPhongModel = await _context.BookPhongs
                .Include(b => b.Phong)
                .Include(b => b.Tiec)
                .FirstOrDefaultAsync(m => m.maTiec == id);
            if (bookPhongModel == null)
            {
                return NotFound();
            }

            return View(bookPhongModel);
        }

        // GET: BookPhong/Create
        public IActionResult Create()
        {
            ViewData["maPhong"] = new SelectList(_context.Phongs, "maPhong", "maPhong");
            ViewData["maTiec"] = new SelectList(_context.Tiecs, "maTiec", "maTiec");
            return View();
        }

        // POST: BookPhong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("maTiec,maPhong,slNuoc")] BookPhongModel bookPhongModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookPhongModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["maPhong"] = new SelectList(_context.Phongs, "maPhong", "maPhong", bookPhongModel.maPhong);
            ViewData["maTiec"] = new SelectList(_context.Tiecs, "maTiec", "maTiec", bookPhongModel.maTiec);
            return View(bookPhongModel);
        }

        // GET: BookPhong/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookPhongModel = await _context.BookPhongs.FindAsync(id);
            if (bookPhongModel == null)
            {
                return NotFound();
            }
            ViewData["maPhong"] = new SelectList(_context.Phongs, "maPhong", "maPhong", bookPhongModel.maPhong);
            ViewData["maTiec"] = new SelectList(_context.Tiecs, "maTiec", "maTiec", bookPhongModel.maTiec);
            return View(bookPhongModel);
        }

        // POST: BookPhong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("maTiec,maPhong,slNuoc")] BookPhongModel bookPhongModel)
        {
            if (id != bookPhongModel.maTiec)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookPhongModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookPhongModelExists(bookPhongModel.maTiec))
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
            ViewData["maPhong"] = new SelectList(_context.Phongs, "maPhong", "maPhong", bookPhongModel.maPhong);
            ViewData["maTiec"] = new SelectList(_context.Tiecs, "maTiec", "maTiec", bookPhongModel.maTiec);
            return View(bookPhongModel);
        }

        // GET: BookPhong/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookPhongModel = await _context.BookPhongs
                .Include(b => b.Phong)
                .Include(b => b.Tiec)
                .FirstOrDefaultAsync(m => m.maTiec == id);
            if (bookPhongModel == null)
            {
                return NotFound();
            }

            return View(bookPhongModel);
        }

        // POST: BookPhong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var bookPhongModel = await _context.BookPhongs.FindAsync(id);
            _context.BookPhongs.Remove(bookPhongModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookPhongModelExists(string id)
        {
            return _context.BookPhongs.Any(e => e.maTiec == id);
        }
    }
}
