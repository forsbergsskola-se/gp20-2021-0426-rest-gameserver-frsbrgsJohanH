using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
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
            return $"{login} \n {url}";
        }
    }
        class Program
        {
            private static HttpClient Client;
            public string userName;



            static void Main(string[] args)
            {
                
               
                Execute();
                

            }

            static string RequestUserNameInput(string input)
            {
                Console.WriteLine("Enter a GitHub-Username: ");
                input = Console.ReadLine();
                
                return input;
            }
            
     

            public static async Task Execute()
            {
                Client = new HttpClient();
                Client.BaseAddress = new Uri("https://api.github.com");
                Client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("GitHubChecker", "1.0"));
                Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(Secret.token);

                var response = Client.GetAsync("/users/frsbrgsJohanH/repos").Result;
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                //Console.WriteLine(content);

                var userResponse = JsonSerializer.Deserialize<List<User>>(content);

               
                 userResponse.ForEach(i => Console.WriteLine(i));

            }

        }
    }

