using System;
using System.Collections.Generic;
using System.Text;

namespace SearchFight.Infrastructure.Network.SearchEngines
{
    public class BingSearchResult
    {
        public WebPages webPages { get; set; }
    }

    public class WebPages
    {
        public long totalEstimatedMatches { get; set; }
    }
}
