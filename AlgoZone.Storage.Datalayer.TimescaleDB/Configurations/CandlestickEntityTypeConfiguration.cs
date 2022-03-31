using AlgoZone.Storage.Datalayer.TimescaleDB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlgoZone.Storage.Datalayer.TimescaleDB.Configurations
{
    public class CandlestickEntityTypeConfiguration : IEntityTypeConfiguration<Candlestick>
    {
        #region Methods

        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<Candlestick> builder)
        {
            builder.HasKey(c => new { c.OpenTime, c.TradingPairId });
            builder.HasOne(c => c.TradingPair).WithMany().HasForeignKey(c => c.TradingPairId);
        }

        #endregion
    }
}