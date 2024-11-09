using Assignment_DMAWS.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Assignment_DMAWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DataContext _context;

        public OrderController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderTbl order)
        {
            _context.Orders.Add(order);
           await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOrderById), new { id = order.ItemCode }, order);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            
                var orders= await _context.Orders.ToListAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderTblUpdateModel updatedOrder)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            order.OrderDelivery = updatedOrder.OrderDelivery;
            order.OrderAddress = updatedOrder.OrderAddress;

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order =  await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
          await  _context.SaveChangesAsync();
            return Ok();
        }
    }
}
