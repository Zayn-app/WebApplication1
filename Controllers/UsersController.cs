using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class UsersController : Controller
    {
        private readonly Context _context;

        public UsersController (Context context)
        {

            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allUsers = await _context.Users.ToListAsync();
            return View(allUsers);
        }
    }
}
