using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;

namespace WebApiNetCore.Controllers
{
    [ApiController]
    [Route("[controller]/{numOfUsers}")]
    public class UsersList : ControllerBase
    {
        [HttpGet]
        public async Task<string> Get(int numOfUsers)
        {
            try
            {
                object listOfUsers = null;
                HttpClient client = new HttpClient();
                string response = await client.GetStringAsync(@$"https://randomuser.me/api/?results={numOfUsers}");
                listOfUsers = response;

                
                Console.WriteLine(listOfUsers);
                return JsonConvert.SerializeObject(listOfUsers);

            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }
    }
}
