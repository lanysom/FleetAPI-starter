using FleetAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FleetAPI.Services.Data
{
    public class CarRentalContext : DbContext
    {
        public CarRentalContext(DbContextOptions<CarRentalContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
    }
}
