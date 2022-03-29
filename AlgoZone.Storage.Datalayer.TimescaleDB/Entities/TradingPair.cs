using System.ComponentModel.DataAnnotations.Schema;

namespace AlgoZone.Storage.Datalayer.TimescaleDB.Entities
{
    public class TradingPair
    {
        #region Properties

        public virtual Symbol BaseSymbol { get; set; }

        [Column(Order = 1)]
        public int BaseSymbolId { get; set; }

        [Column(Order = 0)]
        public int Id { get; set; }

        public virtual Symbol QuoteSymbol { get; set; }

        [Column(Order = 2)]
        public int QuoteSymbolId { get; set; }

        #endregion
    }
}