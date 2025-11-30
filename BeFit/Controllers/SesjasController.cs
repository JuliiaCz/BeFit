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
    public class SesjasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SesjasController(ApplicationDbContext context)
        {
            _context = context;
        }

        private string GetUserId()
            => User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;

        // GET: Sesjas
        public async Task<IActionResult> Index()
        {
            var userId = GetUserId();
            var sesje = await _context.Sesje
                .Where(s => s.StworzonePrzez == userId)
                .ToListAsync();

            return View(sesje);
        }

        // GET: Sesjas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var userId = GetUserId();

            var sesja = await _context.Sesje
                .FirstOrDefaultAsync(m => m.Id == id && m.StworzonePrzez == userId);

            if (sesja == null) return NotFound();

            return View(sesja);
        }

        // GET: Sesjas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sesjas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SesjaDTO model)
        {
            if (ModelState.IsValid)
            {
                var sesja = new Sesja
                {
                    Start = model.Start,
                    End = model.End,
                    StworzonePrzez = GetUserId()
                };

                _context.Add(sesja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            
            var viewModel = new Sesja
            {
                Start = model.Start,
                End = model.End
            };

            return View(viewModel);
        }

        // GET: Sesjas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var userId = GetUserId();

            var sesja = await _context.Sesje
                .FirstOrDefaultAsync(s => s.Id == id && s.StworzonePrzez == userId);

            if (sesja == null) return NotFound();

            return View(sesja);
        }

        // POST: Sesjas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Start,End")] Sesja sesja)
        {
            if (id != sesja.Id) return NotFound();

            var userId = GetUserId();

            var istniejącaSesja = await _context.Sesje
                .FirstOrDefaultAsync(s => s.Id == id && s.StworzonePrzez == userId);

            if (istniejącaSesja == null) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    istniejącaSesja.Start = sesja.Start;
                    istniejącaSesja.End = sesja.End;

                    _context.Update(istniejącaSesja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SesjaExists(id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sesja);
        }

        // GET: Sesjas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var userId = GetUserId();

            var sesja = await _context.Sesje
                .FirstOrDefaultAsync(m => m.Id == id && m.StworzonePrzez == userId);

            if (sesja == null) return NotFound();

            return View(sesja);
        }

        // POST: Sesjas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userId = GetUserId();

            var sesja = await _context.Sesje
                .FirstOrDefaultAsync(s => s.Id == id && s.StworzonePrzez == userId);

            if (sesja != null)
            {
                _context.Sesje.Remove(sesja);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool SesjaExists(int id)
        {
            return _context.Sesje.Any(e => e.Id == id);
        }
    }
}
