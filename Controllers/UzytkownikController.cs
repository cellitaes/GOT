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
    public class UzytkownikController : Controller
    {
        private readonly GotDbContext _context;

        public UzytkownikController(GotDbContext context)
        {
            _context = context;
        }

        // GET: Uzytkownik
        /// <summary>
        /// Wyświetlenie głównego widoku ze wszystkimi użytkownikami
        /// </summary>
        /// <returns>Widok z wszystkimi dostępnymi użytkownikami</returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tourists.ToListAsync());
        }

        // GET: Uzytkownik/Details/5
        /// <summary>
        /// Wyszukanie turysty o podanym identyfikatorze i wyświetlenie szczegółów
        /// </summary>
        /// <param name="id">Identyfikator użytkownika</param>
        /// <returns>Widok z szczegółami na temat wybranego użytkownika</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turysta = await _context.Tourists
                .FirstOrDefaultAsync(m => m.IdT == id);
            if (turysta == null)
            {
                return NotFound();
            }

            return View(turysta);
        }

        // GET: Uzytkownik/Create
        /// <summary>
        /// Wyświetlenie widoku do tworzenia użytkownika
        /// </summary>
        /// <returns>Widok tworzenia użytkownika</returns>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Uzytkownik/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Metoda tworząca nowego użytkownika i zapisująca go w bazie
        /// </summary>
        /// <param name="turysta">Model turysty z przesłanymi danymi z formularza</param>
        /// <returns>w przypadku pozytywnej walidacji przekierowanie na główną stronę, w przeciwnym razie pozostanie w widoku wraz z wprowadzonymi wcześniej danymi</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdT,Login,Password,Name,Surname,PostCode,City,Street,AppartNr,FlatNr")] Turysta turysta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turysta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(turysta);
        }

        // GET: Uzytkownik/Edit/5
        /// <summary>
        /// Eycja użytkownika o podanym identyfikatorze 
        /// </summary>
        /// <param name="id">Identyfikator użytkownika</param>
        /// <returns>Widok z danymi wyszukanego turysty o podanym identyfikatorze</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leader = _context.Leaders.FirstOrDefault(l => l.IdT == id);
            if (leader != null)
            {
                ViewData["isLeader"] = true;
                var permisionss = _context.Permissions.Where(p => p.NrLegitymacji == leader.NrLegitymacji);
                var mountRanges = string.Join(",", _context.MountRanges.Where(m => permisionss.Any(p => p.IdL == m.IdL)).Select(m => m.Name));
                ViewData["selectedPermissions"] = mountRanges;
                ViewData["IdNumber"] = leader.NrLegitymacji;
            }
            else
            {
                ViewData["isLeader"] = false;
            }

            var turysta = await _context.Tourists.FindAsync(id);
            if (turysta == null)
            {
                return NotFound();
            }
            return View(turysta);
        }

        // POST: Uzytkownik/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edycja użytkownika, zmiana uprawnień i nadanie na określone łańcuchy górskie
        /// </summary>
        /// <param name="id">Identyfikator modyfikowanego użytkownika</param>
        /// <param name="turysta">Model turysty z przesłanymi danymi z formularza</param>
        /// <param name="mountRange">Łańcuch górski</param>
        /// <param name="Uprawnienia">Nadanie uprawnienia użytkownikowi</param>
        /// <returns>w przypadku pozytywnej walidacji przekierowanie na główny widok z listą wszystkich użytkowników, w przeciwnym 
        ///         powrót do tego sameog widoku wraz z podanymi wcześniej danymi
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdT,Login,Password,Name,Surname,PostCode,City,Street,AppartNr,FlatNr")] Turysta turysta,
            string[] mountRange, string Uprawnienia)
        {
            if (id != turysta.IdT)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turysta);

                    if (Uprawnienia == "Przodownik")
                    {
                        var leader = _context.Leaders.FirstOrDefault(l => l.IdT == id);

                        if (leader == null)
                        {
                            Przodownik newLeader = new Przodownik() { IdT = id };
                            _context.Add(newLeader);
                            await _context.SaveChangesAsync();
                            var newLeaderId = _context.Leaders.FirstOrDefault(l => l.IdT == id);

                            var chosenMountRanges = _context.MountRanges
                                                    .Where(m => mountRange.Contains(m.Name))
                                                    .Select(m => m.IdL);

                            foreach (int element in chosenMountRanges)
                            {
                                Uprawnienia perm = new Uprawnienia() { NrLegitymacji = newLeaderId.NrLegitymacji, IdL = element };
                                _context.Add(perm);
                            }
                        }

                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurystaExists(turysta.IdT))
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
            return View(turysta);
        }

        // GET: Uzytkownik/Delete/5
        /// <summary>
        /// Usunięcie użytkownika o podanym identyfikatorze
        /// </summary>
        /// <param name="id">Indetyfikator użytkownika</param>
        /// <returns>Widok z danymi użytkwonika do usunięcia</returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turysta = await _context.Tourists
                .FirstOrDefaultAsync(m => m.IdT == id);
            if (turysta == null)
            {
                return NotFound();
            }

            return View(turysta);
        }

        // POST: Uzytkownik/Delete/5
        /// <summary>
        /// Usunięcie użytkownika o podanym identyfikatorze
        /// </summary>
        /// <param name="id">Identyfikator usuwanego użytkownika</param>
        /// <returns>Przekierowanie na stronę główną z listą wszystkich użytkowników</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turysta = await _context.Tourists.FindAsync(id);
            _context.Tourists.Remove(turysta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurystaExists(int id)
        {
            return _context.Tourists.Any(e => e.IdT == id);
        }
    }
}
