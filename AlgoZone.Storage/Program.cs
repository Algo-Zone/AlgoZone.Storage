﻿using System;
using System.Threading.Tasks;
using AlgoZone.Storage.Businesslayer.Candlesticks;
using AlgoZone.Storage.Businesslayer.EventRunners;
using AlgoZone.Storage.Datalayer.RabbitMQ;
using AlgoZone.Storage.Datalayer.TimescaleDB;
using AlgoZone.Storage.Datalayer.TimescaleDB.Extensions;
using LightInject;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Topshelf;
using Host = Microsoft.Extensions.Hosting.Host;

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

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseLightInject(ConfigureServices);

        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var rc = HostFactory.Run(x =>
            {
                x.Service<Startup>(s =>
                {
                    s.ConstructUsing(c => host.Services.GetRequiredService<Startup>());
                    s.WhenStarted(startup => startup.Start());
                    s.WhenStopped(startup => startup.Stop());
                });
            });

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());
            Environment.ExitCode = exitCode;
        }

        private static void ConfigureDals(IServiceRegistry services)
        {
            services.Register(factory =>
            {
                var host = _configuration.GetSection(ConfigurationConstants.RabbitMqHost).Value;
                var username = _configuration.GetSection(ConfigurationConstants.RabbitMqUsername).Value;
                var password = _configuration.GetSection(ConfigurationConstants.RabbitMqPassword).Value;
                return new RabbitMqDal(host, username, password);
            });
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
            services.Register<DbContext>(factory => factory.GetInstance<TimescaleDbContext>());
        }

        private static void ConfigureEventRunners(IServiceRegistry services)
        {
            services.Register<IEventRunner, CandlestickEventRunner>(nameof(CandlestickEventRunner));
        }

        private static void ConfigureManagers(IServiceRegistry services)
        {
            services.Register<ICandlestickManager, CandlestickManager>();
        }

        private static void ConfigureServices(IServiceRegistry services)
        {
            CreateConfiguration();
            
            ConfigureDbContext(services);
            ConfigureDals(services);
            ConfigureManagers(services);
            ConfigureEventRunners(services);

            services.Register(factory => _configuration);
            services.Register<StorageProcessor, StorageProcessor>();
            
            services.Register<Startup>();
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