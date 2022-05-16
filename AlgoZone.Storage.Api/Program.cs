using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace AlgoZone.Storage.Api
{
    public class Program
    {
        #region Methods

        #region Static Methods

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });

        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .ConfigureAppConfiguration(config =>
                {
                    config.AddUserSecrets<Program>();
                })
                .Build()
                .Run();
        }

        #endregion

        #endregion
    }
}