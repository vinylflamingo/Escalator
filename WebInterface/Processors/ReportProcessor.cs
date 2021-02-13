using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Escalator.Common.Models;
using Escalator.WebInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace WebInterface.Processors
{
    public class ReportProcessor
    {

        private IHttpContextAccessor _accessor;
        private readonly IConfiguration Configuration;
        private string apiUrl;
        private HttpClient apiHelper;

        public ReportProcessor(IHttpContextAccessor accessor, IConfiguration configuration)
        {
            _accessor = accessor;
            Configuration = configuration;
            apiUrl = Configuration["ServerUrl"];
            apiHelper = new ApiHelper(_accessor).InitializeClient();
        }


        public async Task<IEnumerable<ContactRecord>> LoadRecords()
        {
            string url = $"https://{apiUrl}/api/Report/";

            using (HttpResponseMessage response = await apiHelper.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<Report> jurisdictions = await response.Content.ReadAsAsync<List<Report>>();
                    return jurisdictions;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }   

        public async Task<Report> LoadJurisdiction(long id)
        {
            string url = $"https://{apiUrl}/api/Report/{id}";

            using (HttpResponseMessage response = await apiHelper.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Report Report = await response.Content.ReadAsAsync<Report>();
                    return Report;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<string> SaveJurisdiction(Report Report)
        {
            string url = $"https://{apiUrl}/api/Report/";
            var data = BuildJson(Report);
            var response = await apiHelper.PostAsync(url, data);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return response.Content.ReadAsStringAsync().Result;
        }

        public async Task<string> EditJurisdiction(Report Report)
        {
            string url = $"https://{apiUrl}/api/Report/{Report.Id}";
            var data = BuildJson(Report);
            var response = await apiHelper.PutAsync(url, data);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return response.Content.ReadAsStringAsync().Result;
        }

        public async Task<string> DeleteJurisdiction(Report Report)
        {
            string url = $"https://{apiUrl}/api/Report/{Report.Id}";
            var data = BuildJson(Report);
            var response = await apiHelper.DeleteAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return response.Content.ReadAsStringAsync().Result;
        }

        private StringContent BuildJson(Report Report)
        {
            var json = JsonConvert.SerializeObject(Report);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return data;
        }

           
    }
}