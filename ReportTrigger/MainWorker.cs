using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Escalator.Common.Models;
using Newtonsoft.Json;
using System.Text;
using System.Diagnostics;

namespace Escalator.ReportTrigger
{
    public class MainWorker : BackgroundService
    {
        private readonly ILogger<MainWorker> _logger;
        private readonly IConfiguration _configuration;
        private IHttpContextAccessor _accessor;
        
        private string apiUrl;


        public MainWorker(ILogger<MainWorker> logger, IConfiguration configuration, IHttpContextAccessor accessor)
        {
            _logger = logger;
            _configuration = configuration;
            apiUrl = _configuration["ServerUrl"];
            _accessor = accessor;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);


                List<ReportSchedule> reportSchedule;
                HttpClient apiHelper = new ApiHelper(_accessor).InitializeClient();
            
                //first need to pull all of the reports for the day 
                string url = $"https://{apiUrl}/api/Report/";
                using (HttpResponseMessage response = await apiHelper.GetAsync(url))
                {   
                    if (response.IsSuccessStatusCode)
                    {
                        reportSchedule = await response.Content.ReadAsAsync<List<ReportSchedule>>();
                        _logger.LogDebug(reportSchedule.ToString());
                    }
                    else
                    {
                        return;
                    }
                }
                foreach(var report in reportSchedule)
                {
                    if (report.Type == "Weekly")
                    {
                        _logger.LogDebug("Starting Weekly Reports");
                        DoReport(report, apiHelper);
                        _logger.LogDebug("Making New Weekly Reports");
                        CreateNewReport(report.Type, DateTime.Now.AddDays(7), apiHelper);
                    }
                    if (report.Type == "Test")
                    {
                        DoReport(report, apiHelper);
                        CreateNewReport(report.Type, DateTime.Now, apiHelper); //disabled unless testing. will create test right after executing. will send on next service interval
                    }
                    if (report.Type == "Monthly")
                    {
                        DoReport(report, apiHelper);
                        CreateNewReport(report.Type, new DateTime
                        (
                            report.ScheduledDate.AddMonths(1).Year,
                            report.ScheduledDate.AddMonths(1).Month,
                            1
                        ), 
                        apiHelper);

                    }
                }
                await Task.Delay(600000, stoppingToken); //time interval to check the server. 600000 = 10 minutes
            }
        }

        private async void DoReport(ReportSchedule report, HttpClient apiHelper)
        {
            var url = $"https://{apiUrl}/api/Report/Execute/{report.Type}";
            await apiHelper.GetAsync(url);

            //modify the report to indicate it has been completed
            report.Executed = true;

            //edit the database to reflect the report has been executed
            url = $"https://{apiUrl}/api/Report/{report.Id}";
            var json = JsonConvert.SerializeObject(report);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            await apiHelper.PutAsync(url, data);
        }

        private async void CreateNewReport(string type, DateTime date, HttpClient apiHelper)
        {
            //generate the next report
            var url = $"https://{apiUrl}/api/Report/";
            var newReport = new ReportSchedule()
            {
                Type = type,
                Executed = false,
                ScheduledDate = date,
                CreatedDate = DateTime.Now
            };
            var json = JsonConvert.SerializeObject(newReport);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            await apiHelper.PostAsync(url, data);
        }
    }
}