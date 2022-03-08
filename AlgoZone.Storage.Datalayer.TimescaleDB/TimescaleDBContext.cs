using AlgoZone.Storage.Datalayer.TimescaleDB.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlgoZone.Storage.Datalayer.TimescaleDB
{
    public class TimescaleDbContext : DbContext
    {
        #region Properties

        public DbSet<Candlestick> Candlesticks { get; set; }

        #endregion

        #region Constructors

        public TimescaleDbContext(DbContextOptions<TimescaleDbContext> options) : base(options) { }

        #endregion
    }
}