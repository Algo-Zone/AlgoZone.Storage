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

        #endregion
    }
}