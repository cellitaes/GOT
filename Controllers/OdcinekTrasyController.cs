using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GOT.Data;
using GOT.Models;
using System.Globalization;

namespace GOT.Controllers
{
    public class OdcinekTrasyController : Controller
    {
        private readonly GotDbContext _context;

        public OdcinekTrasyController(GotDbContext context)
        {
            _context = context;
        }

        // GET: OdcinekTrasies
        public async Task<IActionResult> Index()
        {
            var gotDbContext = _context.Tracks.Include(o => o.PointEnd).Include(o => o.PointStart);
            return View(await gotDbContext.ToListAsync());
        }

        // GET: OdcinekTrasies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odcinekTrasy = await _context.Tracks
                .Include(o => o.PointEnd)
                .Include(o => o.PointStart)
                .FirstOrDefaultAsync(m => m.IdO == id);
            if (odcinekTrasy == null)
            {
                return NotFound();
            }

            return View(odcinekTrasy);
        }

        // GET: OdcinekTrasies/Create
        public IActionResult Create()
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            ViewData["PointId"] = new SelectList(_context.Points, "IdP", "Name");
            ViewData["Trails"] = new SelectList(new List<string>() { "Bez znaku", "Czerwony", "Żółty", "Zielony", "Niebieski", "Czarny" });
            return View();
        }

        // POST: OdcinekTrasies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdO,Trail,Length,HeightDiff,Points,PointStartId,PointEndId")] OdcinekTrasy odcinekTrasy,
                int reversePoints, bool twoWay = false)
        {
            if (ModelState.IsValid)
            {
                var duplicates = _context.Tracks.Where(x => x.Trail == odcinekTrasy.Trail && x.PointStartId == odcinekTrasy.PointStartId && x.PointEndId == odcinekTrasy.PointEndId);
                if (duplicates.Any())
                {
                    var error = "Taki odcinek już znajduje się w bazie!";
                    this.ModelState.AddModelError("Duplicate", error);
                    ViewData["Trails"] = new SelectList(new List<string>() { "Bez znaku", "Czerwony", "Żółty", "Zielony", "Niebieski", "Czarny" });
                    ViewData["PointId"] = new SelectList(_context.Points, "IdP", "Name");
                    return View(odcinekTrasy);
                }

                var p1 = _context.Points.Find(odcinekTrasy.PointStartId);
                var p2 = _context.Points.Find(odcinekTrasy.PointEndId);

                if(p1.IdP == p2.IdP)
                {
                    var error = "Nie można wybrać dwóch takich samych punktów!";
                    this.ModelState.AddModelError("PointEndId", error);
                    ViewData["Trails"] = new SelectList(new List<string>() { "Bez znaku", "Czerwony", "Żółty", "Zielony", "Niebieski", "Czarny" });
                    ViewData["PointId"] = new SelectList(_context.Points, "IdP", "Name");
                    return View(odcinekTrasy);
                }

                if(p1.IdL != p2.IdL)
                {
                    var error = "Punkty muszą należeć do tego samego łańcucha górskiego!";
                    this.ModelState.AddModelError("PointEndId", error);
                    ViewData["Trails"] = new SelectList(new List<string>() { "Bez znaku", "Czerwony", "Żółty", "Zielony", "Niebieski", "Czarny" });
                    ViewData["PointId"] = new SelectList(_context.Points, "IdP", "Name");
                    return View(odcinekTrasy);
                }

                _context.Add(odcinekTrasy);
                SpisTrasPunktowanych spis = new SpisTrasPunktowanych()
                {
                    IdO = odcinekTrasy.IdO,
                    ValidFrom = DateTime.Now,
                    Track = odcinekTrasy
                };
                _context.Add(spis);
                if (twoWay)
                {
                    OdcinekTrasy reverse = new OdcinekTrasy()
                    {
                        HeightDiff = odcinekTrasy.HeightDiff,
                        Trail = odcinekTrasy.Trail,
                        Length = odcinekTrasy.Length,
                        Points = reversePoints,
                        PointStartId = odcinekTrasy.PointEndId,
                        PointEndId = odcinekTrasy.PointStartId
                    };
                    _context.Add(reverse);

                    SpisTrasPunktowanych spisReverse = new SpisTrasPunktowanych()
                    {
                        IdO = reverse.IdO,
                        ValidFrom = DateTime.Now,
                        Track = reverse
                    };
                    _context.Add(spisReverse);
                }

                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(SpisTrasPunktowanychController.Index), "SpisTrasPunktowanych");
            }
            ViewData["Trails"] = new SelectList(new List<string>() { "Bez znaku", "Czerwony", "Żółty", "Zielony", "Niebieski", "Czarny" });
            ViewData["PointId"] = new SelectList(_context.Points, "IdP", "Name");
            return View(odcinekTrasy);
        }

        // GET: OdcinekTrasies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odcinekTrasy = await _context.Tracks.FindAsync(id);
            if (odcinekTrasy == null)
            {
                return NotFound();
            }
            ViewData["PointEndId"] = new SelectList(_context.Points, "IdP", "Name", odcinekTrasy.PointEndId);
            ViewData["PointStartId"] = new SelectList(_context.Points, "IdP", "Name", odcinekTrasy.PointStartId);
            return View(odcinekTrasy);
        }

        // POST: OdcinekTrasies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdO,Trail,Length,HeightDiff,Points,PointStartId,PointEndId")] OdcinekTrasy odcinekTrasy)
        {
            if (id != odcinekTrasy.IdO)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(odcinekTrasy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OdcinekTrasyExists(odcinekTrasy.IdO))
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
            ViewData["PointEndId"] = new SelectList(_context.Points, "IdP", "Name", odcinekTrasy.PointEndId);
            ViewData["PointStartId"] = new SelectList(_context.Points, "IdP", "Name", odcinekTrasy.PointStartId);
            return View(odcinekTrasy);
        }

        // GET: OdcinekTrasies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odcinekTrasy = await _context.Tracks
                .Include(o => o.PointEnd)
                .Include(o => o.PointStart)
                .FirstOrDefaultAsync(m => m.IdO == id);
            if (odcinekTrasy == null)
            {
                return NotFound();
            }

            return View(odcinekTrasy);
        }

        // POST: OdcinekTrasies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var odcinekTrasy = await _context.Tracks.FindAsync(id);
            _context.Tracks.Remove(odcinekTrasy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OdcinekTrasyExists(int id)
        {
            return _context.Tracks.Any(e => e.IdO == id);
        }
    }
}
