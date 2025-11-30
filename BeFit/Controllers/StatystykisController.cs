using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BeFit.Data;
using BeFit.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeFit.Controllers
{
    [Authorize]
    public class StatystykisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StatystykisController(ApplicationDbContext context)
        {
            _context = context;
        }

        private string GetUserId()
            => User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;

        public async Task<IActionResult> Index()
        {
            var userId = GetUserId();
            DateTime fromDate = DateTime.Now.AddDays(-28);

            // 1. Pobieramy tylko treningi zalogowanego użytkownika z ostatnich 28 dni
            var query = _context.SesjeCwiczenia
                .Include(e => e.Sesja)
                .Include(e => e.Cwiczenie)
                .Where(e => e.Sesja.Start >= fromDate)
                .Where(e => e.StworzonePrzez == userId);

            // 2. Pobieramy dane z bazy
            var sesje = await query.ToListAsync();

            // 3. Grupujemy w pamięci po nazwie ćwiczenia i liczymy statystyki
            var stats = sesje
                .GroupBy(e => e.Cwiczenie.Name)
                .Select(g => new Statystyki
                {
                    NazwaCwiczenia = g.Key,
                    Liczba = g.Count(),
                    LacznePowtorzenia = g.Sum(x => x.Serie * x.Powtorzenia),
                    SredniCiezarKg = g.Average(x => x.CiezarKg),
                    MaxCiezarKg = g.Max(x => x.CiezarKg)
                })
                .ToList();

            return View(stats);
        }
    }
}