using System;
using System.Collections.Generic;
using System.Linq;
using AlgoZone.Storage.Businesslayer.Assets.Models;
using AlgoZone.Storage.Businesslayer.TradingPairs.Models;
using AlgoZone.Storage.Datalayer.TimescaleDB;
using AutoMapper;

namespace AlgoZone.Storage.Businesslayer.TradingPairs.Stores
{
    public sealed class TimescaleTradingPairStore : ITradingPairStore
    {
        #region Fields

        private readonly TimescaleDbContext _db;

        private readonly IMapper _mapper;

        #endregion

        #region Constructors

        public TimescaleTradingPairStore(IMapper mapper, TimescaleDbContext db)
        {
            _mapper = mapper;
            _db = db;
        }

        #endregion

        #region Methods

        #endregion

        /// <inheritdoc />
        public void AddTradingPair(TradingPair tradingPair)
        {
            var entity = _mapper.Map<Datalayer.TimescaleDB.Entities.TradingPair>(tradingPair);
            if (entity == null)
                return;
            
            _db.TradingPairs.Add(entity);
            _db.SaveChanges();
        }

        /// <inheritdoc />
        public TradingPair GetTradingPairById(int id)
        {
            var entity = _db.TradingPairs.Find(id);
            if (entity == null)
                return null;

            return _mapper.Map<TradingPair>(entity);
        }

        /// <inheritdoc />
        public TradingPair GetTradingPairBySymbol(string symbol)
        {
            var entity = _db.TradingPairs.FirstOrDefault(tp => tp.Symbol == symbol);
            if (entity == null)
                return null;

            return _mapper.Map<TradingPair>(entity);
        }

        /// <inheritdoc />
        public IEnumerable<TradingPair> GetTradingPairsForBaseAsset(Asset baseAsset)
        {
            return _db.TradingPairs
                      .Where(tp => tp.BaseAssetId == baseAsset.Id)
                      .ToList()
                      .Select(_mapper.Map<TradingPair>)
                      .ToList();
        }

        /// <inheritdoc />
        public IEnumerable<TradingPair> GetTradingPairsForQuoteAsset(Asset quoteAsset)
        {
            return _db.TradingPairs
                      .Where(tp => tp.QuoteAssetId == quoteAsset.Id)
                      .ToList()
                      .Select(_mapper.Map<TradingPair>)
                      .ToList();
        }
    }
}