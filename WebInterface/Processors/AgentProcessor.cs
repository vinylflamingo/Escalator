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
            string url = $"https://{apiUrl}/api/Agent/";
            var apiHelper = new ApiHelper(_accessor).InitializeClient();

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
            string url = $"https://{apiUrl}/api/Agent/{username}";
            var apiHelper = new ApiHelper(_accessor).InitializeClient();
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

            string url = $"https://{apiUrl}/api/Agent/{agent.Id}";
            var apiHelper = new ApiHelper(_accessor).InitializeClient();
           
            var response = await apiHelper.DeleteAsync(url);
           
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return response.Content.ReadAsStringAsync().Result;
        }

        public async Task<string> SaveAgent(Agent agent)
        {

            string url = $"https://{apiUrl}/api/Agent/Create";
            var apiHelper = new ApiHelper(_accessor).InitializeClient();
            var data = BuildJson(agent);
            var response = await apiHelper.PostAsync(url, data);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return response.Content.ReadAsStringAsync().Result;
        }

        public async Task<string> EditAgent(Agent agent)
        {

            string url = $"https://{apiUrl}/api/Agent/put";
            var apiHelper = new ApiHelper(_accessor).InitializeClient();

            var data = BuildJson(agent);

            var response = await apiHelper.PutAsync(url, data);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return response.Content.ReadAsStringAsync().Result;

        }

        public async Task<string> NewPassword(Agent agent)
        {
            string url = $"https://{apiUrl}/api/Agent/put";
            var apiHelper = new ApiHelper(_accessor).InitializeClient();
            agent.NeedsNewPassword = false;   //I think even though this is business logic-esque i'm going ot leave it here for now.
                                              //The method it calls in the api is the same updating ANY agent info, I dont want an email change
                                              //for example to change this password flag. As I dive deeper into the auth system and creating normal
                                              //submission users, maybe this will be something to revisit.

            var data = BuildJson(agent);
            var response = await apiHelper.PutAsync(url, data);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            return response.Content.ReadAsStringAsync().Result;
        }

        private StringContent BuildJson(Agent agent)
        {
            var json = JsonConvert.SerializeObject(agent);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return data;
        }

    }
} 