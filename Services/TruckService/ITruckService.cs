using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Trucks_API.Services
{
    public interface ITruckService
    {
        Task<ServiceResponse<List<GetTruckDto>>> GetAllTrucks();
        Task<ServiceResponse<GetTruckDto>> GetTruckById(int id);

        Task<ServiceResponse<List<GetTruckDto>>> AddTruck(AddTruckDto newTruck);
    }
}