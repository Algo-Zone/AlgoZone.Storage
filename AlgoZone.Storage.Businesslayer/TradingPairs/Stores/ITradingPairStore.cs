using System.Collections.Generic;
using AlgoZone.Storage.Businesslayer.Assets.Models;
using AlgoZone.Storage.Businesslayer.TradingPairs.Models;

namespace AlgoZone.Storage.Businesslayer.TradingPairs.Stores
{
    public interface ITradingPairStore
    {
        #region Methods

        /// <summary>
        /// Adds a new trading pair.
        /// </summary>
        /// <param name="tradingPair">The trading pair to add.</param>
        /// <returns></returns>
        void AddTradingPair(TradingPair tradingPair);

        /// <summary>
        /// Gets the trading pair by it's id.
        /// </summary>
        /// <param name="id">The id of the trading pair.</param>
        /// <returns></returns>
        TradingPair GetTradingPairById(int id);

        /// <summary>
        /// Gets the trading pair by it's id.
        /// </summary>
        /// <param name="symbol">The symbol of the pair.</param>
        /// <returns></returns>
        TradingPair GetTradingPairBySymbol(string symbol);

        /// <summary>
        /// Gets all the trading pairs for it's base assets.
        /// </summary>
        /// <param name="baseAsset">The base asset.</param>
        /// <returns></returns>
        IEnumerable<TradingPair> GetTradingPairsForBaseAsset(Asset baseAsset);

        /// <summary>
        /// Gets all the trading pairs for it's quote assets.
        /// </summary>
        /// <param name="quoteAsset">The quote asset.</param>
        /// <returns></returns>
        IEnumerable<TradingPair> GetTradingPairsForQuoteAsset(Asset quoteAsset);

        #endregion
    }
}