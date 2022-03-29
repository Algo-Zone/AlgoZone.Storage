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
            builder.HasOne(tp => tp.BaseSymbol).WithMany().HasForeignKey(tp => tp.BaseSymbolId);
            builder.HasOne(tp => tp.QuoteSymbol).WithMany().HasForeignKey(tp => tp.QuoteSymbolId);
        }

        #endregion
    }
}