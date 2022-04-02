using AlgoZone.Storage.Businesslayer.Assets.Models;
using AutoMapper;

namespace AlgoZone.Storage.Businesslayer.Mappers
{
    public class AssetProfile : Profile
    {
        #region Constructors

        public AssetProfile()
        {
            CreateMap<Asset, Datalayer.TimescaleDB.Entities.Asset>()
                .ReverseMap();
        }

        #endregion
    }
}