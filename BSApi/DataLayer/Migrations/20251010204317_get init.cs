using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class getinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "AspNetRoles",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        NormalizedName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUsers",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
            //        UserName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
            //        NormalizedUserName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
            //        Email = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
            //        NormalizedEmail = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
            //        EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        PasswordHash = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
            //        SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
            //        PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
            //        LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        AccessFailedCount = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "People",
            //    columns: table => new
            //    {
            //        PersonID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FirstName = table.Column<string>(type: "Nvarchar(30)", maxLength: 30, nullable: false),
            //        SecondName = table.Column<string>(type: "Nvarchar(30)", maxLength: 30, nullable: false),
            //        LastName = table.Column<string>(type: "Nvarchar(30)", maxLength: 30, nullable: false),
            //        Phone = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: true),
            //        Enabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_People", x => x.PersonID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "servics",
            //    columns: table => new
            //    {
            //        ServiceID = table.Column<short>(type: "smallint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ServiceName = table.Column<string>(type: "Nvarchar(30)", maxLength: 30, nullable: false),
            //        price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
            //        duration = table.Column<TimeSpan>(type: "time", nullable: false),
            //        Enabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_servics", x => x.ServiceID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Speclitys",
            //    columns: table => new
            //    {
            //        SpecilityID = table.Column<short>(type: "smallint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SpecilityName = table.Column<string>(type: "Nvarchar(30)", maxLength: 30, nullable: false),
            //        Description = table.Column<string>(type: "Nvarchar(100)", maxLength: 100, nullable: true),
            //        Enabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Speclitys", x => x.SpecilityID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetRoleClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        RoleId = table.Column<int>(type: "int", nullable: false),
            //        ClaimType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
            //        ClaimValue = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<int>(type: "int", nullable: false),
            //        ClaimType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
            //        ClaimValue = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserClaims_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserLogins",
            //    columns: table => new
            //    {
            //        LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UserId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserLogins_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserRoles",
            //    columns: table => new
            //    {
            //        UserId = table.Column<int>(type: "int", nullable: false),
            //        RoleId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserTokens",
            //    columns: table => new
            //    {
            //        UserId = table.Column<int>(type: "int", nullable: false),
            //        LoginProvider = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
            //        Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
            //        Value = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserTokens_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.CreateTable(
                name: "BarberApplications",
                columns: table => new
                {
                    ApplicationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: true),
                    CreatAt = table.Column<DateOnly>(type: "Date", nullable: false, defaultValue: new DateOnly(2025, 10, 10)),
                    UpdateAt = table.Column<DateOnly>(type: "Date", nullable: true),
                    Reason = table.Column<string>(type: "Nvarchar(100)", maxLength: 100, nullable: true),
                    Shop = table.Column<string>(type: "Nvarchar(30)", maxLength: 30, nullable: false),
                    Location = table.Column<string>(type: "Nvarchar(30)", maxLength: 30, nullable: false),
                    CopyFirstName = table.Column<string>(type: "Nvarchar(30)", maxLength: 30, nullable: false),
                    CopySecondName = table.Column<string>(type: "Nvarchar(30)", maxLength: 30, nullable: false),
                    CopyLastName = table.Column<string>(type: "Nvarchar(30)", maxLength: 30, nullable: false),
                    CopyPhone = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: true),
                    Status = table.Column<byte>(type: "TINYINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarberApplications", x => x.ApplicationID);
                    table.ForeignKey(
                        name: "FK_BarberApplications_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BarberApplications_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "PersonID");
                });

            //migrationBuilder.CreateTable(
            //    name: "ServicesDetials",
            //    columns: table => new
            //    {
            //        ServiceDetilasID = table.Column<short>(type: "smallint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SpecilityID = table.Column<short>(type: "smallint", nullable: false),
            //        ServiceID = table.Column<short>(type: "smallint", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ServicesDetials", x => x.ServiceDetilasID);
            //        table.ForeignKey(
            //            name: "FK_ServicesDetials_Speclitys_SpecilityID",
            //            column: x => x.SpecilityID,
            //            principalTable: "Speclitys",
            //            principalColumn: "SpecilityID",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ServicesDetials_servics_ServiceID",
            //            column: x => x.ServiceID,
            //            principalTable: "servics",
            //            principalColumn: "ServiceID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.CreateTable(
                name: "TempBarberServices",
                columns: table => new
                {
                    TempServiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationID = table.Column<int>(type: "int", nullable: false),
                    ServiceDetilasID = table.Column<short>(type: "smallint", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempBarberServices", x => x.TempServiceID);
                    table.ForeignKey(
                        name: "FK_TempBarberServices_BarberApplications_ApplicationID",
                        column: x => x.ApplicationID,
                        principalTable: "BarberApplications",
                        principalColumn: "ApplicationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TempBarberServices_ServicesDetials_ServiceDetilasID",
                        column: x => x.ServiceDetilasID,
                        principalTable: "ServicesDetials",
                        principalColumn: "ServiceDetilasID",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetRoleClaims_RoleId",
            //    table: "AspNetRoleClaims",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles",
            //    column: "NormalizedName",
            //    unique: true,
            //    filter: "[NormalizedName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserClaims_UserId",
            //    table: "AspNetUserClaims",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserLogins_UserId",
            //    table: "AspNetUserLogins",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserRoles_RoleId",
            //    table: "AspNetUserRoles",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "EmailIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedEmail");

            //migrationBuilder.CreateIndex(
            //    name: "UserNameIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedUserName",
            //    unique: true,
            //    filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BarberApplications_PersonID",
                table: "BarberApplications",
                column: "PersonID",
                unique: true,
                filter: "[PersonID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BarberApplications_UserID",
                table: "BarberApplications",
                column: "UserID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ServicesDetials_ServiceID",
            //    table: "ServicesDetials",
            //    column: "ServiceID",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_ServicesDetials_SpecilityID",
            //    table: "ServicesDetials",
            //    column: "SpecilityID");

            migrationBuilder.CreateIndex(
                name: "IX_TempBarberServices_ApplicationID_ServiceDetilasID",
                table: "TempBarberServices",
                columns: new[] { "ApplicationID", "ServiceDetilasID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TempBarberServices_ServiceDetilasID",
                table: "TempBarberServices",
                column: "ServiceDetilasID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "AspNetRoleClaims");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserClaims");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserLogins");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserRoles");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserTokens");

            //migrationBuilder.DropTable(
            //    name: "TempBarberServices");

            //migrationBuilder.DropTable(
            //    name: "AspNetRoles");

            //migrationBuilder.DropTable(
            //    name: "BarberApplications");

            //migrationBuilder.DropTable(
            //    name: "ServicesDetials");

            //migrationBuilder.DropTable(
            //    name: "AspNetUsers");

            //migrationBuilder.DropTable(
            //    name: "People");

            //migrationBuilder.DropTable(
            //    name: "Speclitys");

            //migrationBuilder.DropTable(
            //    name: "servics");

        }
    }
}
