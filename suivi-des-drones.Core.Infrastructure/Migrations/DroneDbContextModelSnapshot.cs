﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using suivie_des_drones.Cores.Infrastructure.Database;

#nullable disable

namespace suivi_des_drones.Core.Infrastructure.Migrations
{
    [DbContext(typeof(DroneDbContext))]
    partial class DroneDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("suivi_des_drones.Core.Models.Drone", b =>
                {
                    b.Property<string>("Matricule")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Matricule");

                    b.HasIndex("StatusId");

                    b.ToTable("Drone", (string)null);
                });

            modelBuilder.Entity("suivi_des_drones.Core.Models.HealthStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HealthStatus", (string)null);
                });

            modelBuilder.Entity("suivi_des_drones.Core.Models.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("suivi_des_drones.Core.Models.Drone", b =>
                {
                    b.HasOne("suivi_des_drones.Core.Models.HealthStatus", "Status")
                        .WithMany("Drones")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("suivi_des_drones.Core.Models.HealthStatus", b =>
                {
                    b.Navigation("Drones");
                });
#pragma warning restore 612, 618
        }
    }
}
