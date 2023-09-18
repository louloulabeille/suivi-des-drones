using Microsoft.EntityFrameworkCore;
using suivi_des_drones.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivi_des_drones.Core.Infrastructure.Database.EntityConfiguration
{
    internal class LoginEntityConfiguration : IEntityTypeConfiguration<Login>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Login> builder)
        {
            builder.HasKey(item => item.Id);
            builder.ToTable(nameof(Login));

            // propiété obligatoire
            builder.Property(item => item.Email).IsRequired();
            builder.Property(item => item.Password).IsRequired();
        }
    }
}
