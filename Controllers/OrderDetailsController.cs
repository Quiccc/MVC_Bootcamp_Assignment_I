using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Bootcamp_Assignment_I.Models;
using System.Linq;

namespace MVC_Bootcamp_Assignment_I.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly MasterContext _context;

        public OrderDetailsController(MasterContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? orderId)
        {
            var masterContext = _context.OrderDetails
                .Include(p => p.Product)
                .Where(q => q.OrderId == orderId);
            return View(await masterContext.ToListAsync());
        }
    }
}
