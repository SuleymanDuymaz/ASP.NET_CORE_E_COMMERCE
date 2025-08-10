using Business.Abstract;
using Entities.Concrete;
using Entities.RequestParametres;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerritoriesController : Controller
    {
        ITerritoryService _ıTerritoryService;
        public TerritoriesController(ITerritoryService territoryService)
        {
            _ıTerritoryService = territoryService;
        }

        [HttpGet("getall")]
        public IActionResult GetList([FromQuery] Pagination pagination)
        {

            var result = _ıTerritoryService.GetList();
            var totalCount = _ıTerritoryService.GetList().Data.Count();
            var territory = _ıTerritoryService.GetList().Data.Skip(pagination.Page * pagination.Size).Take(pagination.Size).
                Select(p => new
                {
                    p.TerritoryID,
                    p.TerritoryDescription,
                    p.RegionID
                });
            if (result.Success)
            {
                return Ok(new
                {
                    totalCount,
                    territory,

                });
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getallList")]
        public IActionResult GetAll()
        {

            var result = _ıTerritoryService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(string territoryId)
        {
            var result = _ıTerritoryService.GetById(territoryId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Territory territory)
        {
            var result = _ıTerritoryService.Add(territory);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Territory territory)
        {
            var result = _ıTerritoryService.Update(territory);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}
