using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace SearchFight.Domain.ValueTypes
{
    public struct SearchText: IComparable<SearchText>
    {
        public string Name { get; set; }
        public long Results { get; set; }
        public string Searcher { get; set; }
        public SearchText(string name, long results, string searcher = null)
        {
            this.Name = name;
            this.Results = results;
            this.Searcher = searcher;
        }

        public int CompareTo(SearchText other)
        {
            return Results.CompareTo(other.Results);
        }
    }

}
