using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_Api
{
    class Program
    {
        static void Main(string[] args)
        {
            //현재날짜, 시각문자열로가져오기
            DateTime now = DateTime.Now;
            string strNow = now.ToString("yyyy/MM/dd HH:mm:ss.fff");

            //문자열날짜, 시각→DateTime타입으로변경
            string strTime = "2022-03-31 21:40:15";
            DateTime dt = DateTime.ParseExact(strTime, "yyyy-MM-dd HH:mm:ss", null);

            //시간차이계산
            string strTime1 = "20220331143610";
            string strTime2 = "20220331143720";
            DateTime dt1 = DateTime.ParseExact(strTime1, "yyyyMMddHHmmss", null);
            DateTime dt2 = DateTime.ParseExact(strTime2, "yyyyMMddHHmmss", null);
            TimeSpan ts = dt2 - dt1;
            Console.WriteLine(ts.TotalSeconds); // Sec Difference

            //10진수4자리로출력
            int a = 14; Console.WriteLine(string.Format("{0:D4}", a));

            //16진수출력
            int a1 = 14;
            Console.WriteLine(string.Format("{0:X2} {1:x2}", a1, a1));

            //소수점 출력
            double b = 12.345678;
            Console.WriteLine(string.Format("{0:f3}", b));

            //위치로 자르기
            String strTest = "My book | Your pen | His desk";
            Console.WriteLine(strTest.Substring(10)); //10자리부터끝까지
            Console.WriteLine(strTest.Substring(10, 8)); //10자리에서8자리이후까지

            //Delimiter 사용하여자르기
            String strTest2 = "My book | Your pen | His desk";
            string[] words = strTest2.Split(new[] { " | " }, StringSplitOptions.None);
            foreach (var item in words)
                Console.WriteLine(item);

            //String →Byte Array
            string strTest3 = "ABCD123";
            byte[] byteTest = System.Text.Encoding.UTF8.GetBytes(strTest3);
            foreach (var b1 in byteTest)
                Console.Write(b1 + " ");

            //Byte Array →String
            string strTest4 = System.Text.Encoding.UTF8.GetString(byteTest);
            Console.WriteLine(strTest4);


        }
    }
}
