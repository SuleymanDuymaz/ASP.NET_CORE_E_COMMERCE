using Business.Abstract;
using Entities.RequestParametres;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTerritoriesController : Controller
    {
        IEmployeeTerritoryService _ıEmployeeTerritoryService;
        public EmployeeTerritoriesController(IEmployeeTerritoryService employeeTerritoryService)
        {
            _ıEmployeeTerritoryService = employeeTerritoryService;
        }
        [HttpGet("getAllByEmployeeId")]
        public IActionResult GetListByEmployee([FromQuery] Pagination pagination, int employeeId)
        {
            var result = _ıEmployeeTerritoryService.GetListByEmployeeId(employeeId);
            int totalCount = result.Data.Count();
            var employeeTerritories = result.Data.Skip(pagination.Page * pagination.Size).Take(pagination.Size).
                Select(p => new
                {
                    p.TerritoryID,
                    p.EmployeeID
                });

            if (result.Success)
            {
                //return Ok(result.Data);
                return Ok(new
                {
                    totalCount,
                    employeeTerritories,

                });
            }

            return BadRequest(result.Message);
        }
    }
}
