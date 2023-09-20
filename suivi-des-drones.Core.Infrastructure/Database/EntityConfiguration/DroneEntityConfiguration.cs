using Microsoft.EntityFrameworkCore;
using suivi_des_drones.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace suivi_des_drones.Core.Infrastructure.Database.EntityConfiguration
{
    internal class DroneEntityConfiguration : IEntityTypeConfiguration<Drone>
    {
        public void Configure(EntityTypeBuilder<Drone> builder)
        {
            builder.HasKey(x => x.Matricule);
            builder.ToTable(nameof(Drone));
            builder.Property(x => x.Matricule).IsRequired(true).HasMaxLength(25);

            builder.HasOne(x => x.Status)   // construction automatique des objects Healthstatus et de la liste drone dans HealthStatus
                .WithMany(x => x.Drones)
                .HasForeignKey(x => x.StatusId);

        }
    }


}
