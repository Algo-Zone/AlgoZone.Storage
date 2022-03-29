using System;

namespace AlgoZone.Storage.Businesslayer.Candlesticks.Models
{
    public class Candlestick
    {
        #region Properties

        public decimal Close { get; set; }

        public decimal High { get; set; }

        public decimal Low { get; set; }
        
        public decimal Open { get; set; }

        public decimal Volume { get; set; }
        
        public DateTime OpenTime { get; set; }

        #endregion
    }
}