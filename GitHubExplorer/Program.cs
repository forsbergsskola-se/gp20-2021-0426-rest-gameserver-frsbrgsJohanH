using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
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
        public string name { get; set; }
        public string company { get; set; }
        public string blog { get; set; }
        public string location { get; set; }
        public string email { get; set; }
        public bool hireable { get; set; }
        public string bio { get; set; }
        public string twitter_username { get; set; }
        public int public_repos { get; set; }
        public int public_gists { get; set; }
        public int followers { get; set; }
        public int following { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public override string ToString()
        {
            return $"{login}\n{bio}\n{blog}\n{company}The users account was last updated at:{updated_at}";
        }
    }
        class Program
        {
            private static HttpClient Client;
        

            static void Main(string[] args)
            {
               
               
                ExecuteAPICall();
                

            }

            static void RequestUserNameInput()
            {
                Console.WriteLine("Enter a GitHub-Username: ");
                string input = Console.ReadLine();
            }
            
     

            public static async Task ExecuteAPICall()
            {

            
                string baseAdress = "/users/";
                Client = new HttpClient();
                Client.BaseAddress = new Uri("https://api.github.com");
                Client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("GitHubChecker", "1.0"));
                Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(Secret.token);
                
                Console.WriteLine("Enter a GitHub-Username: ");
                string userName = Console.ReadLine();
                
                
                var response = Client.GetAsync(baseAdress+userName).Result;
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

               
              User user = JsonSerializer.Deserialize<User>(content);

                 
               
                 
                 Console.WriteLine(user);
                 Console.WriteLine();
                 Console.WriteLine($"Explore {userName}'s \n[0] Followers\n[1] Stars\n[2] Repositories\n[3] Quit\n");
                 Console.ReadLine();

                 int.TryParse(Console.ReadLine(), out var choice);

                 switch (choice)
                 {
                     case 0:
                        
                         Console.WriteLine($"{userName} has {user.followers} followers, and is following {user.following} user/s");
                         Console.WriteLine($"\n{userName}'s followers:");
                         var fol = Client.GetStringAsync(user.followers_url);
                         List<User> followers = JsonSerializer.Deserialize<List<User>>(fol.Result);
                         
                             if (followers?.Any()!=true) {
                                 Console.WriteLine($"{userName} have no followers :(");
                             }
                             else {
                                 foreach (var follower in followers)
                                 Console.WriteLine(follower.login);
                             }
                         break;
                     
                     
                         
                     
                 }


            }

        }
    }

