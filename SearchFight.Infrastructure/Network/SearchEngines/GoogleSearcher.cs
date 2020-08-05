using Microsoft.Extensions.Configuration;
using SearchFight.Domain.ValueTypes;
using SearchFight.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Infrastructure.SearchEngines
{
    public class GoogleSearcher : ISearcher
    {
        private IConfiguration _config;

        public string Name { get; private set; }

        private string _urlBase { get; set; }

        public GoogleSearcher(IConfiguration config)
        {
            this._config = config;
            Name = this._config["GoogleName"].ToString();

            string queryParams = $"&key={this._config["GoogleApiKey"]}&cx={this._config["GoogleApiEngine"]}&q=";
            this._urlBase = this._config["GoogleApiUrl"].ToString() + queryParams;
        }


        public async Task<SearchText> SearchAsync(string searchText)
        {
            var Url = new Uri(this._urlBase + searchText.Replace(" ", "+"));

            var searchResult = await WebClientWrapper.GetAsync<GoogleSearchResult>(Url);

            return new SearchText()
            {
                Name = searchText,
                Results = Convert.ToInt64(searchResult.searchInformation.totalResults),
                Searcher = this.Name
            };
        }
    }
}
