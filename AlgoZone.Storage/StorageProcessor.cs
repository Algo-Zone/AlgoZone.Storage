using System.Collections.Generic;
using System.Threading.Tasks;
using AlgoZone.Storage.Businesslayer.EventRunners;

namespace AlgoZone.Storage
{
    public class StorageProcessor
    {
        #region Fields

        private readonly IEnumerable<IEventRunner> _eventRunners;

        #endregion

        #region Constructors

        public StorageProcessor(IEnumerable<IEventRunner> eventRunners)
        {
            _eventRunners = eventRunners;
        }

        #endregion

        #region Methods

        public async Task StartProcessing()
        {
            await Parallel.ForEachAsync(_eventRunners, (runner, cancellationToken) => runner.Run(cancellationToken));
        }

        #endregion
    }
}