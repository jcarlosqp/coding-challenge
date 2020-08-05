using SearchFight.Application.Models;
using SearchFight.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchFight.Application.Adapters
{
    interface ISearchModelAdapter
    {
        SearchResult GetSearchResult(SearchModel searchModel);
    }
}
