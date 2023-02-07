using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trucks_API.Models
{
    public class Truck
    {
        public int _id { get; set; }

        public int DomainId { get; set; }
        public int Tare { get; set; }

        public int LoadCapacity { get; set; }

        public int MaximumBatteryCharge { get; set; }

        public int AutonomyWhenFullyCharged { get; set; }

        public int FastChargingTime { get; set; }

        public int IsActive { get; set; }

    }
}