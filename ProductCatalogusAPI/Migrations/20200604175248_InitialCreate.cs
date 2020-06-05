using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductCatalogusAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Potplant",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 13, nullable: false),
                    Naam = table.Column<string>(maxLength: 50, nullable: false),
                    Potmaat = table.Column<int>(nullable: false),
                    Planthoogte = table.Column<int>(nullable: false),
                    Kleur = table.Column<string>(nullable: true),
                    Productgroep = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Potplant", x => x.Code);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Potplant");
        }
    }
}
