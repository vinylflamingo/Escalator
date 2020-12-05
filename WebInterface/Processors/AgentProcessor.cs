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

namespace WebInterface.Processors
{
    public class AgentProcessor
    {

        private IHttpContextAccessor _accessor;

        public AgentProcessor(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        
        public async Task<IEnumerable<Agent>> LoadAgents()
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
          
            string url = $"https://localhost:8081/api/Agent/";

            using (HttpResponseMessage response = await apiHelper.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<Agent> agents = await response.Content.ReadAsAsync<List<Agent>>();
                    return agents;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        
        public async Task<string> SaveAgent(Agent agent)
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
            string url = $"https://localhost:8081/api/Agent";


            var json = JsonConvert.SerializeObject(agent);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await apiHelper.PostAsync(url, data);
            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
            return result;
        }


    }
} 