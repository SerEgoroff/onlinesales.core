﻿// <auto-generated />
using Microsoft.EntityFrameworkCore.Migrations;
using SalesPro.Plugin.TestPlugin.TestData;

#nullable disable

namespace SalesPro.Plugin.TestPlugin.Migrations
{
    /// <inheritdoc />
    public partial class DropColumnTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: ChangeLogMigrationsTestData.AddedColumnName,
                table: "test_entity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // not needed
        }
    }
}