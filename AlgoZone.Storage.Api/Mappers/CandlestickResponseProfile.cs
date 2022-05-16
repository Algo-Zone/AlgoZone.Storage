using AlgoZone.Storage.Api.Models;
using AlgoZone.Storage.Businesslayer.Candlesticks.Models;
using AutoMapper;

namespace AlgoZone.Storage.Api.Mappers
{
    public class CandlestickResponseProfile : Profile
    {
        #region Constructors

        public CandlestickResponseProfile()
        {
            CreateMap<Candlestick, CandlestickResponse>().ReverseMap();
        }

        #endregion
    }
}