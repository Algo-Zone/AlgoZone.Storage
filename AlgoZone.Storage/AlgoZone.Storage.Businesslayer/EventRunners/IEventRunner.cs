namespace AlgoZone.Storage.Businesslayer.EventRunners
{
    public interface IEventRunner
    {
        #region Methods

        /// <summary>
        /// Starts listening for the events.
        /// </summary>
        void Run();

        #endregion
    }
}