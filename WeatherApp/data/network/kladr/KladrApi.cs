using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApp.data.network.kladr.pojo;

namespace WeatherApp.data.network.kladr
{
    public class KladrApi
    {

        private static readonly string BASE_URL = "http://kladr-api.ru/";
 
        private readonly HttpClientWrapper httpClientWrapper;

        public KladrApi(HttpClient httpClient)
        { 
            this.httpClientWrapper = new HttpClientWrapper(httpClient, BASE_URL);
        }

        public async Task<List<ResultSearchItem>> GetSearchCity(string text)
        {
            IDictionary<string, string> param = new Dictionary<string, string>
            {
                ["contentType"] = "city",
                ["query"] = text,
                ["withParent"] = "0",
                ["limit"] = "25",
                ["typeCode"] = "1"
            };
            HttpResponseMessage httpResponseMessage = await httpClientWrapper.Get("api.php", param);
            HttpContent httpContent = httpResponseMessage.Content;
            string json = await httpContent.ReadAsStringAsync();

            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            { 
                ResultItem resultItem= JsonConvert.DeserializeObject<ResultItem>(json);
                return resultItem.result;
            }
            else
            { 
                throw new Exception(json);
            }
        }

    }
}
