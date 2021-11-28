using Newtonsoft.Json;
using Report.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Report.Infrastructure.Http
{
    public class HttpService : IHttpService
    {
        public async Task<T> GetAsync<T>(Uri uri, Dictionary<string, string> headers = null)
                where T : class
        {
            try
            {
                using HttpClientHandler httpClientHandler = new();
                using HttpClient httpClient = new(httpClientHandler);

                AddHeaders(httpClient, headers);
                var result = await httpClient.GetStringAsync(uri);

                return JsonConvert.DeserializeObject<T>(result);
            
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AddHeaders(HttpClient httpClient, Dictionary<string, string> headers)
        {
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            if (headers == null)
                return;

            foreach (var (key, value) in headers)
                httpClient.DefaultRequestHeaders.Add(key, value);
        }
    }
}
