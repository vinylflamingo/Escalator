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
                    return null;
                }
            }
        }

        public async Task<IEnumerable<TicketType>> LoadTypes()
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
          
            string url = $"https://localhost:8081/api/TicketType/";

            using (HttpResponseMessage response = await apiHelper.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<TicketType> ticketTypes = await response.Content.ReadAsAsync<List<TicketType>>();
                    return ticketTypes;
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
                    return null;
                }
            }
        }


        public async Task<string> SaveTicket(Ticket ticket)
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
            string url = $"https://localhost:8081/api/Ticket/";
            
            ticket.OpenDate = DateTime.Now;
            ticket.IsCompleted = false;

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
            string url = $"https://localhost:8081/api/Ticket/{ticket.Id}";
            
            var json = JsonConvert.SerializeObject(ticket);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await apiHelper.PutAsync(url, data);
            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
            return result;
        }
        
        public async Task<string> DeleteTicket(Ticket ticket)
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
            string url = $"https://localhost:8081/api/Ticket/{ticket.Id}";

            var json = JsonConvert.SerializeObject(ticket);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await apiHelper.DeleteAsync(url);
            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
            return result;
        }
   
   
    }
}