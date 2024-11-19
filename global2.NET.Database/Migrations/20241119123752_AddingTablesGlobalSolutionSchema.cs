using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace global2.NET.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddingTablesGlobalSolutionSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "incentivo_pontuacao",
                columns: table => new
                {
                    IdPont = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PontosAdquiridos = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    MetaAlcancada = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    DataPontuacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_incentivo_pontuacao", x => x.IdPont);
                });

            migrationBuilder.CreateTable(
                name: "leitura_energia",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Consumo = table.Column<string>(type: "NVARCHAR2(40)", maxLength: 40, nullable: false),
                    ProducaoEnergia = table.Column<string>(type: "NVARCHAR2(40)", maxLength: 40, nullable: false),
                    DataLeitura = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leitura_energia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    IdUsua = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeUsua = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    EmailUsua = table.Column<string>(type: "NVARCHAR2(70)", maxLength: 70, nullable: false),
                    SenhaUsua = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    IncentiveScoreId = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.IdUsua);
                    table.ForeignKey(
                        name: "FK_usuario_incentivo_pontuacao_IncentiveScoreId",
                        column: x => x.IncentiveScoreId,
                        principalTable: "incentivo_pontuacao",
                        principalColumn: "IdPont",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dispositivo",
                columns: table => new
                {
                    IdDisp = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeDispositivo = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    TipoDispositivo = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    StatusDispositivo = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    UsuarioIdUsua = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dispositivo", x => x.IdDisp);
                    table.ForeignKey(
                        name: "FK_dispositivo_usuario_UsuarioIdUsua",
                        column: x => x.UsuarioIdUsua,
                        principalTable: "usuario",
                        principalColumn: "IdUsua",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "endereco",
                columns: table => new
                {
                    IdEnde = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Logradouro = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    CEP = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    Numero = table.Column<string>(type: "NVARCHAR2(5)", maxLength: 5, nullable: false),
                    Complemento = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Bairro = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Cidade = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    UsuarioIdUsua = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_endereco", x => x.IdEnde);
                    table.ForeignKey(
                        name: "FK_endereco_usuario_UsuarioIdUsua",
                        column: x => x.UsuarioIdUsua,
                        principalTable: "usuario",
                        principalColumn: "IdUsua",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "telefone",
                columns: table => new
                {
                    IdTelef = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CodigoPais = table.Column<string>(type: "NVARCHAR2(3)", maxLength: 3, nullable: false),
                    DDD = table.Column<string>(type: "NVARCHAR2(3)", maxLength: 3, nullable: false),
                    NumeroTelefone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    UsuarioIdUsua = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_telefone", x => x.IdTelef);
                    table.ForeignKey(
                        name: "FK_telefone_usuario_UsuarioIdUsua",
                        column: x => x.UsuarioIdUsua,
                        principalTable: "usuario",
                        principalColumn: "IdUsua",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "obter",
                columns: table => new
                {
                    DevicesIdDisp = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    EnergyLecturesId = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_obter", x => new { x.DevicesIdDisp, x.EnergyLecturesId });
                    table.ForeignKey(
                        name: "FK_obter_dispositivo_DevicesIdDisp",
                        column: x => x.DevicesIdDisp,
                        principalTable: "dispositivo",
                        principalColumn: "IdDisp",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_obter_leitura_energia_EnergyLecturesId",
                        column: x => x.EnergyLecturesId,
                        principalTable: "leitura_energia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "alerta_otimizacao",
                columns: table => new
                {
                    IdAler = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TipoAlerta = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    DataAlerta = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    TelefoneIdTelef = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alerta_otimizacao", x => x.IdAler);
                    table.ForeignKey(
                        name: "FK_alerta_otimizacao_telefone_TelefoneIdTelef",
                        column: x => x.TelefoneIdTelef,
                        principalTable: "telefone",
                        principalColumn: "IdTelef",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_alerta_otimizacao_TelefoneIdTelef",
                table: "alerta_otimizacao",
                column: "TelefoneIdTelef");

            migrationBuilder.CreateIndex(
                name: "IX_dispositivo_UsuarioIdUsua",
                table: "dispositivo",
                column: "UsuarioIdUsua");

            migrationBuilder.CreateIndex(
                name: "IX_endereco_UsuarioIdUsua",
                table: "endereco",
                column: "UsuarioIdUsua");

            migrationBuilder.CreateIndex(
                name: "IX_obter_EnergyLecturesId",
                table: "obter",
                column: "EnergyLecturesId");

            migrationBuilder.CreateIndex(
                name: "IX_telefone_UsuarioIdUsua",
                table: "telefone",
                column: "UsuarioIdUsua");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_IncentiveScoreId",
                table: "usuario",
                column: "IncentiveScoreId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alerta_otimizacao");

            migrationBuilder.DropTable(
                name: "endereco");

            migrationBuilder.DropTable(
                name: "obter");

            migrationBuilder.DropTable(
                name: "telefone");

            migrationBuilder.DropTable(
                name: "dispositivo");

            migrationBuilder.DropTable(
                name: "leitura_energia");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "incentivo_pontuacao");
        }
    }
}
