using SearchFight.Domain.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchFight.Domain.Interfaces
{
    interface ISearch
    {
        string SearcherName { get; set; }
        List<SearchText> Terms { set; get; }
        SearchText Winner { get; }
        void Process();
    }
}
