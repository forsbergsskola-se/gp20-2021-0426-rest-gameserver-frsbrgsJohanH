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
            Console.WriteLine("The acme.com TinyBrowser");
            Console.WriteLine("Press 1 to visit acme.com");
            int userChoice = int.Parse(Console.ReadLine());
            bool isRunning = true;
            
            while (isRunning)
            {
                switch (userChoice)
                {
                    case 1:
                        Connection.Connect();
                        MyBrowser.ExtractString(Connection.result);
                        MyBrowser.DisplayLinks();

                        goto case 2;
                
                    case 2:

                        Connection.VisitLink();
                        Connection.ConnectToPath();
                        MyBrowser.ExtractString(Connection.result);
                        Console.WriteLine("Want to check out another page? y/n");
                        string choice = Console.ReadLine();

                        if (choice == "y")
                        {
                            MyBrowser.TitleList.Clear();
                            MyBrowser.UrlList.Clear();
                            goto case 1;
                        }
                            
                        else return;
                        
                    
                    
                }
                
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





