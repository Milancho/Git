using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdminLTE.MVC.Data;
using AdminLTE.MVC.Models.School;
using AdminLTE.MVC.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using DinkToPdf;
using GeneratingPDF.Utility;
using DinkToPdf.Contracts;
using System.IO;
using System.Text;

namespace AdminLTE.MVC.Controllers
{
    public class ExercisesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConverter _converter;

        public ExercisesController(ApplicationDbContext context, IConverter converter)
        {
            _context = context;
            _converter = converter;
        }

        // GET: Exercises
        public async Task<IActionResult> Index()
        {
            var data = await _context.Exercise
                .OrderBy(x => x.Unit.Course.Id).ThenBy(x => x.Unit.Id).ThenBy(x => x.Id)
                .Select(item => new ExerciseViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    UnitId = item.Unit.Id,
                    Unit = item.Unit.Name,
                    CourseId = item.Unit.Course.Id,
                    Course = item.Unit.Course.Name
                }).ToListAsync();

            return View(data);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Report(int id)
        {
            var data = new ExerciseReportViewModel
            {
                ExerciseList = await _context.Exercise.Where(x => x.Unit.Id == id).ToListAsync(),
                UnitId = id
            };

            return View(data);
        }

        // GET: Exercises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _context.Exercise
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exercise == null)
            {
                return NotFound();
            }

            return View(exercise);
        }

        // GET: Exercises/Create
        public async Task<IActionResult> Create()
        {
            var item = new ExerciseViewModel();
            item.Units = await _context.Unit.Include(x => x.Course).Select(n => new SelectListItem()
            {
                Value = Convert.ToString(n.Id),
                Text = $"{n.Course.Name} - {n.Name}"
            }).ToListAsync();

            return View(item);
        }

        // POST: Exercises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,UnitId")] Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exercise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exercise);
        }

        // GET: Exercises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _context.Exercise.FindAsync(id);
            if (exercise == null)
            {
                return NotFound();
            }

            var item = new ExerciseViewModel();
            item.Id = exercise.Id;
            item.Name = exercise.Name;
            item.UnitId = exercise.UnitId;
            item.Units = await _context.Unit.Include(x => x.Course).Select(n => new SelectListItem()
            {
                Value = Convert.ToString(n.Id),
                Text = $"{n.Course.Name} - {n.Name}"
            }).ToListAsync();

            return View(item);

        }

        // POST: Exercises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,UnitId")] Exercise exercise)
        {
            if (id != exercise.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exercise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExerciseExists(exercise.Id))
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
            return View(exercise);
        }

        // GET: Exercises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _context.Exercise
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exercise == null)
            {
                return NotFound();
            }

            return View(exercise);
        }

        // POST: Exercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exercise = await _context.Exercise.FindAsync(id);
            _context.Exercise.Remove(exercise);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExerciseExists(int id)
        {
            return _context.Exercise.Any(e => e.Id == id);
        }

        /// <summary>
        /// Print exercises by Unit
        /// </summary>
        /// <param name="id">UnitId</param>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<IActionResult> CreatePDF(int id)
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                //Out = @"C:\Aspekt\tmp\Employee_Report.pdf"
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = await GetHTMLString(id),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            //_converter.Convert(pdf);
            var file = _converter.Convert(pdf);
            return File(file, "application/pdf");

        }

        public async Task<string> GetHTMLString(int unitId)
        {
            var unit = await _context.Unit
    .Include(x => x.ExerciseList)
    .Include(x => x.Course)
    .FirstOrDefaultAsync(x => x.Id == unitId);

            var sb = new StringBuilder();
            sb.AppendFormat(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>{0}</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Вежби</th>                                        
                                    </tr>", unit.Course.Name + " - " + unit.Name);

            foreach (var exercise in unit.ExerciseList)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>                                    
                                  </tr>", exercise.Name);
            }

            sb.Append(@"
                                </table>
                            </body>
                        </html>");

            return sb.ToString();
        }

    }
}
