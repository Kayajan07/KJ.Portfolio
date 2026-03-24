using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KJ.Portfolio.WebUI.Migrations
{
    /// <inheritdoc />
    public partial class yearModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "HeroExperienceListYear",
                table: "HomePages",
                type: "date",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "HeroExperienceListYear",
                table: "HomePages",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);
        }
    }
}
