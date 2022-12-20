﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webapi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlatNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressID);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    PictureID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bytes = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Filename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Filepath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.PictureID);
                });

            migrationBuilder.CreateTable(
                name: "UserCredentials",
                columns: table => new
                {
                    UserCredentialsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHashed = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UserRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    RefreshToken = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    RefreshTokenExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCredentials", x => x.UserCredentialsID);
                });

            migrationBuilder.CreateTable(
                name: "Salons",
                columns: table => new
                {
                    SalonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WebsiteURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressID = table.Column<int>(type: "int", nullable: false),
                    SalonPicturePictureID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salons", x => x.SalonID);
                    table.ForeignKey(
                        name: "FK_Salons_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Salons_Pictures_SalonPicturePictureID",
                        column: x => x.SalonPicturePictureID,
                        principalTable: "Pictures",
                        principalColumn: "PictureID");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalSpent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserCredentialsID = table.Column<int>(type: "int", nullable: false),
                    ProfilePicturePictureID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Pictures_ProfilePicturePictureID",
                        column: x => x.ProfilePicturePictureID,
                        principalTable: "Pictures",
                        principalColumn: "PictureID");
                    table.ForeignKey(
                        name: "FK_Users_UserCredentials_UserCredentialsID",
                        column: x => x.UserCredentialsID,
                        principalTable: "UserCredentials",
                        principalColumn: "UserCredentialsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Amentities",
                columns: table => new
                {
                    AmentityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconPictureID = table.Column<int>(type: "int", nullable: false),
                    SalonID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amentities", x => x.AmentityID);
                    table.ForeignKey(
                        name: "FK_Amentities_Pictures_IconPictureID",
                        column: x => x.IconPictureID,
                        principalTable: "Pictures",
                        principalColumn: "PictureID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Amentities_Salons_SalonID",
                        column: x => x.SalonID,
                        principalTable: "Salons",
                        principalColumn: "SalonID");
                });

            migrationBuilder.CreateTable(
                name: "AppointmentTypes",
                columns: table => new
                {
                    AppointmentTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LengthMinutes = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalonID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentTypes", x => x.AppointmentTypeID);
                    table.ForeignKey(
                        name: "FK_AppointmentTypes_Salons_SalonID",
                        column: x => x.SalonID,
                        principalTable: "Salons",
                        principalColumn: "SalonID");
                });

            migrationBuilder.CreateTable(
                name: "DayHours",
                columns: table => new
                {
                    DayHoursID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpenTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CloseTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalonID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayHours", x => x.DayHoursID);
                    table.ForeignKey(
                        name: "FK_DayHours_Salons_SalonID",
                        column: x => x.SalonID,
                        principalTable: "Salons",
                        principalColumn: "SalonID");
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    IsCanceled = table.Column<bool>(type: "bit", nullable: false),
                    CalendarAppointmentURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppointmentTypeID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentID);
                    table.ForeignKey(
                        name: "FK_Appointments_AppointmentTypes_AppointmentTypeID",
                        column: x => x.AppointmentTypeID,
                        principalTable: "AppointmentTypes",
                        principalColumn: "AppointmentTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostedTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppointmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_Reviews_Appointments_AppointmentID",
                        column: x => x.AppointmentID,
                        principalTable: "Appointments",
                        principalColumn: "AppointmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amentities_IconPictureID",
                table: "Amentities",
                column: "IconPictureID");

            migrationBuilder.CreateIndex(
                name: "IX_Amentities_SalonID",
                table: "Amentities",
                column: "SalonID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppointmentTypeID",
                table: "Appointments",
                column: "AppointmentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_UserID",
                table: "Appointments",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentTypes_SalonID",
                table: "AppointmentTypes",
                column: "SalonID");

            migrationBuilder.CreateIndex(
                name: "IX_DayHours_SalonID",
                table: "DayHours",
                column: "SalonID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AppointmentID",
                table: "Reviews",
                column: "AppointmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Salons_AddressID",
                table: "Salons",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Salons_SalonPicturePictureID",
                table: "Salons",
                column: "SalonPicturePictureID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProfilePicturePictureID",
                table: "Users",
                column: "ProfilePicturePictureID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserCredentialsID",
                table: "Users",
                column: "UserCredentialsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amentities");

            migrationBuilder.DropTable(
                name: "DayHours");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AppointmentTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Salons");

            migrationBuilder.DropTable(
                name: "UserCredentials");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Pictures");
        }
    }
}