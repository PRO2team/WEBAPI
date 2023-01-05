using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webapi.Migrations
{
    public partial class AddedNewProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Appointments",
                newName: "DateTo");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFrom",
                table: "Appointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "DateTo",
                table: "Appointments",
                newName: "Date");
        }
    }
}
