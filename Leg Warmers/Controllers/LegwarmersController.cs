using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Leg_Warmers.Data;
using Leg_Warmers.Models;

namespace Leg_Warmers.Controllers
{
    public class LegwarmersController : Controller
    {
        private readonly MvcLegWarmersContext _context;

        public LegwarmersController(MvcLegWarmersContext context)
        {
            _context = context;
        }

        // GET: Legwarmers
        public async Task<IActionResult> Index()
        {
            return View(await _context.LegWarmers.ToListAsync());
        }

        // GET: Legwarmers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var legwarmers = await _context.LegWarmers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (legwarmers == null)
            {
                return NotFound();
            }

            return View(legwarmers);
        }

        // GET: Legwarmers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Legwarmers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Colour,Height,Design,Brand")] Legwarmers legwarmers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(legwarmers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(legwarmers);
        }

        // GET: Legwarmers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var legwarmers = await _context.LegWarmers.FindAsync(id);
            if (legwarmers == null)
            {
                return NotFound();
            }
            return View(legwarmers);
        }

        // POST: Legwarmers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Colour,Height,Design,Brand")] Legwarmers legwarmers)
        {
            if (id != legwarmers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(legwarmers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LegwarmersExists(legwarmers.Id))
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
            return View(legwarmers);
        }

        // GET: Legwarmers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var legwarmers = await _context.LegWarmers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (legwarmers == null)
            {
                return NotFound();
            }

            return View(legwarmers);
        }

        // POST: Legwarmers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var legwarmers = await _context.LegWarmers.FindAsync(id);
            _context.LegWarmers.Remove(legwarmers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LegwarmersExists(int id)
        {
            return _context.LegWarmers.Any(e => e.Id == id);
        }
    }
}
