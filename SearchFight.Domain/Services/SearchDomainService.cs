using SearchFight.Domain.Interfaces;
using SearchFight.Domain.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchFight.Domain.Services
{
    public class SearchDomainService : ISearchDomainService
    {
        public List<SearchModel> ProcessWinner(List<SearchModel> searchs)
        {
            //Execute Domain Logic by Search engine
            searchs.ForEach(s => s.Process());

            //Execute Domain Logic for Total Winner
            var totalModel = new SearchModel();
            totalModel.SearcherName = "Total";

            //Process totals by search text
            totalModel.Terms = searchs.SelectMany(s => s.Terms)
                      .GroupBy(g => g.Name, g=>g.Results, (key,results) => new SearchText(key,results.Sum()))
                      .ToList();

            //Process total winner
            totalModel.Process();

            searchs.Add(totalModel);
            return searchs;
        }
    }
}
