using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NextAdminAuth.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesAndCustomers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("334dd663-7d5b-4e78-9151-bf79cd6f1b80"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("a740d3a8-0503-4043-af6a-918cd5ab5707"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("f96bd912-5f71-40d1-9429-ca81626de736"));

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "CreatedAt", "Icon", "IsActive", "Order", "Path", "Title" },
                values: new object[,]
                {
                    { new Guid("2a542ff1-45ae-41f0-b573-32a71cd731ba"), new DateTime(2025, 12, 9, 18, 12, 16, 901, DateTimeKind.Utc).AddTicks(4600), "Users", true, 3, "/dashboard/customers", "Müşteriler" },
                    { new Guid("412c4579-21d8-4244-acca-5a96b2e4ac39"), new DateTime(2025, 12, 9, 18, 12, 16, 901, DateTimeKind.Utc).AddTicks(4610), "Settings", true, 4, "/dashboard/settings", "Ayarlar" },
                    { new Guid("c3b7265a-7fb5-4bf2-bfa9-e0971e2d284d"), new DateTime(2025, 12, 9, 18, 12, 16, 901, DateTimeKind.Utc).AddTicks(3690), "LayoutDashboard", true, 1, "/dashboard", "Ana Sayfa" },
                    { new Guid("fb60308c-cc6d-42bd-9311-cc8d58b07a26"), new DateTime(2025, 12, 9, 18, 12, 16, 901, DateTimeKind.Utc).AddTicks(4590), "Users", true, 2, "/dashboard/users", "Kullanıcılar" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CompanyId",
                table: "Customers",
                column: "CompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("2a542ff1-45ae-41f0-b573-32a71cd731ba"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("412c4579-21d8-4244-acca-5a96b2e4ac39"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("c3b7265a-7fb5-4bf2-bfa9-e0971e2d284d"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("fb60308c-cc6d-42bd-9311-cc8d58b07a26"));

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

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
    }
}
