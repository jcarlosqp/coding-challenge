using SearchFight.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchFight.Presentation.Views
{
    public class SearchResultsView: ISearchView
    {
        public void Load(IEnumerable<SearchResult> model)
        {
            var sb = Generate(model);
            Console.WriteLine(sb);
        }

        private StringBuilder Generate(IEnumerable<SearchResult> model)
        {
            const string TOTAL_KEY = "total";
            StringBuilder sbRow;
            var sbTotal = new StringBuilder();
            var dictionary = new Dictionary<string, StringBuilder>();

            foreach (var searchers in model.Where(m => m.Name.ToLower() != TOTAL_KEY))
            {
                foreach (var result in searchers.Results)
                {
                    if (!dictionary.TryGetValue(result.keyword, out sbRow)) sbRow = new StringBuilder();
                    dictionary[result.keyword] = sbRow.Append($"\t{searchers.Name}: {result.result}");
                }
                sbTotal.AppendLine($"{searchers.Name} Winner: {searchers.Winner}"); 
            }

            var sb = new StringBuilder();
            sb.AppendLine("SearchFight results:");
            sb.AppendLine();

            foreach (var e in dictionary)
            {
                sb.Append($"{e.Key}:");
                sb.Append(e.Value);
                sb.AppendLine();
            }
            sb.AppendLine();

            sb.Append(sbTotal);
            sb.AppendLine();
            var totalWinnerModel = model.FirstOrDefault(m => m.Name.ToLower() == TOTAL_KEY);
            sb.AppendLine($"Total Winner: {totalWinnerModel.Winner}");
            
            return sb;
        }
    }
}
