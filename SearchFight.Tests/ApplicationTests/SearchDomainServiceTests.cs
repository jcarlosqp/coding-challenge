using SearchFight.Domain;
using SearchFight.Domain.Services;
using SearchFight.Domain.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SearchFight.Tests.Application
{
    public class SearchDomainServiceTests
    {
        private SearchDomainService _searchDomainService;
        private SearchModel _search1Model;
        private SearchModel _search2Model;

        private const string _java = "JAVA";
        private const string _net = ".NET";
        private const string _python = "PYTHON";

        private const string _searcher1 = "SEARCHER-1";
        private const string _searcher2 = "SEARCHER-2";

        public SearchDomainServiceTests()
        {
            this._search1Model = new SearchModel()
            {
                SearcherName = _searcher1,
                Terms = new List<SearchText>()
                {
                    new SearchText(_net, 45000),
                    new SearchText(_java, 62000)
                } 
            };
            this._search2Model = new SearchModel()
            {
                SearcherName = _searcher2,
                Terms = new List<SearchText>()
                {
                    new SearchText(_net, 9999000),
                    new SearchText(_java, 650000)
                }
            };
        }

        [Fact]
        public void TestTotalWinnerOfTwoSearchEngine()
        {
            //Arrange
            this._searchDomainService = new SearchDomainService();
            var results = new List<SearchModel>() { this._search1Model, this._search2Model };

            //Act
            results = this._searchDomainService.ProcessWinner(results);

            //Assert
            Assert.Equal(_net, results.FirstOrDefault(r => r.SearcherName.ToLower() == "total").WinnerName);
        }

    }
}
