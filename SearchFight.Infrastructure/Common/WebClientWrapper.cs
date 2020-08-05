using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SearchFight.Infrastructure.Common
{
    public class WebClientWrapper
    {
        public static async Task<TResult> GetAsync<TResult>(Uri url, IEnumerable<(string keyName, string keyValue)> headers = null)
        {
            WebClientSingleton.Instance.DefaultRequestHeaders.Clear();

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    WebClientSingleton.Instance.DefaultRequestHeaders.Add(header.keyName, header.keyValue);
                }
            }

            string resultString = await WebClientSingleton.Instance.GetStringAsync(url);
            TResult result = JsonSerializer.Deserialize<TResult>(resultString);

            return result;
        }
    }
}
