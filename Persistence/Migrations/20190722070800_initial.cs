using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttendanceItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PersonID = table.Column<long>(nullable: false),
                    AttendanceEntry = table.Column<int>(nullable: false),
                    AttendanceDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceMachines",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AttendanceEvent = table.Column<string>(nullable: true),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    AllowMultiple = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceMachines", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendanceItems");

            migrationBuilder.DropTable(
                name: "AttendanceMachines");
        }
    }
}
