using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
namespace GitHubExplorer
{ 
    public class UserData
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
        public int stargazers_count { get; set; }
        public int forks_count { get; set; }
        
        public string full_name { get; set; }
        public string description { get; set; }
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
            return $"{login}\n{bio}\n{blog}\n{company}\nThey created the account {created_at} and it was last updated {updated_at}";
        }
       
    }
        class Program
        {
            private static HttpClient Client;
            static void Main(string[] args)
            {
                ExecuteAPICall();
            }
            public static async Task ExecuteAPICall()
            {
                bool isRunning = true;
                string baseAdress = "/users/";
                Client = new HttpClient();
                Client.BaseAddress = new Uri("https://api.github.com");
                Client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("GitHubChecker", "1.0"));
                Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(Secret.token);

                while (isRunning)
                {
                    newuser:
                    Console.WriteLine("Enter a GitHub-Username: ");
                    string userName = Console.ReadLine();

                    var responseUserBase = Client.GetAsync(baseAdress+userName).Result;
                    responseUserBase.EnsureSuccessStatusCode();

                    var content = await responseUserBase.Content.ReadAsStringAsync();

                    UserData user = JsonSerializer.Deserialize<UserData>(content);

                     Console.WriteLine(user);
                     Console.WriteLine();
                     rewind:
                     Console.WriteLine($"Explore {userName}'s \n[0] Followers\n[1] Stars\n[2] Repositories\n[3] Explore new user\n[4] Quit");

                     int.TryParse(Console.ReadLine(), out var choice);

                     switch (choice)
                     {
                         case 0:
                             
                             Console.WriteLine($"{userName} has {user.followers} followers, and is following {user.following} user/s");
                             Console.WriteLine($"\n{userName}'s followers:");
                             var fol = Client.GetStringAsync(user.followers_url);
                             List<UserData> followers = JsonSerializer.Deserialize<List<UserData>>(fol.Result);
                             
                                 if (followers?.Any()!=true) {
                                     Console.WriteLine($"{userName} have no followers :(");
                                 }
                                 else {
                                     foreach (var follower in followers)
                                         Console.WriteLine(follower.login);
                                 }
                             Console.ReadLine();
                             goto rewind;
                        
                         case 1:
                                
                                string starredUrl = "/starred";
                                var responseUserStarred = Client.GetAsync(baseAdress+userName+starredUrl).Result;
                                var starContent = await responseUserStarred.Content.ReadAsStringAsync();
                             List<UserData> userStars = JsonSerializer.Deserialize<List<UserData>>(starContent);
                                Console.WriteLine($"{userName} have starred the following repositories:");
                             foreach (var star in userStars) 
                             {
                                 Console.WriteLine($"{star.full_name}______{star.description} is currently starred {star.stargazers_count} times and forked by {star.forks_count} users");
                             }
                             Console.ReadLine();
                                goto rewind;

                         case 2:
                             string reposUrl = "/repos";
                             var responseUserRepos = Client.GetAsync(baseAdress+userName+reposUrl).Result;
                             var repoContent = await responseUserRepos.Content.ReadAsStringAsync();
                             List<UserData> userRepos = JsonSerializer.Deserialize<List<UserData>>(repoContent);
                             
                             Console.WriteLine($"The repositories of {userName}:");
                             foreach (var repo in userRepos)
                             {
                                 Console.WriteLine($"{repo.name} ___ {repo.description} created {repo.created_at} ___ visit at:{repo.html_url} ");
                             }

                             Console.ReadLine();
                             goto rewind;
                         
                         case 3:
                             goto newuser;
                         
                         case 4:
                             Environment.Exit(0);
                             break;
                    } 
                }
            }

        }
}

