using SearchFight.Domain;
using SearchFight.Domain.ValueTypes;
using System;
using System.Collections.Generic;
using Xunit;

namespace SearchFight.Tests.Domain
{
    public class SearchModelTests
    {
        private SearchModel _searchModel;
        private List<SearchText> _resultsList;
        private const string _java = "JAVA";
        private const string _net = ".NET";
        private const string _python = "PYTHON";

        public SearchModelTests()
        {
            this._searchModel = new SearchModel();
            this._resultsList = new List<SearchText>()
            {
                new SearchText(_net, 45000),
                new SearchText(_java, 62000)
            };
        }

        [Fact]
        public void TestWinnerOfTwoSearchText()
        {
            //Arrange
            this._searchModel.Terms = this._resultsList;
            string expectedWinner = _java;
            //Act
            this._searchModel.Process();
            var winnerName = this._searchModel.Winner.Name;
            //Assert
            Assert.Equal(expectedWinner, winnerName);
        }

        [Fact]
        public void TestWinnerOfSearchText()
        {
            //Arrange
            this._searchModel.Terms = this._resultsList;
            this._searchModel.Terms.Add(new SearchText(_python, 950000));
            string expectedWinner = _python;
            //Act
            this._searchModel.Process();
            var winnerName = this._searchModel.Winner.Name;
            //Assert
            Assert.Equal(expectedWinner, winnerName);
        }
    }
}
