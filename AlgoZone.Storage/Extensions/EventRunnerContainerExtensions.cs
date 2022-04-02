using AlgoZone.Storage.Businesslayer.EventRunners;
using LightInject;

namespace AlgoZone.Storage.Extensions
{
    public static class EventRunnerContainerExtensions
    {
        #region Methods

        #region Static Methods

        public static void AddEventRunners(this IServiceRegistry services)
        {
            services.Register<IEventRunner, CandlestickEventRunner>(nameof(CandlestickEventRunner));
            services.Register<IEventRunner, TradingPairsEventRunner>(nameof(TradingPairsEventRunner));
        }

        #endregion

        #endregion
    }
}