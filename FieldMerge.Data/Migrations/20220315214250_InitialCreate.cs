using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FieldMerge.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FieldCodePatterns",
                columns: table => new
                {
                    PatternId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PatternFrom = table.Column<string>(type: "TEXT", nullable: false),
                    PatternTo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldCodePatterns", x => x.PatternId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FieldCodePatterns");
        }
    }
}
