using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tienda.API.Migrations
{
    /// <inheritdoc />
    public partial class InicializarUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6a6a7fcc-37ad-40ab-85f6-e080521661b5", null, "Administrador", "ADMINISTRADOR" },
                    { "6d72daf0-8889-4a79-aaf8-ba6c69a33f3a", null, "Usuario", "USUARIO" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2ef59268-57d4-4933-9ed5-69d7e782256d", 0, "ed8511af-8fbd-4d0f-8f2a-7aed6d9318ae", "usuario@localhost.com", true, false, null, "USUARIO@LOCALHOST.COM", "USUARIO@LOCALHOST.COM", "AQAAAAIAAYagAAAAEHHEpt6GQmkUT90iYiRTh/fBsP+hnrO626RW26hboGYkOf0gIodrA7vz73l0evgMoQ==", null, false, "f49ee39d-dd81-4655-be62-3155c4f8aa40", false, "usuario@localhost.com" },
                    { "ac1ea2ae-6cfa-4e37-bace-99a921e2ce3f", 0, "10446fea-e609-4dbe-8cfa-f94f10c58370", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEOf97RG3P2bJtGvV3Ajde74mWLfq+aCYCNgVh6nTfeW78OJoLQfDcjO3V02QocA7LA==", null, false, "35d3d64e-2284-4e81-9ed0-c04e9a65e8b9", false, "admin@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "6d72daf0-8889-4a79-aaf8-ba6c69a33f3a", "2ef59268-57d4-4933-9ed5-69d7e782256d" },
                    { "6a6a7fcc-37ad-40ab-85f6-e080521661b5", "ac1ea2ae-6cfa-4e37-bace-99a921e2ce3f" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6d72daf0-8889-4a79-aaf8-ba6c69a33f3a", "2ef59268-57d4-4933-9ed5-69d7e782256d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6a6a7fcc-37ad-40ab-85f6-e080521661b5", "ac1ea2ae-6cfa-4e37-bace-99a921e2ce3f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a6a7fcc-37ad-40ab-85f6-e080521661b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d72daf0-8889-4a79-aaf8-ba6c69a33f3a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2ef59268-57d4-4933-9ed5-69d7e782256d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac1ea2ae-6cfa-4e37-bace-99a921e2ce3f");
        }
    }
}
