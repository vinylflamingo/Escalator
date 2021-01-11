using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Escalator.Common.Models;
using Escalator.WebInterface;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace WebInterface.Processors
{
    public class LoginProcessor
    {
        private IHttpContextAccessor _accessor;
        private readonly IConfiguration Configuration;
        private AgentProcessor _agentProcessor;
        private string apiUrl;

        public LoginProcessor(IHttpContextAccessor accessor, IConfiguration configuration, AgentProcessor agentProcessor)
        {
            _accessor = accessor;
            _agentProcessor = agentProcessor;
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

                var role = _agentProcessor.LoadAgent(userCred.Username).Result.Role;
                _accessor.HttpContext.Session.SetString("role", role);

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
            _accessor.HttpContext.Session.Remove("username");
            _accessor.HttpContext.Session.Remove("role");

            return !string.IsNullOrEmpty(_accessor.HttpContext.Session.GetString("token"));

        }
    }
}