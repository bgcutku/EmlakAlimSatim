using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmlakAlimSatim.Migrations
{
    /// <inheritdoc />
    public partial class Messagee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Messages",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "kullanicilars",
                keyColumn: "KullaniciID",
                keyValue: 12,
                column: "KayitTarihi",
                value: new DateTime(2026, 3, 4, 1, 30, 8, 32, DateTimeKind.Local).AddTicks(6244));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "kullanicilars",
                keyColumn: "KullaniciID",
                keyValue: 12,
                column: "KayitTarihi",
                value: new DateTime(2026, 3, 1, 23, 45, 37, 44, DateTimeKind.Local).AddTicks(3627));
        }
    }
}
