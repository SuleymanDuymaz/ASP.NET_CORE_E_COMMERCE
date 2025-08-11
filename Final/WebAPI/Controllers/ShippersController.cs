using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : Controller
    {
        IShipperService _ıShipperService;
        public ShippersController(IShipperService shipperService)
        {
            _ıShipperService = shipperService;
        }
        [HttpGet("getall")]
        //[Authorize(Roles = "Product.List")]
        public IActionResult GetList()
        {

            var result = _ıShipperService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
        [HttpGet("getById")]
        public IActionResult GetById(int shipperId)
        {
            var result = _ıShipperService.GetById(shipperId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Shipper shipper)
        {
            var result = _ıShipperService.Update(shipper);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Add(Shipper shipper)
        {
            var result = _ıShipperService.Add(shipper);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}
