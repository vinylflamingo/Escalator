using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;

namespace Escalator.WebInterface
{
    public class ApiHelper
    {
        private string token { get; set;}
        public HttpClient ApiClient { get; set; }
        private IHttpContextAccessor _accessor;

        public ApiHelper(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
       
        public HttpClient InitializeClient() 
        {

            //THIS IS A TEMPORARY SOLUTION. LOCAL CERT SIGNING IS NOT WORKING FOR ME.

           // HttpClientHandler clientHandler = new HttpClientHandler();
           // clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // TO BE REMOVED BEFOFRE MERGER ^^


            ApiClient = new HttpClient(/*clientHandler*/); 
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                ApiClient.DefaultRequestHeaders.Add
                (
                    "Authorization", 
                    string.Concat("Bearer ", _accessor.HttpContext.Session.GetString("token").Trim('"'))
                );  
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }  
            return ApiClient;
        }

    }
}