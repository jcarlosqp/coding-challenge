using Microsoft.Extensions.Configuration;
using SearchFight.Domain;
using SearchFight.Domain.Interfaces;
using SearchFight.Domain.ValueTypes;
using SearchFight.Infrastructure.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Infrastructure.Repositories
{
    public class SearchRepository : ISearchRepository
    {
        private IConfiguration _config;
        public SearchRepository(IConfiguration config)
        {
            this._config = config;
        }
        public async Task<List<SearchModel>> Search(List<string> keywords)
        {
            var searchers = SearcherFactory.CreateSearchers(_config);

            //Optimization for Parallel Searchs
            var searchTasks = new List<Task<SearchText>>();
            searchers.ForEach(s => keywords.ForEach(k => searchTasks.Add(s.SearchAsync(k))));
            await Task.WhenAll(searchTasks);

            var searchTextList = searchTasks.Select(s => s.Result);
 
            var results = searchTextList.GroupBy(s => s.Searcher, e => e, 
                            (k, searchs) => new SearchModel() { SearcherName = k, Terms = searchs.ToList() });


            return results.ToList();
        }
    }
}
