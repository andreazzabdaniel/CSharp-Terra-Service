using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace terraservice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeTableNamestoSingularincode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Points_Projects_ProjectsProjectId",
                table: "Points");

            migrationBuilder.DropForeignKey(
                name: "FK_UmidadeHig_Points_PointsPointId",
                table: "UmidadeHig");

            migrationBuilder.DropForeignKey(
                name: "FK_UmidadeNat_Points_PointsPointId",
                table: "UmidadeNat");

            migrationBuilder.DropIndex(
                name: "IX_UmidadeNat_PointsPointId",
                table: "UmidadeNat");

            migrationBuilder.DropIndex(
                name: "IX_UmidadeHig_PointsPointId",
                table: "UmidadeHig");

            migrationBuilder.DropIndex(
                name: "IX_Points_ProjectsProjectId",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "PointsPointId",
                table: "UmidadeNat");

            migrationBuilder.DropColumn(
                name: "PointsPointId",
                table: "UmidadeHig");

            migrationBuilder.DropColumn(
                name: "ProjectsProjectId",
                table: "Points");

            migrationBuilder.CreateIndex(
                name: "IX_UmidadeNat_PointId",
                table: "UmidadeNat",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_UmidadeHig_PointId",
                table: "UmidadeHig",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_Points_ProjectId",
                table: "Points",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Projects_ProjectId",
                table: "Points",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UmidadeHig_Points_PointId",
                table: "UmidadeHig",
                column: "PointId",
                principalTable: "Points",
                principalColumn: "PointId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UmidadeNat_Points_PointId",
                table: "UmidadeNat",
                column: "PointId",
                principalTable: "Points",
                principalColumn: "PointId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Points_Projects_ProjectId",
                table: "Points");

            migrationBuilder.DropForeignKey(
                name: "FK_UmidadeHig_Points_PointId",
                table: "UmidadeHig");

            migrationBuilder.DropForeignKey(
                name: "FK_UmidadeNat_Points_PointId",
                table: "UmidadeNat");

            migrationBuilder.DropIndex(
                name: "IX_UmidadeNat_PointId",
                table: "UmidadeNat");

            migrationBuilder.DropIndex(
                name: "IX_UmidadeHig_PointId",
                table: "UmidadeHig");

            migrationBuilder.DropIndex(
                name: "IX_Points_ProjectId",
                table: "Points");

            migrationBuilder.AddColumn<int>(
                name: "PointsPointId",
                table: "UmidadeNat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PointsPointId",
                table: "UmidadeHig",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectsProjectId",
                table: "Points",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UmidadeNat_PointsPointId",
                table: "UmidadeNat",
                column: "PointsPointId");

            migrationBuilder.CreateIndex(
                name: "IX_UmidadeHig_PointsPointId",
                table: "UmidadeHig",
                column: "PointsPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Points_ProjectsProjectId",
                table: "Points",
                column: "ProjectsProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Projects_ProjectsProjectId",
                table: "Points",
                column: "ProjectsProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UmidadeHig_Points_PointsPointId",
                table: "UmidadeHig",
                column: "PointsPointId",
                principalTable: "Points",
                principalColumn: "PointId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UmidadeNat_Points_PointsPointId",
                table: "UmidadeNat",
                column: "PointsPointId",
                principalTable: "Points",
                principalColumn: "PointId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
