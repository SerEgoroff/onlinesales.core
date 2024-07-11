using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesPro.Migrations
{
    /// <inheritdoc />
    public partial class WellKnownMailServer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "well_known",
                table: "mail_server",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "well_known",
                table: "mail_server");
        }
    }
}
