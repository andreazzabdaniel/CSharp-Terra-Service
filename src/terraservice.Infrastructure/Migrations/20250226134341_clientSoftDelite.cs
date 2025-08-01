using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace terraservice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class clientSoftDelite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelited",
                table: "Clients",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelited",
                table: "Clients");
        }
    }
}
