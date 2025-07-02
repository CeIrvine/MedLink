using Microsoft.EntityFrameworkCore;
using MedLink.Logic.Models;

namespace MedLink.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
        
        public DbSet<Biometrics> Biometrics { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Illness> Illnesses { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Visit> Visits { get; set; }
    }
}
