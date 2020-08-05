using SearchFight.Application.Models;
using SearchFight.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchFight.Application.Adapters
{
    internal class SearchModelAdapter
    {
        public static SearchResult GetSearchResult(SearchModel searchModel)
        {
            return new SearchResult()
            {
                Name = searchModel.SearcherName,
                Winner = searchModel.WinnerName,
                Results = searchModel.Terms.Select(e => (keyword: e.Name, result: e.Results))
            };
        }
    }
}
