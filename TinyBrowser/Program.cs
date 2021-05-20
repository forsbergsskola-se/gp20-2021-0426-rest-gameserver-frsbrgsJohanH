using System;
using System.IO;
using System.Net.Sockets;

namespace TinyBrowser
{
    class Program
    {
        public string result;
        
        static void Main(string[] args)
        {
            
            Start();
            MyBrowser.ExtractString(Connection.result);
            MyBrowser.DisplayLinks();
            
            Connection.VisitLink();
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





