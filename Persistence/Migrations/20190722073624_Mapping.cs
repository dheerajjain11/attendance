using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Mapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MachineId",
                table: "AttendanceItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceItems_MachineId",
                table: "AttendanceItems",
                column: "MachineId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceItems_AttendanceMachines_MachineId",
                table: "AttendanceItems",
                column: "MachineId",
                principalTable: "AttendanceMachines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceItems_AttendanceMachines_MachineId",
                table: "AttendanceItems");

            migrationBuilder.DropIndex(
                name: "IX_AttendanceItems_MachineId",
                table: "AttendanceItems");

            migrationBuilder.DropColumn(
                name: "MachineId",
                table: "AttendanceItems");
        }
    }
}
