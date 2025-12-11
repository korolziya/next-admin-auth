using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NextAdminAuth.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddMenuHierarchy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("2a677c1b-32f7-4c5e-ac1c-5b90c8c12c3c"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("538db3c5-4b5b-4339-bf52-021ab8e659b2"));

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: new Guid("a643690a-80c7-4eeb-b223-f33aa45c0690"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: new Guid("1c81725d-d806-4b7f-866b-2beeca8325b1"));

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "MenuItems",
                type: "uuid",
                nullable: true);

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
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("72f8c5a2-9b1e-4239-847e-123456789abc"), null, "User" },
                    { new Guid("c7b013f0-5201-4317-a5d4-9d0a5198f2f4"), null, "Admin" },
                    { new Guid("d8663e5e-7494-4f81-8739-6e0de1c9858b"), null, "SuperAdmin" }
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

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_ParentId",
                table: "MenuItems",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_MenuItems_ParentId",
                table: "MenuItems",
                column: "ParentId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_MenuItems_ParentId",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_ParentId",
                table: "MenuItems");

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
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("72f8c5a2-9b1e-4239-847e-123456789abc"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c7b013f0-5201-4317-a5d4-9d0a5198f2f4"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d8663e5e-7494-4f81-8739-6e0de1c9858b"));

            migrationBuilder.DeleteData(
                table: "Screens",
                keyColumn: "Id",
                keyValue: new Guid("46b9bd47-073d-4151-9dba-1607d604be7a"));

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "MenuItems");

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
        }
    }
}
