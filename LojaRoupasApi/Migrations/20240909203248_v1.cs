using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LojaRoupasApi.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    Tipo = table.Column<string>(type: "longtext", nullable: false),
                    Tamanho = table.Column<string>(type: "longtext", nullable: false),
                    Cor = table.Column<string>(type: "longtext", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Cpf = table.Column<string>(type: "longtext", nullable: false),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    Datanascimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    Senha = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProdutoEstoque",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    IdProduto = table.Column<Guid>(type: "char(36)", nullable: false),
                    Estoque = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoEstoque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutoEstoque_Produtos_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Carrinhos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "char(36)", nullable: false),
                    IdCompra = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrinhos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carrinhos_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    IdCarrinho = table.Column<Guid>(type: "char(36)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Situacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compras_Carrinhos_IdCarrinho",
                        column: x => x.IdCarrinho,
                        principalTable: "Carrinhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ItemCarrinhos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    IdCarrinho = table.Column<Guid>(type: "char(36)", nullable: false),
                    IdProduto = table.Column<Guid>(type: "char(36)", nullable: false),
                    Quantia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCarrinhos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemCarrinhos_Carrinhos_IdCarrinho",
                        column: x => x.IdCarrinho,
                        principalTable: "Carrinhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemCarrinhos_Produtos_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Cor", "Nome", "Tamanho", "Tipo", "Valor" },
                values: new object[,]
                {
                    { new Guid("1dfc4a8d-7ed1-443c-9cc7-ac71ea9d003b"), "Preto", "Camisa Basica", "G", "Camisa", 129m },
                    { new Guid("1dfc4a8d-7ed1-443c-9cc7-ac71ea9d004b"), "Branco", "Camisa Basica", "P", "Camisa", 129m },
                    { new Guid("1dfc4a8d-7ed1-443c-9cc7-ac71ea9d005b"), "Branco", "Camisa Basica", "PP", "Camisa", 129m },
                    { new Guid("1dfc4a8d-7ed1-443c-9cc7-ac71ea9d006b"), "Amarelo", "Camisa Basica", "PP", "Camisa", 129m },
                    { new Guid("1dfc4a8d-7ed1-443c-9cc7-ac71ea9d007b"), "Azul", "Camisa Basica", "M", "Camisa", 129m },
                    { new Guid("1dfc4a8d-7ed1-443c-9cc7-ac71ea9d008b"), "Azul", "Camisa Basica Luxo", "M", "Camisa", 129m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carrinhos_IdUsuario",
                table: "Carrinhos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_IdCarrinho",
                table: "Compras",
                column: "IdCarrinho",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemCarrinhos_IdCarrinho",
                table: "ItemCarrinhos",
                column: "IdCarrinho");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCarrinhos_IdProduto",
                table: "ItemCarrinhos",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoEstoque_IdProduto",
                table: "ProdutoEstoque",
                column: "IdProduto",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "ItemCarrinhos");

            migrationBuilder.DropTable(
                name: "ProdutoEstoque");

            migrationBuilder.DropTable(
                name: "Carrinhos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
