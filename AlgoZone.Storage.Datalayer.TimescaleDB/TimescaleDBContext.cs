using AlgoZone.Storage.Datalayer.TimescaleDB.Configurations;
using AlgoZone.Storage.Datalayer.TimescaleDB.Entities;
using AlgoZone.Storage.Datalayer.TimescaleDB.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AlgoZone.Storage.Datalayer.TimescaleDB
{
    public class TimescaleDbContext : DbContext
    {
        #region Properties

        public DbSet<Candlestick> Candlesticks { get; set; }

        public DbSet<Symbol> Symbols { get; set; }

        public DbSet<TradingPair> TradingPairs { get; set; }

        #endregion

        #region Constructors

        public TimescaleDbContext() { }

        public TimescaleDbContext(DbContextOptions<TimescaleDbContext> options) : base(options) { }

        #endregion

        #region Methods

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CandlestickEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TradingPairEntityTypeConfiguration());
        }
        
        

        #endregion
    }
}