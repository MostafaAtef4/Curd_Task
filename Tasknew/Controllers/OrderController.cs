using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasknew.Models;
using Tasknew.Services;

namespace Tasknew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController( IOrderService orderService )
        {
            _orderService = orderService;
        }

        [HttpPost(),Route("CreateOrder")]

        public async Task<IActionResult> CreateOrder(OrderDto order)
        {
            
                return Ok(await _orderService.CreateOrder(order));

            
        }

        [HttpGet(), Route("GetOrders")]

        public async Task<ActionResult> GetOrders()
        {
            return Ok(await _orderService.GetOrders());
        }

        [HttpGet(), Route("GetOrderById " +"/{id}")]

        public async Task<ActionResult> GetOrderById(int id)
        {
            return Ok(await _orderService.GetOrderById(id));
        }

        [HttpDelete(),Route("DeleteOrder"+"/{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            return Ok(await _orderService.DeleteOrder(id));

        }
        [HttpPut(), Route("UpdateOrder" + "/{id}")]

      public async   Task<ActionResult> UpdateOrder(int id, OrderDto order)
        {
            return Ok(await _orderService.UpdateOrder(id, order));
        }


    }
}
