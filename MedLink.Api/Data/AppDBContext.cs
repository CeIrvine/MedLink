using Microsoft.EntityFrameworkCore;
using MedLink.Logic.Models;
using MedLink.Logic.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MedLink.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Biometric> Biometrics { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Illness> Illnesses { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Surgery> Surgerys { get; set; }

        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        private void UpdateTimestamps()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is ITrackable &&
                            (e.State == EntityState.Added || e.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                var entity = (ITrackable)entry.Entity;
                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.UtcNow;
                }
                entity.LastModified = DateTime.UtcNow;
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Patient>()
                .Property(p => p.FullName)
                .HasComputedColumnSql("[first_name] + ' ' + [last_name]")
                .ValueGeneratedOnAddOrUpdate()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
        }       
    }
}
