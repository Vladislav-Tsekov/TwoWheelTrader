using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehEvalu8.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CC",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EngineSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CC__3214EC07249B8CBA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Makes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakeName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Makes__3214EC07DB6B7174", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Models__3214EC076FE5C533", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Years",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Year__3214EC07943E10C2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motocross",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MakeId = table.Column<int>(type: "int", nullable: true),
                    ModelId = table.Column<int>(type: "int", nullable: true),
                    CCId = table.Column<int>(type: "int", nullable: true),
                    YearId = table.Column<int>(type: "int", nullable: true),
                    PriceForeign = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    PriceBGN = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Distance = table.Column<int>(type: "int", nullable: true),
                    FuelCost = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    TotalCost = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Profit = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    ROI = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Motocros__3214EC072EA21A42", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Motocross__CCId__403A8C7D",
                        column: x => x.CCId,
                        principalTable: "CC",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Motocross__MakeI__3E52440B",
                        column: x => x.MakeId,
                        principalTable: "Makes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Motocross__Model__3F466844",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Motocross__YearI__412EB0B6",
                        column: x => x.YearId,
                        principalTable: "Years",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Motocross_CCId",
                table: "Motocross",
                column: "CCId");

            migrationBuilder.CreateIndex(
                name: "IX_Motocross_MakeId",
                table: "Motocross",
                column: "MakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Motocross_ModelId",
                table: "Motocross",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Motocross_YearId",
                table: "Motocross",
                column: "YearId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Motocross");

            migrationBuilder.DropTable(
                name: "CC");

            migrationBuilder.DropTable(
                name: "Makes");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Years");
        }
    }
}
