using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _05_2_Socket_Client
{
    class Program
    {
        static int BUF_SIZE = 1024;

        static void Main(string[] args)
        {
            Basic();
            //FileSend();
        }


        static void Basic()
        {
            byte[] bytes = new byte[1024];

            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 9090);
            Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                sender.Connect(remoteEP);

                // Encode the data string into a byte array.  
                byte[] msg = Encoding.ASCII.GetBytes("This is a test<EOF>");

                // Send the data through the socket.  
                int bytesSent = sender.Send(msg);

                int bytesRec = sender.Receive(bytes);
                Console.WriteLine(Encoding.ASCII.GetString(bytes, 0, bytesRec));
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        static void FileSend()
        {
            byte[] bytes = new byte[1024];

            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 9090);
            Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                sender.Connect(remoteEP);

                NetworkStream ns = new NetworkStream(sender);
                BinaryWriter bw = new BinaryWriter(ns);
                DirectoryInfo di = new DirectoryInfo("./ClientFiles");
                FileInfo[] fiArr = di.GetFiles();
                foreach (FileInfo infoFile in fiArr)
                {
                    // 파일이름전송
                    bw.Write(infoFile.Name);
                    long lSize = infoFile.Length;
                    // 파일크기전송
                    bw.Write(lSize);
                    // 파일내용전송
                    FileStream fs = new FileStream(infoFile.FullName, FileMode.Open);
                    while (lSize > 0)
                    {
                        int nReadLen = fs.Read(bytes, 0, Math.Min(BUF_SIZE, (int)lSize));
                        bw.Write(bytes, 0, nReadLen);
                        lSize -= nReadLen;
                    }
                    fs.Close();
                }

                int bytesRec = sender.Receive(bytes);
                Console.WriteLine(Encoding.ASCII.GetString(bytes, 0, bytesRec));
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
