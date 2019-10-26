﻿// <auto-generated />
using System;
using DevEK.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DevEK.Data.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DevEK.Business.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Complement")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("varchar(70)");

                    b.Property<Guid>("VendorId");

                    b.HasKey("Id");

                    b.HasIndex("VendorId")
                        .IsUnique();

                    b.ToTable("Address");
                });

            modelBuilder.Entity("DevEK.Business.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("Created");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(70)");

                    b.Property<decimal>("Value");

                    b.Property<Guid>("VendorId");

                    b.HasKey("Id");

                    b.HasIndex("VendorId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DevEK.Business.Models.Vendor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IdentifiyDocument")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(70)");

                    b.Property<int>("VendorType");

                    b.HasKey("Id");

                    b.ToTable("Vendor");
                });

            modelBuilder.Entity("DevEK.Business.Models.Address", b =>
                {
                    b.HasOne("DevEK.Business.Models.Vendor", "Vendor")
                        .WithOne("Address")
                        .HasForeignKey("DevEK.Business.Models.Address", "VendorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DevEK.Business.Models.Product", b =>
                {
                    b.HasOne("DevEK.Business.Models.Vendor", "Vendor")
                        .WithMany("Products")
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
