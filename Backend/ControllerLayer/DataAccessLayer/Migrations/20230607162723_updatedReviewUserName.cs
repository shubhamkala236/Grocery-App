using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class updatedReviewUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
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
                values: new object[] { new byte[] { 226, 174, 139, 57, 230, 144, 59, 11, 64, 188, 42, 53, 116, 119, 136, 18, 77, 197, 0, 108, 235, 107, 203, 51, 128, 148, 155, 216, 234, 106, 236, 144, 182, 172, 184, 136, 5, 105, 173, 158, 59, 69, 232, 169, 117, 190, 225, 240, 137, 74, 188, 52, 72, 51, 191, 122, 16, 29, 47, 92, 193, 29, 173, 50 }, new byte[] { 126, 104, 226, 45, 108, 6, 225, 183, 246, 55, 131, 150, 144, 243, 51, 127, 240, 89, 183, 235, 167, 43, 179, 40, 121, 125, 47, 254, 29, 242, 212, 143, 51, 42, 225, 193, 62, 235, 24, 11, 154, 148, 8, 164, 8, 143, 227, 170, 6, 99, 84, 120, 239, 226, 141, 128, 142, 239, 102, 213, 239, 152, 140, 81, 185, 27, 48, 14, 127, 205, 51, 203, 163, 179, 240, 28, 232, 124, 10, 253, 205, 187, 164, 63, 13, 191, 249, 138, 251, 117, 215, 214, 191, 253, 171, 118, 46, 64, 184, 252, 138, 11, 33, 16, 82, 180, 253, 55, 68, 130, 73, 196, 238, 254, 181, 146, 12, 140, 245, 73, 155, 127, 221, 244, 232, 49, 90, 64 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserName",
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
    }
}
