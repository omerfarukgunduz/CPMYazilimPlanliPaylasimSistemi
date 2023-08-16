using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portal.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "linkedin",
                table: "etkinliks");

            migrationBuilder.DropColumn(
                name: "whatsapp",
                table: "etkinliks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "linkedin",
                table: "etkinliks",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "whatsapp",
                table: "etkinliks",
                type: "bit",
                nullable: true);
        }
    }
}
