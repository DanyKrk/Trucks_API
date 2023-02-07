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
            new Truck{Id=1, Tare = 100}
        };
        private readonly IMapper _mapper;

        public TruckService(IMapper mapper)
        {
            this._mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetTruckDto>>> GetAllTrucks()
        {
            var serviceResponse = new ServiceResponse<List<GetTruckDto>>();
            serviceResponse.Data = trucks.Select(t => _mapper.Map<GetTruckDto>(t)).ToList();
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetTruckDto>> GetTruckById(int id)
        {
            var serviceResponse = new ServiceResponse<GetTruckDto>();
            var truck = trucks.FirstOrDefault(t => t.Id == id);
            serviceResponse.Data = _mapper.Map<GetTruckDto>(truck);
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetTruckDto>>> AddTruck(AddTruckDto newTruck)
        {
            var serviceResponse = new ServiceResponse<List<GetTruckDto>>();
            var truck = _mapper.Map<Truck>(newTruck);
            truck.Id = trucks.Max(t => t.Id) + 1;
            trucks.Add(truck);
            serviceResponse.Data = trucks.Select(t => _mapper.Map<GetTruckDto>(t)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTruckDto>> UpdateTruck(UpdateTruckDto updatedTruck)
        {
            var serviceResponse = new ServiceResponse<GetTruckDto>();
            var truck = trucks.FirstOrDefault(t => t.Id == updatedTruck.Id);

            truck.Tare = updatedTruck.Tare;
            truck.LoadCapacity = updatedTruck.LoadCapacity;
            truck.AutonomyWhenFullyCharged = updatedTruck.AutonomyWhenFullyCharged;
            truck.FastChargingTime = updatedTruck.FastChargingTime;
            truck.IsActive = updatedTruck.IsActive;
            truck.MaximumBatteryCharge = updatedTruck.MaximumBatteryCharge;

            serviceResponse.Data = _mapper.Map<GetTruckDto>(truck);
            return serviceResponse;
        }
    }
}