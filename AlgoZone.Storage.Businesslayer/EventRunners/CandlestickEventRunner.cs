using System.Threading;
using System.Threading.Tasks;
using AlgoZone.Core.EventData;
using AlgoZone.Storage.Businesslayer.Candlesticks;
using AlgoZone.Storage.Businesslayer.Events;
using AlgoZone.Storage.Datalayer.RabbitMQ;

namespace AlgoZone.Storage.Businesslayer.EventRunners
{
    public class CandlestickEventRunner : IEventRunner
    {
        #region Fields

        private readonly ICandlestickManager _candlestickManager;

        private readonly IEventConsumer<SymbolTickEventData> _eventConsumer;

        #endregion

        #region Constructors

        public CandlestickEventRunner(ICandlestickManager candlestickManager, RabbitMqDal rabbitMqDal)
        {
            _candlestickManager = candlestickManager;
            _eventConsumer = new RabbitMqEventConsumer<SymbolTickEventData>(rabbitMqDal);

            _eventConsumer.MessageReceived += OnMessageReceived;
        }

        #endregion

        #region Events

        /// <summary>
        /// Event handler for messages.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="eventData">The event date.</param>
        private void OnMessageReceived(object sender, SymbolTickEventData eventData)
        {
            
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public async ValueTask Run(CancellationToken cancellationToken)
        {
            await _eventConsumer.RegisterConsumerAsync();
        }

        /// <inheritdoc />
        public void Stop()
        {
            _eventConsumer.UnregisterConsumer();
        }

        #endregion
    }
}