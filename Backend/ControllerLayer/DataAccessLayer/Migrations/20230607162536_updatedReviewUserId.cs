using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class updatedReviewUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Reviews",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -1,
                columns: new[] { "Password", "PasswordKey" },
                values: new object[] { new byte[] { 229, 115, 135, 34, 22, 121, 54, 206, 148, 28, 176, 94, 105, 194, 186, 106, 138, 143, 105, 12, 206, 8, 48, 172, 144, 5, 11, 105, 233, 148, 212, 195, 157, 79, 163, 246, 138, 123, 42, 26, 114, 74, 248, 152, 23, 209, 58, 200, 52, 41, 112, 42, 4, 82, 137, 243, 31, 90, 166, 179, 141, 205, 171, 21 }, new byte[] { 104, 223, 225, 136, 150, 68, 25, 127, 125, 21, 71, 43, 52, 118, 22, 112, 104, 119, 253, 68, 143, 74, 226, 5, 100, 127, 36, 29, 90, 14, 219, 247, 124, 3, 117, 216, 208, 91, 69, 230, 235, 104, 171, 65, 161, 235, 78, 227, 39, 186, 133, 7, 237, 166, 38, 159, 109, 76, 197, 94, 55, 81, 113, 104, 213, 235, 153, 29, 91, 158, 152, 240, 47, 106, 23, 104, 192, 0, 63, 83, 142, 131, 28, 205, 157, 73, 195, 227, 200, 255, 169, 21, 243, 107, 224, 230, 159, 64, 12, 72, 139, 126, 39, 205, 80, 70, 181, 125, 82, 121, 68, 169, 147, 123, 173, 82, 108, 38, 133, 192, 163, 191, 190, 226, 47, 142, 99, 169 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -1,
                columns: new[] { "Password", "PasswordKey" },
                values: new object[] { new byte[] { 148, 49, 27, 136, 79, 163, 212, 227, 171, 161, 32, 94, 80, 166, 233, 43, 141, 26, 65, 225, 180, 25, 15, 100, 80, 140, 74, 241, 115, 214, 240, 16, 191, 225, 166, 100, 42, 166, 146, 174, 204, 103, 174, 217, 28, 177, 39, 149, 67, 217, 51, 81, 112, 145, 16, 32, 104, 200, 152, 137, 117, 69, 79, 126 }, new byte[] { 93, 124, 69, 178, 16, 7, 107, 197, 255, 18, 184, 12, 172, 21, 245, 85, 61, 7, 56, 228, 238, 111, 196, 221, 50, 4, 243, 213, 200, 51, 69, 25, 175, 34, 34, 117, 106, 210, 135, 224, 136, 147, 44, 212, 119, 36, 168, 8, 39, 87, 233, 245, 142, 98, 106, 9, 153, 94, 255, 68, 246, 4, 84, 185, 86, 185, 83, 14, 198, 67, 187, 175, 230, 80, 53, 8, 0, 21, 240, 206, 4, 224, 86, 249, 154, 202, 242, 94, 177, 101, 135, 61, 173, 19, 236, 142, 123, 197, 116, 167, 98, 244, 120, 4, 244, 143, 229, 123, 43, 233, 34, 172, 78, 109, 248, 122, 82, 80, 207, 21, 164, 34, 120, 177, 47, 75, 216, 75 } });
        }
    }
}
