using EmergencyDepartment.SecondaryAdapter.Persistence.Converters;
using EmergencyDepartment.SecondaryAdapter.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmergencyDepartment.SecondaryAdapter.Persistence
{
    public class EmergencyDepartmentDbContext : DbContext
    {
        public DbSet<BloodPressure> BloodPressures { get; set; }
        public DbSet<RespiratoryRate> RespiratoryRates { get; set; }
        public DbSet<Temperature> Temperatures { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public EmergencyDepartmentDbContext(DbContextOptions<EmergencyDepartmentDbContext> options) : base(options)
        {
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
            configurationBuilder.Properties<DateOnly?>()
                .HaveConversion<NullableDateOnlyConverter>()
                .HaveColumnType("date");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasMany(e => e.BloodPressures).WithOne();
            modelBuilder.Entity<Patient>().Navigation(e => e.BloodPressures).UsePropertyAccessMode(PropertyAccessMode.Property);

            modelBuilder.Entity<Patient>().HasMany(e => e.RespiratoryRates).WithOne();
            modelBuilder.Entity<Patient>().Navigation(e => e.RespiratoryRates).UsePropertyAccessMode(PropertyAccessMode.Property);

            modelBuilder.Entity<Patient>().HasMany(e => e.Temperatures).WithOne();
            modelBuilder.Entity<Patient>().Navigation(e => e.Temperatures).UsePropertyAccessMode(PropertyAccessMode.Property);
        }
    }
}
