using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Digix.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAnalysis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FamilyAnalyses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Score = table.Column<int>(type: "integer", nullable: false),
                    FamilyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyAnalyses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyAnalyses_Families_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Families",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnalysisRules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FamilyAnalysisId = table.Column<int>(type: "integer", nullable: false),
                    FirstRule = table.Column<bool>(type: "boolean", nullable: false),
                    SecondRule = table.Column<bool>(type: "boolean", nullable: false),
                    ThirdRule = table.Column<bool>(type: "boolean", nullable: false),
                    FourthRule = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalysisRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalysisRules_FamilyAnalyses_FamilyAnalysisId",
                        column: x => x.FamilyAnalysisId,
                        principalTable: "FamilyAnalyses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnalysisRules_FamilyAnalysisId",
                table: "AnalysisRules",
                column: "FamilyAnalysisId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FamilyAnalyses_FamilyId",
                table: "FamilyAnalyses",
                column: "FamilyId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalysisRules");

            migrationBuilder.DropTable(
                name: "FamilyAnalyses");
        }
    }
}
