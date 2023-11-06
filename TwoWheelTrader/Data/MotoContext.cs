using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VehEvalu8.Data.DBModels;

namespace VehEvalu8.Data;

public partial class MotoContext : DbContext
{
    public MotoContext()
    {
    }

    public MotoContext(DbContextOptions<DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cc> Ccs { get; set; }

    public virtual DbSet<Make> Makes { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<Motocross> Motocrosses { get; set; }

    public virtual DbSet<Year> Years { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localDB)\\MSSQLLocalDB;Database=VehEvalu8;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CC__3214EC07249B8CBA");
            entity.ToTable("CC");
        });

        modelBuilder.Entity<Make>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Makes__3214EC07DB6B7174");
            entity.Property(e => e.MakeName).HasMaxLength(70);
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Models__3214EC076FE5C533");
            entity.Property(e => e.ModelName).HasMaxLength(70);
        });

        modelBuilder.Entity<Motocross>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Motocros__3214EC072EA21A42");
            entity.ToTable("Motocross");

            entity.Property(e => e.Ccid).HasColumnName("CCId");
            entity.Property(e => e.FuelCost).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PriceBgn)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PriceBGN");
            entity.Property(e => e.PriceForeign).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Profit).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Roi)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("ROI");
            entity.Property(e => e.TotalCost).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Cc).WithMany(p => p.Motocrosses)
                .HasForeignKey(d => d.Ccid)
                .HasConstraintName("FK__Motocross__CCId__403A8C7D");

            entity.HasOne(d => d.Make).WithMany(p => p.Motocrosses)
                .HasForeignKey(d => d.MakeId)
                .HasConstraintName("FK__Motocross__MakeI__3E52440B");

            entity.HasOne(d => d.Model).WithMany(p => p.Motocrosses)
                .HasForeignKey(d => d.ModelId)
                .HasConstraintName("FK__Motocross__Model__3F466844");

            entity.HasOne(d => d.Year).WithMany(p => p.Motocrosses)
                .HasForeignKey(d => d.YearId)
                .HasConstraintName("FK__Motocross__YearI__412EB0B6");
        });

        modelBuilder.Entity<Year>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Year__3214EC07943E10C2");
            entity.ToTable("Year");
            entity.Property(e => e.Year1).HasColumnName("Year");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
