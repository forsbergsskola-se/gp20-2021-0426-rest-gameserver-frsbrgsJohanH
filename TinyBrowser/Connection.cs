using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace TinyBrowser
{
    public class Connection
    {
            public static string path { get; set; }
       
            public static string result { get; set;}
            public static TcpClient tcpClient;
            public static StreamWriter streamWriter;
            public static StreamReader streamReader;

            public static string host = "acme.com";
            
            public static int port = 80;

            public static void Connect()
            {
                tcpClient = new TcpClient(host, port);

                streamWriter = new StreamWriter(tcpClient.GetStream());
                streamWriter.AutoFlush = true;
                streamWriter.Write($"GET / HTTP/1.1\r\nHost: acme.com\r\n\r\n");

                streamReader = new StreamReader(tcpClient.GetStream());
                result = streamReader.ReadToEnd();
                tcpClient.Close();
                streamWriter.Close();
                streamReader.Close();

            }

            public static void ConnectToPath()
            {
                tcpClient = new TcpClient(host, port);
                
                streamWriter = new StreamWriter(tcpClient.GetStream());

                streamWriter.AutoFlush = true;
                
                streamWriter.Write($"GET {path} HTTP/1.1\r\nHost: acme.com\r\n\r\n");
                streamReader = new StreamReader(tcpClient.GetStream());
                result = streamReader.ReadToEnd();
                //MyBrowser.ClearLists();
                
                //MyBrowser.ExtractString(result);
                //MyBrowser.DisplayLinks();
                MyBrowser.ClearLists();
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
                        
                    }
                    else
                    {
                        Console.WriteLine("Bad input, try again!");
                    }
                    return path;
            }
    }
    
}