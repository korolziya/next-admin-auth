using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NextAdminAuth.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddSoftDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("004c9771-18fa-4c36-bc55-e1b941d5325f"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("840f6688-cdb4-4f8d-8628-c1eee72311fe"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("a8170adc-ec96-45bf-9ebf-dfafe5de1a5c"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("f0fb08cd-0dc3-42e0-b5a0-e84f31357028"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("6c38eb97-7a71-4d44-b22a-abc0d7eda8cd"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("840c5027-452e-44e6-924a-14db4befbcee"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("bec2da88-5abf-4e3e-baba-a1e3c757566d"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("7934b421-c4c6-422a-b3f4-13b214eff34d"));

            migrationBuilder.DeleteData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: new Guid("115a8021-9420-44c3-bb6b-4f55178f3f93"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Screens",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Screens",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Roles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Roles",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Permissions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Permissions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "MenuItems",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MenuItems",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Customers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Customers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Companies",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Companies",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Icon", "IsActive", "IsDeleted", "Order", "ParentId", "Path", "Title" },
                values: new object[,]
                {
                    { new Guid("827d783b-15dc-40cc-bb5b-5f6c90368b43"), new DateTime(2025, 12, 12, 20, 55, 29, 526, DateTimeKind.Utc).AddTicks(2490), null, "Users", true, false, 2, null, "#", "Yönetim" },
                    { new Guid("f0539e77-8ab6-49f1-b8f3-c16fba604996"), new DateTime(2025, 12, 12, 20, 55, 29, 526, DateTimeKind.Utc).AddTicks(1400), null, "LayoutDashboard", true, false, 1, null, "/dashboard", "Ana Sayfa" },
                    { new Guid("fdbbb6f4-eca1-4856-a00a-ae568c49538c"), new DateTime(2025, 12, 12, 20, 55, 29, 526, DateTimeKind.Utc).AddTicks(2490), null, "Settings", true, false, 3, null, "/dashboard/settings", "Ayarlar" }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("72f8c5a2-9b1e-4239-847e-123456789abc"),
                columns: new[] { "DeletedAt", "IsDeleted" },
                values: new object[] { null, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c7b013f0-5201-4317-a5d4-9d0a5198f2f4"),
                columns: new[] { "DeletedAt", "IsDeleted" },
                values: new object[] { null, false });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d8663e5e-7494-4f81-8739-6e0de1c9858b"),
                columns: new[] { "DeletedAt", "IsDeleted" },
                values: new object[] { null, false });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Screens");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Companies");

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "CreatedAt", "Icon", "IsActive", "Order", "ParentId", "Path", "Title" },
                values: new object[,]
                {
                    { new Guid("004c9771-18fa-4c36-bc55-e1b941d5325f"), new DateTime(2025, 12, 12, 20, 45, 53, 860, DateTimeKind.Utc).AddTicks(2130), "Settings", true, 3, null, "/dashboard/settings", "Ayarlar" },
                    { new Guid("7934b421-c4c6-422a-b3f4-13b214eff34d"), new DateTime(2025, 12, 12, 20, 45, 53, 860, DateTimeKind.Utc).AddTicks(2130), "Users", true, 2, null, "#", "Yönetim" },
                    { new Guid("840f6688-cdb4-4f8d-8628-c1eee72311fe"), new DateTime(2025, 12, 12, 20, 45, 53, 860, DateTimeKind.Utc).AddTicks(1030), "LayoutDashboard", true, 1, null, "/dashboard", "Ana Sayfa" }
                });

            migrationBuilder.InsertData(
                table: "Screens",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("115a8021-9420-44c3-bb6b-4f55178f3f93"), "PAGE_CUSTOMERS", "Customers" });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "CreatedAt", "Icon", "IsActive", "Order", "ParentId", "Path", "Title" },
                values: new object[,]
                {
                    { new Guid("a8170adc-ec96-45bf-9ebf-dfafe5de1a5c"), new DateTime(2025, 12, 12, 20, 45, 53, 860, DateTimeKind.Utc).AddTicks(2330), "Users", true, 2, new Guid("7934b421-c4c6-422a-b3f4-13b214eff34d"), "/dashboard/customers", "Müşteriler" },
                    { new Guid("f0fb08cd-0dc3-42e0-b5a0-e84f31357028"), new DateTime(2025, 12, 12, 20, 45, 53, 860, DateTimeKind.Utc).AddTicks(2130), "User", true, 1, new Guid("7934b421-c4c6-422a-b3f4-13b214eff34d"), "/dashboard/users", "Kullanıcılar" }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CanCreate", "CanDelete", "CanRead", "CanUpdate", "RoleId", "ScreenId" },
                values: new object[,]
                {
                    { new Guid("6c38eb97-7a71-4d44-b22a-abc0d7eda8cd"), true, true, true, true, new Guid("d8663e5e-7494-4f81-8739-6e0de1c9858b"), new Guid("115a8021-9420-44c3-bb6b-4f55178f3f93") },
                    { new Guid("840c5027-452e-44e6-924a-14db4befbcee"), true, true, true, true, new Guid("c7b013f0-5201-4317-a5d4-9d0a5198f2f4"), new Guid("115a8021-9420-44c3-bb6b-4f55178f3f93") },
                    { new Guid("bec2da88-5abf-4e3e-baba-a1e3c757566d"), false, false, true, false, new Guid("72f8c5a2-9b1e-4239-847e-123456789abc"), new Guid("115a8021-9420-44c3-bb6b-4f55178f3f93") }
                });
        }
    }
}
