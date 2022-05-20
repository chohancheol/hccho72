using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _04_Encript
{
    class Program
    {
        static void Main(string[] args)
        {
            Base64Sample("This is a Base64 test.");

            SHA256Sample("1234");

        }

        static void Base64Sample(string str)
        {
            byte[] byteStr = System.Text.Encoding.UTF8.GetBytes(str);
            string encodedStr;
            byte[] decodedBytes;
            encodedStr = Convert.ToBase64String(byteStr);
            Console.WriteLine(encodedStr);

            decodedBytes = Convert.FromBase64String(encodedStr);
            Console.WriteLine(Encoding.Default.GetString(decodedBytes));
        }

        //https://docs.microsoft.com/ko-kr/dotnet/api/system.security.cryptography.sha256?redirectedfrom=MSDN&view=net-6.0#code-snippet-1
        static void SHA256Sample(string strInput)
        {
            byte[] hashValue;
            byte[] byteInput = System.Text.Encoding.UTF8.GetBytes(strInput);

            SHA256 mySHA256 = SHA256Managed.Create();
            hashValue = mySHA256.ComputeHash(byteInput);
            for (int i = 0; i < hashValue.Length; i++)
                Console.Write(String.Format("{0:X2}", hashValue[i]));
        }
    }
}
