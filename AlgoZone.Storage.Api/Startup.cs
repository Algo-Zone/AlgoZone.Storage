using System.Linq;
using AlgoZone.Storage.Api.Mappers;
using AlgoZone.Storage.Businesslayer.Candlesticks;
using AlgoZone.Storage.Businesslayer.Candlesticks.Stores;
using AlgoZone.Storage.Businesslayer.Mappers;
using AlgoZone.Storage.Businesslayer.TradingPairs;
using AlgoZone.Storage.Businesslayer.TradingPairs.Stores;
using AlgoZone.Storage.Datalayer.TimescaleDB;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace AlgoZone.Storage.Api
{
    public class Startup
    {
        #region Properties

        public IConfiguration Configuration { get; }

        #endregion

        #region Constructors

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion

        #region Methods

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AlgoZone.Storage.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
                o.ReportApiVersions = true;
                o.ApiVersionReader = new HeaderApiVersionReader("X-Version");
            });
            services.AddVersionedApiExplorer(o =>
            {
                o.GroupNameFormat = "'v'VVV";
            });
            
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "AlgoZone.Storage.Api", Version = "v1" }); });

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CandlestickResponseProfile>();
                cfg.AddProfile<CandlestickProfile>();
                cfg.AddProfile<TradingPairProfile>();
            });
            
            var connectionString = Configuration.GetConnectionString("TimescaleDb");
            services.AddSingleton(factory =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<TimescaleDbContext>();
                optionsBuilder.UseNpgsql(connectionString, providerOptions => providerOptions.EnableRetryOnFailure());
                return new TimescaleDbContext(optionsBuilder.Options);
            });
            services.AddSingleton<DbContext>(factory => factory.GetRequiredService<TimescaleDbContext>());
            
            services.AddSingleton(c => config.CreateMapper());
            
            services.AddSingleton<ITradingPairStore, TimescaleTradingPairStore>();
            services.AddSingleton<ICandlestickStore, TimescaleCandlestickStore>();
            
            services.AddSingleton<ITradingPairManager, TradingPairManager>();
            services.AddSingleton<ICandlestickManager, CandlestickManager>();
        }

        #endregion
    }
}