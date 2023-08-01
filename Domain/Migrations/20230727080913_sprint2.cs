using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class sprint2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_centers_governorates_GovernorateId",
                table: "centers");

            migrationBuilder.RenameColumn(
                name: "GovernorateId",
                table: "centers",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_centers_GovernorateId",
                table: "centers",
                newName: "IX_centers_CityId");

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GovernateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_governorates_GovernateId",
                        column: x => x.GovernateId,
                        principalTable: "governorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_GovernateId",
                table: "City",
                column: "GovernateId");

            migrationBuilder.AddForeignKey(
                name: "FK_centers_City_CityId",
                table: "centers",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_centers_City_CityId",
                table: "centers");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "centers",
                newName: "GovernorateId");

            migrationBuilder.RenameIndex(
                name: "IX_centers_CityId",
                table: "centers",
                newName: "IX_centers_GovernorateId");

            migrationBuilder.AddForeignKey(
                name: "FK_centers_governorates_GovernorateId",
                table: "centers",
                column: "GovernorateId",
                principalTable: "governorates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
