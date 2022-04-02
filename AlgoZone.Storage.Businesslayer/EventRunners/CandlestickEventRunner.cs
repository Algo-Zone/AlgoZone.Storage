using System.Threading;
using System.Threading.Tasks;
using AlgoZone.Core.EventData;
using AlgoZone.Storage.Businesslayer.Candlesticks;
using AlgoZone.Storage.Businesslayer.Candlesticks.Models;
using AlgoZone.Storage.Businesslayer.Events;
using AlgoZone.Storage.Datalayer.RabbitMQ;
using AutoMapper;

namespace AlgoZone.Storage.Businesslayer.EventRunners
{
    public class CandlestickEventRunner : IEventRunner
    {
        #region Fields

        private readonly ICandlestickManager _candlestickManager;

        private readonly IEventConsumer<SymbolCandlestickEventData> _eventConsumer;

        private readonly IMapper _mapper;

        #endregion

        #region Constructors

        public CandlestickEventRunner(ICandlestickManager candlestickManager, IMapper mapper, RabbitMqDal rabbitMqDal)
        {
            _candlestickManager = candlestickManager;
            _mapper = mapper;
            _eventConsumer = new RabbitMqEventConsumer<SymbolCandlestickEventData>(rabbitMqDal);

            _eventConsumer.MessageReceived += OnMessageReceived;
        }

        #endregion

        #region Events

        /// <summary>
        /// Event handler for messages.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="eventData">The event data.</param>
        private void OnMessageReceived(object sender, SymbolCandlestickEventData eventData)
        {
            var candlestick = _mapper.Map<Candlestick>(eventData.Data);
            _candlestickManager.AddCandlestick(candlestick);
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