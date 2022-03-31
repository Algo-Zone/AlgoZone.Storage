using AlgoZone.Storage.Businesslayer.Mappers;
using AutoMapper;
using LightInject;

namespace AlgoZone.Storage.Extensions
{
    public static class MapperContainerExtensions
    {
        #region Methods

        #region Static Methods

        public static void AddMappers(this IServiceRegistry services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CandlestickProfile>();
            });
            services.Register(c => config.CreateMapper());
        }

        #endregion

        #endregion
    }
}