using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trucks_API.Dtos.Truck
{
    public class UpdateTruckDto
    {
        public int Id { get; set; }
        public int Tare { get; set; }

        public int LoadCapacity { get; set; }

        public int MaximumBatteryCharge { get; set; }

        public int AutonomyWhenFullyCharged { get; set; }

        public int FastChargingTime { get; set; }

        public bool IsActive { get; set; }
    }
}