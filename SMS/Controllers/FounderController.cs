using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SMS.Models;

namespace SMS.Controllers
{
    public class FounderController : Controller
    {
        private readonly ManagementSystemContext _context;

        public FounderController(ManagementSystemContext context)
        {
            _context = context;
        }

        // GET: Founder
        public async Task<IActionResult> Index()
        {
            return View(await _context.Founders.ToListAsync());
        }

        // GET: Founder/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var founder = await _context.Founders
                .FirstOrDefaultAsync(m => m.FounderId == id);
            if (founder == null)
            {
                return NotFound();
            }

            return View(founder);
        }

        // GET: Founder/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Founder/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FounderId,FounderName,FounterContact")] Founder founder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(founder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(founder);
        }

        // GET: Founder/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var founder = await _context.Founders.FindAsync(id);
            if (founder == null)
            {
                return NotFound();
            }
            return View(founder);
        }

        // POST: Founder/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FounderId,FounderName,FounterContact")] Founder founder)
        {
            if (id != founder.FounderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(founder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FounderExists(founder.FounderId))
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
            return View(founder);
        }

        // GET: Founder/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var founder = await _context.Founders
                .FirstOrDefaultAsync(m => m.FounderId == id);
            if (founder == null)
            {
                return NotFound();
            }

            return View(founder);
        }

        // POST: Founder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var founder = await _context.Founders.FindAsync(id);
            if (founder != null)
            {
                _context.Founders.Remove(founder);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FounderExists(string id)
        {
            return _context.Founders.Any(e => e.FounderId == id);
        }
    }
}
