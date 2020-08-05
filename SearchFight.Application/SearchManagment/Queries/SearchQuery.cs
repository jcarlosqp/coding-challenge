using SearchFight.Application.Adapters;
using SearchFight.Application.Models;
using SearchFight.Domain.Interfaces;
using SearchFight.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchFight.Application.Queries
{
    public class SearchQuery : ISearchQuery
    {
        private ISearchRepository _searchRepository;
        private ISearchDomainService _searchDomainService;
        public SearchQuery(ISearchRepository searchRepository, ISearchDomainService searchDomainService)
        {
            this._searchRepository = searchRepository;
            this._searchDomainService = searchDomainService;
        }
        public IEnumerable<SearchResult> Execute(List<string> keywords)
        {
            //Process the searchs
            var searchs = this._searchRepository.Search(keywords).Result;
            
            //Execute Domain Logic
            var results = this._searchDomainService.ProcessWinner(searchs);

            IEnumerable<SearchResult> searchResult = results.Select(result => SearchModelAdapter.GetSearchResult(result));

            return searchResult;
        }


    }
}
