using System.ComponentModel.DataAnnotations.Schema;

namespace AlgoZone.Storage.Datalayer.TimescaleDB.Entities
{
    public class TradingPair
    {
        #region Properties

        public virtual Asset BaseAsset { get; set; }

        [Column(Order = 1)]
        public int BaseAssetId { get; set; }

        [Column(Order = 0)]
        public int Id { get; set; }

        public virtual Asset QuoteAsset { get; set; }

        [Column(Order = 2)]
        public int QuoteAssetId { get; set; }

        [Column(Order = 3)]
        public string Symbol { get; set; }

        #endregion
    }
}