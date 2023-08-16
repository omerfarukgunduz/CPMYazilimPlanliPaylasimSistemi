using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portal.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TekrarNum",
                table: "etkinliks",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TekrarNum",
                table: "etkinliks");
        }
    }
}
