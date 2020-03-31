using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Destination",
                columns: table => new
                {
                    DestinationId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Country = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destination", x => x.DestinationId);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DestinationId = table.Column<int>(nullable: false),
                    ReviewText = table.Column<string>(nullable: true),
                    user_name = table.Column<string>(nullable: true),
                    Rating = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Review_Destination_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destination",
                        principalColumn: "DestinationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Destination",
                columns: new[] { "DestinationId", "City", "Country", "Rating" },
                values: new object[,]
                {
                    { 1, "New York City", "United States", 0 },
                    { 2, "London", "England", 0 },
                    { 3, "Toronto", "Canada", 0 },
                    { 4, "Guangzho", "China", 0 },
                    { 5, "Belfast", "Northern Ireland", 0 }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "DestinationId", "Rating", "ReviewText", "user_name" },
                values: new object[,]
                {
                    { 1, 1, "7", "United States", "New York" },
                    { 2, 2, "10", "England", "London" },
                    { 3, 3, "2", "Canada", "Toronto" },
                    { 4, 4, "4", "China", "Guangzho" },
                    { 5, 5, "10", "Northern Ireland", "Belfast" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_DestinationId",
                table: "Review",
                column: "DestinationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Destination");
        }
    }
}
