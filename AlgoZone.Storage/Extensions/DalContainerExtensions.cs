using AlgoZone.Storage.Datalayer.RabbitMQ;
using LightInject;
using Microsoft.Extensions.Configuration;

namespace AlgoZone.Storage.Extensions
{
    public static class DalContainerExtensions
    {
        #region Methods

        #region Static Methods

        public static void AddDatalayers(this IServiceRegistry services, IConfiguration configuration)
        {
            services.Register(factory =>
            {
                var host = configuration.GetSection(ConfigurationConstants.RabbitMqHost).Value;
                var username = configuration.GetSection(ConfigurationConstants.RabbitMqUsername).Value;
                var password = configuration.GetSection(ConfigurationConstants.RabbitMqPassword).Value;
                return new RabbitMqDal(host, username, password);
            });
        }

        #endregion

        #endregion
    }
}