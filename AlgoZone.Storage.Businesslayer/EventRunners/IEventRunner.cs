using System.Threading;
using System.Threading.Tasks;

namespace AlgoZone.Storage.Businesslayer.EventRunners
{
    public interface IEventRunner
    {
        #region Methods

        /// <summary>
        /// Starts listening for the events.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        ValueTask Run(CancellationToken cancellationToken);

        /// <summary>
        /// Stops the event runner.
        /// </summary>
        void Stop();

        #endregion
    }
}