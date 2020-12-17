using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Escalator.Common.Models;
using Escalator.WebInterface;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace WebInterface.Processors
{
    public class JurisdictionProcessor
    {

        private IHttpContextAccessor _accessor;

        public JurisdictionProcessor(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }


     public async Task<IEnumerable<Jurisdiction>> LoadJurisdictions()
        {
           HttpClient apiHelper = new ApiHelper().InitializeClient();
            try
            {
                apiHelper.DefaultRequestHeaders.Add
                (
                    "Authorization", 
                    string.Concat("Bearer ", _accessor.HttpContext.Session.GetString("token").Trim('"'))
                );  
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }             
            string url = $"https://localhost:8081/api/Jurisdiction/";

            using (HttpResponseMessage response = await apiHelper.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<Jurisdiction> jurisdictions = await response.Content.ReadAsAsync<List<Jurisdiction>>();
                    return jurisdictions;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }   

        public async Task<string> SaveJurisdiction(Jurisdiction jurisdiction)
        {
            HttpClient apiHelper = new ApiHelper().InitializeClient();
            try
            {
                apiHelper.DefaultRequestHeaders.Add
                (
                    "Authorization", 
                    string.Concat("Bearer ", _accessor.HttpContext.Session.GetString("token").Trim('"'))
                );  
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }  
            string url = $"https://localhost:8081/api/Jurisdiction/";

            var json = JsonConvert.SerializeObject(jurisdiction);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await apiHelper.PostAsync(url, data);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
            return result;
        }
   
   
    }
}