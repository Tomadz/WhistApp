using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WhistApi.Models
{
    public partial class WhistDbContext : DbContext
    {
        public WhistDbContext()
        {
        }

        public WhistDbContext(DbContextOptions<WhistDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bruger> Bruger { get; set; }
        public virtual DbSet<Plus> Plus { get; set; }
        public virtual DbSet<Regelsæt> Regelsæt { get; set; }
        public virtual DbSet<Runder> Runder { get; set; }
        public virtual DbSet<Spil> Spil { get; set; }

        // Unable to generate entity type for table 'dbo.Venner'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.SpilBruger'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.RegelsætPlus'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=WhistDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Bruger>(entity =>
            {
                entity.Property(e => e.Adgangskode)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Brugernavn)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Efternavn)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Fornavn)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Plus>(entity =>
            {
                entity.Property(e => e.Navn)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Regelsæt>(entity =>
            {
                entity.Property(e => e.Base).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.BaseVip).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MultiplyTab).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Runder>(entity =>
            {
                entity.Property(e => e.Beløb).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Plus)
                    .WithMany(p => p.Runder)
                    .HasForeignKey(d => d.PlusId)
                    .HasConstraintName("FK__Runder__PlusId__4AB81AF0");

                entity.HasOne(d => d.Spil)
                    .WithMany(p => p.Runder)
                    .HasForeignKey(d => d.SpilId)
                    .HasConstraintName("FK__Runder__SpilId__49C3F6B7");
            });

            modelBuilder.Entity<Spil>(entity =>
            {
                entity.HasOne(d => d.Regelsæt)
                    .WithMany(p => p.Spil)
                    .HasForeignKey(d => d.RegelsætId)
                    .HasConstraintName("FK__Spil__RegelsætId__3F466844");
            });
        }
    }
}
