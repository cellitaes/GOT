using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GOT.Data;
using GOT.Models;

namespace GOT.Controllers
{
    public class SpisTrasPunktowanychController : Controller
    {
        private readonly GotDbContext _context;

        public SpisTrasPunktowanychController(GotDbContext context)
        {
            _context = context;
        }

        // GET: SpisTrasPunktowanyches
        public async Task<IActionResult> Index()
        {
            var gotDbContext = _context.ScoredTracks.Include(s => s.Track.PointEnd).Include(s => s.Track.PointStart);
            return View(await gotDbContext.ToListAsync());
        }

        // GET: SpisTrasPunktowanyches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spisTrasPunktowanych = await _context.ScoredTracks
                .Include(s => s.Track)
                .ThenInclude(s => s.PointStart)
                .Include(s => s.Track.PointEnd)
                .FirstOrDefaultAsync(m => m.IdS == id);
            if (spisTrasPunktowanych == null)
            {
                return NotFound();
            }

            return View(spisTrasPunktowanych);
        }

        // GET: SpisTrasPunktowanyches/Create
        public IActionResult Create()
        {
            ViewData["IdO"] = new SelectList(_context.Tracks, "IdO", "Trail");
            return View();
        }

        // POST: SpisTrasPunktowanyches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdS,ValidFrom,IdO")] SpisTrasPunktowanych spisTrasPunktowanych)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spisTrasPunktowanych);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdO"] = new SelectList(_context.Tracks, "IdO", "Trail", spisTrasPunktowanych.IdO);
            return View(spisTrasPunktowanych);
        }

        // GET: SpisTrasPunktowanyches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spisTrasPunktowanych = await _context.ScoredTracks.FindAsync(id);
            if (spisTrasPunktowanych == null)
            {
                return NotFound();
            }
            ViewData["IdO"] = new SelectList(_context.Tracks, "IdO", "Trail", spisTrasPunktowanych.IdO);
            return View(spisTrasPunktowanych);
        }

        // POST: SpisTrasPunktowanyches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdS,ValidFrom,IdO")] SpisTrasPunktowanych spisTrasPunktowanych)
        {
            if (id != spisTrasPunktowanych.IdS)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spisTrasPunktowanych);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpisTrasPunktowanychExists(spisTrasPunktowanych.IdS))
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
            ViewData["IdO"] = new SelectList(_context.Tracks, "IdO", "Trail", spisTrasPunktowanych.IdO);
            return View(spisTrasPunktowanych);
        }

        // GET: SpisTrasPunktowanyches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spisTrasPunktowanych = await _context.ScoredTracks
                .Include(s => s.Track)
                .FirstOrDefaultAsync(m => m.IdS == id);
            if (spisTrasPunktowanych == null)
            {
                return NotFound();
            }

            return View(spisTrasPunktowanych);
        }

        // POST: SpisTrasPunktowanyches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spisTrasPunktowanych = await _context.ScoredTracks.FindAsync(id);
            _context.ScoredTracks.Remove(spisTrasPunktowanych);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpisTrasPunktowanychExists(int id)
        {
            return _context.ScoredTracks.Any(e => e.IdS == id);
        }
    }
}
