using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class addBarberwithServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "barbers",
                columns: table => new
                {
                    BarberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    ShopName = table.Column<string>(type: "Nvarchar(30)", maxLength: 30, nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(3,1)", precision: 3, scale: 1, nullable: false, defaultValue: 0m),
                    Location = table.Column<string>(type: "Nvarchar(30)", maxLength: 30, nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_barbers", x => x.BarberID);
                    table.ForeignKey(
                        name: "FK_barbers_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_barbers_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "barberServices",
                columns: table => new
                {
                    BarberServiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarberID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(3,1)", precision: 18, scale: 2, nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    ServiceDetilasID = table.Column<short>(type: "smallint", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_barberServices", x => x.BarberServiceID);
                    table.ForeignKey(
                        name: "FK_barberServices_ServicesDetials_ServiceDetilasID",
                        column: x => x.ServiceDetilasID,
                        principalTable: "ServicesDetials",
                        principalColumn: "ServiceDetilasID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_barberServices_barbers_BarberID",
                        column: x => x.BarberID,
                        principalTable: "barbers",
                        principalColumn: "BarberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_barbers_PersonID",
                table: "barbers",
                column: "PersonID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_barbers_UserID",
                table: "barbers",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_barberServices_BarberID_ServiceDetilasID",
                table: "barberServices",
                columns: new[] { "BarberID", "ServiceDetilasID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_barberServices_ServiceDetilasID",
                table: "barberServices",
                column: "ServiceDetilasID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "barberServices");

            migrationBuilder.DropTable(
                name: "barbers");
        }
    }
}
