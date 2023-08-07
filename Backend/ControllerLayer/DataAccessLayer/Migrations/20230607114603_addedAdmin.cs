using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class addedAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name", "Password", "PasswordKey", "PhoneNumber", "isAdmin" },
                values: new object[] { -1, "admin@gmail.com", "Admin", new byte[] { 31, 105, 83, 174, 33, 116, 232, 92, 57, 109, 149, 233, 71, 136, 10, 36, 9, 97, 189, 129, 31, 117, 61, 10, 212, 61, 188, 176, 238, 161, 240, 89, 225, 204, 153, 42, 126, 147, 177, 128, 107, 158, 40, 160, 58, 170, 101, 179, 150, 178, 43, 249, 167, 95, 76, 163, 54, 194, 190, 153, 61, 155, 131, 160 }, new byte[] { 160, 49, 47, 164, 164, 72, 95, 190, 126, 161, 128, 217, 145, 18, 2, 169, 164, 113, 84, 250, 19, 158, 241, 86, 169, 222, 145, 44, 217, 185, 98, 152, 23, 86, 152, 119, 88, 208, 248, 127, 154, 132, 201, 241, 245, 22, 45, 230, 24, 160, 32, 141, 37, 89, 174, 31, 57, 4, 243, 243, 146, 200, 85, 200, 184, 135, 39, 28, 100, 195, 210, 70, 198, 36, 25, 96, 247, 143, 128, 12, 88, 118, 24, 213, 185, 140, 144, 178, 15, 116, 136, 223, 52, 191, 161, 176, 75, 44, 180, 124, 82, 42, 4, 112, 170, 152, 118, 172, 208, 60, 96, 90, 185, 243, 88, 63, 164, 14, 222, 42, 160, 0, 152, 159, 241, 20, 12, 149 }, "8098767811", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -1);
        }
    }
}
