using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NextAdminAuth.Api.Migrations
{
    /// <inheritdoc />
    public partial class SwitchToRoleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "Users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Screens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ScreenId = table.Column<Guid>(type: "uuid", nullable: false),
                    CanRead = table.Column<bool>(type: "boolean", nullable: false),
                    CanCreate = table.Column<bool>(type: "boolean", nullable: false),
                    CanUpdate = table.Column<bool>(type: "boolean", nullable: false),
                    CanDelete = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permissions_Screens_ScreenId",
                        column: x => x.ScreenId,
                        principalTable: "Screens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "CreatedAt", "Icon", "IsActive", "Order", "Path", "Title" },
                values: new object[,]
                {
                    { new Guid("6da95698-e761-4cec-9481-895772867f4a"), new DateTime(2025, 12, 9, 18, 39, 21, 255, DateTimeKind.Utc).AddTicks(2660), "Settings", true, 4, "/dashboard/settings", "Ayarlar" },
                    { new Guid("7f6308e1-3a5f-4f00-af2d-ea0327561f8e"), new DateTime(2025, 12, 9, 18, 39, 21, 255, DateTimeKind.Utc).AddTicks(2650), "Users", true, 3, "/dashboard/customers", "Müşteriler" },
                    { new Guid("c03102e1-d560-4ee6-80c0-96813229dd52"), new DateTime(2025, 12, 9, 18, 39, 21, 255, DateTimeKind.Utc).AddTicks(1830), "LayoutDashboard", true, 1, "/dashboard", "Ana Sayfa" },
                    { new Guid("e58d1b0b-b67b-4f47-bf5b-7db9389ea95e"), new DateTime(2025, 12, 9, 18, 39, 21, 255, DateTimeKind.Utc).AddTicks(2640), "Users", true, 2, "/dashboard/users", "Kullanıcılar" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), null, "SuperAdmin" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), null, "Admin" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), null, "User" }
                });

            migrationBuilder.InsertData(
                table: "Screens",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("1c81725d-d806-4b7f-866b-2beeca8325b1"), "PAGE_CUSTOMERS", "Customers" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CanCreate", "CanDelete", "CanRead", "CanUpdate", "RoleId", "ScreenId" },
                values: new object[,]
                {
                    { new Guid("2a677c1b-32f7-4c5e-ac1c-5b90c8c12c3c"), false, false, true, false, new Guid("33333333-3333-3333-3333-333333333333"), new Guid("1c81725d-d806-4b7f-866b-2beeca8325b1") },
                    { new Guid("538db3c5-4b5b-4339-bf52-021ab8e659b2"), true, true, true, true, new Guid("11111111-1111-1111-1111-111111111111"), new Guid("1c81725d-d806-4b7f-866b-2beeca8325b1") },
                    { new Guid("a643690a-80c7-4eeb-b223-f33aa45c0690"), true, true, true, true, new Guid("22222222-2222-2222-2222-222222222222"), new Guid("1c81725d-d806-4b7f-866b-2beeca8325b1") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_RoleId",
                table: "Permissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ScreenId",
                table: "Permissions",
                column: "ScreenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Screens");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("6da95698-e761-4cec-9481-895772867f4a"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("7f6308e1-3a5f-4f00-af2d-ea0327561f8e"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("c03102e1-d560-4ee6-80c0-96813229dd52"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("e58d1b0b-b67b-4f47-bf5b-7db9389ea95e"));

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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
        }
    }
}
