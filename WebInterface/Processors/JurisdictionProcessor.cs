using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Escalator.Common.Models;
using Escalator.WebInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace WebInterface.Processors
{
    public class JurisdictionProcessor
    {

        private IHttpContextAccessor _accessor;
        private readonly IConfiguration Configuration;
        private string apiUrl;

        public JurisdictionProcessor(IHttpContextAccessor accessor, IConfiguration configuration)
        {
            _accessor = accessor;
            Configuration = configuration;
            apiUrl = Configuration["ServerUrl"];
        }


        public async Task<IEnumerable<Jurisdiction>> LoadJurisdictions()
        {
            string url = $"https://{apiUrl}/api/Jurisdiction/";
            var apiHelper = new ApiHelper(_accessor).InitializeClient();

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

        public async Task<Jurisdiction> LoadJurisdiction(long id)
        {
            string url = $"https://{apiUrl}/api/Jurisdiction/{id}";
            var apiHelper = new ApiHelper(_accessor).InitializeClient();

            using (HttpResponseMessage response = await apiHelper.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Jurisdiction jurisdiction = await response.Content.ReadAsAsync<Jurisdiction>();
                    return jurisdiction;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<string> SaveJurisdiction(Jurisdiction jurisdiction)
        {
            string url = $"https://{apiUrl}/api/Jurisdiction/";
            var apiHelper = new ApiHelper(_accessor).InitializeClient();
            var data = BuildJson(jurisdiction);
            var response = await apiHelper.PostAsync(url, data);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return response.Content.ReadAsStringAsync().Result;
        }

        public async Task<string> EditJurisdiction(Jurisdiction jurisdiction)
        {
            string url = $"https://{apiUrl}/api/Jurisdiction/{jurisdiction.Id}";
            var apiHelper = new ApiHelper(_accessor).InitializeClient();
            var data = BuildJson(jurisdiction);
            var response = await apiHelper.PutAsync(url, data);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return response.Content.ReadAsStringAsync().Result;
        }

        public async Task<string> DeleteJurisdiction(Jurisdiction jurisdiction)
        {
            string url = $"https://{apiUrl}/api/Jurisdiction/{jurisdiction.Id}";
            var apiHelper = new ApiHelper(_accessor).InitializeClient();
            var data = BuildJson(jurisdiction);
            var response = await apiHelper.DeleteAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return response.Content.ReadAsStringAsync().Result;
        }

        private StringContent BuildJson(Jurisdiction jurisdiction)
        {
            var json = JsonConvert.SerializeObject(jurisdiction);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return data;
        }

   
   
    }
}