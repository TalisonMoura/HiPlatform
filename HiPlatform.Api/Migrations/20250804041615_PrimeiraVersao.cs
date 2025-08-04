using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HiPlatform.Api.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraVersao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Elemento_Estoque",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Preco = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Custo = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    CnpjFabricante = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    DataModificacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elemento_Estoque", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alimento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Peso = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ElementoEstoqueId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    DataModificacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alimento_Elemento_Estoque_ElementoEstoqueId",
                        column: x => x.ElementoEstoqueId,
                        principalTable: "Elemento_Estoque",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estoque",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    ElementoEstoqueId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    DataModificacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estoque_Elemento_Estoque_ElementoEstoqueId",
                        column: x => x.ElementoEstoqueId,
                        principalTable: "Elemento_Estoque",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produto_Limpeza",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Volume = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ElementoEstoqueId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    DataModificacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto_Limpeza", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Limpeza_Elemento_Estoque_ElementoEstoqueId",
                        column: x => x.ElementoEstoqueId,
                        principalTable: "Elemento_Estoque",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pesquisa_Mercado",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Satisfacao = table.Column<int>(type: "integer", nullable: false),
                    InstitutoPesquisa = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ProdutoLimpezaId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    DataModificacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pesquisa_Mercado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pesquisa_Mercado_Produto_Limpeza_ProdutoLimpezaId",
                        column: x => x.ProdutoLimpezaId,
                        principalTable: "Produto_Limpeza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alimento_ElementoEstoqueId",
                table: "Alimento",
                column: "ElementoEstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_ElementoEstoqueId",
                table: "Estoque",
                column: "ElementoEstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Pesquisa_Mercado_ProdutoLimpezaId",
                table: "Pesquisa_Mercado",
                column: "ProdutoLimpezaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_Limpeza_ElementoEstoqueId",
                table: "Produto_Limpeza",
                column: "ElementoEstoqueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alimento");

            migrationBuilder.DropTable(
                name: "Estoque");

            migrationBuilder.DropTable(
                name: "Pesquisa_Mercado");

            migrationBuilder.DropTable(
                name: "Produto_Limpeza");

            migrationBuilder.DropTable(
                name: "Elemento_Estoque");
        }
    }
}
