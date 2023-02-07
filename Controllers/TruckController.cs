using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace Trucks_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TruckController: ControllerBase
    {
        private static List<Truck> trucks = new List<Truck>{
            new Truck(),
            new Truck{Tare = 100}
        };
        [HttpGet("GetAll")]
        public ActionResult<List<Truck>> Get()
        {
            return Ok(trucks);
        }
        [HttpGet]
        public ActionResult<Truck> GetSinglel()
        {
            return Ok(trucks[0]);
        }
    }
}