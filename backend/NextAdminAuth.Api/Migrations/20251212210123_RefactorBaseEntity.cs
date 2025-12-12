using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NextAdminAuth.Api.Migrations
{
    /// <inheritdoc />
    public partial class RefactorBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("7d9d5b63-64dc-4575-8110-9d4052e8cad0"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("d4ed220e-1684-4029-b91e-cf67b032f0cd"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("f0539e77-8ab6-49f1-b8f3-c16fba604996"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("fdbbb6f4-eca1-4856-a00a-ae568c49538c"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("1f72af6c-0f97-4ba0-b27a-a895267277aa"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("b07edd47-4fd6-4431-8d2c-0dd681f4df4c"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("e50dd200-6f98-4651-9f06-c0b589ab4835"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("827d783b-15dc-40cc-bb5b-5f6c90368b43"));

            migrationBuilder.DeleteData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: new Guid("86209540-e680-4672-866b-a0461eacfe25"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Screens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Screens",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Roles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Roles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Permissions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Permissions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "MenuItems",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Icon", "IsActive", "IsDeleted", "Order", "ParentId", "Path", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0e3bbee9-1dc6-40ee-b16d-23bf119efbb4"), new DateTime(2025, 12, 12, 21, 1, 22, 667, DateTimeKind.Utc).AddTicks(2670), null, "Settings", true, false, 3, null, "/dashboard/settings", "Ayarlar", new DateTime(2025, 12, 12, 21, 1, 22, 667, DateTimeKind.Utc).AddTicks(2670) },
                    { new Guid("110bed69-34fc-4354-8ecb-440cb77c35c1"), new DateTime(2025, 12, 12, 21, 1, 22, 667, DateTimeKind.Utc).AddTicks(990), null, "LayoutDashboard", true, false, 1, null, "/dashboard", "Ana Sayfa", new DateTime(2025, 12, 12, 21, 1, 22, 667, DateTimeKind.Utc).AddTicks(990) },
                    { new Guid("550c6f29-6893-4134-942a-1f5ea44f4991"), new DateTime(2025, 12, 12, 21, 1, 22, 667, DateTimeKind.Utc).AddTicks(2670), null, "Users", true, false, 2, null, "#", "Yönetim", new DateTime(2025, 12, 12, 21, 1, 22, 667, DateTimeKind.Utc).AddTicks(2670) }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("72f8c5a2-9b1e-4239-847e-123456789abc"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 12, 21, 1, 22, 668, DateTimeKind.Utc).AddTicks(200), new DateTime(2025, 12, 12, 21, 1, 22, 668, DateTimeKind.Utc).AddTicks(200) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c7b013f0-5201-4317-a5d4-9d0a5198f2f4"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 12, 21, 1, 22, 668, DateTimeKind.Utc).AddTicks(190), new DateTime(2025, 12, 12, 21, 1, 22, 668, DateTimeKind.Utc).AddTicks(200) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d8663e5e-7494-4f81-8739-6e0de1c9858b"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 12, 21, 1, 22, 667, DateTimeKind.Utc).AddTicks(9920), new DateTime(2025, 12, 12, 21, 1, 22, 667, DateTimeKind.Utc).AddTicks(9920) });

            migrationBuilder.InsertData(
                table: "Screens",
                columns: new[] { "Id", "Code", "CreatedAt", "DeletedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[] { new Guid("4b545f7e-34fd-445e-b0aa-962843ce1540"), "PAGE_CUSTOMERS", new DateTime(2025, 12, 12, 21, 1, 22, 668, DateTimeKind.Utc).AddTicks(630), null, false, "Customers", new DateTime(2025, 12, 12, 21, 1, 22, 668, DateTimeKind.Utc).AddTicks(630) });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Icon", "IsActive", "IsDeleted", "Order", "ParentId", "Path", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("320ac7fd-17f9-4ae3-833c-a389924320c0"), new DateTime(2025, 12, 12, 21, 1, 22, 667, DateTimeKind.Utc).AddTicks(3000), null, "Users", true, false, 2, new Guid("550c6f29-6893-4134-942a-1f5ea44f4991"), "/dashboard/customers", "Müşteriler", new DateTime(2025, 12, 12, 21, 1, 22, 667, DateTimeKind.Utc).AddTicks(3000) },
                    { new Guid("7c5f2c1f-069b-46a5-b5f0-e4171a2104e4"), new DateTime(2025, 12, 12, 21, 1, 22, 667, DateTimeKind.Utc).AddTicks(2670), null, "User", true, false, 1, new Guid("550c6f29-6893-4134-942a-1f5ea44f4991"), "/dashboard/users", "Kullanıcılar", new DateTime(2025, 12, 12, 21, 1, 22, 667, DateTimeKind.Utc).AddTicks(2680) }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CanCreate", "CanDelete", "CanRead", "CanUpdate", "CreatedAt", "DeletedAt", "IsDeleted", "RoleId", "ScreenId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("277deb13-6bf9-473b-ab50-3c644a66c18e"), true, true, true, true, new DateTime(2025, 12, 12, 21, 1, 22, 668, DateTimeKind.Utc).AddTicks(1550), null, false, new Guid("d8663e5e-7494-4f81-8739-6e0de1c9858b"), new Guid("4b545f7e-34fd-445e-b0aa-962843ce1540"), new DateTime(2025, 12, 12, 21, 1, 22, 668, DateTimeKind.Utc).AddTicks(1550) },
                    { new Guid("2e797c0c-82ae-4d92-a756-0d3495826c94"), false, false, true, false, new DateTime(2025, 12, 12, 21, 1, 22, 668, DateTimeKind.Utc).AddTicks(3010), null, false, new Guid("72f8c5a2-9b1e-4239-847e-123456789abc"), new Guid("4b545f7e-34fd-445e-b0aa-962843ce1540"), new DateTime(2025, 12, 12, 21, 1, 22, 668, DateTimeKind.Utc).AddTicks(3010) },
                    { new Guid("37e079a4-ba94-472d-9516-7cf3b842f0ee"), true, true, true, true, new DateTime(2025, 12, 12, 21, 1, 22, 668, DateTimeKind.Utc).AddTicks(3000), null, false, new Guid("c7b013f0-5201-4317-a5d4-9d0a5198f2f4"), new Guid("4b545f7e-34fd-445e-b0aa-962843ce1540"), new DateTime(2025, 12, 12, 21, 1, 22, 668, DateTimeKind.Utc).AddTicks(3000) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("0e3bbee9-1dc6-40ee-b16d-23bf119efbb4"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("110bed69-34fc-4354-8ecb-440cb77c35c1"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("320ac7fd-17f9-4ae3-833c-a389924320c0"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("7c5f2c1f-069b-46a5-b5f0-e4171a2104e4"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("277deb13-6bf9-473b-ab50-3c644a66c18e"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("2e797c0c-82ae-4d92-a756-0d3495826c94"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("37e079a4-ba94-472d-9516-7cf3b842f0ee"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("550c6f29-6893-4134-942a-1f5ea44f4991"));

            migrationBuilder.DeleteData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: new Guid("4b545f7e-34fd-445e-b0aa-962843ce1540"));

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "MenuItems");

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Icon", "IsActive", "IsDeleted", "Order", "ParentId", "Path", "Title" },
                values: new object[,]
                {
                    { new Guid("827d783b-15dc-40cc-bb5b-5f6c90368b43"), new DateTime(2025, 12, 12, 20, 55, 29, 526, DateTimeKind.Utc).AddTicks(2490), null, "Users", true, false, 2, null, "#", "Yönetim" },
                    { new Guid("f0539e77-8ab6-49f1-b8f3-c16fba604996"), new DateTime(2025, 12, 12, 20, 55, 29, 526, DateTimeKind.Utc).AddTicks(1400), null, "LayoutDashboard", true, false, 1, null, "/dashboard", "Ana Sayfa" },
                    { new Guid("fdbbb6f4-eca1-4856-a00a-ae568c49538c"), new DateTime(2025, 12, 12, 20, 55, 29, 526, DateTimeKind.Utc).AddTicks(2490), null, "Settings", true, false, 3, null, "/dashboard/settings", "Ayarlar" }
                });

            migrationBuilder.InsertData(
                table: "Screens",
                columns: new[] { "Id", "Code", "DeletedAt", "IsDeleted", "Name" },
                values: new object[] { new Guid("86209540-e680-4672-866b-a0461eacfe25"), "PAGE_CUSTOMERS", null, false, "Customers" });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Icon", "IsActive", "IsDeleted", "Order", "ParentId", "Path", "Title" },
                values: new object[,]
                {
                    { new Guid("7d9d5b63-64dc-4575-8110-9d4052e8cad0"), new DateTime(2025, 12, 12, 20, 55, 29, 526, DateTimeKind.Utc).AddTicks(2490), null, "User", true, false, 1, new Guid("827d783b-15dc-40cc-bb5b-5f6c90368b43"), "/dashboard/users", "Kullanıcılar" },
                    { new Guid("d4ed220e-1684-4029-b91e-cf67b032f0cd"), new DateTime(2025, 12, 12, 20, 55, 29, 526, DateTimeKind.Utc).AddTicks(2690), null, "Users", true, false, 2, new Guid("827d783b-15dc-40cc-bb5b-5f6c90368b43"), "/dashboard/customers", "Müşteriler" }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CanCreate", "CanDelete", "CanRead", "CanUpdate", "DeletedAt", "IsDeleted", "RoleId", "ScreenId" },
                values: new object[,]
                {
                    { new Guid("1f72af6c-0f97-4ba0-b27a-a895267277aa"), true, true, true, true, null, false, new Guid("c7b013f0-5201-4317-a5d4-9d0a5198f2f4"), new Guid("86209540-e680-4672-866b-a0461eacfe25") },
                    { new Guid("b07edd47-4fd6-4431-8d2c-0dd681f4df4c"), true, true, true, true, null, false, new Guid("d8663e5e-7494-4f81-8739-6e0de1c9858b"), new Guid("86209540-e680-4672-866b-a0461eacfe25") },
                    { new Guid("e50dd200-6f98-4651-9f06-c0b589ab4835"), false, false, true, false, null, false, new Guid("72f8c5a2-9b1e-4239-847e-123456789abc"), new Guid("86209540-e680-4672-866b-a0461eacfe25") }
                });
        }
    }
}
