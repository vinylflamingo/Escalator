using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

namespace Escalator.ReportTrigger
{
    public class TestWorker : BackgroundService
    {
        private readonly ILogger<TestWorker> _logger;
        private readonly IConfiguration _configuration;
        private IHttpContextAccessor _accessor;
        
        private string apiUrl;


        public TestWorker(ILogger<TestWorker> logger, IConfiguration configuration, IHttpContextAccessor accessor)
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

                HttpClient apiHelper = new ApiHelper(_accessor).InitializeClient();
                string url = $"https://{apiUrl}/api/Contact/";
                await apiHelper.GetAsync(url);
                await Task.Delay(30000, stoppingToken);
            }
        }
    }
}
