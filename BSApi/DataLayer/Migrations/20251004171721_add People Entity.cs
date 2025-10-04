using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class addPeopleEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "Nvarchar(30)", maxLength: 30, nullable: false),
                    SecondName = table.Column<string>(type: "Nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "Nvarchar(30)", maxLength: 30, nullable: false),
                    Phone = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: true),
                    Email = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
