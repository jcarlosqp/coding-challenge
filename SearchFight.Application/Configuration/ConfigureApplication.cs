using Microsoft.Extensions.DependencyInjection;
using SearchFight.Application.Queries;
using SearchFight.Domain.Interfaces;
using SearchFight.Domain.Services;
using SearchFight.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchFight.Application.Configuration
{
    public class ConfigureApplication
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ISearchQuery, SearchQuery>();
            services.AddSingleton<ISearchRepository, SearchRepository>();
            services.AddSingleton<ISearchDomainService, SearchDomainService>();
        }
    }
}
