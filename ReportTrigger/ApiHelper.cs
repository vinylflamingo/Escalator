using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;

namespace Escalator.ReportTrigger
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



            ApiClient = new HttpClient(); 
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