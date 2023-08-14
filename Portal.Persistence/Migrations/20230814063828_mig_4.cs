using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portal.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "color",
                table: "etkinliks");

            migrationBuilder.AddColumn<bool>(
                name: "allDay",
                table: "etkinliks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "allDay",
                table: "etkinliks");

            migrationBuilder.AddColumn<string>(
                name: "color",
                table: "etkinliks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
