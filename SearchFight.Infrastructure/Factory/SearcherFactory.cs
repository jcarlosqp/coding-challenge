using Microsoft.Extensions.Configuration;
using SearchFight.Infrastructure.SearchEngines;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchFight.Infrastructure.Factory
{
    public class SearcherFactory
    {
        public static List<ISearcher> CreateSearchers(IConfiguration config)
        {
            return new List<ISearcher>
            {
                new GoogleSearcher(config),
                new BingSearcher(config)
            };
        }
    }
}
