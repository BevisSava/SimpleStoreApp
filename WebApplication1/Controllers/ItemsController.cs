using Microsoft.AspNetCore.Mvc;
using Assignment2.Models; 
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Assignment2.Controllers
{
    [Authorize]
    public class ItemsController : Controller
    {
        private readonly AppDbContext _context;
        public ItemsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var itemsList = _context.Items.ToList();
            return View(itemsList);
        }
    }
}
