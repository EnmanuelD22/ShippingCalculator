using Microsoft.EntityFrameworkCore;
using ShippingCalculator.Core.Entities;

namespace ShippingCalculator.Data.Context
{
    public class ShippingDbContext : DbContext
    {
        public ShippingDbContext(DbContextOptions<ShippingDbContext> options) : base(options) { }

        public DbSet<Country> Country { get; set; }

    }
}
