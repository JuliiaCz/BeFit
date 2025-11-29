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
    public class SesjaCwiczeniasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SesjaCwiczeniasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SesjaCwiczenias
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SesjeCwiczenia.Include(s => s.Cwiczenie).Include(s => s.Sesja);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SesjaCwiczenias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sesjaCwiczenia = await _context.SesjeCwiczenia
                .Include(s => s.Cwiczenie)
                .Include(s => s.Sesja)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sesjaCwiczenia == null)
            {
                return NotFound();
            }

            return View(sesjaCwiczenia);
        }

        // GET: SesjaCwiczenias/Create
        public IActionResult Create()
        {
            ViewData["CwiczenieId"] = new SelectList(_context.Cwiczenie, "Id", "Name");
            ViewData["SesjaId"] = new SelectList(_context.Sesje, "Id", "Start");
            return View();
        }

        // POST: SesjaCwiczenias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SesjaId,CwiczenieId,CiezarKg,Serie,Powtorzenia")] SesjaCwiczenia sesjaCwiczenia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sesjaCwiczenia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CwiczenieId"] = new SelectList(_context.Cwiczenie, "Id", "Name", sesjaCwiczenia.CwiczenieId);
            ViewData["SesjaId"] = new SelectList(_context.Sesje, "Id", "Start", sesjaCwiczenia.SesjaId);
            return View(sesjaCwiczenia);
        }

        // GET: SesjaCwiczenias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sesjaCwiczenia = await _context.SesjeCwiczenia.FindAsync(id);
            if (sesjaCwiczenia == null)
            {
                return NotFound();
            }
            ViewData["CwiczenieId"] = new SelectList(_context.Cwiczenie, "Id", "Name", sesjaCwiczenia.CwiczenieId);
            ViewData["SesjaId"] = new SelectList(_context.Sesje, "Id", "Start", sesjaCwiczenia.SesjaId);
            return View(sesjaCwiczenia);
        }

        // POST: SesjaCwiczenias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SesjaId,CwiczenieId,CiezarKg,Serie,Powtorzenia")] SesjaCwiczenia sesjaCwiczenia)
        {
            if (id != sesjaCwiczenia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sesjaCwiczenia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SesjaCwiczeniaExists(sesjaCwiczenia.Id))
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
            ViewData["CwiczenieId"] = new SelectList(_context.Cwiczenie, "Id", "Name", sesjaCwiczenia.CwiczenieId);
            ViewData["SesjaId"] = new SelectList(_context.Sesje, "Id", "Start", sesjaCwiczenia.SesjaId);
            return View(sesjaCwiczenia);
        }

        // GET: SesjaCwiczenias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sesjaCwiczenia = await _context.SesjeCwiczenia
                .Include(s => s.Cwiczenie)
                .Include(s => s.Sesja)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sesjaCwiczenia == null)
            {
                return NotFound();
            }

            return View(sesjaCwiczenia);
        }

        // POST: SesjaCwiczenias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sesjaCwiczenia = await _context.SesjeCwiczenia.FindAsync(id);
            if (sesjaCwiczenia != null)
            {
                _context.SesjeCwiczenia.Remove(sesjaCwiczenia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SesjaCwiczeniaExists(int id)
        {
            return _context.SesjeCwiczenia.Any(e => e.Id == id);
        }
    }
}
