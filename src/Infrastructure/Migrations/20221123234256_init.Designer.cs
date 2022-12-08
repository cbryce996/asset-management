﻿// <auto-generated />
using System;
using AssetManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AssetManagement.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221123234256_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("AssetManagement.Domain.System.SystemEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("SystemTable");
                });

            modelBuilder.Entity("AssetManagement.Domain.System.SystemEntity", b =>
                {
                    b.OwnsOne("AssetManagement.Domain.System.ValueObjects.IpAddress", "Ip", b1 =>
                        {
                            b1.Property<Guid>("SystemEntityId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Ip")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("SystemEntityId");

                            b1.ToTable("SystemTable");

                            b1.WithOwner()
                                .HasForeignKey("SystemEntityId");
                        });

                    b.OwnsOne("AssetManagement.Domain.System.ValueObjects.MacAddress", "Mac", b1 =>
                        {
                            b1.Property<Guid>("SystemEntityId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Mac")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("SystemEntityId");

                            b1.ToTable("SystemTable");

                            b1.WithOwner()
                                .HasForeignKey("SystemEntityId");
                        });

                    b.OwnsMany("AssetManagement.Domain.System.ValueObjects.Software", "InstalledSoftware", b1 =>
                        {
                            b1.Property<Guid>("SystemEntityId")
                                .HasColumnType("char(36)");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<string>("Manufacturer")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("Version")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("SystemEntityId", "Id");

                            b1.ToTable("Software");

                            b1.WithOwner()
                                .HasForeignKey("SystemEntityId");
                        });

                    b.OwnsOne("AssetManagement.Domain.System.ValueObjects.SystemName", "Name", b1 =>
                        {
                            b1.Property<Guid>("SystemEntityId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("SystemEntityId");

                            b1.ToTable("SystemTable");

                            b1.WithOwner()
                                .HasForeignKey("SystemEntityId");
                        });

                    b.Navigation("InstalledSoftware");

                    b.Navigation("Ip")
                        .IsRequired();

                    b.Navigation("Mac")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
