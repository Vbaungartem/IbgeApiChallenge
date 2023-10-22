using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IbgeApiChallenge.Api.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "states",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ibge_code = table.Column<string>(type: "NVARCHAR(2)", maxLength: 2, nullable: false),
                    name = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    acronym = table.Column<string>(type: "NVARCHAR(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_states", x => x.Id);
                    table.UniqueConstraint("AK_states_ibge_code", x => x.ibge_code);
                });

            migrationBuilder.CreateTable(
                name: "localities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ibge_code = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    state_id = table.Column<Guid>(type: "uniqueidentifier ", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_localities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_localities_states_state_id",
                        column: x => x.state_id,
                        principalTable: "states",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_localities_state_id",
                table: "localities",
                column: "state_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "localities");

            migrationBuilder.DropTable(
                name: "states");
        }
    }
}
