using SearchFight.Domain.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchFight.Domain
{
    public class SearchModel : SearchBase
    {
        public SearchModel()
        {
            this.Terms = new List<SearchText>();
        }
        public string WinnerName => Winner.Name;

        public long WinnerResults => Winner.Results;
    }
}
