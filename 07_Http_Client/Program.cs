using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _07_Http
{
    class Program
    {
        //https://www.zetcode.com/csharp/json/
        //https://www.zetcode.com/csharp/httplistener/
        //https://www.zetcode.com/csharp/httpclient/

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

                var response = context.Response;

                switch (context.Request.HttpMethod)
                {
                    case "GET":
                        //Get the current settings
                        response.ContentType = "application/json";

                        //This is what we want to send back
                        var responseBody = ""; // JsonConvert.SerializeObject(MyApplicationSettings);

                        //Write it to the response stream
                        var buffer = Encoding.UTF8.GetBytes(responseBody);
                        response.ContentLength64 = buffer.Length;
                        response.OutputStream.Write(buffer, 0, buffer.Length);
                        //handled = true;
                        break;

                    case "PUT":
                        //Update the settings
                        using (var body = context.Request.InputStream)
                        using (var reader = new StreamReader(body, context.Request.ContentEncoding))
                        {
                            //Get the data that was sent to us
                            var json = reader.ReadToEnd();

                            //Use it to update our settings
                            //UpdateSettings(JsonConvert.DeserializeObject<MySettings>(json));

                            //Return 204 No Content to say we did it successfully
                            response.StatusCode = 204;
                            //handled = true;
                        }
                        break;

                }

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

        private Stream GetBody(HttpListenerContext context)
        {
            if (!context.Request.HasEntityBody)
            {
                return null;
            }

            System.IO.Stream body = context.Request.InputStream; // Stream형식으로 받아오기 
                                                                 //원하는 자료형에 따라 변환하여 사용가능

            return body;
        }

        void listner_GetContext()
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://127.0.0.1:8080/");
            listener.Start();


            // Samples
            var context = listener.GetContext();
            var request = context.Request;
            string text;
            using (var reader = new StreamReader(request.InputStream,
                                                 request.ContentEncoding))
            {
                text = reader.ReadToEnd();
            }



            string path = "image";

            if (path == "/image")
            {
                sendImage(context);
            }
            else
            {
                notFound(context);
            }
        }
        // Use text here

        void notFound(HttpListenerContext ctx)
        {
            HttpListenerResponse resp = ctx.Response;
            resp.Headers.Set("Content-Type", "text/plain");

            Stream ros = resp.OutputStream;

            ctx.Response.StatusCode = (int)HttpStatusCode.NotFound;
            string err = "404 - not found";

            byte[] ebuf = Encoding.UTF8.GetBytes(err);
            resp.ContentLength64 = ebuf.Length;

            ros.Write(ebuf, 0, ebuf.Length);
        }

        void sendImage(HttpListenerContext ctx)
        {
            HttpListenerResponse resp = ctx.Response;
            resp.Headers.Set("Content-Type", "image/png");

            byte[] buf = File.ReadAllBytes("public/img/sid.png");
            resp.ContentLength64 = buf.Length;

            Stream ros = resp.OutputStream;
            ros.Write(buf, 0, buf.Length);
        }
        
    }
}
