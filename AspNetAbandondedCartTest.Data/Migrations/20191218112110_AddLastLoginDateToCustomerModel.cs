using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetAbandondedCartTest.Data.Migrations
{
    public partial class AddLastLoginDateToCustomerModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginDate",
                table: "AspNetUsers",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2019, 12, 18, 12, 21, 9, 343, DateTimeKind.Local).AddTicks(3057));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastLoginDate",
                table: "AspNetUsers");
        }
    }
}
