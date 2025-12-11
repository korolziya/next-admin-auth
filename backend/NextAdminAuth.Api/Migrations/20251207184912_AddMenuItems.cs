using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NextAdminAuth.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddMenuItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "CreatedAt", "Icon", "IsActive", "Order", "Path", "Title" },
                values: new object[,]
                {
                    { new Guid("334dd663-7d5b-4e78-9151-bf79cd6f1b80"), new DateTime(2025, 12, 7, 18, 49, 12, 303, DateTimeKind.Utc).AddTicks(2250), "Users", true, 2, "/dashboard/users", "Kullanıcılar" },
                    { new Guid("a740d3a8-0503-4043-af6a-918cd5ab5707"), new DateTime(2025, 12, 7, 18, 49, 12, 303, DateTimeKind.Utc).AddTicks(1340), "LayoutDashboard", true, 1, "/dashboard", "Ana Sayfa" },
                    { new Guid("f96bd912-5f71-40d1-9429-ca81626de736"), new DateTime(2025, 12, 7, 18, 49, 12, 303, DateTimeKind.Utc).AddTicks(2260), "Settings", true, 3, "/dashboard/settings", "Ayarlar" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItems");
        }
    }
}
