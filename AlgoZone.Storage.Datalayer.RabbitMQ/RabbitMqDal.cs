using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyNetQ;
using NLog;

namespace AlgoZone.Storage.Datalayer.RabbitMQ
{
    public class RabbitMqDal : IDisposable
    {
        #region Fields

        private readonly IBus _bus;

        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        private readonly IDictionary<Guid, IDisposable> _subscriptions;

        #endregion

        #region Constructors

        public RabbitMqDal(string hostname, string username, string password)
        {
            _bus = RabbitHutch.CreateBus($"host={hostname};username={username};password={password};publisherConfirms=true;timeout=10");
            _subscriptions = new ConcurrentDictionary<Guid, IDisposable>();
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public void Dispose()
        {
            _bus.Dispose();
        }

        public async Task<Guid> RegisterConsumerAsync<TEventType>(EventHandler<TEventType> onMessageReceived)
        {
            var subscription = await _bus.PubSub.SubscribeAsync<TEventType>($"{AppDomain.CurrentDomain.FriendlyName}", (msg, _) =>
            {
                AssertMessageNotNull(msg);

                onMessageReceived?.Invoke(this, msg);

                return Task.CompletedTask;
            }, cfg => cfg.WithPrefetchCount(1));

            var guid = Guid.NewGuid();
            _subscriptions.Add(guid, subscription);

            return guid;
        }

        public void UnregisterConsumerAsync(Guid subscriptionId)
        {
            _subscriptions.Remove(subscriptionId);
        }

        private void AssertMessageNotNull<TEventType>(TEventType message)
        {
            if (message == null)
                throw new Exception("Empty msg, could not process.");
        }

        #endregion
    }
}