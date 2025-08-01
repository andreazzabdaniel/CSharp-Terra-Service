using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace terraservice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeumidadetables4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SsDelited",
                table: "Umidade",
                newName: "IsDelited");

            migrationBuilder.AlterColumn<string>(
                name: "Result",
                table: "Umidade",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<float>(
                name: "ResultMedia",
                table: "Umidade",
                type: "float",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResultMedia",
                table: "Umidade");

            migrationBuilder.RenameColumn(
                name: "IsDelited",
                table: "Umidade",
                newName: "SsDelited");

            migrationBuilder.AlterColumn<float>(
                name: "Result",
                table: "Umidade",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
