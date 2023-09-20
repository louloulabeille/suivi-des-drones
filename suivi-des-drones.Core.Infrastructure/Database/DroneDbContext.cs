using Microsoft.EntityFrameworkCore;
using suivi_des_drones.Core.Infrastructure.Database.EntityConfiguration;
using suivi_des_drones.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivie_des_drones.Cores.Infrastructure.Database
{
    public class DroneDbContext : DbContext
    {
        public DroneDbContext(DbContextOptions<DroneDbContext> options) : base(options)
        {
        }

        public DroneDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Drone>(new DroneEntityConfiguration());
            modelBuilder.ApplyConfiguration<HealthStatus>(new HealthStatusEntityConfiguration());
            modelBuilder.ApplyConfiguration<Incident>(new IncidentEntityConfiguration());
            modelBuilder.ApplyConfiguration<Login>(new LoginEntityConfiguration());
            //modelBuilder.Entity<Drone>().HasKey(item => item.Matricule);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           /* optionsBuilder.UseSqlServer(
                @"Server=localhost;Database=Drone;User Id=sa;Password=ieupn486jadF&;TrustServerCertificate=true;");*/
        }

        public virtual DbSet<Drone> Drones { get; set; }
        public virtual DbSet<HealthStatus> HealthStatus { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Incident> Incidents { get; set; }

    }
}
