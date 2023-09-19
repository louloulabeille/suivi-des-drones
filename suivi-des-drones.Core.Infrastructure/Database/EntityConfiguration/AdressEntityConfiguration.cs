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
    internal class AdressEntityConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable(nameof(Address));
            builder.HasKey(item=>item.Id);

            builder.Property(item=>item.Id).IsRequired()
                .HasAnnotation("SqlServer:Identity", "1, 1");
            builder.Property(item => item.Rue).IsRequired()
                .HasMaxLength(255);
            builder.Property(item => item.IdCustomer).IsRequired();
            builder.Property(item => item.CodePostal).IsRequired()
                .HasMaxLength(5);
            builder.Property(item => item.Pays).IsRequired()
                .HasMaxLength(255);

            builder.HasIndex(item=>item.Id);

            builder.HasOne(x => x.IdCustomerNavigation)
                .WithOne(x => x.IdAddressNavigation)
                .OnDelete(DeleteBehavior.ClientSetNull);
                
        }
    }
}
