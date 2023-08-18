using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Bootcamp_Assignment_I.Models;

namespace MVC_Bootcamp_Assignment_I.Controllers
{
    public class LandingPageController : Controller
    {
        private readonly MasterContext _context;

        public LandingPageController(MasterContext context)
        {
            _context = context;
        }

        // GET: LandingPage
        public async Task<IActionResult> Index()
        {
            var masterContext = _context.Employees.Include(e => e.ReportsToNavigation);
            return View(await masterContext.ToListAsync());
        }
    }
}
