using AlgoZone.Storage.Businesslayer.Candlesticks.Models;

namespace AlgoZone.Storage.Businesslayer.Candlesticks
{
    public interface ICandlestickManager
    {
        #region Methods

        /// <summary>
        /// Adds a candlestick.
        /// </summary>
        /// <param name="candlestick">The candlestick to add.</param>
        /// <returns></returns>
        bool UpdateCandlestick(Candlestick candlestick);

        #endregion
    }
}