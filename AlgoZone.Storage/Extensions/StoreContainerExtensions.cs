using AlgoZone.Storage.Businesslayer.Candlesticks.Stores;
using LightInject;

namespace AlgoZone.Storage.Extensions
{
    public static class StoreContainerExtensions
    {
        #region Methods

        #region Static Methods

        public static void AddStores(this IServiceRegistry services)
        {
            services.Register<ICandlestickStore, TimescaleCandlestickStore>();
        }

        #endregion

        #endregion
    }
}