using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GitHubExplorer
{
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

            Task.WaitAll(Execute());
            Console.ReadLine();





        }

        public static async Task Execute()
        {
            Client = new HttpClient();
            

            Client.BaseAddress = new Uri("https://api.github.com");
            
            Client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("AppName", "1.0"));
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(Secret.token);

            var response = await Client.GetAsync("/users/frsbrgsJohanH/repos");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            
            Console.WriteLine(content);

          
            
            
            

            response.Content.ReadAsStream();

            /*UserResponse? userResponse = await Client.GetFromJsonAsync<UserResponse>("/users/frsbrgsJohanH/");
            Console.WriteLine($"Name: {userResponse.name}");
            Console.WriteLine($"Name: {userResponse.job}");*/

            //UserResponse? userResponse = JsonSerializer.Deserialize<UserResponse>(jsonText);
            
            
            Console.WriteLine(response);

            

        }
        
    }
}
