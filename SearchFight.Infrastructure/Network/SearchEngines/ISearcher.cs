using SearchFight.Domain.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Infrastructure.SearchEngines
{
    public interface ISearcher
    {
        string Name { get; }
        Task<SearchText> SearchAsync(string searchText);
    }
}
