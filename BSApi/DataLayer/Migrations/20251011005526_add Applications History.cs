using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class addApplicationsHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "CreatAt",
                table: "BarberApplications",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "Date",
                oldDefaultValue: new DateOnly(2025, 10, 10));

            migrationBuilder.CreateTable(
                name: "applicationsHistory",
                columns: table => new
                {
                    HistoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ApplicationID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<byte>(type: "TINYINT", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Notes = table.Column<string>(type: "Nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicationsHistory", x => x.HistoryID);
                    table.ForeignKey(
                        name: "FK_applicationsHistory_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_applicationsHistory_BarberApplications_ApplicationID",
                        column: x => x.ApplicationID,
                        principalTable: "BarberApplications",
                        principalColumn: "ApplicationID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_applicationsHistory_ApplicationID",
                table: "applicationsHistory",
                column: "ApplicationID");

            migrationBuilder.CreateIndex(
                name: "IX_applicationsHistory_UserID",
                table: "applicationsHistory",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "applicationsHistory");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "CreatAt",
                table: "BarberApplications",
                type: "Date",
                nullable: false,
                defaultValue: new DateOnly(2025, 10, 10),
                oldClrType: typeof(DateOnly),
                oldType: "Date");
        }
    }
}
