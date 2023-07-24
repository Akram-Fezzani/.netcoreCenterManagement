using Centre.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Type = Centre.Domain.Models.Type;

namespace Centre.Data.Context
{
    public class BLContext : DbContext
    {
        public BLContext(DbContextOptions<BLContext> options)
            : base(options)
        { }

        public DbSet<Antenna> Antennas { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Center> Centers { get; set; }
        public DbSet<Collector> Collectors { get; set; }
        public DbSet<Domaines> Domains { get; set; }
        public DbSet<Society> Societys { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<SocietyCenter> SocietyCenters { get; set; }
        public DbSet<SpeculationCenter> SpeculationCenters { get; set; }
        public DbSet<FicheMedicale> FicheMedicale { get; set; }
        public DbSet<Veterinaire> Veterinaires { get; set; }
        public DbSet<DemandeVeto> DemandeVetos { get; set; }

        public DbSet<Speculation> Speculations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Antenna>().HasKey(sc => new { sc.AntennaId });
            modelBuilder.Entity<Building>().HasKey(sc => new { sc.BuildingId });
            modelBuilder.Entity<Center>().HasKey(sc => new { sc.CenterId });
            modelBuilder.Entity<Collector>().HasKey(sc => new { sc.CollecteurId });
            modelBuilder.Entity<Domaines>().HasKey(sc => new { sc.DomaineId });
            modelBuilder.Entity<Society>().HasKey(sc => new { sc.SocietyId });
            modelBuilder.Entity<Type>().HasKey(sc => (new { sc.TypeId }));
            modelBuilder.Entity<Speculation>().HasKey(sc => (new { sc.SpeculationId }));
            modelBuilder.Entity<SocietyCenter>().HasKey(sc => (new { sc.SocietyCenterId }));
            modelBuilder.Entity<SpeculationCenter>().HasKey(sc => (new { sc.SpeculationCenterId }));
            modelBuilder.Entity<Veterinaire>().HasKey(sc => new { sc.VeterinaireId });
            modelBuilder.Entity<FicheMedicale>().HasKey(sc => new { sc.FicheMedicaleId });
            modelBuilder.Entity<DemandeVeto>().HasKey(sc => new { sc.DemandeVetoId });



            modelBuilder.Entity<Center>()
                    .HasOne(center => center.Antenna)
                    .WithMany(antenna => antenna.Centers)
                    .HasForeignKey("AntennaId")
                    .OnDelete(DeleteBehavior.Cascade);


              /*   modelBuilder.Entity<Building>()
                  .HasOne(building => building.Center)
                  .WithMany(center => center.Buildings)
                  .HasForeignKey("CenterId")
                  .OnDelete(DeleteBehavior.Cascade);*/



            modelBuilder.Entity<Center>()
                  .HasOne(Center => Center.Type)
                  .WithMany(type => type.Centers)
                  .HasForeignKey("TypeId")
                  .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Collector>()
                .HasOne(Collector => Collector.Center)
                .WithMany(center => center.Collectors)
                .HasForeignKey("CenterId")
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Society>()
              .HasOne(Society => Society.Domaines)
              .WithMany(Domaines => Domaines.Societys)
              .HasForeignKey("DomaineId")
              .OnDelete(DeleteBehavior.Cascade);



           /*  modelBuilder.Entity<BE>()
             .HasOne<BLs>(s => s.Bl)
             .WithOne(ad => ad.BE)
             .HasForeignKey<BLs>(ad => ad.BLId);*/

            modelBuilder.Entity<Center>()
           .HasOne<ChefCenter>(s => s.ChefCenter)
           .WithOne(ad => ad.Center)
           .HasForeignKey<ChefCenter>(ad => ad.CenterId);
        }





        public void Configure(EntityTypeBuilder<SpeculationCenter> builder)
        {
            builder.HasKey(f => new
            {
                f.SpeculationCenterId,
                f.CenterId,
                f.SpeculationId
            });
        }
        public void Configure(EntityTypeBuilder<SocietyCenter> builder)
        {
            builder.HasKey(f => new
            {
                f.SocietyCenterId,
                f.CenterId,
                f.SocietyId
            });
        }


    }
}
