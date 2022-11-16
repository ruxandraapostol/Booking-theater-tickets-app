using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Tema1.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Tema1.Context
{
    public partial class Tema1EgovContext : DbContext
    {
        public Tema1EgovContext()
        {
        }

        public Tema1EgovContext(DbContextOptions<Tema1EgovContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Orar> Orar { get; set; }
        public virtual DbSet<Piesa> Piesa { get; set; }
        public virtual DbSet<Rezervare> Rezervare { get; set; }
        public virtual DbSet<Teatru> Teatru { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(local);Initial Catalog=Tema1Egov;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orar>(entity =>
            {
                entity.Property(e => e.OrarId).ValueGeneratedNever();

                entity.Property(e => e.DataOra).HasColumnType("datetime");

                entity.HasOne(d => d.Piesa)
                    .WithMany(p => p.Orar)
                    .HasForeignKey(d => d.PiesaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orar_Piesa");
            });

            modelBuilder.Entity<Piesa>(entity =>
            {
                entity.Property(e => e.PiesaId).ValueGeneratedNever();

                entity.Property(e => e.Nume)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Teatru)
                    .WithMany(p => p.Piesa)
                    .HasForeignKey(d => d.TeatruId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Piesa_Teatru");
            });

            modelBuilder.Entity<Rezervare>(entity =>
            {
                entity.Property(e => e.RezervareId).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Nume)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Prenume)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Teatru>(entity =>
            {
                entity.Property(e => e.TeatruId).ValueGeneratedNever();

                entity.Property(e => e.Nume)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
