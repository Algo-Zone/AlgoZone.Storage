using AlgoZone.Storage.Businesslayer.Candlesticks;

namespace AlgoZone.Storage.Businesslayer.EventRunners
{
    public class CandlestickRunner : IEventRunner
    {
        #region Fields

        private ICandlestickManager _candlestickManager;

        #endregion

        #region Constructors

        public CandlestickRunner(ICandlestickManager candlestickManager)
        {
            _candlestickManager = candlestickManager;
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public ValueTask Run(CancellationToken cancellationToken)
        {
            return ValueTask.CompletedTask;
        }

        #endregion
    }
}