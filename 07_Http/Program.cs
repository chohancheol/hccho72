using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _07_Http
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://127.0.0.1:8080/");
            listener.Start();

            while (true)
            {
                var context = listener.GetContext();
                Console.WriteLine("Request : " + context.Request.Url);

                byte[] data = Encoding.UTF8.GetBytes("HelloWorld1");
                context.Response.OutputStream.Write(data, 0, data.Length);
                context.Response.StatusCode = 200;
                context.Response.Close();
            }

            /*
            bool isReturningOk = true;
            Console.Title = "Samples.CustomChecks.3rdPartySystem";
            Console.WriteLine("Press enter key to toggle the server to return a error or success");
            Console.WriteLine("Press any key to exit");

            HttpListener listener = new HttpListener();
            using (listener = new HttpListener())
            {
                listener.Prefixes.Add("http://127.0.0.1:8080/");
                listener.Start();
                //listener.BeginGetContext(ListenerCallback, listener);

                while (true)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    Console.WriteLine();

                    if (key.Key != ConsoleKey.Enter)
                    {
                        return;
                    }
                    listener.Close();
                    if (isReturningOk)
                    {
                        Console.WriteLine("\r\nCurrently returning success");
                    }
                    else
                    {
                        Console.WriteLine("\r\nCurrently returning error");
                    }
                    isReturningOk = !isReturningOk;
                }
            } 
            */

        }
    }
}
