using AlgoZone.Storage.Datalayer.TimescaleDB;

namespace AlgoZone.Storage.Businesslayer.Candlesticks
{
    public class CandlestickManager : ICandlestickManager
    {
        #region Fields

        private TimescaleDbContext _timescaleDbContext;

        #endregion

        #region Constructors

        public CandlestickManager(TimescaleDbContext timescaleDbContext)
        {
            _timescaleDbContext = timescaleDbContext;
        }

        #endregion
    }
}