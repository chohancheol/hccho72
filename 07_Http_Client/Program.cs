using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _07_Http_Client
{
    class Program
    {
        static readonly HttpClient httpClient = new HttpClient();

        static void Main(string[] args)
        {
            //HttpClient client = new HttpClient();
            //var res = client.GetAsync("http://127.0.0.1:8080/helloworld").Result;

            //Console.WriteLine("Response : " + res.StatusCode);


            string strTest = "http://127.0.0.1:8080/helloworld";
            Test(strTest).GetAwaiter().GetResult();

            Console.WriteLine($" ---------- END ------------");

            string httpsUrl = "https://jsonplaceholder.typicode.com/todos/1";
            string httpUrl = "http://jsonplaceholder.typicode.com/todos/2";

            Console.WriteLine($" -------- HTTPS ------------");

            Test(httpsUrl).GetAwaiter().GetResult();  // Main함수에서 await Test(httpsUrl) 사용못하므로, 이를 대신함

            Console.WriteLine($"\n\n\n --------- HTTP ------------");

            Test(httpUrl).GetAwaiter().GetResult();

            Console.WriteLine($" ---------- END ------------");



            Console.Read();



        }

        //https://freeprog.tistory.com/456 [취미로 하는 프로그래밍 !!!]
        static async Task Test(string url)
        {
            try
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    Console.WriteLine(response.StatusCode);

                    if (HttpStatusCode.OK == response.StatusCode)
                    {
                        string body = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(body);
                    }
                    else
                    {
                        Console.WriteLine($" -- response.ReasonPhrase ==> {response.ReasonPhrase}");
                    }
                }

            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"ex.Message={ex.Message}");
                Console.WriteLine($"ex.InnerException.Message = {ex.InnerException.Message}");

                Console.WriteLine($"----------- 서버에 연결할수없습니다 ---------------------");
            }
            catch (Exception ex2)
            {
                Console.WriteLine($"Exception={ex2.Message}");
            }
        }


        /*
                private static void IgnoreFailure(Action a)
                {
                    try
                    {
                        a();
                    }
                    // ReSharper disable EmptyGeneralCatchClause
                    catch
                    // ReSharper restore EmptyGeneralCatchClause
                    {
                    }
                }

                public static void Main(string[] args)
                {
                    const int numConcurrent = 4;
                    IgnoreFailure(() =>
                    {
                        using (var hl = new HttpListener())
                        {
                            var tasks = new Task[numConcurrent];
                            var cts = new CancellationTokenSource();

                            try
                            {
                                hl.Prefixes.Add("http://127.0.0.1:8080/helloworld/");
                                hl.Start();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                                Environment.Exit(-1);
                            }
                            for (var i = 0; i < tasks.Length; ++i)
                            {
                                Start(tasks, i, cts.Token, hl);
                            }
                            Console.WriteLine("Press any key to stop server.");
                            Console.ReadKey();
                            cts.Cancel();
                            foreach (var t in tasks)
                            {
                                t.Wait(TimeSpan.FromSeconds(30));
                            }
                            hl.Stop();
                        }
                    }
                        );
                }

                private static void Start(Task[] tasks, int i, CancellationToken token, HttpListener hl)
                {
                    tasks[i] =
                        hl
                            .GetContextAsync()
                            .ContinueWith(ProcessRequest, token)
                            .ContinueWith(_ => Start(tasks, i, token, hl), token);
                }

                private static void ProcessRequest(Task<HttpListenerContext> task)
                {
                    IgnoreFailure(() =>
                    {
                        if (!task.IsCompleted)
                            return;
                        var ctx = task.Result;
                        var filename =
                            ctx.Request.Url.AbsolutePath.ToLowerInvariant()
                               .Split('/')
                               .SkipWhile(x => x != "test")
                               .Skip(1)
                               .First()
                            ;
                        var buffer = Encoding.UTF8.GetBytes(filename);
                        ctx.Response.ContentType = "text/plain";
                        ctx.Response.OutputStream.Write(buffer, 0, buffer.Length);
                        ctx.Response.Close();
                    }
                        );
                }
                */
    }
}
