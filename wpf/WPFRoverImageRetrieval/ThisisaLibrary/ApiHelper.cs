using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ThisisaLibrary
    {
    public static class ApiHelper
        {
        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient()
            {
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri("https://api.nasa.gov/mars-photos/api/v1/rovers/Perseverance/latest_photos?api_key=6TDMngLNOBW9LaJHihpPwqkrLMgQToOaD8H5Pii9&page=1");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


            }
        }
    }