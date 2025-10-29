using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeFit.Data;
using BeFit.Models;

namespace BeFit.Controllers
{
    public class CwiczeniesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CwiczeniesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cwiczenies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cwiczenie.ToListAsync());
        }

        // GET: Cwiczenies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cwiczenie = await _context.Cwiczenie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cwiczenie == null)
            {
                return NotFound();
            }

            return View(cwiczenie);
        }

        // GET: Cwiczenies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cwiczenies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Cwiczenie cwiczenie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cwiczenie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cwiczenie);
        }

        // GET: Cwiczenies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cwiczenie = await _context.Cwiczenie.FindAsync(id);
            if (cwiczenie == null)
            {
                return NotFound();
            }
            return View(cwiczenie);
        }

        // POST: Cwiczenies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Cwiczenie cwiczenie)
        {
            if (id != cwiczenie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cwiczenie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CwiczenieExists(cwiczenie.Id))
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
            return View(cwiczenie);
        }

        // GET: Cwiczenies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cwiczenie = await _context.Cwiczenie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cwiczenie == null)
            {
                return NotFound();
            }

            return View(cwiczenie);
        }

        // POST: Cwiczenies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cwiczenie = await _context.Cwiczenie.FindAsync(id);
            if (cwiczenie != null)
            {
                _context.Cwiczenie.Remove(cwiczenie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CwiczenieExists(int id)
        {
            return _context.Cwiczenie.Any(e => e.Id == id);
        }
    }
}
