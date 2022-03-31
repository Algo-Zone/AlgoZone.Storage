using AlgoZone.Storage.Businesslayer.Assets;
using AlgoZone.Storage.Businesslayer.Candlesticks;
using AlgoZone.Storage.Businesslayer.TradingPairs;
using LightInject;

namespace AlgoZone.Storage.Extensions
{
    public static class ManagerContainerExtensions
    {
        #region Methods

        #region Static Methods

        public static void AddManagers(this IServiceRegistry services)
        {
            services.Register<IAssetManager, AssetManager>();
            services.Register<ITradingPairManager, TradingPairManager>();
            services.Register<ICandlestickManager, CandlestickManager>();
        }

        #endregion

        #endregion
    }
}