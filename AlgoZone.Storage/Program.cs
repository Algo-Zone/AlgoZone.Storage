using System.Threading.Tasks;
using AlgoZone.Storage.Businesslayer.Candlesticks;
using AlgoZone.Storage.Businesslayer.EventRunners;
using AlgoZone.Storage.Datalayer.TimescaleDB;
using LightInject;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AlgoZone.Storage
{
    public class Program
    {
        #region Fields

        private static IConfiguration _configuration;

        #endregion

        #region Constructors

        protected Program() { }

        #endregion

        #region Methods

        #region Static Methods

        public static async Task Main(string[] args)
        {
            CreateConfiguration();
            var container = ConfigureServices();

            var processor = container.GetInstance<StorageProcessor>();
            await processor.StartProcessing();
        }

        private static void ConfigureDbContext(IServiceRegistry services)
        {
            var connectionString = _configuration.GetConnectionString("TimescaleDb");
            services.Register(factory =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<TimescaleDbContext>();
                optionsBuilder.UseNpgsql(connectionString, providerOptions => providerOptions.EnableRetryOnFailure());
                return new TimescaleDbContext(optionsBuilder.Options);
            });
        }

        private static void ConfigureEventRunners(IServiceRegistry services)
        {
            services.Register<IEventRunner, CandlestickRunner>(nameof(CandlestickRunner));
        }

        private static void ConfigureManagers(IServiceRegistry services)
        {
            services.Register<ICandlestickManager, CandlestickManager>();
        }

        private static ServiceContainer ConfigureServices()
        {
            var container = new ServiceContainer();

            ConfigureDbContext(container);
            ConfigureManagers(container);
            ConfigureEventRunners(container);

            container.Register<StorageProcessor, StorageProcessor>();

            return container;
        }

        private static void CreateConfiguration()
        {
            _configuration = new ConfigurationBuilder()
                             .AddUserSecrets<Program>()
                             .Build();
        }

        #endregion

        #endregion
    }
}