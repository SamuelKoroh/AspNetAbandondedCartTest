using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetAbandondedCartTest.Data.Migrations
{
    public partial class SeedProductWithSampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastLoginDate",
                table: "AspNetUsers",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2019, 12, 20, 5, 48, 12, 488, DateTimeKind.Local).AddTicks(4656),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2019, 12, 20, 5, 44, 36, 930, DateTimeKind.Local).AddTicks(3736));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastLoginDate",
                table: "AspNetUsers",
                type: "DateTime",
                nullable: false,
                defaultValue: new DateTime(2019, 12, 20, 5, 44, 36, 930, DateTimeKind.Local).AddTicks(3736),
                oldClrType: typeof(DateTime),
                oldType: "DateTime",
                oldDefaultValue: new DateTime(2019, 12, 20, 5, 48, 12, 488, DateTimeKind.Local).AddTicks(4656));
        }
    }
}
