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
    public class TicketProcessor
    {
        
        public static async Task<Ticket> LoadTicket(int ticketId)
        {
            string url = $"https://localhost:8081/api/Ticket/{ticketId}/";
            
            using (HttpResponseMessage response = await apiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Ticket ticket = await response.Content.ReadAsAsync<Ticket>();
                    return ticket;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        public static async Task<IEnumerable<Ticket>> LoadTickets()
        {
            string url = $"https://localhost:8081/api/Ticket/";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<Ticket> tickets = await response.Content.ReadAsAsync<List<Ticket>>();
                    return tickets;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<string> SaveTicket(Ticket ticket)
        {
            string url = $"https://localhost:8081/api/Ticket/";
            
            var json = JsonConvert.SerializeObject(ticket);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await ApiHelper.ApiClient.PostAsync(url, data);
            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
            return result;
        }


        public static async Task<string> EditTicket(Ticket ticket)
        {
            string url = $"https://localhost:8081/api/Ticket/";
            
            var json = JsonConvert.SerializeObject(ticket);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await ApiHelper.ApiClient.PutAsync(url, data);
            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
            return result;
        }
    }
}