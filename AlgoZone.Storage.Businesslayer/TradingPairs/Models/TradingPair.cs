using AlgoZone.Storage.Businesslayer.Assets.Models;

namespace AlgoZone.Storage.Businesslayer.TradingPairs.Models
{
    public class TradingPair
    {
        #region Properties

        public Asset BaseAsset { get; set; }

        public int Id { get; set; }

        public Asset QuoteAsset { get; set; }

        public string Symbol { get; set; }

        #endregion
    }
}