using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityServer.AzureAdUserService;
using Microsoft.Azure.ActiveDirectory.GraphClient;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AzureADUserServiceTests
{
    [TestClass]
    public class UnitTest1
    {
        private string Secret = "MYk+1ZWjfXju6/Vj0z69SZJN0o+V/nW/N/yToWtUGfs="; //its deleted, dont bother trying.

        [TestMethod]
        public async Task CreateUserTest()
        {
            var client = new B2CGraphClient("aeefcc33-b5b3-4997-90e9-817e0d91d068", Secret, "b6bdfb2f-60a9-48b4-9fa5-5c15a97e4ffb");
            
            var userTemplate = JObject.Parse(new StreamReader(typeof(B2CGraphClient).Assembly.GetManifestResourceStream("IdentityServer.AzureAdUserService.CreateUserTemplate.json")).ReadToEnd());
            (userTemplate.SelectToken("alternativeSignInNamesInfo[0].type").Parent as JProperty).Value = "userName"; // "emailAddress";
            (userTemplate.SelectToken("alternativeSignInNamesInfo[0].value").Parent as JProperty).Value = "myUserName";
            (userTemplate.SelectToken("passwordProfile.password").Parent as JProperty).Value = "P@ssword!";


            Console.WriteLine(JObject.Parse(await client.CreateUser(userTemplate.ToString())).ToString(Formatting.Indented));

        }

        [TestMethod]
        public async Task ListAllUsers()
        {
            var client = new B2CGraphClient("aeefcc33-b5b3-4997-90e9-817e0d91d068", Secret, "b6bdfb2f-60a9-48b4-9fa5-5c15a97e4ffb");

            var users = await client.GetAllUsers();
            Console.WriteLine(JObject.Parse(users).ToString(Formatting.Indented));
            
        }
        [TestMethod]
        public async Task Signin()
        {
            //https://login.microsoftonline.com/b6bdfb2f-60a9-48b4-9fa5-5c15a97e4ffb/oauth2/v2.0/token dont implement RO flow

            var client = new HttpClient();
            var a = await client.PostAsync("https://login.microsoftonline.com/b6bdfb2f-60a9-48b4-9fa5-5c15a97e4ffb/oauth2/token",
                new FormUrlEncodedContent(new Dictionary<string, string> {
                    { "username","myUserName" },
                    { "password","P@ssword!" },
                    { "client_id","aeefcc33-b5b3-4997-90e9-817e0d91d068" },
                    {"client_secret",Secret },
                    { "grant_type","password" }, {
                    "resource",Globals.aadGraphResourceId}
                }
                    ));
           ;
            //IF SUCCED the user is signed in
            Console.WriteLine(await a.EnsureSuccessStatusCode().Content.ReadAsStringAsync());

          
        }
    }
}
