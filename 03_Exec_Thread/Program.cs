using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _03_Exec_Thread
{
    class Program
    {
        static void Main(string[] args)
        {
            //string output = getProcessOutput("add_2sec.exe", "2 3");
            //Console.WriteLine(output);

            ThreadTest();

        }

        //https://docs.microsoft.com/ko-kr/previous-versions/visualstudio/visual-studio-2008/7a2f3ay4(v=vs.90)?redirectedfrom=MSDN
        static void ThreadTest()
        {
            //Create the thread object.This does not start the thread.
            Worker workerObject1 = new Worker();
            Thread workerThread1 = new Thread(workerObject1.DoWork);

            // Start the worker thread. 
            workerThread1.Start();

            // Use the Join method to block the current thread  
            // until the object's thread terminates. 
            workerThread1.Join();
        }

        //https://docs.microsoft.com/ko-kr/dotnet/api/system.threading.mutex?redirectedfrom=MSDN&view=net-6.0#code-snippet-1
        static void MutexTest()
        {
            WorkerM workerObject1 = new WorkerM();
            Thread workerThread1 = new Thread(workerObject1.DoWork);
            workerThread1.Start();
            workerThread1.Join();
        }

        static string getProcessOutput(string fileName, string args)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = fileName;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            start.Arguments = args;
            Process process = Process.Start(start);

            StreamReader reader = process.StandardOutput;
            return reader.ReadLine();
        }
    }

    public class Worker
    {
        // This method will be called when the thread is started. 
        public void DoWork()
        {
            Console.WriteLine("Thread is running...");
        }
    }

    
    public class WorkerM
    {
        private static Mutex mut = new Mutex();
        // This method will be called when the thread is started. 

        public void DoWork()
        {
            mut.WaitOne();
            //SaveFile(data);
            mut.ReleaseMutex();
        }
    }
}
