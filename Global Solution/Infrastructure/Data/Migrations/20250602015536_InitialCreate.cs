using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Global_Solution.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SMAE_AREA_RISCO",
                columns: table => new
                {
                    ID_AREA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME_AREA = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    LATITUDE = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    LONGITUDE = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    NIVEL_NORMAL_ESTACAO_SECA = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    NIVEL_NORMAL_ESTACAO_CHUVA = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    NIVEL_ALERTA_PREVENTIVO = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    NIVEL_ALERTA_EMERGENCIA = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    NIVEL_EVACUACAO = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    AREA_ALAGADA_ALERTA = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    AREA_ALAGADA_EMERGENCIA = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: true),
                    METODO_MEDICAO_NIVEL = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    METODO_MEDICAO_EXTENSAO = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    FONTE_DADOS = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    ULTIMA_ATUALIZACAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    RESPONSAVEL_ATUALIZACAO = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    DESCRICAO = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMAE_AREA_RISCO", x => x.ID_AREA);
                });

            migrationBuilder.CreateTable(
                name: "SMAE_USUARIO",
                columns: table => new
                {
                    ID_USUARIO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME_USUARIO = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    EMAIL = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    TELEFONE = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    TIPO_USUARIO = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    SENHA_HASH = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DATA_CADASTRO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMAE_USUARIO", x => x.ID_USUARIO);
                });

            migrationBuilder.CreateTable(
                name: "SMAE_SENSOR",
                columns: table => new
                {
                    ID_SENSOR = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    ID_AREA = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TIPO_SENSOR = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    MODELO = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    DATA_INSTALACAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ULTIMA_MANUTENCAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    STATUS_SENSOR = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMAE_SENSOR", x => x.ID_SENSOR);
                    table.ForeignKey(
                        name: "FK_SMAE_SENSOR_SMAE_AREA_RISCO_ID_AREA",
                        column: x => x.ID_AREA,
                        principalTable: "SMAE_AREA_RISCO",
                        principalColumn: "ID_AREA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SMAE_INSCRICAO_ALERTA",
                columns: table => new
                {
                    ID_INSCRICAO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_USUARIO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ID_AREA = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RECEBER_EMAIL = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RECEBER_SMS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RECEBER_PUSH = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TIMESTAMP_INSCRICAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMAE_INSCRICAO_ALERTA", x => x.ID_INSCRICAO);
                    table.ForeignKey(
                        name: "FK_SMAE_INSCRICAO_ALERTA_SMAE_AREA_RISCO_ID_AREA",
                        column: x => x.ID_AREA,
                        principalTable: "SMAE_AREA_RISCO",
                        principalColumn: "ID_AREA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SMAE_INSCRICAO_ALERTA_SMAE_USUARIO_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "SMAE_USUARIO",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SMAE_LEITURA_SENSOR",
                columns: table => new
                {
                    ID_LEITURA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_SENSOR = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    TIMESTAMP_LEITURA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    VALOR_LEITURA = table.Column<decimal>(type: "DECIMAL(18, 2)", nullable: false),
                    UNIDADE_MEDIDA = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMAE_LEITURA_SENSOR", x => x.ID_LEITURA);
                    table.ForeignKey(
                        name: "FK_SMAE_LEITURA_SENSOR_SMAE_SENSOR_ID_SENSOR",
                        column: x => x.ID_SENSOR,
                        principalTable: "SMAE_SENSOR",
                        principalColumn: "ID_SENSOR",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SMAE_ALERTA",
                columns: table => new
                {
                    ID_ALERTA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_AREA = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ID_LEITURA_GATILHO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TIMESTAMP_ALERTA = table.Column<DateTime>(type: "timestamp", nullable: false),
                    TIPO_ALERTA = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    MENSAGEM_ALERTA = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    STATUS_ALERTA = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMAE_ALERTA", x => x.ID_ALERTA);
                    table.ForeignKey(
                        name: "FK_SMAE_ALERTA_SMAE_AREA_RISCO_ID_AREA",
                        column: x => x.ID_AREA,
                        principalTable: "SMAE_AREA_RISCO",
                        principalColumn: "ID_AREA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SMAE_ALERTA_SMAE_LEITURA_SENSOR_ID_LEITURA_GATILHO",
                        column: x => x.ID_LEITURA_GATILHO,
                        principalTable: "SMAE_LEITURA_SENSOR",
                        principalColumn: "ID_LEITURA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SMAE_NOTIFICACAO",
                columns: table => new
                {
                    ID_NOTIFICACAO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_ALERTA = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ID_USUARIO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TIMESTAMP_ENVIO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CANAL_ENVIO = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    STATUS_ENVIO = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMAE_NOTIFICACAO", x => x.ID_NOTIFICACAO);
                    table.ForeignKey(
                        name: "FK_SMAE_NOTIFICACAO_SMAE_ALERTA_ID_ALERTA",
                        column: x => x.ID_ALERTA,
                        principalTable: "SMAE_ALERTA",
                        principalColumn: "ID_ALERTA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SMAE_NOTIFICACAO_SMAE_USUARIO_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "SMAE_USUARIO",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SMAE_ALERTA_ID_AREA",
                table: "SMAE_ALERTA",
                column: "ID_AREA");

            migrationBuilder.CreateIndex(
                name: "IX_SMAE_ALERTA_ID_LEITURA_GATILHO",
                table: "SMAE_ALERTA",
                column: "ID_LEITURA_GATILHO");

            migrationBuilder.CreateIndex(
                name: "IX_SMAE_INSCRICAO_ALERTA_ID_AREA",
                table: "SMAE_INSCRICAO_ALERTA",
                column: "ID_AREA");

            migrationBuilder.CreateIndex(
                name: "IX_SMAE_INSCRICAO_ALERTA_ID_USUARIO",
                table: "SMAE_INSCRICAO_ALERTA",
                column: "ID_USUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_SMAE_LEITURA_SENSOR_ID_SENSOR",
                table: "SMAE_LEITURA_SENSOR",
                column: "ID_SENSOR");

            migrationBuilder.CreateIndex(
                name: "IX_SMAE_NOTIFICACAO_ID_ALERTA",
                table: "SMAE_NOTIFICACAO",
                column: "ID_ALERTA");

            migrationBuilder.CreateIndex(
                name: "IX_SMAE_NOTIFICACAO_ID_USUARIO",
                table: "SMAE_NOTIFICACAO",
                column: "ID_USUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_SMAE_SENSOR_ID_AREA",
                table: "SMAE_SENSOR",
                column: "ID_AREA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SMAE_INSCRICAO_ALERTA");

            migrationBuilder.DropTable(
                name: "SMAE_NOTIFICACAO");

            migrationBuilder.DropTable(
                name: "SMAE_ALERTA");

            migrationBuilder.DropTable(
                name: "SMAE_USUARIO");

            migrationBuilder.DropTable(
                name: "SMAE_LEITURA_SENSOR");

            migrationBuilder.DropTable(
                name: "SMAE_SENSOR");

            migrationBuilder.DropTable(
                name: "SMAE_AREA_RISCO");
        }
    }
}
