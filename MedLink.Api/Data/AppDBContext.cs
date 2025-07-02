using Microsoft.EntityFrameworkCore;
using MedLink.Logic.Models;

namespace MedLink.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
        
        public DbSet<Patient> Patient { get; set; }
    }
}
