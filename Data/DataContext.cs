using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trucks_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        DbSet<Truck> Trucks => Set<Truck>();
    }
}