using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portal.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TokenUsername",
                table: "AccessTokens");

            migrationBuilder.AlterColumn<string>(
                name: "TokenTitle",
                table: "AccessTokens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TokenTitle",
                table: "AccessTokens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TokenUsername",
                table: "AccessTokens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
