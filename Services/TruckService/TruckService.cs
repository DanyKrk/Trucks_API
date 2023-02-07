using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trucks_API.Services.TruckService
{
    public class TruckService : ITruckService
    {
        private static List<Truck> trucks = new List<Truck>{
            new Truck(),
            new Truck{Tare = 100}
        };
        public async Task<ServiceResponse<List<Truck>>> GetAllTrucks()
        {
            var serviceResponse = new ServiceResponse<List<Truck>>();
            serviceResponse.Data = trucks;
            return serviceResponse;
        }
        public async Task<ServiceResponse<Truck>> GetTruckById(int id)
        {
            var serviceResponse = new ServiceResponse<Truck>();
            var truck = trucks.FirstOrDefault(t => t.DomainId == id);
            serviceResponse.Data = truck;
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<Truck>>> AddTruck(Truck newTruck)
        {
            var serviceResponse = new ServiceResponse<List<Truck>>();
            trucks.Add(newTruck);
            serviceResponse.Data = trucks;
            return serviceResponse;
        }
    }
}