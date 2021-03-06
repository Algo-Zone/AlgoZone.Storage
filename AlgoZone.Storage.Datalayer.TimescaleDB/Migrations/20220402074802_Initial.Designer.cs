// <auto-generated />
using System;
using AlgoZone.Storage.Datalayer.TimescaleDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AlgoZone.Storage.Datalayer.TimescaleDB.Migrations
{
    [DbContext(typeof(TimescaleDbContext))]
    [Migration("20220402074802_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AlgoZone.Storage.Datalayer.TimescaleDB.Entities.Asset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnOrder(0);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnOrder(2);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnOrder(1);

                    b.HasKey("Id");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("AlgoZone.Storage.Datalayer.TimescaleDB.Entities.Candlestick", b =>
                {
                    b.Property<DateTime>("OpenTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnOrder(0);

                    b.Property<int>("TradingPairId")
                        .HasColumnType("integer")
                        .HasColumnOrder(1);

                    b.Property<decimal>("Close")
                        .HasColumnType("numeric")
                        .HasColumnOrder(5);

                    b.Property<decimal>("High")
                        .HasColumnType("numeric")
                        .HasColumnOrder(3);

                    b.Property<decimal>("Low")
                        .HasColumnType("numeric")
                        .HasColumnOrder(4);

                    b.Property<decimal>("Open")
                        .HasColumnType("numeric")
                        .HasColumnOrder(2);

                    b.Property<decimal>("Volume")
                        .HasColumnType("numeric")
                        .HasColumnOrder(6);

                    b.HasKey("OpenTime", "TradingPairId");

                    b.HasIndex("TradingPairId");

                    b.ToTable("Candlesticks");
                });

            modelBuilder.Entity("AlgoZone.Storage.Datalayer.TimescaleDB.Entities.TradingPair", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnOrder(0);

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BaseAssetId")
                        .HasColumnType("integer")
                        .HasColumnOrder(1);

                    b.Property<int>("QuoteAssetId")
                        .HasColumnType("integer")
                        .HasColumnOrder(2);

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnOrder(3);

                    b.HasKey("Id");

                    b.HasIndex("BaseAssetId");

                    b.HasIndex("QuoteAssetId");

                    b.ToTable("TradingPairs");
                });

            modelBuilder.Entity("AlgoZone.Storage.Datalayer.TimescaleDB.Entities.Candlestick", b =>
                {
                    b.HasOne("AlgoZone.Storage.Datalayer.TimescaleDB.Entities.TradingPair", "TradingPair")
                        .WithMany()
                        .HasForeignKey("TradingPairId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TradingPair");
                });

            modelBuilder.Entity("AlgoZone.Storage.Datalayer.TimescaleDB.Entities.TradingPair", b =>
                {
                    b.HasOne("AlgoZone.Storage.Datalayer.TimescaleDB.Entities.Asset", "BaseAsset")
                        .WithMany()
                        .HasForeignKey("BaseAssetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlgoZone.Storage.Datalayer.TimescaleDB.Entities.Asset", "QuoteAsset")
                        .WithMany()
                        .HasForeignKey("QuoteAssetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BaseAsset");

                    b.Navigation("QuoteAsset");
                });
#pragma warning restore 612, 618
        }
    }
}
