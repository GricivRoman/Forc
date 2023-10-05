using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forc.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AlterTable_User_AddColumnHasPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasPhoto",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasPhoto",
                table: "AspNetUsers");
        }
    }
}
