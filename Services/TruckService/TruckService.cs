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

            try
            {
                var truck = trucks.FirstOrDefault(t => t.Id == updatedTruck.Id);
                if (truck is null)
                {
                    throw new Exception($"Truck with Id '{updatedTruck.Id}' not found");
                }

                _mapper.Map(updatedTruck, truck);

                serviceResponse.Data = _mapper.Map<GetTruckDto>(truck);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTruckDto>>> DeleteTruck(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetTruckDto>>();

            try
            {
                var truck = trucks.FirstOrDefault(t => t.Id == id);
                if (truck is null)
                {
                    throw new Exception($"Truck with Id '{id}' not found");
                }

                trucks.Remove(truck);
                serviceResponse.Data = trucks.Select(t => _mapper.Map<GetTruckDto>(t)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}