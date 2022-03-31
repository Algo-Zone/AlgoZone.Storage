using AlgoZone.Storage.Datalayer.TimescaleDB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlgoZone.Storage.Datalayer.TimescaleDB.Configurations
{
    public class TradingPairEntityTypeConfiguration : IEntityTypeConfiguration<TradingPair>
    {
        #region Methods

        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<TradingPair> builder)
        {
            builder.HasOne(tp => tp.BaseAsset).WithMany().HasForeignKey(tp => tp.BaseAssetId);
            builder.HasOne(tp => tp.QuoteAsset).WithMany().HasForeignKey(tp => tp.QuoteAssetId);
        }

        #endregion
    }
}