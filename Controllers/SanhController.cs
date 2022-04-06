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
    public class SanhController : Controller
    {
        private readonly RestaurantContext _context;

        public SanhController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: Sanh
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sanhs.ToListAsync());
        }

        // GET: Sanh/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanhModel = await _context.Sanhs
                .FirstOrDefaultAsync(m => m.maSanh == id);
            if (sanhModel == null)
            {
                return NotFound();
            }

            return View(sanhModel);
        }

        // GET: Sanh/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sanh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("maSanh,tenSanh")] SanhModel sanhModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanhModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sanhModel);
        }

        // GET: Sanh/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanhModel = await _context.Sanhs.FindAsync(id);
            if (sanhModel == null)
            {
                return NotFound();
            }
            return View(sanhModel);
        }

        // POST: Sanh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("maSanh,tenSanh")] SanhModel sanhModel)
        {
            if (id != sanhModel.maSanh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanhModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanhModelExists(sanhModel.maSanh))
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
            return View(sanhModel);
        }

        // GET: Sanh/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanhModel = await _context.Sanhs
                .FirstOrDefaultAsync(m => m.maSanh == id);
            if (sanhModel == null)
            {
                return NotFound();
            }

            return View(sanhModel);
        }

        // POST: Sanh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sanhModel = await _context.Sanhs.FindAsync(id);
            _context.Sanhs.Remove(sanhModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanhModelExists(string id)
        {
            return _context.Sanhs.Any(e => e.maSanh == id);
        }
    }
}
