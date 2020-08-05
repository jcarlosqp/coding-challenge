using SearchFight.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchFight.Application.Queries
{
    public interface ISearchQuery
    {
        public IEnumerable<SearchResult> Execute(List<string> keywords);
    }
}
