using System.Threading.Tasks;
using System.Net.Http;
using Escalator.Common.Models;
using Escalator.WebInterface;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace WebInterface.Processors
{
    public class AgentProcessor
    {

        private IHttpContextAccessor _accessor;
        private readonly IConfiguration Configuration;
        private string apiUrl;

        public AgentProcessor(IHttpContextAccessor accessor, IConfiguration configuration)
        {
            _accessor = accessor;
            Configuration = configuration;
            apiUrl = Configuration["ServerUrl"];
        }
        
        public async Task<IEnumerable<Agent>> LoadAgents()
        {
            HttpClient apiHelper = new ApiHelper(_accessor).InitializeClient();
          
            string url = $"https://{apiUrl}/api/Agent/";

            using (HttpResponseMessage response = await apiHelper.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<Agent> agents = await response.Content.ReadAsAsync<List<Agent>>();
                    return agents;
                }
                else
                {
                    return null;
                }
            }
        }
        
        public async Task<Agent> LoadAgent(string username)
        {
            HttpClient apiHelper = new ApiHelper(_accessor).InitializeClient();
          
            string url = $"https://{apiUrl}/api/Agent/{username}";

            using (HttpResponseMessage response = await apiHelper.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Agent agent = await response.Content.ReadAsAsync<Agent>();
                    return agent;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<string> DeleteAgent(Agent agent)
        {
            HttpClient apiHelper = new ApiHelper(_accessor).InitializeClient();

            string url = $"https://{apiUrl}/api/Agent/{agent.Id}";


            var json = JsonConvert.SerializeObject(agent);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await apiHelper.DeleteAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
            return result;
        }

        public async Task<string> SaveAgent(Agent agent)
        {
            HttpClient apiHelper = new ApiHelper(_accessor).InitializeClient();

            string url = $"https://{apiUrl}/api/Agent/Create";


            var json = JsonConvert.SerializeObject(agent);
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

        public async Task<string> EditAgent(Agent agent)
        {
            HttpClient apiHelper = new ApiHelper(_accessor).InitializeClient();

            string url = $"https://{apiUrl}/api/Agent/put";


            var json = JsonConvert.SerializeObject(agent);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await apiHelper.PutAsync(url, data);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
            return result;
        }

        public async Task<string> NewPassword(Agent agent)
        {
            HttpClient apiHelper = new ApiHelper(_accessor).InitializeClient();
            
            string url = $"https://{apiUrl}/api/Agent/put";

            agent.NeedsNewPassword = false;

            var json = JsonConvert.SerializeObject(agent);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await apiHelper.PutAsync(url, data);
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