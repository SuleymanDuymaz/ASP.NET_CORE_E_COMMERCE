using Business.Abstract;
using Entities.Concrete;
using Entities.RequestParametres;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : Controller
    {

        ISupplierService _supplierService;
        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        [HttpGet("getall")]
        public IActionResult GetList([FromQuery] Pagination pagination)
        {

            var result = _supplierService.GetList();
            var totalCount = _supplierService.GetList().Data.Count();
            var suppliers = _supplierService.GetList().Data.Skip(pagination.Page * pagination.Size).Take(pagination.Size)
                .Select(p => new
                {
                    p.SupplierID,
                    p.SupplierName,
                    p.ContactName,
                    p.Address,
                    p.Country,
                    p.Phone,
                    p.City,
                    p.PostalCode,
                });
            if (result.Success)
            {
                return Ok(new
                {
                    totalCount,
                    suppliers,

                });
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getallList")]
        public IActionResult GetAll()
        {

            var result = _supplierService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int supplierId)
        {
            var result = _supplierService.GetById(supplierId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Supplier supplier)
        {
            var result = _supplierService.Update(supplier);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Add(Supplier supplier)
        {
            var result = _supplierService.Add(supplier);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}
