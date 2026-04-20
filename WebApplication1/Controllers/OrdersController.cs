using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Assignment2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Assignment2.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var orders = _context.Orders.ToList();
            return View(orders);
        }


        public IActionResult Create()
        {
            ViewBag.Agents = new SelectList(_context.Agents, "AgentID", "AgentName");
            ViewBag.Items = _context.Items.ToList();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int AgentID, DateTime OrderDate, int[] ItemIDs, int[] Quantities)
        {
            var newOrder = new Order
            {
                AgentID = AgentID,
                OrderDate = OrderDate
            };

            _context.Orders.Add(newOrder);
            _context.SaveChanges();

            for (int i = 0; i < ItemIDs.Length; i++)
            {
                if (Quantities[i] > 0)
                {
                    var item = _context.Items.Find(ItemIDs[i]);

                    var detail = new OrderDetail
                    {
                        OrderID = newOrder.OrderID, 
                        ItemID = ItemIDs[i],
                        Quantity = Quantities[i],
                        UnitAmount = item.Price
                    };

                    _context.OrderDetails.Add(detail);
                }
            }
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = newOrder.OrderID });
        }
        public IActionResult Details(int id)
        {
            var order = _context.Orders
                .Include(o => o.Agent) 
                .Include(o => o.OrderDetails) 
                    .ThenInclude(od => od.Item) 
                .FirstOrDefault(o => o.OrderID == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
    }
}