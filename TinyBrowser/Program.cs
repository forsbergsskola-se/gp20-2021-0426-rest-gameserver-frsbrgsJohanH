using System;
using System.IO;
using System.Net.Sockets;

namespace TinyBrowser
{
    class Program
    {
        public string result;
        public static bool isRunning;
        static void Main(string[] args)
        {
            
            Start();
            MyBrowser.ExtractString(Connection.result);
            MyBrowser.DisplayLinks();

            isRunning = true;

            while (isRunning)
            {
                Connection.VisitLink();
                
            }
            
            
        }

        public static void Start()
        {
            Console.WriteLine("Acme.com Weblink Browser. Press a key to explore this ancient site...");
            //Console.ReadKey();
            Connection.Connect();
            Connection.ReadResponse();
        }
    }



}





