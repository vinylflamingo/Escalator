using System.Threading.Tasks;
using System.Net.Http;
using Escalator.Common.Models;
using Escalator.WebInterface;
using System;
using System.Collections.Generic;

namespace WebInterface.Processors
{
    public class EscalationProcessor
    {
        public static async Task<Escalation> LoadEscalation(int escalationID)
        {
            string url = $"https://localhost:8081/api/Escalation/{escalationID}/";
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

        public static async Task<Escalation> SaveEscalation(Escalation escalation)
        {
            string url = $"https://localhost:8081/api/Escalation/";
            var content = new FormUrlEncodedContent(escalation);
            var response = await client.PostAsync(url, content);
            var responseString = await response.Contet.ReadAsAsync();
        }
    }
}