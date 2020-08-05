using System;
using System.Collections.Generic;
using System.Text;

namespace SearchFight.Infrastructure.SearchEngines
{
    public class GoogleSearchResult
    {
        public SearchInformation searchInformation { get; set; }
    }

    public class SearchInformation
    {
        public string totalResults { get; set; }
        public string formattedTotalResults { get; set; }
    }
}
