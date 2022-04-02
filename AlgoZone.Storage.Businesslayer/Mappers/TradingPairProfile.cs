using AlgoZone.Storage.Businesslayer.TradingPairs.Models;
using AutoMapper;

namespace AlgoZone.Storage.Businesslayer.Mappers
{
    public class TradingPairProfile : Profile
    {
        #region Constructors

        public TradingPairProfile()
        {
            CreateMap<TradingPair, Datalayer.TimescaleDB.Entities.TradingPair>()
                .ReverseMap();
        }

        #endregion
    }
}