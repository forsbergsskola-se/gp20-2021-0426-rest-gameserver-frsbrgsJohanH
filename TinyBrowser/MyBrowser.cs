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
           Regex regx = new Regex(@"\b(?:https?://|www\.)[^ \f\n\r\t\v\]]+\b",
                RegexOptions.IgnoreCase);
           Match match = Regex.Match(checkString, @"(?<=\<title\>).*?(?=\<\/title\>)", RegexOptions.IgnoreCase);
           
            Console.WriteLine(match);
            foreach (Match m in regx.Matches(checkString))
            {
                Console.WriteLine("   {0} {1}", m.Index, m.Value);
            }
            
            return checkString;
        }
    }
}