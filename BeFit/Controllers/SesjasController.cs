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
    public class SesjasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SesjasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sesjas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sesje.ToListAsync());
        }

        // GET: Sesjas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sesja = await _context.Sesje
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sesja == null)
            {
                return NotFound();
            }

            return View(sesja);
        }

        // GET: Sesjas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sesjas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Start,End")] Sesja sesja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sesja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sesja);
        }

        // GET: Sesjas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sesja = await _context.Sesje.FindAsync(id);
            if (sesja == null)
            {
                return NotFound();
            }
            return View(sesja);
        }

        // POST: Sesjas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Start,End")] Sesja sesja)
        {
            if (id != sesja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sesja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SesjaExists(sesja.Id))
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
            return View(sesja);
        }

        // GET: Sesjas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sesja = await _context.Sesje
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sesja == null)
            {
                return NotFound();
            }

            return View(sesja);
        }

        // POST: Sesjas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sesja = await _context.Sesje.FindAsync(id);
            if (sesja != null)
            {
                _context.Sesje.Remove(sesja);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SesjaExists(int id)
        {
            return _context.Sesje.Any(e => e.Id == id);
        }
    }
}
