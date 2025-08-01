using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace terraservice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeumidadetables3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Result",
                table: "Umidade",
                type: "float",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Result",
                table: "Umidade");
        }
    }
}
