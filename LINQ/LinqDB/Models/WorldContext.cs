using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace LinqDB.Models
{
    public partial class WorldContext : DbContext
    {
        public WorldContext()
        {
        }

        public WorldContext(DbContextOptions<WorldContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Continent> Continent { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Region> Region { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;database=world;user=root;pwd=rootpass");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.HasIndex(e => e.CountryCode)
                    .HasName("CountryCode");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasColumnType("char(3)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.District)
                    .IsRequired()
                    .HasColumnType("char(20)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("char(35)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Population)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("city_ibfk_1");
            });

            modelBuilder.Entity<Continent>(entity =>
            {
                entity.ToTable("continent");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("char(20)")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PRIMARY");

                entity.ToTable("country");

                entity.HasIndex(e => e.ContinentId)
                    .HasName("Country_Continent_idx");

                entity.HasIndex(e => e.RegionId)
                    .HasName("Country_Region_idx");

                entity.Property(e => e.Code)
                    .HasColumnType("char(3)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Capital).HasColumnType("int(11)");

                entity.Property(e => e.Code2)
                    .IsRequired()
                    .HasColumnType("char(2)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.ContinentId)
                    .HasColumnName("ContinentID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'3'");

                entity.Property(e => e.Gnp)
                    .HasColumnName("GNP")
                    .HasColumnType("float(10,2)");

                entity.Property(e => e.Gnpold)
                    .HasColumnName("GNPOld")
                    .HasColumnType("float(10,2)");

                entity.Property(e => e.GovernmentForm)
                    .IsRequired()
                    .HasColumnType("char(45)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.HeadOfState).HasColumnType("char(60)");

                entity.Property(e => e.IndepYear).HasColumnType("smallint(6)");

                entity.Property(e => e.LifeExpectancy).HasColumnType("float(3,1)");

                entity.Property(e => e.LocalName)
                    .IsRequired()
                    .HasColumnType("char(45)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("char(52)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Population)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.RegionId)
                    .HasColumnName("RegionID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.SurfaceArea)
                    .HasColumnType("float(10,2)")
                    .HasDefaultValueSql("'0.00'");

                entity.HasOne(d => d.Continent)
                    .WithMany(p => p.Country)
                    .HasForeignKey(d => d.ContinentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Country_Continent");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Country)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Country_Region");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasKey(e => new { e.CountryCode, e.Name })
                    .HasName("PRIMARY");

                entity.ToTable("language");

                entity.HasIndex(e => e.CountryCode)
                    .HasName("CountryCode");

                entity.Property(e => e.CountryCode)
                    .HasColumnType("char(3)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Name)
                    .HasColumnType("char(30)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.IsOfficial)
                    .IsRequired()
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("'b\\'0\\''");

                entity.Property(e => e.Percentage)
                    .HasColumnType("float(4,1)")
                    .HasDefaultValueSql("'0.0'");

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.Language)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("countryLanguage_ibfk_1");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("region");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("char(40)")
                    .HasDefaultValueSql("''");
            });
        }
    }
}
