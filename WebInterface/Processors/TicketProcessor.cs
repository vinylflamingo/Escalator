using System.Threading.Tasks;
using System.Net.Http;
using Escalator.Common.Models;
using Escalator.WebInterface;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace WebInterface.Processors
{
    public class TicketProcessor
    {
        private IHttpContextAccessor _accessor;

        public TicketProcessor(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public async Task<Ticket> LoadTicket(int ticketId)
        {
            HttpClient apiHelper = new ApiHelper().InitializeClient();
            apiHelper.DefaultRequestHeaders.Add
            (
                "Authorization", 
                string.Concat("Bearer ", _accessor.HttpContext.Session.GetString("token").Trim('"'))
            );  

            string url = $"https://localhost:8081/api/Ticket/{ticketId}/";
            
            using (HttpResponseMessage response = await apiHelper.GetAsync(url))
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


        public async Task<IEnumerable<Ticket>> LoadTickets()
        {
            HttpClient apiHelper = new ApiHelper().InitializeClient();
            apiHelper.DefaultRequestHeaders.Add
            (
                "Authorization", 
                string.Concat("Bearer ", _accessor.HttpContext.Session.GetString("token").Trim('"'))
            );            
            string url = $"https://localhost:8081/api/Ticket/";

            using (HttpResponseMessage response = await apiHelper.GetAsync(url))
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


        public async Task<string> SaveTicket(Ticket ticket)
        {
            HttpClient apiHelper = new ApiHelper().InitializeClient();
            apiHelper.DefaultRequestHeaders.Add
            (
                "Authorization", 
                string.Concat("Bearer ", _accessor.HttpContext.Session.GetString("token").Trim('"'))
            );  
            string url = $"https://localhost:8081/api/Ticket/";
            
            var json = JsonConvert.SerializeObject(ticket);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await apiHelper.PostAsync(url, data);
            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
            return result;
        }


        public async Task<string> EditTicket(Ticket ticket)
        {
            HttpClient apiHelper = new ApiHelper().InitializeClient();
            apiHelper.DefaultRequestHeaders.Add
            (
                "Authorization", 
                string.Concat("Bearer ", _accessor.HttpContext.Session.GetString("token").Trim('"'))
            );  
            string url = $"https://localhost:8081/api/Ticket/";
            
            var json = JsonConvert.SerializeObject(ticket);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await apiHelper.PutAsync(url, data);
            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
            return result;
        }
    }
}