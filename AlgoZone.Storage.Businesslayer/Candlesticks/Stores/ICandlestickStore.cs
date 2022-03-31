using AlgoZone.Storage.Businesslayer.Candlesticks.Models;

namespace AlgoZone.Storage.Businesslayer.Candlesticks.Stores
{
    public interface ICandlestickStore
    {
        #region Methods

        /// <summary>
        /// Adds a candlestick to the store.
        /// </summary>
        /// <param name="candlestick">The candlestick to add.</param>
        void AddCandlestick(Candlestick candlestick);

        #endregion
    }
}