using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GOT.Data;
using GOT.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace GOT.Controllers
{
    public class WycieczkaController : Controller
    {
        private readonly GotDbContext _context;

        public WycieczkaController(GotDbContext context)
        {
            _context = context;
        }

        // GET: Wycieczkas
        /// <summary>
        /// Wyświetlenie widoku do tworzenia wycieczki oraz czyszczenie sesji
        /// </summary>
        /// <param name="auto">
        /// Parametr mówiący czy została wybrana wycieczka automatyczna, czy też zwykła
        /// </param>
        /// <returns>widok wraz z listą łancuchów górskich</returns>
        public IActionResult Index(string? auto)
        {
            HttpContext.Session.Remove("nazwa");
            HttpContext.Session.Remove("lancuch");
            HttpContext.Session.Remove("isAuto");
            HttpContext.Session.Remove("points");
            HttpContext.Session.Remove("totalLength");

            if (auto == "auto")
            {
                HttpContext.Session.SetString("isAuto", "auto");
            }
            else
            {
                HttpContext.Session.SetString("isAuto", "NOTauto");
            }

            var lancuchy = _context.MountRanges.ToList();
            ViewData["lancuchy"] = new SelectList(lancuchy, "IdL", "Name");

            return View();
        }

        /// <summary>
        /// Wyświetlenie widoku ze wszystkimi punktami z wybranego wcześniej łanucha górskiego
        /// </summary>
        /// <param name="nazwaWycieczki">nazwa wycieczki podana przez użytkownika w poprzednim widoku</param>
        /// <param name="lancuchy">łańcuch górski wybrany przez użytkownika w poprzednim widoku</param>
        /// <returns>widok wraz ze wszystkimi punktami z łańcucha górskiego</returns>
        public async Task<IActionResult> Build(string? nazwaWycieczki, int? lancuchy)
        {

            if (nazwaWycieczki != null && lancuchy != null)
            {
                var points = _context.Points.Where(p => p.IdL == lancuchy);
                var mountRange = _context.MountRanges.FirstOrDefault(m => m.IdL == lancuchy);

                HttpContext.Session.SetString("nazwa", nazwaWycieczki);
                HttpContext.Session.SetString("lancuch", mountRange.Name);

                return View(await points.ToListAsync());
            }


            return View();
        }

        public class PassToListsToView
        {
            public IEnumerable<Punkt> collocatedPoints;
            public IEnumerable<Punkt> chosenPoints;
            public PassToListsToView() { }
        }


        /// <summary>
        /// Metoda obsługująca kolejne wybrane punkty do wycieczki
        /// </summary>
        /// <param name="id">Identyfikator wybranego punktu</param>
        /// <param name="indexToSkip">Index usuniętego punktu z listy wybranych już punktów</param>
        /// <returns>Odświeżony widok z kolejnymi punktami, do których można dojść oraz zaaktualizowana lista wybranych już punktów</returns>
        public IActionResult NextPoint(int? id, int? indexToSkip)
        {

            if (id != null)
            {
                var point = _context.Points.FirstOrDefault(p => p.IdP == id);

                var isAuto = HttpContext.Session.GetString("isAuto");

                List<Punkt> pointsList = new List<Punkt>();
                IQueryable<Punkt> collocatedPoints = null;

                byte[] arr;
                HttpContext.Session.TryGetValue("points", out arr);
                if (arr != null)
                {
                    pointsList = JsonConvert.DeserializeObject<List<Punkt>>(HttpContext.Session.GetString("points"));
                }

                if (isAuto != "auto" || (isAuto == "auto" && pointsList.Count == 0))
                    pointsList.Add(point);
                else
                {
                    var tracks = GetShortestRoute(pointsList[pointsList.Count - 1].IdP, id.Value);
                    if (tracks == null)
                    {
                        var error = "Brak połączenia do danego punktu!";
                        this.ModelState.AddModelError("NoTracks", error);

                        ViewData["chosenPointsNumber"] = 0;
                        var lancuch = HttpContext.Session.GetString("lancuch");
                        var mountId = _context.MountRanges.FirstOrDefault(m => m.Name == lancuch).IdL;

                        collocatedPoints = _context.Points.Where(p => p.IdL == mountId);
                        return View(new PassToListsToView { collocatedPoints = collocatedPoints, chosenPoints = pointsList });
                    }
                    else
                    {
                        foreach (var track in tracks)
                        {
                            pointsList.Add(track.PointEnd);
                            double totalLength = Convert.ToDouble(HttpContext.Session.GetString("totalLength"));
                            totalLength += track.Length;
                            HttpContext.Session.SetString("totalLength", totalLength.ToString());

                        }
                    }
                }

                HttpContext.Session.SetString("points", JsonConvert.SerializeObject(pointsList));

                if (isAuto == "auto")
                {

                    var lancuch = HttpContext.Session.GetString("lancuch");
                    var mountId = _context.MountRanges.FirstOrDefault(m => m.Name == lancuch).IdL;
                    collocatedPoints = _context.Points.Where(p => p.IdL == mountId);

                }
                else
                {
                    var points = _context.Tracks.Include(p => p.PointStart)
                            .Include(t => t.PointEnd)
                            .Where(t => t.PointStartId == id)
                            .Select(t => t.PointEndId).ToList();

                    collocatedPoints = _context.Points.Where(p => points.Contains(p.IdP));
                }



                ViewData["chosenPointsNumber"] = pointsList.Count();
                if (pointsList.Count <= 1)
                {
                    HttpContext.Session.SetString("totalLength", "0");
                }
                else if (isAuto != "auto")
                {

                    var penultimateChosen = pointsList[pointsList.Count - 2];

                    var length = _context.Tracks.FirstOrDefault(t => t.PointStart == penultimateChosen && t.PointEnd == point);

                    if (length != null)
                    {
                        double totalLength = Convert.ToDouble(HttpContext.Session.GetString("totalLength"));
                        totalLength += length.Length;

                        HttpContext.Session.SetString("totalLength", totalLength.ToString());
                    }

                }


                return View(new PassToListsToView { collocatedPoints = collocatedPoints, chosenPoints = pointsList });
            }

            if (indexToSkip != null)
            {

                if (indexToSkip == 0)
                {
                    var MountID = _context.MountRanges.FirstOrDefault(m => m.Name == HttpContext.Session.GetString("lancuch"));

                    HttpContext.Session.SetString("totalLength", "0");

                    RedirectToAction("Build", new { nazwa = HttpContext.Session.GetString("nazwa"), lancuch = MountID.IdL });
                }

                List<Punkt> pointsList = new List<Punkt>();

                byte[] arr;
                HttpContext.Session.TryGetValue("points", out arr);
                if (arr != null)
                {
                    pointsList = JsonConvert.DeserializeObject<List<Punkt>>(HttpContext.Session.GetString("points"));
                }

                if (indexToSkip != 0)
                {
                    var deletedPoints = pointsList.GetRange(indexToSkip.Value - 1, pointsList.Count - indexToSkip.Value + 1);
                    double deletedLength = 0;

                    for (int i = 1; i < deletedPoints.Count; i++)
                    {
                        var length = _context.Tracks.FirstOrDefault(t => t.PointStartId == deletedPoints[i - 1].IdP && t.PointEndId == deletedPoints[i].IdP).Length;
                        deletedLength += length;
                    }

                    HttpContext.Session.SetString("totalLength", (Convert.ToDouble(HttpContext.Session.GetString("totalLength")) - deletedLength).ToString());
                }

                pointsList = pointsList.Take(indexToSkip ?? 0).ToList();


                HttpContext.Session.SetString("points", JsonConvert.SerializeObject(pointsList));


                Punkt LastChosenPoint = null;
                List<Punkt> collocatedPoints = null;

                if (pointsList.Count > 0) LastChosenPoint = _context.Points.FirstOrDefault(p => p.IdP == pointsList[pointsList.Count - 1].IdP);
                if (LastChosenPoint != null && HttpContext.Session.GetString("isAuto") != "auto")
                {
                    var points = _context.Tracks.Include(p => p.PointStart)
                                  .Include(t => t.PointEnd)
                                  .Where(t => t.PointStartId == LastChosenPoint.IdP)
                                  .Select(t => t.PointEndId).ToList();

                    collocatedPoints = _context.Points.Where(p => points.Contains(p.IdP)).ToList();
                }
                else
                {
                    var MountID = _context.MountRanges.FirstOrDefault(m => m.Name == HttpContext.Session.GetString("lancuch"));

                    collocatedPoints = _context.Points.Where(p => p.IdL == MountID.IdL).ToList();
                }

                ViewData["chosenPointsNumber"] = pointsList.Count();

                return View(new PassToListsToView { collocatedPoints = collocatedPoints, chosenPoints = pointsList });
            }


            return View();
        }

        /// <summary>
        /// Potwierdzenie utworzenia wycieczki, wyczyszczenie danych sesyjnych
        /// </summary>
        /// <returns>Powrót do głównego widoku tworzenia wycieczki</returns>
        public IActionResult ConfirmTrip()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Usunięcie punktu z listy wybranych już punktów
        /// </summary>
        /// <param name="id">Index elementu do usunięcia</param>
        /// <returns>Przekierowanie do widoku, w którym zostanie usunięty punkt z listy wybrancyh punktów</returns>
        public IActionResult RemovePoint(int? id)
        {
            //string isAuto = HttpContext.Session.GetString("isAuto");

            return RedirectToAction("NextPoint", new { indexToSkip = id });
        }


        /// <summary>
        /// Metoda wyszukująca wszystkie możliwe trasy począwszy od punktu startowego
        /// </summary>
        /// <param name="StartId">Index punktu startowego</param>
        /// <returns>tablica ze wszystkimi dostępnymi ścieżkami z punktu o indeksie początkowym</returns>
        public (int, OdcinekTrasy)[] GetAvailableRoutes(int StartId)
        {
            List<OdcinekTrasy> tracks = _context.Tracks.Include(p => p.PointStart).Include(t => t.PointEnd).ToList();
            Func<int, IEnumerable<int>, int, (int, OdcinekTrasy)[]> build = null;

            build = (p, s, n) =>
            {
                return (from x in tracks
                        where x.PointStartId == p && s.All(t => t != x.PointEndId)
                        from y in new[] {
                                    (n, x)
                                }.Union(build(x.PointEndId, s.Append(x.PointStartId), n + 1))
                        select y).ToArray();
            };
            return build(StartId, new List<int>() { StartId }, 0);
        }

        /// <summary>
        /// Transformacja listy wszystkich tras do listy dwuwymiarowej
        /// </summary>
        /// <param name="routes">Lista wszystkich tras</param>
        /// <returns>Lista list z trasami</returns>
        public List<List<OdcinekTrasy>> MakeRoutesStartFromRoot((int, OdcinekTrasy)[] routes)
        {
            List<List<OdcinekTrasy>> transformed = new List<List<OdcinekTrasy>>();

            int root = 0;
            int prevLvl = 0;
            int idx = 0;

            foreach (var track in routes)
            {
                if (track.Item1 <= prevLvl)
                {
                    if (track.Item1 == 0)
                        root = idx;
                    List<OdcinekTrasy> route = new List<OdcinekTrasy>();
                    for (int i = root; i < (root + track.Item1); i++)
                        route.Add(routes[i].Item2);
                    route.Add(track.Item2);
                    transformed.Add(route);
                }
                else
                    transformed[transformed.Count - 1].Add(track.Item2);
                idx++;
                prevLvl = track.Item1;
            }
            return transformed;
        }


        /// <summary>
        /// Wyszukanie najkrótszej trasy mając podany punkt początkowy oraz końcowy
        /// </summary>
        /// <param name="StartId">Index punktu początkowego</param>
        /// <param name="endId">Index punktu końcowego</param>
        /// <returns>najkrótszą trasę z podanych punktów</returns>
        public List<OdcinekTrasy> GetShortestRoute(int StartId, int endId)
        {
            var routes = MakeRoutesStartFromRoot(GetAvailableRoutes(StartId));


            double minLength = int.MaxValue;
            double currLength = 0;
            int minIdx = -1;
            int currIdx = 0;

            foreach (var route in routes)
            {
                var endTrack = route.FindIndex(x => x.PointEndId == endId);
                if (endTrack != -1)
                {
                    if (endTrack < route.Count() - 1)
                        route.RemoveRange(endTrack + 1, route.Count() - endTrack - 1);
                    foreach (var track in route)
                    {
                        currLength += track.Length;
                    }
                    if (currLength < minLength)
                    {
                        minLength = currLength;
                        minIdx = currIdx;
                    }
                    currLength = 0;
                }
                currIdx++;
            }
            if (minIdx != -1)
                return routes[minIdx];
            else
                return null;
        }
    }
}
