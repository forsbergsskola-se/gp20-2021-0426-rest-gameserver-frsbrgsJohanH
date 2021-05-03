using System;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;


namespace TinyBrowser
{

    class Program
    {


        static void Main(string[] args)
        {

            // Connect to acme.com Server via TCP on HTTP-Default-Port 80.
            var tcpClient = new TcpClient("acme.com", 80);

            // Send a HTTP-Request for the Root-Page
            var streamWriter = new StreamWriter(tcpClient.GetStream());
            streamWriter.AutoFlush = true;
            streamWriter.Write("GET / HTTP/1.1\r\nHost: acme.com\r\n\r\n");

            // Read the Response
            var streamReader = new StreamReader(tcpClient.GetStream());
            var result = streamReader.ReadToEnd();

            Regex regx = new Regex(@"\b(?:https?://|www\.)[^ \f\n\r\t\v\]]+\b" , RegexOptions.IgnoreCase);

            foreach (Match m in regx.Matches(result))
            {
                

                Console.WriteLine("   {0} {1}", m.Index, m.Value);
            }

        }

        ///TODO Find title, Count Lines in the output instead of original string, trim of remaining <tags>
        /// 

    }
}

