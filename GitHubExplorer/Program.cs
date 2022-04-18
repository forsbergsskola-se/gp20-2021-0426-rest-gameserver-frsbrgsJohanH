using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GitHubExplorer
{
    public class User

    {
        public string login { get; set; }
        public int id { get; set; }
        public string node_id { get; set; }
        public string avatar_url { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
        public string html_url { get; set; }
        public string followers_url { get; set; }
        public string following_url { get; set; }
        public string gists_url { get; set; }
        public string starred_url { get; set; }
        public string subscriptions_url { get; set; }
        public string organizations_url { get; set; }
        public string repos_url { get; set; }
        public string events_url { get; set; }
        public string received_events_url { get; set; }
        public string type { get; set; }
        public bool site_admin { get; set; }
        public override string ToString()
        {
            return $"{login}: {id} {node_id}";
        }
    }
    
    


        class Program
        {
            private static HttpClient Client;

            public string userName;
            public static string gitAPI = "https://api.github.com/users/frsbrgsJohanH";

            public static HttpRequestMessage RequestMessage;

            
            public static StreamReader StreamReader;
            

            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");

                //Task.WaitAll(Execute());

                Execute();
                Console.ReadLine();

                

                

            }

            public static async Task Execute()
            {
                Client = new HttpClient();


                Client.BaseAddress = new Uri("https://api.github.com");

                Client.DefaultRequestHeaders.UserAgent.Add(
                    new System.Net.Http.Headers.ProductInfoHeaderValue("GitHubChecker", "1.0"));
                Client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                Client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue(Secret.token);

                var response = Client.GetAsync("/users/frsbrgsJohanH/following").Result;
                response.EnsureSuccessStatusCode();




                var content = await response.Content.ReadAsStringAsync();



                Console.WriteLine(content);



                 var userResponse = JsonSerializer.Deserialize<List<User>>(content);

                 

                Console.WriteLine(userResponse[0]);
                Console.WriteLine(userResponse[1]);
                Console.WriteLine(userResponse[2]);



                 //Console.WriteLine($"login name: {User.login}");





            }

        }
    }

