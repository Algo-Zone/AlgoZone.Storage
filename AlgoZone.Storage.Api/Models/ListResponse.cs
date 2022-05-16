using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AlgoZone.Storage.Api.Models
{
    public sealed class ListResponse<TData>
        where TData : class
    {
        #region Properties

        [JsonPropertyName("items")]
        public IEnumerable<TData> Items { get; set; }

        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }

        #endregion
    }
}