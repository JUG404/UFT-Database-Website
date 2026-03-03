using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Finance.Data;
using Finance.Models;
 
namespace Finance.Controllers
{
    public class MerretsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MerretsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Merrets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Merret.ToListAsync());
        }


        // GET: Merrets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merret = await _context.Merret
                .FirstOrDefaultAsync(m => m.Id == id);
            if (merret == null)
            {
                return NotFound();
            }

            return View(merret);
        }

        // GET: Merrets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Merrets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Emer,Mbiemer,Shuma,Kodi")] Merret merret)
        {
            if (!ModelState.IsValid)
                return View(merret);

            var dergues = await _context.Dergon
                .FirstOrDefaultAsync(d => d.Kodi == merret.Kodi);

            if (dergues == null)
            {
                ViewBag.Mesazhi = "Kodi nuk përputhet me asnjë transfertë.";
                return View(merret);
            }

            if (merret.Shuma > dergues.Shuma)
            {
                ViewBag.Mesazhi = $"Shuma që po tërhiqet ({merret.Shuma}) është më e madhe se shuma e dërguar ({dergues.Shuma}).";
                return View(merret);
            }

            ViewBag.Mesazhi = $"Tërheqja nga llogaria e {dergues.Emer} {dergues.Mbiemer} u krye me sukses.";

            _context.Merret.Add(merret);
            await _context.SaveChangesAsync();

            return View(merret);
        }



        // GET: Merrets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merret = await _context.Merret.FindAsync(id);
            if (merret == null)
            {
                return NotFound();
            }
            return View(merret);
        }

        // POST: Merrets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Emer,Mbiemer,Shuma,Kodi")] Merret merret)
        {
            if (id != merret.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(merret);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MerretExists(merret.Id))
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
            return View(merret);
        }

        // GET: Merrets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merret = await _context.Merret
                .FirstOrDefaultAsync(m => m.Id == id);
            if (merret == null)
            {
                return NotFound();
            }

            return View(merret);
        }

        // POST: Merrets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var merret = await _context.Merret.FindAsync(id);
            if (merret != null)
            {
                _context.Merret.Remove(merret);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MerretExists(int id)
        {
            return _context.Merret.Any(e => e.Id == id);
        }
    }
}
