using System;
using System.Collections.Generic;
using AlgoZone.Storage.Businesslayer.Candlesticks.Models;
using AlgoZone.Storage.Businesslayer.Candlesticks.Stores;
using AlgoZone.Storage.Businesslayer.TradingPairs;
using NLog;

namespace AlgoZone.Storage.Businesslayer.Candlesticks
{
    public class CandlestickManager : ICandlestickManager
    {
        #region Fields

        private readonly ICandlestickStore _candlestickStore;

        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        private readonly ITradingPairManager _tradingPairManager;

        #endregion

        #region Constructors

        public CandlestickManager(ICandlestickStore candlestickStore, ITradingPairManager tradingPairManager)
        {
            _candlestickStore = candlestickStore;
            _tradingPairManager = tradingPairManager;
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public ICollection<Candlestick> GetCandlesticks(string symbol, DateTime startDate, DateTime endDate)
        {
            try
            {
                var tradingPair = _tradingPairManager.GetTradingPair(symbol);
                return _candlestickStore.GetCandlesticks(tradingPair.Id, startDate, endDate);
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }

            return new List<Candlestick>();
        }

        /// <inheritdoc />
        public bool UpdateCandlestick(Candlestick candlestick)
        {
            try
            {
                if(_candlestickStore.CheckIfCandlestickExists(candlestick))
                    _candlestickStore.UpdateCandlestick(candlestick);
                else
                    _candlestickStore.AddCandlestick(candlestick);

                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }

            return false;
        }

        #endregion
    }
}