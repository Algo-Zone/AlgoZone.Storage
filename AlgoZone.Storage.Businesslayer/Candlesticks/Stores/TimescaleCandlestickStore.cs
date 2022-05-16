using System;
using System.Collections.Generic;
using System.Linq;
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

            entity.TradingPair = null;

            _db.Candlesticks.Add(entity);
            _db.SaveChanges();
        }

        /// <inheritdoc />
        public bool CheckIfCandlestickExists(Candlestick candlestick)
        {
            return GetCandlestickEntity(candlestick.OpenTime, candlestick.TradingPair.Id) != null;
        }

        /// <inheritdoc />
        public Datalayer.TimescaleDB.Entities.Candlestick GetCandlestickEntity(DateTime openTime, int tradingPairId)
        {
            return _db.Candlesticks.Find(openTime, tradingPairId);
        }

        /// <inheritdoc />
        public ICollection<Candlestick> GetCandlesticks(int tradingPairId, DateTime startDate, DateTime endDate)
        {
            var entities = _db.Candlesticks.Where(c => c.TradingPairId == tradingPairId &&  c.OpenTime >= startDate && c.OpenTime <= endDate).ToList();
            return entities.Select(_mapper.Map<Candlestick>).ToList();
        }

        /// <inheritdoc />
        public void UpdateCandlestick(Candlestick candlestick)
        {
            var entity = GetCandlestickEntity(candlestick.OpenTime, candlestick.TradingPair.Id);
            
            entity.Open = candlestick.Open;
            entity.High = candlestick.High;
            entity.Low = candlestick.Low;
            entity.Close = candlestick.Close;
            entity.Volume = candlestick.Volume;
            
            _db.SaveChanges();
        }

        #endregion
    }
}