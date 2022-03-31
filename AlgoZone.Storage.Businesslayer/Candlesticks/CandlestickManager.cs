using System;
using AlgoZone.Storage.Businesslayer.Candlesticks.Models;
using AlgoZone.Storage.Businesslayer.Candlesticks.Stores;
using NLog;

namespace AlgoZone.Storage.Businesslayer.Candlesticks
{
    public class CandlestickManager : ICandlestickManager
    {
        #region Fields

        private readonly ICandlestickStore _candlestickStore;

        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Constructors

        public CandlestickManager(ICandlestickStore candlestickStore)
        {
            _candlestickStore = candlestickStore;
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public bool AddCandlestick(Candlestick candlestick)
        {
            try
            {
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