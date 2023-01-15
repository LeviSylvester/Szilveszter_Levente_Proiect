using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Szilveszter_Levente_Proiect.ReverseEngineeredTables
{
    public partial class Szilveszter_Levente_ProiectDataContext : DbContext
    {
        public Szilveszter_Levente_ProiectDataContext()
        {
        }

        public Szilveszter_Levente_ProiectDataContext(DbContextOptions<Szilveszter_Levente_ProiectDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Caller> Callers { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Sender> Senders { get; set; } = null!;
        public virtual DbSet<Shipment> Shipments { get; set; } = null!;
        public virtual DbSet<ShipmentCategory> ShipmentCategories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Szilveszter_Levente_Proiect.Data;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Caller>(entity =>
            {
                entity.ToTable("Caller");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Sender>(entity =>
            {
                entity.ToTable("Sender");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Shipment>(entity =>
            {
                entity.ToTable("Shipment");

                entity.HasIndex(e => e.CallerId, "IX_Shipment_CallerID");

                entity.HasIndex(e => e.SenderId, "IX_Shipment_SenderID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CallerId).HasColumnName("CallerID");

                entity.Property(e => e.Price).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Recipient).HasMaxLength(150);

                entity.Property(e => e.SenderId).HasColumnName("SenderID");

                entity.HasOne(d => d.Caller)
                    .WithMany(p => p.Shipments)
                    .HasForeignKey(d => d.CallerId);

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.Shipments)
                    .HasForeignKey(d => d.SenderId);
            });

            modelBuilder.Entity<ShipmentCategory>(entity =>
            {
                entity.ToTable("ShipmentCategory");

                entity.HasIndex(e => e.CategoryId, "IX_ShipmentCategory_CategoryID");

                entity.HasIndex(e => e.ShipmentId, "IX_ShipmentCategory_ShipmentID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.ShipmentId).HasColumnName("ShipmentID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ShipmentCategories)
                    .HasForeignKey(d => d.CategoryId);

                entity.HasOne(d => d.Shipment)
                    .WithMany(p => p.ShipmentCategories)
                    .HasForeignKey(d => d.ShipmentId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
