using System;
using System.Collections.Generic;
using System.Linq;
using AlgoZone.Storage.Businesslayer.Assets.Models;
using AlgoZone.Storage.Businesslayer.TradingPairs.Models;
using AlgoZone.Storage.Businesslayer.TradingPairs.Stores;
using NLog;

namespace AlgoZone.Storage.Businesslayer.TradingPairs
{
    public class TradingPairManager : ITradingPairManager
    {
        #region Fields

        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        private readonly ITradingPairStore _tradingPairStore;

        #endregion

        #region Constructors

        public TradingPairManager(ITradingPairStore tradingPairStore)
        {
            _tradingPairStore = tradingPairStore;
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public bool AddTradingPair(Asset baseAsset, Asset quoteAsset)
        {
            if (quoteAsset.Id <= 0)
                throw new ArgumentNullException(nameof(quoteAsset));

            if (baseAsset.Id <= 0)
                throw new ArgumentNullException(nameof(baseAsset));

            try
            {
                var symbol = $"{baseAsset.Name}{quoteAsset.Name}";
                if (GetTradingPair(symbol) != null)
                    return true;
                
                var tradingPair = new TradingPair
                {
                    Symbol = symbol,
                    BaseAsset = baseAsset,
                    QuoteAsset = quoteAsset
                };
                _tradingPairStore.AddTradingPair(tradingPair);

                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }

            return false;
        }

        /// <inheritdoc />
        public TradingPair GetTradingPair(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException(nameof(id));

            try
            {
                return _tradingPairStore.GetTradingPairById(id);
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }

            return null;
        }

        /// <inheritdoc />
        public TradingPair GetTradingPair(string symbol)
        {
            if (string.IsNullOrWhiteSpace(symbol))
                throw new ArgumentNullException(nameof(symbol));

            try
            {
                return _tradingPairStore.GetTradingPairBySymbol(symbol.ToUpper());
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }

            return null;
        }

        /// <inheritdoc />
        public IEnumerable<TradingPair> GetTradingPairsForBaseAsset(Asset baseAsset)
        {
            if (baseAsset.Id <= 0)
                throw new ArgumentOutOfRangeException(nameof(baseAsset));

            try
            {
                return _tradingPairStore.GetTradingPairsForBaseAsset(baseAsset);
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }

            return Enumerable.Empty<TradingPair>();
        }

        /// <inheritdoc />
        public IEnumerable<TradingPair> GetTradingPairsForQuoteAsset(Asset quoteAsset)
        {
            if (quoteAsset.Id <= 0)
                throw new ArgumentOutOfRangeException(nameof(quoteAsset));

            try
            {
                return _tradingPairStore.GetTradingPairsForQuoteAsset(quoteAsset);
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }

            return Enumerable.Empty<TradingPair>();
        }

        #endregion
    }
}