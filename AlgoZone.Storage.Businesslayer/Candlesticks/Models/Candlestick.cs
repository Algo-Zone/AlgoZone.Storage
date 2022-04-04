using System;
using AlgoZone.Storage.Businesslayer.TradingPairs.Models;

namespace AlgoZone.Storage.Businesslayer.Candlesticks.Models
{
    public class Candlestick
    {
        #region Properties

        public decimal Close { get; set; }

        public decimal High { get; set; }

        public decimal Low { get; set; }

        public decimal Open { get; set; }

        public DateTime OpenTime { get; set; }

        public TradingPair TradingPair { get; set; }

        public decimal Volume { get; set; }

        #endregion
    }
}