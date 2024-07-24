using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVineGrapesRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VinesId",
                table: "Grapes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grapes_VinesId",
                table: "Grapes",
                column: "VinesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grapes_Vines_VinesId",
                table: "Grapes",
                column: "VinesId",
                principalTable: "Vines",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grapes_Vines_VinesId",
                table: "Grapes");

            migrationBuilder.DropIndex(
                name: "IX_Grapes_VinesId",
                table: "Grapes");

            migrationBuilder.DropColumn(
                name: "VinesId",
                table: "Grapes");
        }
    }
}
