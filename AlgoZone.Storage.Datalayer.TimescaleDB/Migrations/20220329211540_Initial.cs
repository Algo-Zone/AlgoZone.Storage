using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AlgoZone.Storage.Datalayer.TimescaleDB.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Symbols",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    FullName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symbols", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TradingPairs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BaseSymbolId = table.Column<int>(type: "integer", nullable: false),
                    QuoteSymbolId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradingPairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TradingPairs_Symbols_BaseSymbolId",
                        column: x => x.BaseSymbolId,
                        principalTable: "Symbols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TradingPairs_Symbols_QuoteSymbolId",
                        column: x => x.QuoteSymbolId,
                        principalTable: "Symbols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Candlesticks",
                columns: table => new
                {
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TradingPairId = table.Column<int>(type: "integer", nullable: false),
                    Open = table.Column<decimal>(type: "numeric", nullable: false),
                    High = table.Column<decimal>(type: "numeric", nullable: false),
                    Low = table.Column<decimal>(type: "numeric", nullable: false),
                    Close = table.Column<decimal>(type: "numeric", nullable: false),
                    Volume = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candlesticks", x => new { x.Timestamp, x.TradingPairId });
                    table.ForeignKey(
                        name: "FK_Candlesticks_TradingPairs_TradingPairId",
                        column: x => x.TradingPairId,
                        principalTable: "TradingPairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candlesticks_TradingPairId",
                table: "Candlesticks",
                column: "TradingPairId");

            migrationBuilder.CreateIndex(
                name: "IX_TradingPairs_BaseSymbolId",
                table: "TradingPairs",
                column: "BaseSymbolId");

            migrationBuilder.CreateIndex(
                name: "IX_TradingPairs_QuoteSymbolId",
                table: "TradingPairs",
                column: "QuoteSymbolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candlesticks");

            migrationBuilder.DropTable(
                name: "TradingPairs");

            migrationBuilder.DropTable(
                name: "Symbols");
        }
    }
}
