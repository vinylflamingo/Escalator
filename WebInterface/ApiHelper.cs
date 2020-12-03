using System.Net.Http;
using System.Net.Http.Headers;

namespace Escalator.WebInterface
{
    public class ApiHelper
    {
        private string token { get; set;}
        public HttpClient ApiClient { get; set; }
        public HttpClient InitializeClient() 
        {
           ApiClient = new HttpClient(); 
           ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
           return ApiClient;
        }
    }
}