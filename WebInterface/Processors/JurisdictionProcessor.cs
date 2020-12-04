using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Escalator.Common.Models;
using Escalator.WebInterface;
using Microsoft.AspNetCore.Http;

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
            apiHelper.DefaultRequestHeaders.Add
            (
                "Authorization", 
                string.Concat("Bearer ", _accessor.HttpContext.Session.GetString("token").Trim('"'))
            );            
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
    }
}