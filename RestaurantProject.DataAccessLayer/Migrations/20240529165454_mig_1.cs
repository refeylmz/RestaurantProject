using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantProject.DataAccessLayer.Migrations
{
    public partial class mig_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MenuTableID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MenuTableID",
                table: "Orders",
                column: "MenuTableID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_MenuTables_MenuTableID",
                table: "Orders",
                column: "MenuTableID",
                principalTable: "MenuTables",
                principalColumn: "MenuTableID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_MenuTables_MenuTableID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_MenuTableID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MenuTableID",
                table: "Orders");
        }
    }
}
