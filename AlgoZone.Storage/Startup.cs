using System.Threading;
using AlgoZone.Storage.Datalayer.TimescaleDB;
using AlgoZone.Storage.Datalayer.TimescaleDB.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AlgoZone.Storage
{
    public class Startup
    {
        #region Fields

        private readonly StorageProcessor _storageProcessor;

        private Thread runningThread;

        #endregion

        #region Constructors

        public Startup(StorageProcessor storageProcessor, TimescaleDbContext timescaleDbContext)
        {
            _storageProcessor = storageProcessor;

            timescaleDbContext.Database.Migrate();
            timescaleDbContext.ApplyHypertables();
        }

        #endregion

        #region Methods

        public void Start()
        {
            var threadDelegate = new ThreadStart(StartProcessor);
            runningThread = new Thread(threadDelegate);
            runningThread.Start();
        }

        public void Stop()
        {
            runningThread.Abort();
        }

        private void StartProcessor()
        {
            _storageProcessor.StartProcessing();
        }

        #endregion
    }
}