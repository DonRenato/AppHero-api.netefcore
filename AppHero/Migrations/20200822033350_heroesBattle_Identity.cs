using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppHero.Migrations
{
    public partial class heroesBattle_Identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_Battles_battleId",
                table: "Heroes");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Heroes_heroId",
                table: "Weapons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Weapons",
                table: "Weapons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Heroes",
                table: "Heroes");

            migrationBuilder.DropIndex(
                name: "IX_Heroes_battleId",
                table: "Heroes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Battles",
                table: "Battles");

            migrationBuilder.DropColumn(
                name: "battleId",
                table: "Heroes");

            migrationBuilder.RenameTable(
                name: "Weapons",
                newName: "weapons");

            migrationBuilder.RenameTable(
                name: "Heroes",
                newName: "heroes");

            migrationBuilder.RenameTable(
                name: "Battles",
                newName: "battles");

            migrationBuilder.RenameIndex(
                name: "IX_Weapons_heroId",
                table: "weapons",
                newName: "IX_weapons_heroId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_weapons",
                table: "weapons",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_heroes",
                table: "heroes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_battles",
                table: "battles",
                column: "id");

            migrationBuilder.CreateTable(
                name: "battleHeroes",
                columns: table => new
                {
                    heroId = table.Column<int>(nullable: false),
                    battleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_battleHeroes", x => new { x.battleId, x.heroId });
                    table.ForeignKey(
                        name: "FK_battleHeroes_battles_battleId",
                        column: x => x.battleId,
                        principalTable: "battles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_battleHeroes_heroes_heroId",
                        column: x => x.heroId,
                        principalTable: "heroes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "secretIdentities",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    realName = table.Column<string>(nullable: true),
                    heroId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_secretIdentities", x => x.id);
                    table.ForeignKey(
                        name: "FK_secretIdentities_heroes_heroId",
                        column: x => x.heroId,
                        principalTable: "heroes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_battleHeroes_heroId",
                table: "battleHeroes",
                column: "heroId");

            migrationBuilder.CreateIndex(
                name: "IX_secretIdentities_heroId",
                table: "secretIdentities",
                column: "heroId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_weapons_heroes_heroId",
                table: "weapons",
                column: "heroId",
                principalTable: "heroes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_weapons_heroes_heroId",
                table: "weapons");

            migrationBuilder.DropTable(
                name: "battleHeroes");

            migrationBuilder.DropTable(
                name: "secretIdentities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_weapons",
                table: "weapons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_heroes",
                table: "heroes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_battles",
                table: "battles");

            migrationBuilder.RenameTable(
                name: "weapons",
                newName: "Weapons");

            migrationBuilder.RenameTable(
                name: "heroes",
                newName: "Heroes");

            migrationBuilder.RenameTable(
                name: "battles",
                newName: "Battles");

            migrationBuilder.RenameIndex(
                name: "IX_weapons_heroId",
                table: "Weapons",
                newName: "IX_Weapons_heroId");

            migrationBuilder.AddColumn<int>(
                name: "battleId",
                table: "Heroes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weapons",
                table: "Weapons",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Heroes",
                table: "Heroes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Battles",
                table: "Battles",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_battleId",
                table: "Heroes",
                column: "battleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_Battles_battleId",
                table: "Heroes",
                column: "battleId",
                principalTable: "Battles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Heroes_heroId",
                table: "Weapons",
                column: "heroId",
                principalTable: "Heroes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
