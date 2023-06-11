﻿// <auto-generated />
using System;
using Centre.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Centre.Data.Migrations
{
    [DbContext(typeof(BLContext))]
    [Migration("20230610235816_Migration2")]
    partial class Migration2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Centre.Domain.Models.Antenna", b =>
                {
                    b.Property<Guid>("AntennaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AntennaCode")
                        .HasColumnType("int");

                    b.Property<string>("AntennaLabel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AntennaId");

                    b.ToTable("Antennas");
                });

            modelBuilder.Entity("Centre.Domain.Models.Building", b =>
                {
                    b.Property<Guid>("BuildingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("BuildingAdress")
                        .HasColumnType("int");

                    b.Property<int>("BuildingArea")
                        .HasColumnType("int");

                    b.Property<int>("BuildingCode")
                        .HasColumnType("int");

                    b.Property<int>("BuildingLabel")
                        .HasColumnType("int");

                    b.Property<Guid?>("CenterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Couvoir")
                        .HasColumnType("int");

                    b.Property<string>("Souche")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("rotation")
                        .HasColumnType("int");

                    b.HasKey("BuildingId");

                    b.HasIndex("CenterId");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("Centre.Domain.Models.Center", b =>
                {
                    b.Property<Guid>("CenterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AntennaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BlPrefixNumber")
                        .HasColumnType("int");

                    b.Property<int>("BuildingNumber")
                        .HasColumnType("int");

                    b.Property<int>("CenterCode")
                        .HasColumnType("int");

                    b.Property<string>("CenterLabel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CodeSpecification")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("RotationActuelle")
                        .HasColumnType("int");

                    b.Property<string>("SocialReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UsefulSurface")
                        .HasColumnType("int");

                    b.HasKey("CenterId");

                    b.HasIndex("AntennaId");

                    b.HasIndex("TypeId");

                    b.ToTable("Centers");
                });

            modelBuilder.Entity("Centre.Domain.Models.ChefCenter", b =>
                {
                    b.Property<Guid>("ChefCenterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CenterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ChefCenterCin")
                        .HasColumnType("int");

                    b.Property<int>("ModificationCin")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ChefCenterId");

                    b.HasIndex("CenterId")
                        .IsUnique();

                    b.ToTable("ChefCenter");
                });

            modelBuilder.Entity("Centre.Domain.Models.Collector", b =>
                {
                    b.Property<Guid>("CollecteurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CenterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CodeCollecteur")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telephone")
                        .HasColumnType("int");

                    b.Property<bool>("state")
                        .HasColumnType("bit");

                    b.HasKey("CollecteurId");

                    b.HasIndex("CenterId");

                    b.ToTable("Collectors");
                });

            modelBuilder.Entity("Centre.Domain.Models.Domaines", b =>
                {
                    b.Property<Guid>("DomaineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CapitalSocial")
                        .HasColumnType("int");

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("DomaineName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RaisonSocial")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DomaineId");

                    b.ToTable("Domains");
                });

            modelBuilder.Entity("Centre.Domain.Models.Society", b =>
                {
                    b.Property<Guid>("SocietyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adresse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CapitalSocial")
                        .HasColumnType("int");

                    b.Property<int>("CodeSociétés")
                        .HasColumnType("int");

                    b.Property<Guid?>("DomaineId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RaisonSocial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("tel")
                        .HasColumnType("int");

                    b.HasKey("SocietyId");

                    b.HasIndex("DomaineId");

                    b.ToTable("Societys");
                });

            modelBuilder.Entity("Centre.Domain.Models.SocietyCenter", b =>
                {
                    b.Property<Guid>("SocietyCenterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CenterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SocietyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SocietyCenterId");

                    b.HasIndex("CenterId");

                    b.HasIndex("SocietyId");

                    b.ToTable("SocietyCenters");
                });

            modelBuilder.Entity("Centre.Domain.Models.Speculation", b =>
                {
                    b.Property<Guid>("SpeculationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SpeculationCode")
                        .HasColumnType("int");

                    b.HasKey("SpeculationId");

                    b.ToTable("Speculations");
                });

            modelBuilder.Entity("Centre.Domain.Models.SpeculationCenter", b =>
                {
                    b.Property<Guid>("SpeculationCenterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CenterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("SpeculationCenterCode")
                        .HasColumnType("int");

                    b.Property<string>("SpeculationCenterLabel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SpeculationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SpeculationCenterId");

                    b.HasIndex("CenterId");

                    b.HasIndex("SpeculationId");

                    b.ToTable("SpeculationCenters");
                });

            modelBuilder.Entity("Centre.Domain.Models.Type", b =>
                {
                    b.Property<Guid>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CodeSouche")
                        .HasColumnType("int");

                    b.Property<string>("LibSouche")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeId");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("Centre.Domain.Models.Building", b =>
                {
                    b.HasOne("Centre.Domain.Models.Center", "Center")
                        .WithMany("Buildings")
                        .HasForeignKey("CenterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Centre.Domain.Models.Center", b =>
                {
                    b.HasOne("Centre.Domain.Models.Antenna", "Antenna")
                        .WithMany("Centers")
                        .HasForeignKey("AntennaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Centre.Domain.Models.Type", "Type")
                        .WithMany("Centers")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Centre.Domain.Models.ChefCenter", b =>
                {
                    b.HasOne("Centre.Domain.Models.Center", "Center")
                        .WithOne("ChefCenter")
                        .HasForeignKey("Centre.Domain.Models.ChefCenter", "CenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Centre.Domain.Models.Collector", b =>
                {
                    b.HasOne("Centre.Domain.Models.Center", "Center")
                        .WithMany("Collectors")
                        .HasForeignKey("CenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Centre.Domain.Models.Society", b =>
                {
                    b.HasOne("Centre.Domain.Models.Domaines", "Domaines")
                        .WithMany("Societys")
                        .HasForeignKey("DomaineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Centre.Domain.Models.SocietyCenter", b =>
                {
                    b.HasOne("Centre.Domain.Models.Center", null)
                        .WithMany("SocietyCenters")
                        .HasForeignKey("CenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Centre.Domain.Models.Society", null)
                        .WithMany("SocietyCenters")
                        .HasForeignKey("SocietyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Centre.Domain.Models.SpeculationCenter", b =>
                {
                    b.HasOne("Centre.Domain.Models.Center", null)
                        .WithMany("SpeculationCenters")
                        .HasForeignKey("CenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Centre.Domain.Models.Speculation", null)
                        .WithMany("SpeculationCenters")
                        .HasForeignKey("SpeculationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
