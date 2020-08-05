using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SearchFight.Application.Configuration;
using SearchFight.Presentation.Controllers;
using SearchFight.Presentation.Views;
using System;
using System.IO;

namespace SearchFight.Presentation
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private IServiceProvider _provider;
        public Startup()
        {
            var environment = Environment.GetEnvironmentVariable("APP_ENVIRONMENT");

            _configuration = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .AddJsonFile($"appsettings.{environment}.json", optional: true)
                            .AddEnvironmentVariables()
                            .Build();           
        }

        public void ConfigureServices()
        {
            var services = new ServiceCollection();

            // add necessary services
            services.AddSingleton<IConfiguration>(_configuration);
            services.AddSingleton<ISearchView, SearchResultsView>();
            services.AddSingleton<ISearchController, SearchController>();

            ConfigureApplication.ConfigureServices(services);

            _provider = services.BuildServiceProvider();
        }

        public IServiceProvider Provider => _provider;

        public IConfiguration Configuration => _configuration;
    }
}
