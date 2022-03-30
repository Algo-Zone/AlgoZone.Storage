using AlgoZone.Storage.Datalayer.TimescaleDB;
using LightInject;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AlgoZone.Storage.Extensions
{
    public static class DatabaseContainerExtensions
    {
        #region Methods

        #region Static Methods

        public static void AddDatabaseContexts(this IServiceRegistry services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("TimescaleDb");
            services.Register(factory =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<TimescaleDbContext>();
                optionsBuilder.UseNpgsql(connectionString, providerOptions => providerOptions.EnableRetryOnFailure());
                return new TimescaleDbContext(optionsBuilder.Options);
            });
            services.Register<DbContext>(factory => factory.GetInstance<TimescaleDbContext>());
        }

        #endregion

        #endregion
    }
}