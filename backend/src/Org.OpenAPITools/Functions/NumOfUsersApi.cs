using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Org.OpenAPITools.Models;
using System.Web.Http;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.Generic;
using System;
using System.Data;
using Newtonsoft.Json.Serialization;
using Microsoft.VisualBasic;
using Microsoft.Azure.Storage.Shared.Protocol;

namespace Org.OpenAPITools.Functions
{ 
    public partial class NumOfUsersApi
    { 

        [FunctionName("NumOfUsersApi_GetList")]
        public async Task<ActionResult<string>> _GetList([HttpTrigger(AuthorizationLevel.Anonymous, "Get", Route = "usersList/{numOfUsers}")]HttpRequest req, string numOfUsers)  
        {
            try
            {
                req.Headers.Add("Content-Type", "application/json");
                req.Headers.Add("Access-Control-Allow-Origin", "*");
                var listOfUsers = await GetList(numOfUsers);
                if (listOfUsers == null)
                {
                    return new StatusCodeResult((int)HttpStatusCode.NotImplemented);
                }
                else
                {
                    return JsonConvert.SerializeObject(listOfUsers);
                }
                //return (await ((Task<UsersList>)method.Invoke(this, new object[] { req, context, numOfUsers })).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<object> GetList(string numOfUsers)
        {
            try
            {
                object listOfUsers = null;

                HttpClient client = new HttpClient();
                string response = await client.GetStringAsync(@$"https://randomuser.me/api/?results={numOfUsers}");
                listOfUsers = response;


                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@$"https://randomuser.me/api/?results={numOfUsers}");
                //request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                //using (HttpWebResponse response2 = (HttpWebResponse)request.GetResponse())
                //using (Stream stream = response2.GetResponseStream())
                //using (StreamReader reader = new StreamReader(stream))
                //{
                //    listOfUsers = reader.ReadToEnd();
                //}

                Console.WriteLine(listOfUsers.ToString());
                return listOfUsers;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
