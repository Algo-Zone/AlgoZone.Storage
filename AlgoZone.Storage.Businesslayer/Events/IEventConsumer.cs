using System;
using System.Threading.Tasks;
using AlgoZone.Core.EventData;

namespace AlgoZone.Storage.Businesslayer.Events
{
    public interface IEventConsumer<TEventType>
        where TEventType : IEventData
    {
        #region Events

        /// <summary>
        /// The event handler for when new messages are received.
        /// </summary>
        event EventHandler<TEventType> MessageReceived;

        #endregion

        #region Methods

        /// <summary>
        /// Registers the event consumer;
        /// </summary>
        Task RegisterConsumerAsync();

        /// <summary>
        /// Unregisters the event consumer.
        /// </summary>
        void UnregisterConsumer();

        #endregion
    }
}