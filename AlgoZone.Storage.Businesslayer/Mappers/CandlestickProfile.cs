using AlgoZone.Core.EventData;
using AlgoZone.Storage.Businesslayer.Candlesticks.Models;
using AutoMapper;

namespace AlgoZone.Storage.Businesslayer.Mappers
{
    public sealed class CandlestickProfile : Profile
    {
        public CandlestickProfile()
        {
            CreateMap<SymbolCandlestick, Candlestick>();

            CreateMap<Candlestick, Datalayer.TimescaleDB.Entities.Candlestick>();
        }
    }
}