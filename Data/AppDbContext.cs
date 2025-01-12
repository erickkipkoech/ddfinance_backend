using DDFinanceBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace DDFinanceBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<InsurancePolicies> InsurancePolicies { get; set; }
    }
}