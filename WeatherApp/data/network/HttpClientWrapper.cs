using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.data.network
{
    public class HttpClientWrapper
    {
        private readonly HttpClient httpClient;
        private string baseUrl;

        public HttpClientWrapper(HttpClient httpClient, string baseUrl)
        {
            this.httpClient = httpClient;
            this.baseUrl = baseUrl;
        }


        public async Task<HttpResponseMessage> Get(string path, IDictionary<string, string> properties = null, IDictionary<string, string> headers = null)
        {
            HttpRequestMessage request = new HttpRequestMessage
            {
                RequestUri = new Uri(baseUrl + path+GetParams(properties)),
                Method = HttpMethod.Get
            };
            if (headers != null)
            {
                foreach (string header in headers.Keys)
                {
                    request.Headers.Add(header, headers[header]);
                }
            } 
            return await httpClient.SendAsync(request);
        }

        private string GetParams(IDictionary<string, string> parameters)
        {
            if (parameters == null || parameters.Count <=0) return "";
            StringBuilder s = new StringBuilder();
            s.Append("?");
            ICollection<string> keys = parameters.Keys;
            var i = 0;
            foreach(string key in keys)
            {
                s.Append(key);
                s.Append("=");
                s.Append(parameters[key]);
                if (++i < keys.Count)
                {
                    s.Append("&");
                }
            }
            return s.ToString();
        }

    }

}
