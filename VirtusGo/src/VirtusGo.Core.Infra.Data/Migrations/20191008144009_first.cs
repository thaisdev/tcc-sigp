using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VirtusGo.Core.Infra.Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TCS_ESTADO",
                columns: table => new
                {
                    CODEST = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NOMEEST = table.Column<string>(maxLength: 40, nullable: false),
                    SIGLAEST = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TCS_ESTADO", x => x.CODEST);
                });

            migrationBuilder.CreateTable(
                name: "TCS_ESTEND",
                columns: table => new
                {
                    CODEND = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    COLUNA = table.Column<string>(nullable: false),
                    DESCREND = table.Column<string>(nullable: false),
                    RUA = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TCS_ESTEND", x => x.CODEND);
                });

            migrationBuilder.CreateTable(
                name: "TCS_PRO",
                columns: table => new
                {
                    CODPROD = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DESCPROD = table.Column<string>(nullable: false),
                    ESTOQUE = table.Column<int>(nullable: false),
                    NCM = table.Column<string>(nullable: false),
                    UNID = table.Column<string>(nullable: false),
                    VLRUNIT = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TCS_PRO", x => x.CODPROD);
                });

            migrationBuilder.CreateTable(
                name: "TCS_CIDADE",
                columns: table => new
                {
                    CODCID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CODEST = table.Column<int>(nullable: false),
                    NOMECID = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TCS_CIDADE", x => x.CODCID);
                    table.ForeignKey(
                        name: "FK_TCS_CIDADE_TCS_ESTADO_CODEST",
                        column: x => x.CODEST,
                        principalTable: "TCS_ESTADO",
                        principalColumn: "CODEST",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TTS_PEDITE",
                columns: table => new
                {
                    CODPED = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CODPROD = table.Column<int>(nullable: false),
                    QTD = table.Column<int>(nullable: false),
                    VLRTOT = table.Column<double>(nullable: false),
                    VLRUNIT = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TTS_PEDITE", x => x.CODPED);
                    table.ForeignKey(
                        name: "FK_TTS_PEDITE_TCS_PRO_CODPROD",
                        column: x => x.CODPROD,
                        principalTable: "TCS_PRO",
                        principalColumn: "CODPROD",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TTS_RASTRE",
                columns: table => new
                {
                    CODRASTRE = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CODPEDC = table.Column<int>(nullable: false),
                    CODPEDV = table.Column<int>(nullable: false),
                    CODPROD = table.Column<int>(nullable: false),
                    QTD = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TTS_RASTRE", x => x.CODRASTRE);
                    table.ForeignKey(
                        name: "FK_TTS_RASTRE_TCS_PRO_CODPROD",
                        column: x => x.CODPROD,
                        principalTable: "TCS_PRO",
                        principalColumn: "CODPROD",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TCS_ENDERECO",
                columns: table => new
                {
                    CODEND = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BAIRRO = table.Column<string>(maxLength: 40, nullable: false),
                    CEP = table.Column<string>(maxLength: 40, nullable: false),
                    CODCID = table.Column<int>(nullable: false),
                    LOGRADOURO = table.Column<string>(maxLength: 40, nullable: false),
                    NUM = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TCS_ENDERECO", x => x.CODEND);
                    table.ForeignKey(
                        name: "FK_TCS_ENDERECO_TCS_CIDADE_CODCID",
                        column: x => x.CODCID,
                        principalTable: "TCS_CIDADE",
                        principalColumn: "CODCID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TCS_EMP",
                columns: table => new
                {
                    CODEMP = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CNPJ = table.Column<string>(nullable: false),
                    CODEND = table.Column<int>(nullable: false),
                    INSCRI = table.Column<string>(nullable: false),
                    RAZAO = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TCS_EMP", x => x.CODEMP);
                    table.ForeignKey(
                        name: "FK_TCS_EMP_TCS_ENDERECO_CODEND",
                        column: x => x.CODEND,
                        principalTable: "TCS_ENDERECO",
                        principalColumn: "CODEND",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TCS_MOT",
                columns: table => new
                {
                    CODMOT = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CPF = table.Column<string>(nullable: false),
                    CATCNH = table.Column<string>(nullable: false),
                    DTNASC = table.Column<DateTime>(nullable: false),
                    DTVENCCNHM = table.Column<DateTime>(nullable: false),
                    CODEND = table.Column<int>(nullable: false),
                    NOMEMOT = table.Column<string>(nullable: false),
                    NROCNH = table.Column<string>(nullable: false),
                    TEL = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TCS_MOT", x => x.CODMOT);
                    table.ForeignKey(
                        name: "FK_TCS_MOT_TCS_ENDERECO_CODEND",
                        column: x => x.CODEND,
                        principalTable: "TCS_ENDERECO",
                        principalColumn: "CODEND",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TCS_PAR",
                columns: table => new
                {
                    CODPAR = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EMAIL = table.Column<string>(maxLength: 40, nullable: false),
                    CODEND = table.Column<int>(nullable: false),
                    NOMEPAR = table.Column<string>(maxLength: 40, nullable: false),
                    CPF_CNPJ = table.Column<string>(maxLength: 14, nullable: false),
                    RG_INCRIEST = table.Column<string>(maxLength: 12, nullable: false),
                    SITE = table.Column<string>(maxLength: 20, nullable: true),
                    TEL = table.Column<string>(maxLength: 20, nullable: true),
                    TipoPessoa = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TCS_PAR", x => x.CODPAR);
                    table.ForeignKey(
                        name: "FK_TCS_PAR_TCS_ENDERECO_CODEND",
                        column: x => x.CODEND,
                        principalTable: "TCS_ENDERECO",
                        principalColumn: "CODEND",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TCS_ROTA_END",
                columns: table => new
                {
                    CODROTA = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CODEND = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TCS_ROTA_END", x => x.CODROTA);
                    table.ForeignKey(
                        name: "FK_TCS_ROTA_END_TCS_ENDERECO_CODEND",
                        column: x => x.CODEND,
                        principalTable: "TCS_ENDERECO",
                        principalColumn: "CODEND",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TCS_VEI",
                columns: table => new
                {
                    CODVEI = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    COR = table.Column<string>(nullable: true),
                    MARCA = table.Column<string>(nullable: true),
                    MODELO = table.Column<string>(nullable: true),
                    ParceiroId = table.Column<int>(nullable: false),
                    PLACA = table.Column<string>(nullable: true),
                    RENAVAM = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TCS_VEI", x => x.CODVEI);
                    table.ForeignKey(
                        name: "FK_TCS_VEI_TCS_PAR_ParceiroId",
                        column: x => x.ParceiroId,
                        principalTable: "TCS_PAR",
                        principalColumn: "CODPAR",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TTS_PED",
                columns: table => new
                {
                    CODPED = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DTNEG = table.Column<DateTime>(nullable: false),
                    CODEMP = table.Column<int>(nullable: false),
                    CODMOT = table.Column<int>(nullable: false),
                    CODPAR = table.Column<int>(nullable: false),
                    TIPO = table.Column<string>(nullable: false),
                    CODUSU = table.Column<int>(nullable: false),
                    CODVENCCOMP = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TTS_PED", x => x.CODPED);
                    table.ForeignKey(
                        name: "FK_TTS_PED_TCS_EMP_CODEMP",
                        column: x => x.CODEMP,
                        principalTable: "TCS_EMP",
                        principalColumn: "CODEMP",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TTS_PED_TCS_MOT_CODMOT",
                        column: x => x.CODMOT,
                        principalTable: "TCS_MOT",
                        principalColumn: "CODMOT",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TTS_PED_TCS_PAR_CODPAR",
                        column: x => x.CODPAR,
                        principalTable: "TCS_PAR",
                        principalColumn: "CODPAR",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TTS_OC",
                columns: table => new
                {
                    CODOC = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DTCHEGADA = table.Column<DateTime>(nullable: false),
                    DTSAIDA = table.Column<DateTime>(nullable: false),
                    CODMOT = table.Column<int>(nullable: false),
                    CODROTA = table.Column<int>(nullable: false),
                    CODVEI = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TTS_OC", x => x.CODOC);
                    table.ForeignKey(
                        name: "FK_TTS_OC_TCS_MOT_CODMOT",
                        column: x => x.CODMOT,
                        principalTable: "TCS_MOT",
                        principalColumn: "CODMOT",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TTS_OC_TCS_ROTA_END_CODROTA",
                        column: x => x.CODROTA,
                        principalTable: "TCS_ROTA_END",
                        principalColumn: "CODROTA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TTS_OC_TCS_VEI_CODVEI",
                        column: x => x.CODVEI,
                        principalTable: "TCS_VEI",
                        principalColumn: "CODVEI",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TTS_OCITE",
                columns: table => new
                {
                    CODOC = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CODPED = table.Column<int>(nullable: false),
                    SEQUENCIA = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TTS_OCITE", x => x.CODOC);
                    table.ForeignKey(
                        name: "FK_TTS_OCITE_TTS_PED_CODPED",
                        column: x => x.CODPED,
                        principalTable: "TTS_PED",
                        principalColumn: "CODPED",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TCS_CIDADE_CODEST",
                table: "TCS_CIDADE",
                column: "CODEST");

            migrationBuilder.CreateIndex(
                name: "IX_TCS_EMP_CODEND",
                table: "TCS_EMP",
                column: "CODEND");

            migrationBuilder.CreateIndex(
                name: "IX_TCS_ENDERECO_CODCID",
                table: "TCS_ENDERECO",
                column: "CODCID");

            migrationBuilder.CreateIndex(
                name: "IX_TCS_MOT_CODEND",
                table: "TCS_MOT",
                column: "CODEND");

            migrationBuilder.CreateIndex(
                name: "IX_TCS_PAR_CODEND",
                table: "TCS_PAR",
                column: "CODEND");

            migrationBuilder.CreateIndex(
                name: "IX_TCS_ROTA_END_CODEND",
                table: "TCS_ROTA_END",
                column: "CODEND");

            migrationBuilder.CreateIndex(
                name: "IX_TCS_VEI_ParceiroId",
                table: "TCS_VEI",
                column: "ParceiroId");

            migrationBuilder.CreateIndex(
                name: "IX_TTS_OC_CODMOT",
                table: "TTS_OC",
                column: "CODMOT");

            migrationBuilder.CreateIndex(
                name: "IX_TTS_OC_CODROTA",
                table: "TTS_OC",
                column: "CODROTA");

            migrationBuilder.CreateIndex(
                name: "IX_TTS_OC_CODVEI",
                table: "TTS_OC",
                column: "CODVEI");

            migrationBuilder.CreateIndex(
                name: "IX_TTS_OCITE_CODPED",
                table: "TTS_OCITE",
                column: "CODPED");

            migrationBuilder.CreateIndex(
                name: "IX_TTS_PED_CODEMP",
                table: "TTS_PED",
                column: "CODEMP");

            migrationBuilder.CreateIndex(
                name: "IX_TTS_PED_CODMOT",
                table: "TTS_PED",
                column: "CODMOT");

            migrationBuilder.CreateIndex(
                name: "IX_TTS_PED_CODPAR",
                table: "TTS_PED",
                column: "CODPAR");

            migrationBuilder.CreateIndex(
                name: "IX_TTS_PEDITE_CODPROD",
                table: "TTS_PEDITE",
                column: "CODPROD");

            migrationBuilder.CreateIndex(
                name: "IX_TTS_RASTRE_CODPROD",
                table: "TTS_RASTRE",
                column: "CODPROD");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TCS_ESTEND");

            migrationBuilder.DropTable(
                name: "TTS_OC");

            migrationBuilder.DropTable(
                name: "TTS_OCITE");

            migrationBuilder.DropTable(
                name: "TTS_PEDITE");

            migrationBuilder.DropTable(
                name: "TTS_RASTRE");

            migrationBuilder.DropTable(
                name: "TCS_ROTA_END");

            migrationBuilder.DropTable(
                name: "TCS_VEI");

            migrationBuilder.DropTable(
                name: "TTS_PED");

            migrationBuilder.DropTable(
                name: "TCS_PRO");

            migrationBuilder.DropTable(
                name: "TCS_EMP");

            migrationBuilder.DropTable(
                name: "TCS_MOT");

            migrationBuilder.DropTable(
                name: "TCS_PAR");

            migrationBuilder.DropTable(
                name: "TCS_ENDERECO");

            migrationBuilder.DropTable(
                name: "TCS_CIDADE");

            migrationBuilder.DropTable(
                name: "TCS_ESTADO");
        }
    }
}
