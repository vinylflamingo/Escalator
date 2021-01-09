using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Escalator.Common.Models;
using Escalator.WebInterface;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace WebInterface.Processors
{
    public class LoginProcessor
    {
        private IHttpContextAccessor _accessor;
        private readonly IConfiguration Configuration;
        private string apiUrl;

        public LoginProcessor(IHttpContextAccessor accessor, IConfiguration configuration)
        {
            _accessor = accessor;
            Configuration = configuration;
            apiUrl = Configuration["ServerUrl"];
            
        }

        // post that resets password


        public async Task<string> Login(UserCred userCred)
        {
            HttpClient apiHelper = new ApiHelper(_accessor).InitializeClient();
            string url = $"https://{apiUrl}/api/Agent/authenticate";
            var json = JsonConvert.SerializeObject(userCred);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await apiHelper.PostAsync(url, data);
            if (response.IsSuccessStatusCode)
            {
                string stringJWT = response.Content.ReadAsStringAsync().Result;
                _accessor.HttpContext.Session.SetString("token", stringJWT);
                _accessor.HttpContext.Session.SetString("username", userCred.Username);
                return stringJWT;
            }
            else
            {
                return null;
            }
        }


        //returns true if logout is successful and token is wiped.
        public bool Logout()
        {
            _accessor.HttpContext.Session.Remove("token");
            return !string.IsNullOrEmpty(_accessor.HttpContext.Session.GetString("token"));

        }
    }
}