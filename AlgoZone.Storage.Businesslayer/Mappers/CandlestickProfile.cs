using AlgoZone.Core.EventData;
using AlgoZone.Storage.Businesslayer.Candlesticks.Models;
using AutoMapper;

namespace AlgoZone.Storage.Businesslayer.Mappers
{
    public sealed class CandlestickProfile : Profile
    {
        #region Constructors

        public CandlestickProfile()
        {
            CreateMap<SymbolCandlestick, Candlestick>()
                .ForMember(dst => dst.OpenTime, opts => opts.MapFrom(src => src.Timestamp));

            CreateMap<Candlestick, Datalayer.TimescaleDB.Entities.Candlestick>();
        }

        #endregion
    }
}