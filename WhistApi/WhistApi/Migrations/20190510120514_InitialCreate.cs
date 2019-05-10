using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhistApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Runder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SpilId = table.Column<int>(nullable: false),
                    RundeNr = table.Column<int>(nullable: false),
                    Melder = table.Column<int>(nullable: false),
                    Melding = table.Column<int>(nullable: false),
                    PlusId = table.Column<int>(nullable: false),
                    Makker = table.Column<int>(nullable: false),
                    Vundet = table.Column<bool>(nullable: false),
                    Beloeb = table.Column<decimal>(nullable: false),
                    Spiller1 = table.Column<int>(nullable: false),
                    Spiller2 = table.Column<int>(nullable: false),
                    Spiller3 = table.Column<int>(nullable: false),
                    Spiller4 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Runder", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Runder");
        }
    }
}
