using AlgoZone.Storage.Businesslayer.Candlesticks;
using LightInject;

namespace AlgoZone.Storage.Extensions
{
    public static class ManagerContainerExtensions
    {
        #region Methods

        #region Static Methods

        public static void AddManagers(this IServiceRegistry services)
        {
            services.Register<ICandlestickManager, CandlestickManager>();
        }

        #endregion

        #endregion
    }
}