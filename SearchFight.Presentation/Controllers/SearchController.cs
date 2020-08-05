using Microsoft.Extensions.Options;
using SearchFight.Application.Queries;
using SearchFight.Presentation.Exceptions;
using SearchFight.Presentation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchFight.Presentation.Controllers
{
    class SearchController: ISearchController
    {
        private ISearchQuery _searchService;
        private ISearchView _view;
        public SearchController(ISearchQuery searchService, ISearchView view)
        {
            this._searchService = searchService;
            this._view = view;
        }

        public void Search(string[] args)
        {
            if (this.ValidateArgs(args))
            {
                var keywords = args.ToList<string>();

                var searchResults = _searchService.Execute(keywords);

                this._view.Load(searchResults);
            }
            
        }

        private bool ValidateArgs(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                throw new SearchException("You should write some keywords to search.");
            }
            
            if (args.Length < 2) 
            {
                throw new SearchException("Provide at least two keywords to do the comparation.");
            }
            return true;
        }
    }
}
