using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SearchFight.Domain.Services
{
    public interface ISearchDomainService
    {
        public List<SearchModel> ProcessWinner(List<SearchModel> searchs);
    }
}
