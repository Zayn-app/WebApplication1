using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class TicketsController : Controller
    {
        private readonly Context _context;

        public TicketsController(Context context)
        {

            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allTickets = await _context.Tickets.ToListAsync();
            return View(allTickets);
        }
    }
}
