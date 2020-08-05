using Microsoft.Extensions.Configuration;
using SearchFight.Domain.ValueTypes;
using SearchFight.Infrastructure.Common;
using SearchFight.Infrastructure.Network.SearchEngines;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Infrastructure.SearchEngines
{
    public class BingSearcher : ISearcher
    {
        private IConfiguration _config;

        public string Name { get; private set; }

        private string _urlBase { get; set; }
        private List<(string keyName, string keyValue)> _headers { get; set; }

        public BingSearcher(IConfiguration config)
        {
            this._config = config;
            Name = this._config["BingName"].ToString();

            string queryParams = $"&q=";
            this._urlBase = this._config["BingApiUrl"].ToString() + queryParams;

            this._headers = new List<(string keyName, string keyValue)>();
            this._headers.Add((this._config["BingApiKeyName"], this._config["BingApiKeyValue"]));
        }


        public async Task<SearchText> SearchAsync(string searchText)
        {
            var Url = new Uri(this._urlBase + searchText.Replace(" ", "+"));

            var searchResult = await WebClientWrapper.GetAsync<BingSearchResult>(Url, this._headers);

            return new SearchText() { 
                Name = searchText,
                Results = searchResult.webPages.totalEstimatedMatches,
                Searcher = this.Name
            };
        }
    }
}
