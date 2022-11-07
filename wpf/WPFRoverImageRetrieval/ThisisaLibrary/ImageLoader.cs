namespace ThisisaLibrary
{
    public class ImageLoader : DaysToSols

    {

        public static async Task<PerseveranceResultModel.Photos[]> CurrentSol(int solNumber = 1)
        {

            string url = $"https://mars-photos.herokuapp.com/api/v1/rovers/Perseverance/photos?sol={solNumber}/info.0.json";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    PerseveranceResultModel.Photos_List result = await response.Content.ReadAsAsync<PerseveranceResultModel.Photos_List>();
                   
                    return result.photos; 
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
