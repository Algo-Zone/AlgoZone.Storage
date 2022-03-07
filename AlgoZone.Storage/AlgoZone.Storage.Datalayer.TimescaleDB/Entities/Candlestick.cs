using System.ComponentModel.DataAnnotations.Schema;
using AlgoZone.Storage.Datalayer.TimescaleDB.Attributes;

namespace AlgoZone.Storage.Datalayer.TimescaleDB.Entities
{
    [Hypertable]
    public class Candlestick
    {
        #region Properties

        [Column(TypeName = "float", Order = 5)]
        public float Close { get; set; }

        [Column(TypeName = "float", Order = 3)]
        public float High { get; set; }

        [Column(TypeName = "bigserial", Order = 0)]
        public long Id { get; set; }

        [Column(TypeName = "float", Order = 4)]
        public float Low { get; set; }

        [Column(TypeName = "float", Order = 2)]
        public float Open { get; set; }

        [HypertableTimeColumn]
        [Column(TypeName = "timestamptz", Order = 1)]
        public DateTime Timestamp { get; set; }

        [Column(TypeName = "float", Order = 6)]
        public float Volume { get; set; }

        #endregion
    }
}