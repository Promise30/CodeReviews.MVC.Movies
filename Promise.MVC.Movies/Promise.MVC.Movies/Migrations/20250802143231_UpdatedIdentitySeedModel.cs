using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Promise.MVC.Movies.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedIdentitySeedModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8e445865-a24d-4543-a6c6-9443d048cdb7", 0, "c8554266-b401-4513-9e3d-9dcf5c6bf8f9", "janedoe@gmail.com", true, false, null, "JANEDOE@GMAIL.COM", "JANEDOE@GMAIL.COM", "AQAAAAIAAYagAAAAEPpjsB2W25waFbwxKMUtB0eDK7DXTimaSfJPrP7glbe0WGyVCsY7B9Av7xDIez4hmw==", null, false, "", false, "janedoe@gmail.com" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdb8", 0, "c8554266-b401-4513-9e3d-9dcf5c6bf8f8", "johndoe@gmail.com", true, false, null, "JOHNDOE@GMAIL.COM", "JOHNDOE@GMAIL.COM", "AQAAAAIAAYagAAAAEPbr2g/tkz59UUzefT046CregZrIT/vTdnBo0JwGTD1QPx2qwyvBg8yYV/cDEz9iOA==", null, false, "", false, "johndoe@gmail.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "2", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "694d9c7c-decb-46f9-bae9-94d2f6c3fb3b", "johndoe@gmail.com", true, false, null, "JOHNDOE@GMAIL.COM", "JOHNDOE", "AQAAAAIAAYagAAAAEHL9jga9mbTptjayg2GUXwUjo8BpUbeYKN+xfewDu4O3YJ3wjDJg2xq3QPp24e4Ywg==", "1234567890", true, "c3a81fab-6839-4eea-894e-1fd066b82ca2", false, "JohnDoe" },
                    { "2", 0, "cd95b0c2-35d1-4e10-a235-3499b5b09a7d", "janedoe@gmail.com", true, false, null, "JANEDOE@GMAIL.COM", "JANEDOE", "AQAAAAIAAYagAAAAEGcLgYduk773EfWooVbzp03KFLjIU1S7XQtleT+uZg8u4oNAyqkF53rKWvCJJb8HdA==", "0987654321", true, "9fff7e89-805c-4afe-bc03-5817f91ad8c2", false, "JaneDoe" }
                });
        }
    }
}
