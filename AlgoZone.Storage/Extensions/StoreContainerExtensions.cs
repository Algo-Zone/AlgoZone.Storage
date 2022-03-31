using AlgoZone.Storage.Businesslayer.Assets.Stores;
using AlgoZone.Storage.Businesslayer.Candlesticks.Stores;
using AlgoZone.Storage.Businesslayer.TradingPairs.Stores;
using LightInject;

namespace AlgoZone.Storage.Extensions
{
    public static class StoreContainerExtensions
    {
        #region Methods

        #region Static Methods

        public static void AddStores(this IServiceRegistry services)
        {
            services.Register<IAssetStore, TimescaleAssetStore>();
            services.Register<ITradingPairStore, TimescaleTradingPairStore>();
            services.Register<ICandlestickStore, TimescaleCandlestickStore>();
        }

        #endregion

        #endregion
    }
}