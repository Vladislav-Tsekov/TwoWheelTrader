using Microsoft.EntityFrameworkCore;
using VehEvalu8.Data.DBModels;

namespace VehEvalu8.Data;

public partial class MotoContext : DbContext
{
    private readonly string connectionString = "Server=(localDB)\\MSSQLLocalDB;Database=VehEvalu8;Integrated Security=True;";

    public MotoContext(){}

    public virtual DbSet<Cc> Ccs { get; set; }
    public virtual DbSet<Make> Makes { get; set; }
    public virtual DbSet<Model> Models { get; set; }
    public virtual DbSet<Year> Years { get; set; }
    public virtual DbSet<Motocross> Motocrosses { get; set; }
    public virtual DbSet<Enduro> Enduroes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cc>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("CC");
        });

        modelBuilder.Entity<Make>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.MakeName).HasMaxLength(70);
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ModelName).HasMaxLength(70);
        });

        modelBuilder.Entity<Year>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Years");
            entity.Property(e => e.Year1).HasColumnName("Year");
        });

        modelBuilder.Entity<Motocross>(entity =>
        {
            entity.HasKey(e => e.Id);
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
                .HasForeignKey(d => d.Ccid);

            entity.HasOne(d => d.Make).WithMany(p => p.Motocrosses)
                .HasForeignKey(d => d.MakeId);

            entity.HasOne(d => d.Model).WithMany(p => p.Motocrosses)
                .HasForeignKey(d => d.ModelId);

            entity.HasOne(d => d.Year).WithMany(p => p.Motocrosses)
                .HasForeignKey(d => d.YearId);
        });

        modelBuilder.Entity<Enduro>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Enduro");

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

            entity.HasOne(d => d.Cc).WithMany(p => p.Enduroes)
                .HasForeignKey(d => d.Ccid);

            entity.HasOne(d => d.Make).WithMany(p => p.Enduroes)
                .HasForeignKey(d => d.MakeId);

            entity.HasOne(d => d.Model).WithMany(p => p.Enduroes)
                .HasForeignKey(d => d.ModelId);

            entity.HasOne(d => d.Year).WithMany(p => p.Enduroes)
                .HasForeignKey(d => d.YearId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
