using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantProject.DataAccessLayer.Migrations
{
    public partial class mig_add_identity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surame",
                table: "AspNetUsers",
                newName: "Surname");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "AspNetUsers",
                newName: "Surame");
        }
    }
}
