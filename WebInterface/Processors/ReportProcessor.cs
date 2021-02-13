using System;
using System.Collections.Generic;
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
    public class ReportProcessor
    {

        private IHttpContextAccessor _accessor;
        private readonly IConfiguration Configuration;
        private string apiUrl;

        public ReportProcessor(IHttpContextAccessor accessor, IConfiguration configuration)
        {
            _accessor = accessor;
            Configuration = configuration;
            apiUrl = Configuration["ServerUrl"];
        }

        /// <summary>
        /// This section describes the request for handling Report Schedules (Weekly, Monthly, Test, Etc.)
        /// </summary>

        public async Task<IEnumerable<ReportSchedule>> LoadActiveReportSchedules()
        {
            string url = $"https://{apiUrl}/api/Report/";
            var apiHelper = new ApiHelper(_accessor).InitializeClient();

            using (HttpResponseMessage response = await apiHelper.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<ReportSchedule> records = await response.Content.ReadAsAsync<List<ReportSchedule>>();
                    return records;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }   

        public async Task<IEnumerable<ReportSchedule>> LoadAllReportSchedules()
        {
            string url = $"https://{apiUrl}/api/Report/all";
            var apiHelper = new ApiHelper(_accessor).InitializeClient();

            using (HttpResponseMessage response = await apiHelper.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<ReportSchedule> records = await response.Content.ReadAsAsync<List<ReportSchedule>>();
                    return records;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }   
       
        public async Task<string> SaveReportSchedule(ReportSchedule report)
        {
            string url = $"https://{apiUrl}/api/Report/";
            var apiHelper = new ApiHelper(_accessor).InitializeClient();
            var data = BuildJsonSchedule(report);
            var response = await apiHelper.PostAsync(url, data);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return response.Content.ReadAsStringAsync().Result;
        }
        
        public async Task<ReportSchedule> LoadReportSchedule(long id)
        {
            string url = $"https://{apiUrl}/api/Report/{id}";
            var apiHelper = new ApiHelper(_accessor).InitializeClient();

            using (HttpResponseMessage response = await apiHelper.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    ReportSchedule report = await response.Content.ReadAsAsync<ReportSchedule>();
                    return report;
                }
                else
                {
                    return null;
                }
            }
        }
       
        public async Task<string> EditReportSchedule(ReportSchedule report)
        {
            string url = $"https://{apiUrl}/api/Report/{report.Id}";
            var apiHelper = new ApiHelper(_accessor).InitializeClient();
            var data = BuildJsonSchedule(report);
            var response = await apiHelper.PutAsync(url, data);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return response.Content.ReadAsStringAsync().Result;
        }
       
        public async void ExecuteReportSchedule(string type = "")
        {
            string url = $"https://{apiUrl}/api/Report/Execute/{type}";
            var apiHelper = new ApiHelper(_accessor).InitializeClient();
            await apiHelper.GetAsync(url);
        }

        /// <summary>
        /// This section describes the request for handling Contact Records (Notifications and Reports)
        /// </summary>
   
        public async Task<IEnumerable<ContactRecord>> LoadRecords(string type = "")
        {
            string url = $"https://{apiUrl}/api/Report/Records/{type}";
            var apiHelper = new ApiHelper(_accessor).InitializeClient();

            using (HttpResponseMessage response = await apiHelper.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<ContactRecord> records = await response.Content.ReadAsAsync<List<ContactRecord>>();
                    return records;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }   

        public async Task<ContactRecord> LoadRecord(long id)
        {
            string url = $"https://{apiUrl}/api/Report/Records/id/{id}";
            var apiHelper = new ApiHelper(_accessor).InitializeClient();

            using (HttpResponseMessage response = await apiHelper.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    ContactRecord Report = await response.Content.ReadAsAsync<ContactRecord>();
                    return Report;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<string> SaveRecord(ContactRecord record)
        {
            string url = $"https://{apiUrl}/api/Report/Records/";
            var apiHelper = new ApiHelper(_accessor).InitializeClient();
            var data = BuildJsonRecord(record);
            var response = await apiHelper.PostAsync(url, data);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return response.Content.ReadAsStringAsync().Result;
        }

        public async Task<string> EditRecord(ContactRecord record)
        {
            string url = $"https://{apiUrl}/api/Report/{record.Id}";
            var apiHelper = new ApiHelper(_accessor).InitializeClient();
            var data = BuildJsonRecord(record);
            var response = await apiHelper.PutAsync(url, data);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return response.Content.ReadAsStringAsync().Result;
        }
        

        /// <summary>
        /// Utility functions to build the Json format for records and reports.
        /// </summary>
        
        private StringContent BuildJsonRecord(ContactRecord record)
        {
            var json = JsonConvert.SerializeObject(record);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return data;
        } 

        private StringContent BuildJsonSchedule(ReportSchedule report)
        {
            var json = JsonConvert.SerializeObject(report);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return data;
        } 

           
    }
} 