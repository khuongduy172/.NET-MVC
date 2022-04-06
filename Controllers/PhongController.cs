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
    public class PhongController : Controller
    {
        private readonly RestaurantContext _context;

        public PhongController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: Phong
        public async Task<IActionResult> Index()
        {
            var restaurantContext = _context.Phongs.Include(p => p.sanh);
            return View(await restaurantContext.ToListAsync());
        }

        // GET: Phong/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phongModel = await _context.Phongs
                .Include(p => p.sanh)
                .FirstOrDefaultAsync(m => m.maPhong == id);
            if (phongModel == null)
            {
                return NotFound();
            }

            return View(phongModel);
        }

        // GET: Phong/Create
        public IActionResult Create()
        {
            ViewData["maSanh"] = new SelectList(_context.Sanhs, "maSanh", "maSanh");
            return View();
        }

        // POST: Phong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("maPhong,tenPhong,sucChua,loaiPhong,maSanh")] PhongModel phongModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phongModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["maSanh"] = new SelectList(_context.Sanhs, "maSanh", "maSanh", phongModel.maSanh);
            return View(phongModel);
        }

        // GET: Phong/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phongModel = await _context.Phongs.FindAsync(id);
            if (phongModel == null)
            {
                return NotFound();
            }
            ViewData["maSanh"] = new SelectList(_context.Sanhs, "maSanh", "maSanh", phongModel.maSanh);
            return View(phongModel);
        }

        // POST: Phong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("maPhong,tenPhong,sucChua,loaiPhong,maSanh")] PhongModel phongModel)
        {
            if (id != phongModel.maPhong)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phongModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhongModelExists(phongModel.maPhong))
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
            ViewData["maSanh"] = new SelectList(_context.Sanhs, "maSanh", "maSanh", phongModel.maSanh);
            return View(phongModel);
        }

        // GET: Phong/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phongModel = await _context.Phongs
                .Include(p => p.sanh)
                .FirstOrDefaultAsync(m => m.maPhong == id);
            if (phongModel == null)
            {
                return NotFound();
            }

            return View(phongModel);
        }

        // POST: Phong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var phongModel = await _context.Phongs.FindAsync(id);
            _context.Phongs.Remove(phongModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhongModelExists(string id)
        {
            return _context.Phongs.Any(e => e.maPhong == id);
        }
    }
}
