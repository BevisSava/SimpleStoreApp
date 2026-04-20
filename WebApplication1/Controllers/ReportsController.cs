using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment2.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Assignment2.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        private readonly AppDbContext _context;

        public ReportsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? searchAgentId)
        {
            ViewBag.Agents = new SelectList(_context.Agents, "AgentID", "AgentName");
            var query = _context.OrderDetails
                .Include(od => od.Item)
                .Include(od => od.Order)
                    .ThenInclude(o => o.Agent)
                .AsQueryable();
            if (searchAgentId.HasValue)
            {
                query = query.Where(od => od.Order.AgentID == searchAgentId.Value);
                ViewBag.CurrentAgentId = searchAgentId.Value;
            }
            return View(query.ToList());
        }
    }
}
