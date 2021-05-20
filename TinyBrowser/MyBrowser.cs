using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TinyBrowser
{ 
    static class Link
    {
        public static string Title { get; set; }
        public static string Url { get; set; }
    }
    static class MyBrowser
    {
        public static List<string> UrlList = new List<string>();
        public static List<string> TitleList = new List<string>();

        public static string GetPageTitle(string checkString)
        {
            Match titleMatch = Regex.Match(checkString, @"(?<=\<title\>).*?(?=\<\/title\>)", RegexOptions.None);
            Console.WriteLine(titleMatch);
            return checkString;
        }

        public static string ExtractString(string fromText)
        {
            List<string> title = TitleList;
            List<string> url = UrlList;

            string urlStart = "<a href=\"";
            string urlEnd = "\">";

            string titleStart = ">";
            string titleEnd = "</a>";
           

            int indexStart = 0;
            int indexEnd = 0;

            bool exit = false;
            while (!exit)
            {
                indexStart = fromText.IndexOf(urlStart);

                if (indexStart != -1)
                {
                    indexEnd = indexStart + fromText.Substring(indexStart).IndexOf(urlEnd);

                    url.Add(fromText.Substring(indexStart + urlStart.Length, indexEnd - indexStart - urlStart.Length));

                    indexStart = indexEnd + 1;
                    indexEnd = indexStart + fromText.Substring(indexStart).IndexOf(titleEnd);


                    title.Add(fromText.Substring(indexStart + titleStart.Length, indexEnd - indexStart - titleStart.Length));

                    fromText = fromText.Substring(indexEnd + urlEnd.Length + titleEnd.Length);
                }
                else
                {
                    exit = true;
                }
            }
            return fromText;
        }
        public static List<string> CleanList(List<string> list)
            {
                for (int i = 0; i < TitleList.Count; i++)
                {
                    TitleList[i] = TitleList[i].Replace("<b>", "");
                    TitleList[i] = TitleList[i].Replace("</b>", "");

                    string tag = "<";
                    
                    if (TitleList[i].Contains(tag))
                    {
                        TitleList.RemoveAll(x => x.Contains("<img"));
                    }
                }
                return UrlList;
            }
        public static void DisplayLinks()
        {
            CleanList(UrlList);
            
            for (int i = 0; i < TitleList.Count; i++)
            {
                Console.WriteLine($"{i + ":"} {TitleList[i] + " (" + UrlList[i] + ")"} ");
            }
        }
    }
}

