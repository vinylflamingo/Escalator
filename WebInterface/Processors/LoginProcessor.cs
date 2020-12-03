using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Escalator.Common.Models;
using Escalator.WebInterface;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace WebInterface.Processors
{
    public class LoginProcessor
    {
        IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();
    

        // post that returns token and saves to header. 

        // post that creates new login 


        public async Task<string> Login(UserCred userCred)
        {
            HttpClient apiHelper = new ApiHelper().InitializeClient();
            string url = $"https://localhost:8081/api/Agent/authenticate";

            var json = JsonConvert.SerializeObject(userCred);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await apiHelper.PostAsync(url, data);
            string stringJWT = response.Content.ReadAsStringAsync().Result;
            httpContextAccessor.HttpContext.Session.SetString("token", stringJWT);
            return "ok";
        }

        public void Logout()
        {
            httpContextAccessor.HttpContext.Session.Remove("token");
        }
    }
}