using System;
using System.Threading.Tasks;
using AlgoZone.Core.EventData;
using AlgoZone.Storage.Datalayer.RabbitMQ;

namespace AlgoZone.Storage.Businesslayer.Events
{
    public sealed class RabbitMqEventConsumer<TEventType> : IEventConsumer<TEventType>
        where TEventType : IEventData
    {
        #region Fields

        private readonly RabbitMqDal _dal;

        private Guid _subscriptionId;

        #endregion

        #region Constructors

        public RabbitMqEventConsumer(RabbitMqDal rabbitMqDal)
        {
            _dal = rabbitMqDal;
        }

        #endregion

        #region Events

        /// <inheritdoc />
        public event EventHandler<TEventType> MessageReceived;

        #endregion

        #region Methods

        /// <inheritdoc />
        public async Task RegisterConsumerAsync()
        {
            _subscriptionId = await _dal.RegisterConsumerAsync(MessageReceived);
        }

        /// <inheritdoc />
        public void UnregisterConsumer()
        {
            _dal.UnregisterConsumerAsync(_subscriptionId);
        }

        #endregion
    }
}