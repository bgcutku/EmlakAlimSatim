using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmlakAlimSatim.Migrations
{
    /// <inheritdoc />
    public partial class mesaj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    SendDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "kullanicilars",
                keyColumn: "KullaniciID",
                keyValue: 12,
                column: "KayitTarihi",
                value: new DateTime(2026, 3, 1, 23, 45, 37, 44, DateTimeKind.Local).AddTicks(3627));

            migrationBuilder.CreateIndex(
                name: "IX_Messages_PropertyId",
                table: "Messages",
                column: "PropertyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.UpdateData(
                table: "kullanicilars",
                keyColumn: "KullaniciID",
                keyValue: 12,
                column: "KayitTarihi",
                value: new DateTime(2026, 3, 1, 18, 58, 8, 306, DateTimeKind.Local).AddTicks(8932));
        }
    }
}
