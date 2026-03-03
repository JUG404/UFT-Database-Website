using Finance.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Finance.Controllers
{
    public class TransaksioneController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransaksioneController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult ShowSearchForm()
        {
            return View();
        }

        // POST: Show the results
        public async Task<IActionResult> ShowSearchResults(string search)
        {
            var results = await _context.Dergon
                .Where(d =>
                    d.Emer.Contains(search) ||
                    d.Mbiemer.Contains(search) ||
                    d.Kodi.ToString().Contains(search) ||
                    d.Shuma.ToString().Contains(search))
                .ToListAsync();

            return View(results);
        }

        public async Task<IActionResult> ShowSearchTerheqje(string search)
        {
            var results = await _context.Merret
                .Where(d =>
                    d.Emer.Contains(search) ||
                    d.Mbiemer.Contains(search) ||
                    d.Kodi.ToString().Contains(search) ||
                    d.Shuma.ToString().Contains(search))
                .ToListAsync();

            return View(results);
        }
    }
}
