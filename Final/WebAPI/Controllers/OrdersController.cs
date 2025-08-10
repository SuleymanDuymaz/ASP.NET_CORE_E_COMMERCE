using Business.Abstract;
using Entities.RequestParametres;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("getall")]
        public IActionResult GetList([FromQuery] Pagination pagination)
        {
            var result = _orderService.GetList();
            var totalCount = _orderService.GetList().Data.Count();
            var orders = _orderService.GetList().Data.Skip(pagination.Page * pagination.Size).Take(pagination.Size)
                .Select(p => new
                {
                    p.OrderId,
                    p.CustomerId,
                    p.EmployeeId,
                    p.OrderDate,
                    p.ShipperId,


                });
            if (result.Success)
            {
                //return Ok(result.Data);
                return Ok(new
                {
                    totalCount,
                    orders,

                });
            }

            return BadRequest(result.Message);
        }



    }
}
