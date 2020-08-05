using System;
using System.Collections.Generic;
using System.Text;

namespace SearchFight.Application.Models
{
    public class SearchResult
    {
        public string Name { get; set; }
        public IEnumerable<(string keyword, long result)> Results { get; set; }
        public string Winner { get; set; }
    }
}
