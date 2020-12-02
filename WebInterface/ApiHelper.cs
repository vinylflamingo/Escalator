using System.Net.Http;
using System.Net.Http.Headers;

namespace Escalator.WebInterface
{
    public class ApiHelper
    {
        private string token;
        public HttpClient ApiClient { get; set; }

        public ApiHelper(string token)
        {
            this.token = token;
        }
       
        public void InitializeClient() 
        {
           ApiClient = new HttpClient(); 
           ApiClient.DefaultRequestHeaders.Accept.Clear();
           ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
           ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
        }
    }
}