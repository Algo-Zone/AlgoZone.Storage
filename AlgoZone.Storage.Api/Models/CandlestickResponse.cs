using System;
using System.Text.Json.Serialization;

namespace AlgoZone.Storage.Api.Models
{
    public sealed class CandlestickResponse
    {
        #region Properties

        [JsonPropertyName("c")]
        public decimal Close { get; set; }

        [JsonPropertyName("h")]
        public decimal High { get; set; }

        [JsonPropertyName("l")]
        public decimal Low { get; set; }

        [JsonPropertyName("o")]
        public decimal Open { get; set; }

        [JsonPropertyName("ot")]
        public DateTime OpenTime { get; set; }

        [JsonPropertyName("v")]
        public decimal Volume { get; set; }

        #endregion
    }
}