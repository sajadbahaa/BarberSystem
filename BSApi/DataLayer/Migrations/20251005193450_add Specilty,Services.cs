using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class addSpeciltyServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "servics",
                columns: table => new
                {
                    ServiceID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "Nvarchar(30)", maxLength: 30, nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servics", x => x.ServiceID);
                });

            migrationBuilder.CreateTable(
                name: "Speclitys",
                columns: table => new
                {
                    SpecilityID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecilityName = table.Column<string>(type: "Nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "Nvarchar(100)", maxLength: 100, nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speclitys", x => x.SpecilityID);
                });

            migrationBuilder.CreateTable(
                name: "ServicesDetials",
                columns: table => new
                {
                    ServiceDetilasID = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecilityID = table.Column<short>(type: "smallint", nullable: false),
                    ServiceID = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesDetials", x => x.ServiceDetilasID);
                    table.ForeignKey(
                        name: "FK_ServicesDetials_Speclitys_SpecilityID",
                        column: x => x.SpecilityID,
                        principalTable: "Speclitys",
                        principalColumn: "SpecilityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicesDetials_servics_ServiceID",
                        column: x => x.ServiceID,
                        principalTable: "servics",
                        principalColumn: "ServiceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServicesDetials_ServiceID",
                table: "ServicesDetials",
                column: "ServiceID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServicesDetials_SpecilityID",
                table: "ServicesDetials",
                column: "SpecilityID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicesDetials");

            migrationBuilder.DropTable(
                name: "Speclitys");

            migrationBuilder.DropTable(
                name: "servics");
        }
    }
}
