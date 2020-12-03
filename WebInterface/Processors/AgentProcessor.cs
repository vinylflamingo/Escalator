/* using System.Threading.Tasks;
using System.Net.Http;
using Escalator.Common.Models;
using Escalator.WebInterface;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;

namespace WebInterface.Processors
{
    public class AgentProcessor
    {
        
        public static async Task<Agent> LoadAgent(int ticketId)
        {
            string url = $"https://localhost:8081/api/Agent/{ticketId}/";
            
            using (HttpResponseMessage response = await apiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Agent ticket = await response.Content.ReadAsAsync<Agent>();
                    return ticket;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public static async Task<IEnumerable<Agent>> LoadAgents()
        {
            string url = $"https://localhost:8081/api/Agent/";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<Agent> tickets = await response.Content.ReadAsAsync<List<Agent>>();
                    return tickets;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<string> SaveAgent(Agent ticket)
        {
            string url = $"https://localhost:8081/api/Agent/";
            
            var json = JsonConvert.SerializeObject(ticket);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await ApiHelper.ApiClient.PostAsync(url, data);
            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
            return result;
        }


        public static async Task<string> EditAgent(Agent ticket)
        {
            string url = $"https://localhost:8081/api/Agent/";
            
            var json = JsonConvert.SerializeObject(ticket);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await ApiHelper.ApiClient.PutAsync(url, data);
            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
            return result;
        }
    }
} */