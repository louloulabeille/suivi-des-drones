using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using suivie_des_drones.Cores.Infrastructure.Database;

namespace suivi_des_drones.Core.Infrastructure.Database
{
    public class DroneContextFactory : IDesignTimeDbContextFactory<DroneDbContext>
    {
        /*public DroneContextFactory CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DroneDbContext>();
            optionsBuilder.UseSqlServer("");

            return new DroneDbContext(optionsBuilder.Options);
        }*/

        DroneDbContext IDesignTimeDbContextFactory<DroneDbContext>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DroneDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=Drone;User Id=sa;Password=ieupn486jadF&;TrustServerCertificate=True;");

            return new DroneDbContext(optionsBuilder.Options);
        }
    }
}
