using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class ReviewAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -1,
                columns: new[] { "Password", "PasswordKey" },
                values: new object[] { new byte[] { 148, 49, 27, 136, 79, 163, 212, 227, 171, 161, 32, 94, 80, 166, 233, 43, 141, 26, 65, 225, 180, 25, 15, 100, 80, 140, 74, 241, 115, 214, 240, 16, 191, 225, 166, 100, 42, 166, 146, 174, 204, 103, 174, 217, 28, 177, 39, 149, 67, 217, 51, 81, 112, 145, 16, 32, 104, 200, 152, 137, 117, 69, 79, 126 }, new byte[] { 93, 124, 69, 178, 16, 7, 107, 197, 255, 18, 184, 12, 172, 21, 245, 85, 61, 7, 56, 228, 238, 111, 196, 221, 50, 4, 243, 213, 200, 51, 69, 25, 175, 34, 34, 117, 106, 210, 135, 224, 136, 147, 44, 212, 119, 36, 168, 8, 39, 87, 233, 245, 142, 98, 106, 9, 153, 94, 255, 68, 246, 4, 84, 185, 86, 185, 83, 14, 198, 67, 187, 175, 230, 80, 53, 8, 0, 21, 240, 206, 4, 224, 86, 249, 154, 202, 242, 94, 177, 101, 135, 61, 173, 19, 236, 142, 123, 197, 116, 167, 98, 244, 120, 4, 244, 143, 229, 123, 43, 233, 34, 172, 78, 109, 248, 122, 82, 80, 207, 21, 164, 34, 120, 177, 47, 75, 216, 75 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: -1,
                columns: new[] { "Password", "PasswordKey" },
                values: new object[] { new byte[] { 31, 105, 83, 174, 33, 116, 232, 92, 57, 109, 149, 233, 71, 136, 10, 36, 9, 97, 189, 129, 31, 117, 61, 10, 212, 61, 188, 176, 238, 161, 240, 89, 225, 204, 153, 42, 126, 147, 177, 128, 107, 158, 40, 160, 58, 170, 101, 179, 150, 178, 43, 249, 167, 95, 76, 163, 54, 194, 190, 153, 61, 155, 131, 160 }, new byte[] { 160, 49, 47, 164, 164, 72, 95, 190, 126, 161, 128, 217, 145, 18, 2, 169, 164, 113, 84, 250, 19, 158, 241, 86, 169, 222, 145, 44, 217, 185, 98, 152, 23, 86, 152, 119, 88, 208, 248, 127, 154, 132, 201, 241, 245, 22, 45, 230, 24, 160, 32, 141, 37, 89, 174, 31, 57, 4, 243, 243, 146, 200, 85, 200, 184, 135, 39, 28, 100, 195, 210, 70, 198, 36, 25, 96, 247, 143, 128, 12, 88, 118, 24, 213, 185, 140, 144, 178, 15, 116, 136, 223, 52, 191, 161, 176, 75, 44, 180, 124, 82, 42, 4, 112, 170, 152, 118, 172, 208, 60, 96, 90, 185, 243, 88, 63, 164, 14, 222, 42, 160, 0, 152, 159, 241, 20, 12, 149 } });
        }
    }
}
