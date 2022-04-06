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
    public class NhanVienController : Controller
    {
        private readonly RestaurantContext _context;

        public NhanVienController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: NhanVien
        public async Task<IActionResult> Index()
        {
            return View(await _context.NhanVienModel.ToListAsync());
        }

        // GET: NhanVien/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVienModel = await _context.NhanVienModel
                .FirstOrDefaultAsync(m => m.manv == id);
            if (nhanVienModel == null)
            {
                return NotFound();
            }

            return View(nhanVienModel);
        }

        // GET: NhanVien/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NhanVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("manv,tennv")] NhanVienModel nhanVienModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanVienModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhanVienModel);
        }

        // GET: NhanVien/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVienModel = await _context.NhanVienModel.FindAsync(id);
            if (nhanVienModel == null)
            {
                return NotFound();
            }
            return View(nhanVienModel);
        }

        // POST: NhanVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("manv,tennv")] NhanVienModel nhanVienModel)
        {
            if (id != nhanVienModel.manv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanVienModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanVienModelExists(nhanVienModel.manv))
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
            return View(nhanVienModel);
        }

        // GET: NhanVien/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanVienModel = await _context.NhanVienModel
                .FirstOrDefaultAsync(m => m.manv == id);
            if (nhanVienModel == null)
            {
                return NotFound();
            }

            return View(nhanVienModel);
        }

        // POST: NhanVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhanVienModel = await _context.NhanVienModel.FindAsync(id);
            _context.NhanVienModel.Remove(nhanVienModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanVienModelExists(int id)
        {
            return _context.NhanVienModel.Any(e => e.manv == id);
        }
    }
}
