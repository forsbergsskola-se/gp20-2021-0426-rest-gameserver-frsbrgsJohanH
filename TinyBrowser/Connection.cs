using System;
using System.IO;
using System.Net.Sockets;

namespace TinyBrowser
{
    public class Connection
    {
            public static string path { get; set; }
       
            public static string result;
            public static TcpClient tcpClient;
            public static StreamWriter streamWriter;
            public static StreamReader streamReader;

            public static string host = "acme.com";
            
            
            public static void Connect()
            {
                tcpClient = new TcpClient(host, 80);
                streamWriter = new StreamWriter(tcpClient.GetStream());
                streamWriter.AutoFlush = true;
                streamWriter.Write("GET / HTTP/1.1\r\nHost: acme.com\r\n\r\n");
                
                
            }

            public static void ReadResponse()
            {
                streamReader = new StreamReader(tcpClient.GetStream());
                result = streamReader.ReadToEnd();
            }

            public static string VisitLink()
            {
                var userInput = string.Empty;
                var correctInput = false;
                
                
                Console.WriteLine();
                Console.Write("Enter a number between: 0 - 62: " );
                userInput = Console.ReadLine();

                int.TryParse(userInput, out var num);
                
                
                
                    if (num <= MyBrowser.UrlList.Count - 7)
                    {
                        path = "/" + MyBrowser.UrlList[num];
                        Console.WriteLine(path);
                        BuildLink(path);
                    }
                    else
                    {
                        Console.WriteLine("Bad input, try again!");
                        
                    }

                        //should return a path ----> build path to acme.com and read that response

                return path;
            }

            public static string BuildLink(string path)
            {
                host += path;

                return host;
            }
           
    }
    
}