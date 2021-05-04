using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;


namespace TinyBrowser
{
    class MyBrowser
    {
        
        
        public static string FindLinks(string checkString)
        {
            List<string> LinkList = new List<string>(); 
           Regex regx = new Regex(@"\b(?:https?://|www\.)[^ \f\n\r\t\v\]]+\b",
                RegexOptions.IgnoreCase);
           Match match = Regex.Match(checkString, @"(?<=\<title\>).*?(?=\<\/title\>)", RegexOptions.None);
           
            Console.WriteLine(match);
            foreach (Match m in regx.Matches(checkString))
            {
               LinkList.Add(m.Value);
                
            }

            for (int i = 0; i < LinkList.Count; i++)

                Console.WriteLine($"{i} {LinkList[i]}");
            
            return checkString;
        }

      
        
    }
}