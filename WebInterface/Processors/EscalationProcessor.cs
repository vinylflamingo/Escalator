using System.Threading.Tasks;
using System.Net.Http;
using Escalator.Common.Models;
using Escalator.WebInterface;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;

namespace WebInterface.Processors
{
    public class EscalationProcessor
    {
        public static async Task<Escalation> LoadEscalation(int escalationId)
        {
            string url = $"https://localhost:8081/api/Escalation/{escalationId}/";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Escalation escalation = await response.Content.ReadAsAsync<Escalation>();
                    return escalation;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public static async Task<IEnumerable<Escalation>> LoadEscalations()
        {
            string url = $"https://localhost:8081/api/Escalation/";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<Escalation> escalations = await response.Content.ReadAsAsync<List<Escalation>>();
                    return escalations;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<string> SaveEscalation(Escalation escalation)
        {
            string url = $"https://localhost:8081/api/Escalation/";
            
            var json = JsonConvert.SerializeObject(escalation);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await ApiHelper.ApiClient.PostAsync(url, data);
            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
            return result;
            

        }
    }
}