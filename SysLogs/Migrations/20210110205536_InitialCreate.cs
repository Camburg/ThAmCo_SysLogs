using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SysLogs.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SystemLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ComponentName = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    AlertType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemLogs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemLogs");
        }
    }
}
