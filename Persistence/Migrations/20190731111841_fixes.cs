using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendanceItems");

            migrationBuilder.DropTable(
                name: "AttendanceMachines");

            migrationBuilder.CreateTable(
                name: "AttendanceEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EventName = table.Column<string>(nullable: true),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    AllowMultiple = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PersonID = table.Column<string>(nullable: true),
                    AttendanceEntry = table.Column<int>(nullable: false),
                    AttendanceDate = table.Column<DateTime>(nullable: false),
                    EventId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendances_AttendanceEvents_EventId",
                        column: x => x.EventId,
                        principalTable: "AttendanceEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_EventId",
                table: "Attendances",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "AttendanceEvents");

            migrationBuilder.CreateTable(
                name: "AttendanceMachines",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AllowMultiple = table.Column<bool>(nullable: false),
                    AttendanceEvent = table.Column<string>(nullable: true),
                    Duration = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceMachines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AttendanceDate = table.Column<DateTime>(nullable: false),
                    AttendanceEntry = table.Column<int>(nullable: false),
                    MachineId = table.Column<Guid>(nullable: true),
                    PersonID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendanceItems_AttendanceMachines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "AttendanceMachines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceItems_MachineId",
                table: "AttendanceItems",
                column: "MachineId");
        }
    }
}
