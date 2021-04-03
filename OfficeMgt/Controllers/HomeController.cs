using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OfficeMgt.Data;
using OfficeMgt.Models;
using OfficeMgt.Models.Flg;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OfficeMgt.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        // test purpose for development mode get all list of certain things in the home page
        public async Task<IEnumerable<Mission>> Index()
        {
            #region MyRegion
            //return await (from m in _context.Missions
            //              join t in _context.MissionTypes on m.MissionTypeId equals t.MissionTypeId
            //              join p in _context.Phases on m.PhaseId equals p.PhaseId
            //              select new Mission
            //              {
            //                  Id = m.Id,
            //                  Name = m.Name,
            //                  Duration = m.Duration,
            //                  Aircraft = m.Aircraft,
            //                  Syllabus = m.Syllabus,
            //                  MissionTypeId = m.MissionTypeId,
            //                  PhaseId = m.PhaseId,
            //                  Type = m.Type,
            //                  Phase = m.Phase
            //              }).ToListAsync();
            #endregion


            return await _context.Missions
                                .Include(m => m.Type)
                                .Include(m => m.Phase).ToListAsync();

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
