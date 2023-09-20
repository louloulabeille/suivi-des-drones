using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using suivi_des_drones.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivi_des_drones.Core.Infrastructure.Database.EntityConfiguration
{
    public class IncidentEntityConfiguration : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            builder.HasKey(x =>x.Id);
            builder.Property(item => item.Id).IsRequired()
                .HasAnnotation("SqlServer:Identity", "1, 1");
            builder.ToTable(nameof(Incident));

            builder.Property(x=>x.IdDrone).IsRequired().HasMaxLength(25);
            builder.Property(x=>x.DateIncident).IsRequired();
            builder.Property(x=>x.Raison).IsRequired()
                .HasMaxLength(500);
            builder.Property(x=>x.PathFichier).HasMaxLength(255);
            builder.HasOne(x => x.IdDroneNav)
                .WithMany(x=>x.Problemes).HasForeignKey(x=>x.IdDrone);
        }
    }
}
