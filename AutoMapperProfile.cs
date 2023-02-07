using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trucks_API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Truck, GetTruckDto>();
            CreateMap<AddTruckDto, Truck>();
        }
    }
}