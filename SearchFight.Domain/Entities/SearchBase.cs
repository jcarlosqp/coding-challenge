using SearchFight.Domain.Interfaces;
using SearchFight.Domain.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchFight.Domain
{
    public abstract class SearchBase : ISearch
    {
        public string SearcherName { get; set; }
        public List<SearchText> Terms { get; set; }
        public SearchText Winner { get; private set; }

        public virtual void Process() {
            this.Winner = Terms.Max();
        }
    }
}
