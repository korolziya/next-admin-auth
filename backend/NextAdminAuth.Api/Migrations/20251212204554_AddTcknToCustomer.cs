using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NextAdminAuth.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddTcknToCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("2bd88f4a-5547-4f22-a04a-77815c88519c"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("8186d3fc-b8c3-4dbb-8c3e-f933c4b8ed8b"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("b10d7ed6-2217-410a-b310-9c993286ef04"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("cf15deb7-06ff-4573-bb11-0a853938c624"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("bbdf8a70-e10d-4cbb-bb9d-05ab3333a2b4"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("d5e2910e-ca1a-469e-a109-82356a4f840c"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("f775c6be-3e5f-4793-b1f6-d0faaf472fb5"));

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: new Guid("f814ab62-ffc8-48fe-b9e8-e049edb1dec0"));

            migrationBuilder.DeleteData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: new Guid("46b9bd47-073d-4151-9dba-1607d604be7a"));

            migrationBuilder.AddColumn<string>(
                name: "Tckn",
                table: "Customers",
                type: "character varying(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Tckn",
                table: "Customers",
                column: "Tckn",
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Customer_Tckn_NoLeadingZero",
                table: "Customers",
                sql: "\"Tckn\" NOT LIKE '0%'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_Tckn",
                table: "Customers");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Customer_Tckn_NoLeadingZero",
                table: "Customers");

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

            migrationBuilder.DropColumn(
                name: "Tckn",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "CreatedAt", "Icon", "IsActive", "Order", "ParentId", "Path", "Title" },
                values: new object[,]
                {
                    { new Guid("2bd88f4a-5547-4f22-a04a-77815c88519c"), new DateTime(2025, 12, 11, 18, 46, 19, 395, DateTimeKind.Utc).AddTicks(6290), "Settings", true, 3, null, "/dashboard/settings", "Ayarlar" },
                    { new Guid("cf15deb7-06ff-4573-bb11-0a853938c624"), new DateTime(2025, 12, 11, 18, 46, 19, 395, DateTimeKind.Utc).AddTicks(5270), "LayoutDashboard", true, 1, null, "/dashboard", "Ana Sayfa" },
                    { new Guid("f814ab62-ffc8-48fe-b9e8-e049edb1dec0"), new DateTime(2025, 12, 11, 18, 46, 19, 395, DateTimeKind.Utc).AddTicks(6290), "Users", true, 2, null, "#", "Yönetim" }
                });

            migrationBuilder.InsertData(
                table: "Screens",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { new Guid("46b9bd47-073d-4151-9dba-1607d604be7a"), "PAGE_CUSTOMERS", "Customers" });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "CreatedAt", "Icon", "IsActive", "Order", "ParentId", "Path", "Title" },
                values: new object[,]
                {
                    { new Guid("8186d3fc-b8c3-4dbb-8c3e-f933c4b8ed8b"), new DateTime(2025, 12, 11, 18, 46, 19, 395, DateTimeKind.Utc).AddTicks(6290), "User", true, 1, new Guid("f814ab62-ffc8-48fe-b9e8-e049edb1dec0"), "/dashboard/users", "Kullanıcılar" },
                    { new Guid("b10d7ed6-2217-410a-b310-9c993286ef04"), new DateTime(2025, 12, 11, 18, 46, 19, 395, DateTimeKind.Utc).AddTicks(6490), "Users", true, 2, new Guid("f814ab62-ffc8-48fe-b9e8-e049edb1dec0"), "/dashboard/customers", "Müşteriler" }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CanCreate", "CanDelete", "CanRead", "CanUpdate", "RoleId", "ScreenId" },
                values: new object[,]
                {
                    { new Guid("bbdf8a70-e10d-4cbb-bb9d-05ab3333a2b4"), true, true, true, true, new Guid("d8663e5e-7494-4f81-8739-6e0de1c9858b"), new Guid("46b9bd47-073d-4151-9dba-1607d604be7a") },
                    { new Guid("d5e2910e-ca1a-469e-a109-82356a4f840c"), true, true, true, true, new Guid("c7b013f0-5201-4317-a5d4-9d0a5198f2f4"), new Guid("46b9bd47-073d-4151-9dba-1607d604be7a") },
                    { new Guid("f775c6be-3e5f-4793-b1f6-d0faaf472fb5"), false, false, true, false, new Guid("72f8c5a2-9b1e-4239-847e-123456789abc"), new Guid("46b9bd47-073d-4151-9dba-1607d604be7a") }
                });
        }
    }
}
