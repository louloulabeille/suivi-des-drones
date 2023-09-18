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
    internal class HealthStatusEntityConfiguration : IEntityTypeConfiguration<HealthStatus>
    {
        void IEntityTypeConfiguration<HealthStatus>.Configure(EntityTypeBuilder<HealthStatus> builder)
        {
            builder.ToTable(nameof(HealthStatus));
                
        }
    }
}
