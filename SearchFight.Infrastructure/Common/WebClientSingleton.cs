using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SearchFight.Infrastructure.Common
{
    public sealed class WebClientSingleton
    {
        private static readonly Lazy<HttpClient> _client = new Lazy<HttpClient>();
        public static HttpClient Instance 
        { 
            get { return _client.Value; } 
        }

        private WebClientSingleton()
        {
        }
    }
}
