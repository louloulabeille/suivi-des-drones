using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using suivie_des_drones.Cores.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivi_des_drones.Core.Infrastructure.Database
{
    public class AuthentificationUserContextFactory : IDesignTimeDbContextFactory<AuthentificationUserContext>
    {
        public AuthentificationUserContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AuthentificationUserContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=Drone;User Id=sa;Password=ieupn486jadF&;TrustServerCertificate=True;");

            return new AuthentificationUserContext(optionsBuilder.Options);
        }
    }
}
