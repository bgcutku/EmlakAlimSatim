using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmlakAlimSatim.Migrations
{
    /// <inheritdoc />
    public partial class adminlogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "kullanicilars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "KullaniciAdi",
                table: "kullanicilars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "kullanicilars",
                columns: new[] { "KullaniciID", "Ad", "Email", "IsAdmin", "KayitTarihi", "KullaniciAdi", "PhoneNumber", "Role", "SifreHash", "Soyad" },
                values: new object[] { 12, "Admin", "admin@emlakalimsatim.com", false, new DateTime(2026, 3, 1, 18, 58, 8, 306, DateTimeKind.Local).AddTicks(8932), "admin", "1234567890", "Admin", "Admin1234.!", "User" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "kullanicilars",
                keyColumn: "KullaniciID",
                keyValue: 12);

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "kullanicilars");

            migrationBuilder.DropColumn(
                name: "KullaniciAdi",
                table: "kullanicilars");
        }
    }
}
