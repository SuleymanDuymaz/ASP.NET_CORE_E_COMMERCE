using Business.Abstract;
using Entities.RequestParametres;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : Controller
    {
        IOrderDetailService _IOrderDetailService;
        public OrderDetailsController(IOrderDetailService orderDetailService)
        {
            _IOrderDetailService = orderDetailService;
        }
        [HttpGet("getall")]
        public IActionResult GetList([FromQuery] Pagination pagination, [FromQuery] int orderId)
        {
            var result = _IOrderDetailService.GetList(orderId);
            var totalCount = _IOrderDetailService.GetList(orderId).Data.Count();
            var orderDetails = _IOrderDetailService.GetList(orderId).Data.Skip(pagination.Page * pagination.Size).Take(pagination.Size)
                .Select(p => new
                {
                    p.OrderID,
                    p.Quantity,
                    p.Discount,
                    p.ProductID,
                    p.UnitPrice,


                });
            if (result.Success)
            {
                //return Ok(result.Data);
                return Ok(new
                {
                    totalCount,
                    orderDetails,

                });
            }

            return BadRequest(result.Message);
        }
    }
}
