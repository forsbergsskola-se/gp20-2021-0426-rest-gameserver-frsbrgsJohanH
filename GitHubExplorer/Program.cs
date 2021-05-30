using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GitHubExplorer
{
    class Program
    {
        private static HttpClient Client;

        public string userName;
        public static string gitAPI = "https://api.github.com/users/frsbrgsJohanH";

        public static HttpRequestMessage RequestMessage;
        public static string response;
        
        
        
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Task.WaitAll(Ececute());
            Console.ReadLine();





        }

        public static async Task Ececute()
        {
            Client = new HttpClient();

            Client.BaseAddress = new Uri("https://api.github.com");
            
            Client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("AppName", "1.0"));
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(Secret.token);

            var response = await Client.GetAsync("/users/frsbrgsJohanH");
            
            Console.WriteLine(response);

        }
        
    }
}
