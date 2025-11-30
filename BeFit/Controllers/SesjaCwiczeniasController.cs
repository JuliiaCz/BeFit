using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeFit.Data;
using BeFit.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using BeFit.DTOs;

namespace BeFit.Controllers
{
    [Authorize]
    public class SesjaCwiczeniasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SesjaCwiczeniasController(ApplicationDbContext context)
        {
            _context = context;
        }

        private string GetUserId()
            => User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;

        // GET: SesjaCwiczenias
        public async Task<IActionResult> Index()
        {
            var userId = GetUserId();

            var applicationDbContext = _context.SesjeCwiczenia
                .Include(s => s.Cwiczenie)
                .Include(s => s.Sesja)
                .Where(s => s.StworzonePrzez == userId);

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SesjaCwiczenias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var userId = GetUserId();

            var sesjaCwiczenia = await _context.SesjeCwiczenia
                .Include(s => s.Cwiczenie)
                .Include(s => s.Sesja)
                .FirstOrDefaultAsync(m => m.Id == id && m.StworzonePrzez == userId);

            if (sesjaCwiczenia == null)
                return NotFound();

            return View(sesjaCwiczenia);
        }

        // GET: SesjaCwiczenias/Create
        public IActionResult Create()
        {
            var userId = GetUserId();

            ViewData["CwiczenieId"] = new SelectList(_context.Cwiczenie, "Id", "Name");
            ViewData["SesjaId"] = new SelectList(
                _context.Sesje.Where(s => s.StworzonePrzez == userId),
                "Id", "Start"
            );
            return View();
        }

        // POST: SesjaCwiczenias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SesjaCwiczeniaDTO model)
        {
            var userId = GetUserId();

            
            bool sesjaOk = await _context.Sesje
                .AnyAsync(s => s.Id == model.SesjaId && s.StworzonePrzez == userId);

            if (!sesjaOk)
            {
                ModelState.AddModelError("SesjaId", "Nie możesz dodać ćwiczenia do cudzej sesji.");
            }

            if (ModelState.IsValid)
            {
                var sesjaCwiczenia = new SesjaCwiczenia
                {
                    SesjaId = model.SesjaId,
                    CwiczenieId = model.CwiczenieId,
                    CiezarKg = model.CiezarKg,
                    Serie = model.Serie,
                    Powtorzenia = model.Powtorzenia,
                    StworzonePrzez = userId
                };

                _context.Add(sesjaCwiczenia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CwiczenieId"] = new SelectList(_context.Cwiczenie, "Id", "Name", model.CwiczenieId);
            ViewData["SesjaId"] = new SelectList(
                _context.Sesje.Where(s => s.StworzonePrzez == userId),
                "Id", "Start",
                model.SesjaId);

            
            var viewModel = new SesjaCwiczenia
            {
                SesjaId = model.SesjaId,
                CwiczenieId = model.CwiczenieId,
                CiezarKg = model.CiezarKg,
                Serie = model.Serie,
                Powtorzenia = model.Powtorzenia
            };

            return View(viewModel);
        }

        // GET: SesjaCwiczenias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var userId = GetUserId();

            var sesjaCwiczenia = await _context.SesjeCwiczenia
                .FirstOrDefaultAsync(s => s.Id == id && s.StworzonePrzez == userId);

            if (sesjaCwiczenia == null)
                return NotFound();

            ViewData["CwiczenieId"] = new SelectList(_context.Cwiczenie, "Id", "Name", sesjaCwiczenia.CwiczenieId);
            ViewData["SesjaId"] = new SelectList(
                _context.Sesje.Where(s => s.StworzonePrzez == userId),
                "Id", "Start",
                sesjaCwiczenia.SesjaId);

            return View(sesjaCwiczenia);
        }

        // POST: SesjaCwiczenias/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SesjaId,CwiczenieId,CiezarKg,Serie,Powtorzenia")] SesjaCwiczenia sesjaCwiczenia)
        {
            if (id != sesjaCwiczenia.Id)
                return NotFound();

            var userId = GetUserId();

            var istniejąca = await _context.SesjeCwiczenia
                .FirstOrDefaultAsync(s => s.Id == id && s.StworzonePrzez == userId);

            if (istniejąca == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    istniejąca.SesjaId = sesjaCwiczenia.SesjaId;
                    istniejąca.CwiczenieId = sesjaCwiczenia.CwiczenieId;
                    istniejąca.CiezarKg = sesjaCwiczenia.CiezarKg;
                    istniejąca.Serie = sesjaCwiczenia.Serie;
                    istniejąca.Powtorzenia = sesjaCwiczenia.Powtorzenia;

                    _context.Update(istniejąca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SesjaCwiczeniaExists(id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["CwiczenieId"] = new SelectList(_context.Cwiczenie, "Id", "Name", sesjaCwiczenia.CwiczenieId);
            ViewData["SesjaId"] = new SelectList(
                _context.Sesje.Where(s => s.StworzonePrzez == userId),
                "Id", "Start",
                sesjaCwiczenia.SesjaId);

            return View(sesjaCwiczenia);
        }

        // GET: SesjaCwiczenias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var userId = GetUserId();

            var sesjaCwiczenia = await _context.SesjeCwiczenia
                .Include(s => s.Cwiczenie)
                .Include(s => s.Sesja)
                .FirstOrDefaultAsync(m => m.Id == id && m.StworzonePrzez == userId);

            if (sesjaCwiczenia == null)
                return NotFound();

            return View(sesjaCwiczenia);
        }

        // POST: SesjaCwiczenias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userId = GetUserId();

            var sesjaCwiczenia = await _context.SesjeCwiczenia
                .FirstOrDefaultAsync(s => s.Id == id && s.StworzonePrzez == userId);

            if (sesjaCwiczenia != null)
            {
                _context.SesjeCwiczenia.Remove(sesjaCwiczenia);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool SesjaCwiczeniaExists(int id)
        {
            return _context.SesjeCwiczenia.Any(e => e.Id == id);
        }
    }
}
