using AlgoZone.Storage.Businesslayer.Candlesticks.Models;
using AlgoZone.Storage.Datalayer.TimescaleDB;
using AutoMapper;

namespace AlgoZone.Storage.Businesslayer.Candlesticks.Stores
{
    public sealed class TimescaleCandlestickStore : ICandlestickStore
    {
        #region Fields

        private readonly TimescaleDbContext _db;

        private readonly IMapper _mapper;

        #endregion

        #region Constructors

        public TimescaleCandlestickStore(IMapper mapper, TimescaleDbContext db)
        {
            _mapper = mapper;
            _db = db;
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public void AddCandlestick(Candlestick candlestick)
        {
            var entity = _mapper.Map<Datalayer.TimescaleDB.Entities.Candlestick>(candlestick);
            if (entity == null)
                return;
            
            _db.Candlesticks.Add(entity);
            _db.SaveChanges();
        }

        #endregion
    }
}