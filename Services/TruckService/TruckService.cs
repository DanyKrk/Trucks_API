using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trucks_API.Services.TruckService
{
    public class TruckService : ITruckService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public TruckService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetTruckDto>>> GetAllTrucks()
        {
            var serviceResponse = new ServiceResponse<List<GetTruckDto>>();
            var dbTrucks = await _context.Trucks.ToListAsync();
            serviceResponse.Data = dbTrucks.Select(t => _mapper.Map<GetTruckDto>(t)).ToList();
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetTruckDto>> GetTruckById(int id)
        {
            var serviceResponse = new ServiceResponse<GetTruckDto>();
            var dbTruck = await _context.Trucks.FirstOrDefaultAsync(t => t.Id == id);
            serviceResponse.Data = _mapper.Map<GetTruckDto>(dbTruck);
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetTruckDto>>> AddTruck(AddTruckDto newTruck)
        {
            var serviceResponse = new ServiceResponse<List<GetTruckDto>>();
            var truck = _mapper.Map<Truck>(newTruck);
            // truck.Id = trucks.Max(t => t.Id) + 1;
            _context.Trucks.Add(truck);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _context.Trucks.Select(t => _mapper.Map<GetTruckDto>(t)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTruckDto>> UpdateTruck(UpdateTruckDto updatedTruck)
        {
            var serviceResponse = new ServiceResponse<GetTruckDto>();

            try
            {
                var dbTruck = await _context.Trucks.FirstOrDefaultAsync(t => t.Id == updatedTruck.Id);
                if (dbTruck is null)
                {
                    throw new Exception($"Truck with Id '{updatedTruck.Id}' not found");
                }

                _mapper.Map(updatedTruck, dbTruck);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetTruckDto>(dbTruck);
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
                var dbTruck = await _context.Trucks.FirstOrDefaultAsync(t => t.Id == id);
                if (dbTruck is null)
                {
                    throw new Exception($"Truck with Id '{id}' not found");
                }

                _context.Trucks.Remove(dbTruck);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _context.Trucks.Select(t => _mapper.Map<GetTruckDto>(t)).ToList();
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