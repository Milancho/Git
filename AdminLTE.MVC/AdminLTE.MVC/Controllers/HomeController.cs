using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AdminLTE.MVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdminLTE.MVC.Models;
using AdminLTE.MVC.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace AdminLTE.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [AllowAnonymous]
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
