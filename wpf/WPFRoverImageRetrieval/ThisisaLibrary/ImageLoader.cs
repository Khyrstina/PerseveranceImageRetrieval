using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using System.Net.Http;

namespace ThisisaLibrary
{
    public class ImageLoader

    {
        public static async Task<PerseveranceResultModel.Latest_Photos[]> CurrentPage(int pageNumber = 1)
        {
            string url = $"https://api.nasa.gov/mars-photos/api/v1/rovers/Perseverance/latest_photos?api_key=6TDMngLNOBW9LaJHihpPwqkrLMgQToOaD8H5Pii9&page={pageNumber}/info.0.json";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    PerseveranceResultModel.Photos_List result = await response.Content.ReadAsAsync<PerseveranceResultModel.Photos_List>();
                   
                    return result.latest_photos; 
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
