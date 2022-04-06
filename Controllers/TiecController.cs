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
    public class TiecController : Controller
    {
        private readonly RestaurantContext _context;

        public TiecController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: Tiec
        public async Task<IActionResult> Index()
        {
            var restaurantContext = _context.Tiecs.Include(t => t.KhachHang);
            return View(await restaurantContext.ToListAsync());
        }

        // GET: Tiec/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiecModel = await _context.Tiecs
                .Include(t => t.KhachHang)
                .FirstOrDefaultAsync(m => m.maTiec == id);
            if (tiecModel == null)
            {
                return NotFound();
            }

            return View(tiecModel);
        }

        // GET: Tiec/Create
        public IActionResult Create()
        {
            ViewData["maKhachHang"] = new SelectList(_context.KhachHangs, "maKh", "maKh");
            return View();
        }

        // POST: Tiec/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("maTiec,tenTiec,ngayDat,maKhachHang")] TiecModel tiecModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiecModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["maKhachHang"] = new SelectList(_context.KhachHangs, "maKh", "maKh", tiecModel.maKhachHang);
            return View(tiecModel);
        }

        // GET: Tiec/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiecModel = await _context.Tiecs.FindAsync(id);
            if (tiecModel == null)
            {
                return NotFound();
            }
            ViewData["maKhachHang"] = new SelectList(_context.KhachHangs, "maKh", "maKh", tiecModel.maKhachHang);
            return View(tiecModel);
        }

        // POST: Tiec/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("maTiec,tenTiec,ngayDat,maKhachHang")] TiecModel tiecModel)
        {
            if (id != tiecModel.maTiec)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiecModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiecModelExists(tiecModel.maTiec))
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
            ViewData["maKhachHang"] = new SelectList(_context.KhachHangs, "maKh", "maKh", tiecModel.maKhachHang);
            return View(tiecModel);
        }

        // GET: Tiec/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiecModel = await _context.Tiecs
                .Include(t => t.KhachHang)
                .FirstOrDefaultAsync(m => m.maTiec == id);
            if (tiecModel == null)
            {
                return NotFound();
            }

            return View(tiecModel);
        }

        // POST: Tiec/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tiecModel = await _context.Tiecs.FindAsync(id);
            _context.Tiecs.Remove(tiecModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiecModelExists(string id)
        {
            return _context.Tiecs.Any(e => e.maTiec == id);
        }
    }
}
