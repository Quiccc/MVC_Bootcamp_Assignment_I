using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using MVC_Bootcamp_Assignment_I.Models;

namespace MVC_Bootcamp_Assignment_I.Controllers
{
    public class EmployeeDetailsController : Controller
    {
        private readonly MasterContext _context;

        public EmployeeDetailsController(MasterContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? employeeId)
        {
            var masterContext = _context.Employees
            .Include(e => e.ReportsToNavigation)
            .Where(e => e.EmployeeId == employeeId);
            return View(await masterContext.ToListAsync());
        }

        public ActionResult Edit(int? employeeId)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string NewNumber, int employeeId)
        {
            _context.Employees.First(e => e.EmployeeId == employeeId).HomePhone = NewNumber;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { employeeId });
        }
    }
}
