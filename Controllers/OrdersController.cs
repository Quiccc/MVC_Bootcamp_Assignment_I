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
    public class OrdersController : Controller
    {
        private readonly MasterContext _context;

        public OrdersController(MasterContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> EmployeeOrders(int? employeeId)
        {
            var masterContext = _context.Orders
                .Include(o => o.Customer)
                .Where(o => o.EmployeeId == employeeId);
            return View(await masterContext.ToListAsync());
        }
    }
}
