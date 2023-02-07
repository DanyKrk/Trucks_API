using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace Trucks_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TruckController : ControllerBase
    {
        private readonly ITruckService _truckService;

        public TruckController(ITruckService truckService)
        {
            this._truckService = truckService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetTruckDto>>>> Get()
        {
            return Ok(await _truckService.GetAllTrucks());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTruckDto>>> GetSingle(int id)
        {
            return Ok(await _truckService.GetTruckById(id));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetTruckDto>>>> AddTruck(AddTruckDto newTruck)
        {
            return Ok(await _truckService.AddTruck(newTruck));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetTruckDto>>>> UpdateTruck(UpdateTruckDto updatedTruck)
        {
            return Ok(await _truckService.UpdateTruck(updatedTruck));
        }
    }
}