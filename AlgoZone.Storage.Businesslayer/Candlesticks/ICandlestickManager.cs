using System;
using System.Collections.Generic;
using AlgoZone.Storage.Businesslayer.Candlesticks.Models;

namespace AlgoZone.Storage.Businesslayer.Candlesticks
{
    public interface ICandlestickManager
    {
        #region Methods

        /// <summary>
        /// Get a list of candlesticks between two date times.
        /// </summary>
        /// <param name="symbol">The symbol for which to get the candlesticks.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns></returns>
        ICollection<Candlestick> GetCandlesticks(string symbol, DateTime startDate, DateTime endDate);

        /// <summary>
        /// Adds a candlestick.
        /// </summary>
        /// <param name="candlestick">The candlestick to add.</param>
        /// <returns></returns>
        bool UpdateCandlestick(Candlestick candlestick);

        #endregion
    }
}