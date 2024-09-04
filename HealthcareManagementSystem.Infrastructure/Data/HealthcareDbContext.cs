using Microsoft.EntityFrameworkCore;
using HealthcareManagementSystem.Core.Entities;

namespace HealthcareManagementSystem.Infrastructure.Data
{
    public class HealthcareDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Plot> Plots { get; set; }

        public HealthcareDbContext(DbContextOptions<HealthcareDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Office)
                .WithMany()
                .HasForeignKey(d => d.OfficeId);

            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Specialization)
                .WithMany()
                .HasForeignKey(d => d.SpecializationId);

            modelBuilder.Entity<Patient>()
                .HasOne(p => p.Plot)
                .WithMany()
                .HasForeignKey(p => p.PlotId);            
        }
    }
}
