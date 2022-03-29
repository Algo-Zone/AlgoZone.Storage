using System;
using System.ComponentModel.DataAnnotations.Schema;
using AlgoZone.Storage.Datalayer.TimescaleDB.Attributes;

namespace AlgoZone.Storage.Datalayer.TimescaleDB.Entities
{
    [Hypertable]
    public class Candlestick
    {
        #region Properties

        [Column(Order = 5)]
        public decimal Close { get; set; }

        [Column(Order = 3)]
        public decimal High { get; set; }

        [Column(Order = 4)]
        public decimal Low { get; set; }

        [Column(Order = 2)]
        public decimal Open { get; set; }

        [HypertableTimeColumn]
        [Column(Order = 0)]
        public DateTime Timestamp { get; set; }

        public virtual TradingPair TradingPair { get; set; }

        [Column(Order = 1)]
        public int TradingPairId { get; set; }

        [Column(Order = 6)]
        public decimal Volume { get; set; }

        #endregion
    }
}