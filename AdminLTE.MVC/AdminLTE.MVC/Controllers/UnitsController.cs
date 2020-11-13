using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdminLTE.MVC.Data;
using AdminLTE.MVC.Models.School;
using Microsoft.AspNetCore.Authorization;
using AdminLTE.MVC.ViewModel;

namespace AdminLTE.MVC.Controllers
{
    public class UnitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UnitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Units
        public async Task<IActionResult> Index()
        {
            return View(await _context.Unit.ToListAsync());
        }

        // GET: Units/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Report(int? id, string source)
        {
            if (id == null)
            {
                return NotFound();
            }

            var units = new List<Unit>();

            if (source == "course")
            {
                units = await _context.Unit.Where(m => m.Course.Id == id).ToListAsync();
            }
            if (source == "exercise")
            {
                var unitId = id;
                var unit = await _context.Unit.Include(x => x.Course).FirstOrDefaultAsync(x => x.Id == unitId);
                var course = await _context.Course.FirstOrDefaultAsync(x => x.Id == unit.Course.Id);
                units = await _context.Unit.Where(m => m.Course.Id == course.Id).ToListAsync();
            }

            return View(units);
        }

        // GET: Units/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = await _context.Unit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unit == null)
            {
                return NotFound();
            }

            return View(unit);
        }

        // GET: Units/Create
        public async Task< IActionResult> Create()
        {
            var item = new UnitViewModel();
            item.Courses = await _context.Course.Select(n => new SelectListItem
            {
                Value = Convert.ToString(n.Id),
                Text = n.Name
            }).ToListAsync();

            return View(item);
        }

        // POST: Units/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CourseId")] UnitViewModel unit)
        {
            if (ModelState.IsValid)
            {
                var newUnit = new Unit()
                {
                    Name = unit.Name,
                    Description = unit.Description,
                    CourseId = unit.CourseId
                };
                _context.Add(newUnit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unit);
        }

        // GET: Units/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = await _context.Unit.FindAsync(id);
            if (unit == null)
            {
                return NotFound();
            }
            return View(unit);
        }

        // POST: Units/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Unit unit)
        {
            if (id != unit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitExists(unit.Id))
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
            return View(unit);
        }

        // GET: Units/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = await _context.Unit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (unit == null)
            {
                return NotFound();
            }

            return View(unit);
        }

        // POST: Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unit = await _context.Unit.FindAsync(id);
            _context.Unit.Remove(unit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnitExists(int id)
        {
            return _context.Unit.Any(e => e.Id == id);
        }
    }
}
