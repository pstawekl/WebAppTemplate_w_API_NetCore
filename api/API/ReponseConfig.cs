using Microsoft.AspNetCore.Mvc;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace API
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new string[] { "value1", "value2" });
        }

        public async void GetFromRandomUser(string url)
        {
            //jedna metoda
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(url);
            var data = JsonConvert.DeserializeObject<List<object>>(response);
            foreach(var obj in data)
            {
                Console.WriteLine(obj.ToString());
            }

            //druga metoda
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression= DecompressionMethods.GZip | DecompressionMethods.Deflate;
            using (HttpWebResponse response2 = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response2.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
        }

        // GET api/values/number
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            string html = string.Empty;
            string url = @$"https://randomuser.me/api/?results={id}";
            object listOfUsers = null;
            GetFromRandomUser(url);
            //listOfUsers = GetFromRandomUser(url);
            //Console.WriteLine(listOfUsers);
            return Ok(listOfUsers);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return Created($"api/Values/{value}", value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Accepted(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
