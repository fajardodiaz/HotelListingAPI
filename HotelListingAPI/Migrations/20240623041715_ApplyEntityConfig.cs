using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelListingAPI.Migrations
{
    /// <inheritdoc />
    public partial class ApplyEntityConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "431d314f-c65c-48c4-9bf7-ee82968b9d29", null, "Administrator", "ADMINISTRATOR" },
                    { "7cfdff1f-78a0-4c6c-95be-7185305649c5", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "431d314f-c65c-48c4-9bf7-ee82968b9d29");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cfdff1f-78a0-4c6c-95be-7185305649c5");
        }
    }
}
