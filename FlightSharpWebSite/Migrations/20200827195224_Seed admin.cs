using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightSharpWebSite.Migrations
{
    public partial class Seedadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "c592ccec-3b12-41dd-b344-957baf84e8f8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "06aeced9-23f2-4821-8561-a2b832fe13de", "AQAAAAEAACcQAAAAEMgMdRw63h2LYMNeadFQK6RQfRb1mWBBa9kBPqohYqrdKa+ho66QEArNXLehJ86IOw==", "c34ff24d-a3c4-4018-8aa4-80af9c8af578", "admintest@example.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "e50ce712-6d9d-4afe-9473-4e97eaa7decb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "b3237add-57ad-48c4-b621-391cfca24de7", "AQAAAAEAACcQAAAAEKuKwswpa4y487b6n2PiUXPlkvro0QYhexUjU0pMr6wFGNEdJKIwgVs15J/n6ghVuw==", "2bcc6497-892f-4a50-87e4-8476801bc325", "adminuser" });
        }
    }
}
