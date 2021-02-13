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
using Microsoft.Extensions.Configuration;

namespace WebInterface.Processors
{
    public class TicketProcessor
    {
        private IHttpContextAccessor _accessor;
        private readonly IConfiguration Configuration;
        private string apiUrl;

        public TicketProcessor(IHttpContextAccessor accessor, IConfiguration configuration)
        {
            _accessor = accessor;
            Configuration = configuration;
            apiUrl = Configuration["ServerUrl"];
        }

        public async Task<Ticket> LoadTicket(int ticketId)
        {
            string url = $"https://{apiUrl}/api/Ticket/{ticketId}/";
            var apiHelper = new ApiHelper(_accessor).InitializeClient();
            
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

        public async Task<IEnumerable<Ticket>> LoadTickets()
        {   
            string url = $"https://{apiUrl}/api/Ticket/";
            var apiHelper = new ApiHelper(_accessor).InitializeClient();

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
            string url = $"https://{apiUrl}/api/Ticket/";
            var apiHelper = new ApiHelper(_accessor).InitializeClient();
            var data = BuildJson(ticket);
            var response = await apiHelper.PostAsync(url, data);
            return response.Content.ReadAsStringAsync().Result;
        }
       
        public async Task<string> EditTicket(Ticket ticket)
        {
            string url = $"https://{apiUrl}/api/Ticket/{ticket.Id}";
            var apiHelper = new ApiHelper(_accessor).InitializeClient();
            var data = BuildJson(ticket);
            var response = await apiHelper.PutAsync(url, data);
            return response.Content.ReadAsStringAsync().Result;

        }        
       
        public async Task<string> DeleteTicket(Ticket ticket)
        {
            string url = $"https://{apiUrl}/api/Ticket/{ticket.Id}";
            var apiHelper = new ApiHelper(_accessor).InitializeClient();
            var data = BuildJson(ticket);
            var response = await apiHelper.DeleteAsync(url);
            return response.Content.ReadAsStringAsync().Result;
        }
       
        public async Task<IEnumerable<TicketType>> LoadTypes()
        {
            string url = $"https://{apiUrl}/api/TicketType/";
            var apiHelper = new ApiHelper(_accessor).InitializeClient();
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
       
        public async Task<TicketType> LoadType(int typeId)
        {
            string url = $"https://{apiUrl}/api/TicketType/{typeId}";
            var apiHelper = new ApiHelper(_accessor).InitializeClient();
            using (HttpResponseMessage response = await apiHelper.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    TicketType ticketType = await response.Content.ReadAsAsync<TicketType>();
                    return ticketType;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
       
        public async Task<string> SaveType(TicketType ticketType)
        {
            string url = $"https://{apiUrl}/api/TicketType/";
            var apiHelper = new ApiHelper(_accessor).InitializeClient();

            var json = JsonConvert.SerializeObject(ticketType);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await apiHelper.PostAsync(url, data);
            if (!response.IsSuccessStatusCode)
            {
                Debug.Write(response.StatusCode);
                Debug.Write(response.Content.ToString());
            }
            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
            return result;
        }

        public async Task<string> EditType(TicketType ticketType)
        {
            var apiHelper = new ApiHelper(_accessor).InitializeClient();

            string url = $"https://{apiUrl}/api/TicketType/{ticketType.Id}";
            
            var json = JsonConvert.SerializeObject(ticketType);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await apiHelper.PutAsync(url, data);
            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
            return result;
        }

        public async Task<string> DeleteType(long id)
        {
            var apiHelper = new ApiHelper(_accessor).InitializeClient();
 
            string url = $"https://{apiUrl}/api/TicketType/{id}";
            var response = await apiHelper.DeleteAsync(url);
            string result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
            return result;
        }

        private StringContent BuildJson(Ticket ticket)
        {
            var json = JsonConvert.SerializeObject(ticket);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return data;
        }
    }
}