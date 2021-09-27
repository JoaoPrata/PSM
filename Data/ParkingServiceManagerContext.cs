using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace agap2it.labs.projects.PSM.Data
{
    public partial class ParkingServiceManagerContext : DbContext
    {
        public ParkingServiceManagerContext()
        {
        }

        public ParkingServiceManagerContext(DbContextOptions<ParkingServiceManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Floor> Floors { get; set; }
        public virtual DbSet<ParkingSpot> ParkingSpots { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<SectionsStaff> SectionsStaffs { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Staff> staff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-31R10F5;Database=ParkingServiceManager;User Id=joaoprata;Password=jprata;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Building>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Buildings_Districts");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Districts_Countries");
            });

            modelBuilder.Entity<Floor>(entity =>
            {
                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Floors)
                    .HasForeignKey(d => d.BuildingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Floors_Buildings");
            });

            modelBuilder.Entity<ParkingSpot>(entity =>
            {
                entity.HasOne(d => d.Section)
                    .WithMany(p => p.ParkingSpots)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ParkingSpots_Sections");
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.Property(e => e.Letter)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Floor)
                    .WithMany(p => p.Sections)
                    .HasForeignKey(d => d.FloorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sections_Floors");
            });

            modelBuilder.Entity<SectionsStaff>(entity =>
            {
                entity.HasKey(e => new { e.SectionId, e.StaffId });

                entity.ToTable("SectionsStaff");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.SectionsStaffs)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SectionsStaff_Floors");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.SectionsStaffs)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SectionsStaff_Staff");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasOne(d => d.ParkingSpot)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.ParkingSpotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tickets_ParkingSpots");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.ToTable("Staff");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
