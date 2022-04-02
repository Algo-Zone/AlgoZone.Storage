using System.Threading;
using System.Threading.Tasks;
using AlgoZone.Core.EventData;
using AlgoZone.Storage.Businesslayer.Assets;
using AlgoZone.Storage.Businesslayer.Assets.Models;
using AlgoZone.Storage.Businesslayer.Events;
using AlgoZone.Storage.Businesslayer.TradingPairs;
using AlgoZone.Storage.Datalayer.RabbitMQ;
using AutoMapper;

namespace AlgoZone.Storage.Businesslayer.EventRunners
{
    public class TradingPairsEventRunner : IEventRunner
    {
        #region Fields

        private readonly IAssetManager _assetManager;

        private readonly IEventConsumer<SymbolTradingPairEventData> _eventConsumer;

        private readonly IMapper _mapper;

        private readonly ITradingPairManager _tradingPairManager;

        #endregion

        #region Constructors

        public TradingPairsEventRunner(IAssetManager assetManager, ITradingPairManager tradingPairManager, IMapper mapper, RabbitMqDal rabbitMqDal)
        {
            _assetManager = assetManager;
            _tradingPairManager = tradingPairManager;
            _mapper = mapper;
            _eventConsumer = new RabbitMqEventConsumer<SymbolTradingPairEventData>(rabbitMqDal);

            _eventConsumer.MessageReceived += OnMessageReceived;
        }

        #endregion

        #region Events

        /// <summary>
        /// Event handler for messages received by consumer.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="eventData">The event data.</param>
        private void OnMessageReceived(object sender, SymbolTradingPairEventData eventData)
        {
            var tradingPair = _tradingPairManager.GetTradingPair(eventData.Data.Symbol);
            if (tradingPair != null)
                return;

            var baseAsset = _assetManager.GetAsset(eventData.Data.BaseAsset);
            if (baseAsset == null)
            {
                baseAsset = new Asset { Name = eventData.Data.BaseAsset, FullName = eventData.Data.BaseAsset };
                _assetManager.AddAsset(baseAsset);
            }

            var quoteAsset = _assetManager.GetAsset(eventData.Data.QuoteAsset);
            if (quoteAsset == null)
            {
                quoteAsset = new Asset { Name = eventData.Data.QuoteAsset, FullName = eventData.Data.QuoteAsset };
                _assetManager.AddAsset(quoteAsset);
            }

            _tradingPairManager.AddTradingPair(baseAsset, quoteAsset);
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