using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tienda.API.Migrations
{
    /// <inheritdoc />
    public partial class _10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2ef59268-57d4-4933-9ed5-69d7e782256d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64a6fba3-1eba-42db-abbe-79e8508fdc85", "AQAAAAIAAYagAAAAEDvQiIOMDbt3vYwi22rAJMf4QrZBqXESFP5co7H4GvcCOAXkk5UFuRTYgpcvR2pnMQ==", "fd1b2b48-157d-4f83-8e95-9c5fa9e3afdd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac1ea2ae-6cfa-4e37-bace-99a921e2ce3f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69cf1d4d-2f4a-487f-b385-2ba1d9000b48", "AQAAAAIAAYagAAAAEMTiv/rp4yN6i6lzuiqxwLEA7slc30cmvp76c7HDmqBUnloyMx8sAjbP7EL/ITC3eA==", "ed1e64a2-132e-4879-9d5f-3465f5c41f4c" });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Foto",
                value: "https://i.ibb.co/VN7hJHG/camisa.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Foto",
                value: "https://i.ibb.co/mT8Cq6t/pantalon.pngk");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 3,
                column: "Foto",
                value: "https://i.ibb.co/0n11K12/sueter.png");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 4,
                column: "Foto",
                value: "https://i.ibb.co/m5BvxBb/Znike.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2ef59268-57d4-4933-9ed5-69d7e782256d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e7b2bb3-9bc8-4211-8118-2e00950fd848", "AQAAAAIAAYagAAAAED6azbJfnSHnthgIEM/9ZlrQz8IMS/69cKi/wgsSQn35SpWVcrWQft4QJbinrJqDIA==", "bb74b05d-80b9-47be-94e5-daf7550bff88" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac1ea2ae-6cfa-4e37-bace-99a921e2ce3f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01f7dab8-5447-4da3-9b51-a7bc40cf2ecd", "AQAAAAIAAYagAAAAEGmoXKV2pTwawn6Nz9vepljNqVZRClDU/6ckPpyVMOvYcSBajrvsap+uGg54cD59xQ==", "2b24f266-b21e-4df0-8a24-557c4f55882a" });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Foto",
                value: "https://ibb.co/mBLYbvK");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Foto",
                value: "https://ibb.co/chvbmvk");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 3,
                column: "Foto",
                value: "https://ibb.co/51CCkC4");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 4,
                column: "Foto",
                value: "https://ibb.co/SyrXnR0");
        }
    }
}
