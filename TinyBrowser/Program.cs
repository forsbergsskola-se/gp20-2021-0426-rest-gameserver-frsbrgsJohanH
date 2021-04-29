using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace TinyBrowser
{
  
    class Program
    {
        

        static void Main(string[] args)
        {
            TcpClient myTcpClient = new TcpClient("acme.com", 80);
            NetworkStream stream = myTcpClient.GetStream();
            
            byte[] sentData = Encoding.ASCII.GetBytes("GET / HTTP/1.1\r\nHost: acme.com\r\n\r\n");
            
            stream.Write(sentData, 0, sentData.Length);
            
            Console.WriteLine("Sent: {0}", sentData);
            
            //Receive response//

            byte[] recData = new Byte[10000];
            
            string responseData = String.Empty;

            Int32 bytes = stream.Read(recData, 0, recData.Length);
            responseData = Encoding.ASCII.GetString(recData, 0, bytes);
            
            Console.WriteLine("Received: {0}", responseData);






        }
    }
}