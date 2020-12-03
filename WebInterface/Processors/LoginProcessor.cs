using System.Diagnostics;
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
        private IHttpContextAccessor _accessor;

        public LoginProcessor(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        // post that returns token and saves to header. 

        // post that creates new login 


        public async Task<string> Login(UserCred userCred)
        {
            HttpClient apiHelper = new ApiHelper().InitializeClient();
            string url = $"https://localhost:8081/api/Agent/authenticate";

            var json = JsonConvert.SerializeObject(userCred);
            Debug.WriteLine("JSON : "+json);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await apiHelper.PostAsync(url, data);
            Debug.WriteLine("RESPONSE : "+response);
            string stringJWT = response.Content.ReadAsStringAsync().Result;
            stringJWT.Trim('\"');
            Debug.WriteLine("STRINGJWT : "+stringJWT);
            _accessor.HttpContext.Session.SetString("token", stringJWT);
            return stringJWT;
        }

        public void Logout()
        {
            _accessor.HttpContext.Session.Remove("token");
        }
    }
}