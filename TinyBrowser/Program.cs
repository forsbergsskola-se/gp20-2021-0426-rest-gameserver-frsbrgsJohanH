using System;
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
                        MyBrowser.ClearLists();
                        Connection.Connect();
                        MyBrowser.ExtractString(Connection.result);
                        MyBrowser.DisplayLinks();
                        
                        

                        goto case 2;
                
                    case 2:

                        Connection.VisitLink();
                        Connection.ConnectToPath();
                        MyBrowser.ExtractString(Connection.result);
                        MyBrowser.DisplayLinks();
                        Console.WriteLine(Connection.result);
                        //MyBrowser.DisplayLinks();
                        
                        
                        Console.WriteLine("Want to check out another page? y/n");
                        string choice = Console.ReadLine();

                        if (choice.ToLower() == "y")
                        {
                            goto case 1;
                        }

                        if (choice.ToLower() == "n")
                        {
                            Environment.Exit(0);
                        }
                            
                        else return;

                        break;
                }
            }
        }
    }
}





