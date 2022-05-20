using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TctStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrintFile(@"Test.txt");
            //CopyFile(@"Test.txt", @".\Dir1\Test.txt");
            //FileDirList();
        }

        static void PrintFile(string filename)
        {
            string line;
            StreamReader file = new StreamReader(filename);
            while ((line = file.ReadLine()) != null)
            {
                System.Console.WriteLine(line);
            }
            file.Close();
        }

        static void CopyFile(string InputFilename, string OutputFilename)
        {
            //Directory 생성
            //System.IO.Directory.CreateDirectory(@".\Dir1");

            const int BUF_SIZE = 4096;
            byte[] buffer = new byte[BUF_SIZE];
            int nFReadLen;
            FileStream fs_in = new FileStream(InputFilename, FileMode.Open, FileAccess.Read);
            FileStream fs_out = new FileStream(OutputFilename, FileMode.Create, FileAccess.Write);
            while ((nFReadLen = fs_in.Read(buffer, 0, BUF_SIZE)) > 0)
            {
                fs_out.Write(buffer, 0, nFReadLen);
            }
            fs_in.Close();
            fs_out.Close();
        }

        static void FileDirList() {
            string[] subdirectoryEntries = Directory.GetDirectories(".");

            foreach (string subdirectory in subdirectoryEntries)
                Console.WriteLine("[{0}]", subdirectory);

            string[] fileEntries = Directory.GetFiles(".");

            foreach (string fileName in fileEntries)
                Console.WriteLine(fileName);
        }
    }
}
