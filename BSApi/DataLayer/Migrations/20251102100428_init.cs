using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
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
            //        RoleId = table.Column<int>(type: "int", nullable: false),
            //        AppUserId = table.Column<int>(type: "int", nullable: true)
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
            //            name: "FK_AspNetUserRoles_AspNetUsers_AppUserId",
            //            column: x => x.AppUserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id");
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

            //migrationBuilder.CreateTable(
            //    name: "BarberApplications",
            //    columns: table => new
            //    {
            //        ApplicationID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserID = table.Column<int>(type: "int", nullable: false),
            //        PersonID = table.Column<int>(type: "int", nullable: true),
            //        CreatAt = table.Column<DateOnly>(type: "Date", nullable: false),
            //        UpdateAt = table.Column<DateOnly>(type: "Date", nullable: true),
            //        Reason = table.Column<string>(type: "Nvarchar(100)", maxLength: 100, nullable: true),
            //        Shop = table.Column<string>(type: "Nvarchar(30)", maxLength: 30, nullable: false),
            //        Location = table.Column<string>(type: "Nvarchar(30)", maxLength: 30, nullable: false),
            //        CopyFirstName = table.Column<string>(type: "Nvarchar(30)", maxLength: 30, nullable: false),
            //        CopySecondName = table.Column<string>(type: "Nvarchar(30)", maxLength: 30, nullable: false),
            //        CopyLastName = table.Column<string>(type: "Nvarchar(30)", maxLength: 30, nullable: false),
            //        CopyPhone = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: true),
            //        Status = table.Column<byte>(type: "TINYINT", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_BarberApplications", x => x.ApplicationID);
            //        table.ForeignKey(
            //            name: "FK_BarberApplications_AspNetUsers_UserID",
            //            column: x => x.UserID,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_BarberApplications_People_PersonID",
            //            column: x => x.PersonID,
            //            principalTable: "People",
            //            principalColumn: "PersonID");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "barbers",
            //    columns: table => new
            //    {
            //        BarberID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PersonID = table.Column<int>(type: "int", nullable: false),
            //        ShopName = table.Column<string>(type: "Nvarchar(30)", maxLength: 30, nullable: false),
            //        Rating = table.Column<decimal>(type: "decimal(3,1)", precision: 3, scale: 1, nullable: false, defaultValue: 0m),
            //        Location = table.Column<string>(type: "Nvarchar(30)", maxLength: 30, nullable: false),
            //        UserID = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_barbers", x => x.BarberID);
            //        table.ForeignKey(
            //            name: "FK_barbers_AspNetUsers_UserID",
            //            column: x => x.UserID,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_barbers_People_PersonID",
            //            column: x => x.PersonID,
            //            principalTable: "People",
            //            principalColumn: "PersonID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Customers",
            //    columns: table => new
            //    {
            //        CustomerID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PersonID = table.Column<int>(type: "int", nullable: false),
            //        UserID = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Customers", x => x.CustomerID);
            //        table.ForeignKey(
            //            name: "FK_Customers_AspNetUsers_UserID",
            //            column: x => x.UserID,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Customers_People_PersonID",
            //            column: x => x.PersonID,
            //            principalTable: "People",
            //            principalColumn: "PersonID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

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

            //migrationBuilder.CreateTable(
            //    name: "applicationsHistory",
            //    columns: table => new
            //    {
            //        HistoryID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserID = table.Column<int>(type: "int", nullable: false),
            //        ApplicationID = table.Column<int>(type: "int", nullable: false),
            //        Status = table.Column<byte>(type: "TINYINT", nullable: false),
            //        CreateAt = table.Column<DateTime>(type: "datetime", nullable: false),
            //        Notes = table.Column<string>(type: "Nvarchar(100)", maxLength: 100, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_applicationsHistory", x => x.HistoryID);
            //        table.ForeignKey(
            //            name: "FK_applicationsHistory_AspNetUsers_UserID",
            //            column: x => x.UserID,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_applicationsHistory_BarberApplications_ApplicationID",
            //            column: x => x.ApplicationID,
            //            principalTable: "BarberApplications",
            //            principalColumn: "ApplicationID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "barberServices",
            //    columns: table => new
            //    {
            //        BarberServiceID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        BarberID = table.Column<int>(type: "int", nullable: false),
            //        Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
            //        Duration = table.Column<TimeSpan>(type: "time", nullable: false),
            //        ServiceDetilasID = table.Column<short>(type: "smallint", nullable: false),
            //        Enabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_barberServices", x => x.BarberServiceID);
            //        table.ForeignKey(
            //            name: "FK_barberServices_ServicesDetials_ServiceDetilasID",
            //            column: x => x.ServiceDetilasID,
            //            principalTable: "ServicesDetials",
            //            principalColumn: "ServiceDetilasID",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_barberServices_barbers_BarberID",
            //            column: x => x.BarberID,
            //            principalTable: "barbers",
            //            principalColumn: "BarberID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "TempBarberServices",
            //    columns: table => new
            //    {
            //        TempServiceID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ApplicationID = table.Column<int>(type: "int", nullable: false),
            //        ServiceDetilasID = table.Column<short>(type: "smallint", nullable: false),
            //        Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
            //        Duration = table.Column<TimeSpan>(type: "time", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_TempBarberServices", x => x.TempServiceID);
            //        table.ForeignKey(
            //            name: "FK_TempBarberServices_BarberApplications_ApplicationID",
            //            column: x => x.ApplicationID,
            //            principalTable: "BarberApplications",
            //            principalColumn: "ApplicationID",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_TempBarberServices_ServicesDetials_ServiceDetilasID",
            //            column: x => x.ServiceDetilasID,
            //            principalTable: "ServicesDetials",
            //            principalColumn: "ServiceDetilasID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Appointments",
            //    columns: table => new
            //    {
            //        AppointmentID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CustomerID = table.Column<int>(type: "int", nullable: false),
            //        BarberServiceID = table.Column<int>(type: "int", nullable: false),
            //        StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        status = table.Column<byte>(type: "TINYINT", nullable: false),
            //        Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Appointments", x => x.AppointmentID);
            //        table.ForeignKey(
            //            name: "FK_Appointments_Customers_CustomerID",
            //            column: x => x.CustomerID,
            //            principalTable: "Customers",
            //            principalColumn: "CustomerID",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Appointments_barberServices_BarberServiceID",
            //            column: x => x.BarberServiceID,
            //            principalTable: "barberServices",
            //            principalColumn: "BarberServiceID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    RatingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentID = table.Column<int>(type: "int", nullable: false),
                    BarberID = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<byte>(type: "Tinyint", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.RatingID);
                    table.ForeignKey(
                        name: "FK_Ratings_Appointments_AppointmentID",
                        column: x => x.AppointmentID,
                        principalTable: "Appointments",
                        principalColumn: "AppointmentID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Ratings_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Ratings_barbers_BarberID",
                        column: x => x.BarberID,
                        principalTable: "barbers",
                        principalColumn: "BarberID",
                        onDelete: ReferentialAction.NoAction);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_applicationsHistory_ApplicationID",
            //    table: "applicationsHistory",
            //    column: "ApplicationID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_applicationsHistory_UserID",
            //    table: "applicationsHistory",
            //    column: "UserID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Appointments_BarberServiceID_StartDate_EndDate_status",
            //    table: "Appointments",
            //    columns: new[] { "BarberServiceID", "StartDate", "EndDate", "status" });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Appointments_CustomerID",
            //    table: "Appointments",
            //    column: "CustomerID");

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
            //    name: "IX_AspNetUserRoles_AppUserId",
            //    table: "AspNetUserRoles",
            //    column: "AppUserId");

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

            //migrationBuilder.CreateIndex(
            //    name: "IX_BarberApplications_PersonID",
            //    table: "BarberApplications",
            //    column: "PersonID",
            //    unique: true,
            //    filter: "[PersonID] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_BarberApplications_UserID",
            //    table: "BarberApplications",
            //    column: "UserID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_barbers_PersonID",
            //    table: "barbers",
            //    column: "PersonID",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_barbers_UserID",
            //    table: "barbers",
            //    column: "UserID",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_barberServices_BarberID_ServiceDetilasID",
            //    table: "barberServices",
            //    columns: new[] { "BarberID", "ServiceDetilasID" },
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_barberServices_ServiceDetilasID",
            //    table: "barberServices",
            //    column: "ServiceDetilasID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Customers_PersonID",
            //    table: "Customers",
            //    column: "PersonID",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Customers_UserID",
            //    table: "Customers",
            //    column: "UserID",
            //    unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_AppointmentID",
                table: "Ratings",
                column: "AppointmentID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_BarberID",
                table: "Ratings",
                column: "BarberID");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_CustomerID",
                table: "Ratings",
                column: "CustomerID");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ServicesDetials_ServiceID",
        //        table: "ServicesDetials",
        //        column: "ServiceID",
        //        unique: true);

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ServicesDetials_SpecilityID",
        //        table: "ServicesDetials",
        //        column: "SpecilityID");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_TempBarberServices_ApplicationID_ServiceDetilasID",
        //        table: "TempBarberServices",
        //        columns: new[] { "ApplicationID", "ServiceDetilasID" },
        //        unique: true);

        //    migrationBuilder.CreateIndex(
        //        name: "IX_TempBarberServices_ServiceDetilasID",
        //        table: "TempBarberServices",
        //        column: "ServiceDetilasID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "applicationsHistory");

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

            migrationBuilder.DropTable(
                name: "Ratings");

            //migrationBuilder.DropTable(
            //    name: "TempBarberServices");

            //migrationBuilder.DropTable(
            //    name: "AspNetRoles");

            //migrationBuilder.DropTable(
            //    name: "Appointments");

            //migrationBuilder.DropTable(
            //    name: "BarberApplications");

            //migrationBuilder.DropTable(
            //    name: "Customers");

            //migrationBuilder.DropTable(
            //    name: "barberServices");

            //migrationBuilder.DropTable(
            //    name: "ServicesDetials");

            //migrationBuilder.DropTable(
            //    name: "barbers");

            //migrationBuilder.DropTable(
            //    name: "Speclitys");

            //migrationBuilder.DropTable(
            //    name: "servics");

            //migrationBuilder.DropTable(
            //    name: "AspNetUsers");

            //migrationBuilder.DropTable(
            //    name: "People");
        }
    }
}
