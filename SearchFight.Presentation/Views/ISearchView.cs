using SearchFight.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchFight.Presentation.Views
{
    interface ISearchView
    {
        void Load(IEnumerable<SearchResult> model);
    }
}
