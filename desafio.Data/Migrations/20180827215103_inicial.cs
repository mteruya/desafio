using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace desafio.Data.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lotearquivos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Lote = table.Column<string>(nullable: true),
                    DataArquivo = table.Column<DateTime>(nullable: false),
                    TotalRegistros = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lotearquivos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cartoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumCartao = table.Column<string>(nullable: true),
                    LoteArquivoId = table.Column<int>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cartoes_lotearquivos_LoteArquivoId",
                        column: x => x.LoteArquivoId,
                        principalTable: "lotearquivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cartoes_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "Id", "Login", "Nome", "Senha" },
                values: new object[] { 1, "teste", "teste", "teste123" });

            migrationBuilder.InsertData(
                table: "cartoes",
                columns: new[] { "Id", "LoteArquivoId", "NumCartao", "UsuarioId" },
                values: new object[] { 1, null, "123457890123", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_cartoes_LoteArquivoId",
                table: "cartoes",
                column: "LoteArquivoId");

            migrationBuilder.CreateIndex(
                name: "IX_cartoes_UsuarioId",
                table: "cartoes",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cartoes");

            migrationBuilder.DropTable(
                name: "lotearquivos");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
