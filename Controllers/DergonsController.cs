using Finance.Data;
using Finance.Data.Migrations;
using Finance.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Finance.Controllers
{

    public class DergonsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DergonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dergons
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var currentUser = User.Identity.Name;

                var userTransactions = await _context.Dergon
                    .Where(d => d.UserName == currentUser)
                    .ToListAsync();

                return View(userTransactions);
            }
            else
            {
                return View(null); 
            }
        }



        // GET: Dergons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dergon = await _context.Dergon
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dergon == null)
            {
                return NotFound();
            }

            return View(dergon);
        }

        // GET: Dergons/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }


        private int GjeneroKodiUnik()
        {
            int kod;
            do
            {
                kod = new Random().Next(100000, 999999);
            }
            while (_context.Dergon.Any(d => d.Kodi == kod));

            return kod;
        }

        // POST: Dergons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Dergon model)
        {
            if (ModelState.IsValid)
            {
                model.Kodi = GjeneroKodiUnik();
                model.UserName = User.Identity.Name;

                _context.Add(model);
                await _context.SaveChangesAsync();

                TempData["JustCreated"] = true; 
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        // GET: Dergons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dergon = await _context.Dergon.FindAsync(id);
            if (dergon == null)
            {
                return NotFound();
            }
            return View(dergon);
        }

        // POST: Dergons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Emer,Mbiemer,Datelindja,Shuma,Kodi")] Dergon dergon)
        {
            if (id != dergon.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dergon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DergonExists(dergon.ID))
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
            return View(dergon);
        }

        // GET: Dergons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dergon = await _context.Dergon
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dergon == null)
            {
                return NotFound();
            }

            return View(dergon);
        }


        // POST: Dergons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dergon = await _context.Dergon.FindAsync(id);
            if (dergon != null)
            {
                _context.Dergon.Remove(dergon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DergonExists(int id)
        {
            return _context.Dergon.Any(e => e.ID == id);
        }
    }
}
