using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using VehEvalu8.Data;

namespace VehEvalu8.Migrations
{
    [DbContext(typeof(MotoContext))]
    partial class MotoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VehEvalu8.Data.DBModels.Cc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EngineSize")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__CC__3214EC07249B8CBA");

                    b.ToTable("CC", (string)null!);
                    //REMOVE "!" IN CASE OF ERRORS
                });

            modelBuilder.Entity("VehEvalu8.Data.DBModels.Enduro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Ccid")
                        .HasColumnType("int")
                        .HasColumnName("CCId");

                    b.Property<int?>("Distance")
                        .HasColumnType("int");

                    b.Property<decimal?>("FuelCost")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MakeId")
                        .HasColumnType("int");

                    b.Property<int?>("ModelId")
                        .HasColumnType("int");

                    b.Property<decimal?>("PriceBgn")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("PriceBGN");

                    b.Property<decimal?>("PriceForeign")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal?>("Profit")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal?>("Roi")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("ROI");

                    b.Property<decimal?>("TotalCost")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int?>("YearId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Ccid");

                    b.HasIndex("MakeId");

                    b.HasIndex("ModelId");

                    b.HasIndex("YearId");

                    b.ToTable("Enduro", (string)null);
                });

            modelBuilder.Entity("VehEvalu8.Data.DBModels.Make", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MakeName")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.HasKey("Id")
                        .HasName("PK__Makes__3214EC07DB6B7174");

                    b.ToTable("Makes");
                });

            modelBuilder.Entity("VehEvalu8.Data.DBModels.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.HasKey("Id")
                        .HasName("PK__Models__3214EC076FE5C533");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("VehEvalu8.Data.DBModels.Motocross", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Ccid")
                        .HasColumnType("int")
                        .HasColumnName("CCId");

                    b.Property<int?>("Distance")
                        .HasColumnType("int");

                    b.Property<decimal?>("FuelCost")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MakeId")
                        .HasColumnType("int");

                    b.Property<int?>("ModelId")
                        .HasColumnType("int");

                    b.Property<decimal?>("PriceBgn")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("PriceBGN");

                    b.Property<decimal?>("PriceForeign")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal?>("Profit")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal?>("Roi")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("ROI");

                    b.Property<decimal?>("TotalCost")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int?>("YearId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Motocros__3214EC072EA21A42");

                    b.HasIndex("Ccid");

                    b.HasIndex("MakeId");

                    b.HasIndex("ModelId");

                    b.HasIndex("YearId");

                    b.ToTable("Motocross", (string)null);
                });

            modelBuilder.Entity("VehEvalu8.Data.DBModels.Year", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Year1")
                        .HasColumnType("int")
                        .HasColumnName("Year");

                    b.HasKey("Id")
                        .HasName("PK__Year__3214EC07943E10C2");

                    b.ToTable("Years", (string)null);
                });

            modelBuilder.Entity("VehEvalu8.Data.DBModels.Enduro", b =>
                {
                    b.HasOne("VehEvalu8.Data.DBModels.Cc", "Cc")
                        .WithMany("Enduroes")
                        .HasForeignKey("Ccid");

                    b.HasOne("VehEvalu8.Data.DBModels.Make", "Make")
                        .WithMany("Enduroes")
                        .HasForeignKey("MakeId");

                    b.HasOne("VehEvalu8.Data.DBModels.Model", "Model")
                        .WithMany("Enduroes")
                        .HasForeignKey("ModelId");

                    b.HasOne("VehEvalu8.Data.DBModels.Year", "Year")
                        .WithMany("Enduroes")
                        .HasForeignKey("YearId");

                    b.Navigation("Cc");

                    b.Navigation("Make");

                    b.Navigation("Model");

                    b.Navigation("Year");
                });

            modelBuilder.Entity("VehEvalu8.Data.DBModels.Motocross", b =>
                {
                    b.HasOne("VehEvalu8.Data.DBModels.Cc", "Cc")
                        .WithMany("Motocrosses")
                        .HasForeignKey("Ccid")
                        .HasConstraintName("FK__Motocross__CCId__403A8C7D");

                    b.HasOne("VehEvalu8.Data.DBModels.Make", "Make")
                        .WithMany("Motocrosses")
                        .HasForeignKey("MakeId")
                        .HasConstraintName("FK__Motocross__MakeI__3E52440B");

                    b.HasOne("VehEvalu8.Data.DBModels.Model", "Model")
                        .WithMany("Motocrosses")
                        .HasForeignKey("ModelId")
                        .HasConstraintName("FK__Motocross__Model__3F466844");

                    b.HasOne("VehEvalu8.Data.DBModels.Year", "Year")
                        .WithMany("Motocrosses")
                        .HasForeignKey("YearId")
                        .HasConstraintName("FK__Motocross__YearI__412EB0B6");

                    b.Navigation("Cc");

                    b.Navigation("Make");

                    b.Navigation("Model");

                    b.Navigation("Year");
                });

            modelBuilder.Entity("VehEvalu8.Data.DBModels.Cc", b =>
                {
                    b.Navigation("Enduroes");

                    b.Navigation("Motocrosses");
                });

            modelBuilder.Entity("VehEvalu8.Data.DBModels.Make", b =>
                {
                    b.Navigation("Enduroes");

                    b.Navigation("Motocrosses");
                });

            modelBuilder.Entity("VehEvalu8.Data.DBModels.Model", b =>
                {
                    b.Navigation("Enduroes");

                    b.Navigation("Motocrosses");
                });

            modelBuilder.Entity("VehEvalu8.Data.DBModels.Year", b =>
                {
                    b.Navigation("Enduroes");

                    b.Navigation("Motocrosses");
                });
        }
    }
}
