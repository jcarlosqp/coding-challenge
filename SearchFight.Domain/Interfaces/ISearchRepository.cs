using SearchFight.Domain.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Domain.Interfaces
{
    public interface ISearchRepository
    {
        Task<List<SearchModel>> Search(List<string> keywords);
    }
}
