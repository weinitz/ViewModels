using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ViewModels.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "City", "Name", "PhoneNumber" },
                values: new object[] { 1, "Halmstad", "Tim", "112" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "City", "Name", "PhoneNumber" },
                values: new object[] { 2, "Malmö", "Johan", "114-114" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "City", "Name", "PhoneNumber" },
                values: new object[] { 3, "Helsingborg", "Leif", "118-118" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
