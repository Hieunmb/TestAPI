using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TestAPI.Entities;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        
        private readonly TestApiContext _context;

        public OrderController(TestApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = _context.OrderTbls.ToList();
            return Ok(orders);
        }
        [Route("create")]
        [HttpPost]
        public IActionResult CreateOrder(OrderTbl order)
        {
            _context.OrderTbls.Add(order);
            _context.SaveChanges();
            return Ok(order);
        }

        [Route("update")]
        [HttpPut]
        public IActionResult UpdateOrder(EditOrder updatedOrder)
        {
            var existingOrder = _context.OrderTbls.FirstOrDefault(o => o.ItemCode == updatedOrder.Itemcode);
            if (existingOrder == null)
            {
                return NotFound();
            }

            existingOrder.OderDelivery = updatedOrder.OrderDelivery;
            existingOrder.OrderAddress = updatedOrder.OrderAddress;

            _context.SaveChanges();

            return NoContent();
        }
    }
 }
