using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trucks_API.Services
{
    public interface ITruckService
    {
        Task<ServiceResponse<List<Truck>>> GetAllTrucks();
        Task<ServiceResponse<Truck>> GetTruckById(int id);

        Task<ServiceResponse<List<Truck>>> AddTruck(Truck newTruck);
    }
}