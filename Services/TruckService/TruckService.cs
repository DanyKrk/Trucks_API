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
            var truck = trucks.FirstOrDefault(t => t.DomainId == id);
            serviceResponse.Data = _mapper.Map<GetTruckDto>(truck);
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetTruckDto>>> AddTruck(AddTruckDto newTruck)
        {
            var serviceResponse = new ServiceResponse<List<GetTruckDto>>();
            trucks.Add(_mapper.Map<Truck>(newTruck));
            serviceResponse.Data = trucks.Select(t => _mapper.Map<GetTruckDto>(t)).ToList();
            return serviceResponse;
        }
    }
}