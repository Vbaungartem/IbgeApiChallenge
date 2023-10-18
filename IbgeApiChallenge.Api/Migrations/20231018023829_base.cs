using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IbgeApiChallenge.Api.Migrations
{
    /// <inheritdoc />
    public partial class @base : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "auth_roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "NVARCHAR(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auth_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "auth_users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "NVARCHAR(250)", maxLength: 250, nullable: false),
                    given_name = table.Column<string>(type: "NVARCHAR(250)", maxLength: 250, nullable: false),
                    email = table.Column<string>(type: "NVARCHAR(250)", maxLength: 250, nullable: false),
                    password_hash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auth_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "auth_users_x_roles",
                columns: table => new
                {
                    id_role = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_user = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auth_users_x_roles", x => new { x.id_role, x.id_user });
                    table.ForeignKey(
                        name: "FK_auth_users_x_roles_auth_roles_id_role",
                        column: x => x.id_role,
                        principalTable: "auth_roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_auth_users_x_roles_auth_users_id_user",
                        column: x => x.id_user,
                        principalTable: "auth_users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_auth_users_x_roles_id_user",
                table: "auth_users_x_roles",
                column: "id_user");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "auth_users_x_roles");

            migrationBuilder.DropTable(
                name: "auth_roles");

            migrationBuilder.DropTable(
                name: "auth_users");
        }
    }
}
