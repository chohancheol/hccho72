using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            List();
            Dictionary();
            QueueTest();
        }

        static void List()
        {
            List<string> al = new List<string>();
            al.Add("Michael Knight");
            al.Add("Mac Guyver");
            al.Add("Clark Kent");
            al.Add("Bruce Wayne");
            al.Add("Tony Stark");
            foreach (string name in al)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();
            al.Remove("Clark Kent");
            for (int i = 0; i < al.Count; i++)
            {
                Console.WriteLine(al[i]);
            }
            Console.WriteLine();
            al.Remove(al[0]);
            var enumerator = al.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }

            al.Sort();
            foreach (string name in al)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();
            al.Sort(delegate (string x, string y) {return y.CompareTo(x);});  //y, x 자리변경시오름차순

            foreach (string name in al)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            al.Sort((string x, string y) => x.CompareTo(y));

            foreach (string name in al)
            {
                Console.WriteLine(name);
            }
        }

        static void Dictionary()
        {
            Dictionary<string, string> m = new Dictionary<string, string>();
            m.Add("kit@gmail.com", "Michael Knight");
            m.Add("knife@gmail.com", "Mac Guyver");
            m.Add("superman@gmail.com", "Clark Kent");
            m.Add("batman@gmail.com", "Bruce Wayne");
            m.Add("ironman@gmail.com", "Tony Stark");
            foreach (KeyValuePair<string, string> items in m)
            {
                Console.WriteLine(items.Key + " : " + items.Value);
            }
            Console.WriteLine();
            m.Remove("superman@gmail.com");
            foreach (KeyValuePair<string, string> items in m)
            {
                Console.WriteLine(items.Key + " : " + items.Value);
            }

            Console.WriteLine();
            m["batman@gmail.com"] = "Robin";
            foreach (KeyValuePair<string, string> items in m)
            {
                Console.WriteLine(items.Key + " : " + items.Value);
            }
        }

        static void QueueTest()
        {
            //Queue 사용
            Queue<string> numberQ = new Queue<string>();
            numberQ.Enqueue("one");
            numberQ.Enqueue("two");
            numberQ.Enqueue("three");
            Console.WriteLine("Queue Count = {0}", numberQ.Count);
            foreach (string number in numberQ) {
                Console.WriteLine(number);
            }
            Console.WriteLine("Deque '{0}'", numberQ.Dequeue());
            Console.WriteLine("Peek : {0}", numberQ.Peek());
            Console.WriteLine("Contains(\"three\") = {0}", numberQ.Contains("three"));
            numberQ.Clear();
            Console.WriteLine("Queue Count = {0}", numberQ.Count);

            //List 사용
            List<string> numberList = new List<string>();
            numberList.Add("one");
            numberList.Add("two");
            numberList.Add("three");
            Console.WriteLine("Queue Count = {0}", numberList.Count);

            foreach (string number in numberList)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("Deque '{0}'", numberList[0]);
            numberList.RemoveAt(0);
            Console.WriteLine("Peek : {0}", numberList[0]);
            Console.WriteLine("Contains(\"three\") = {0}", numberList.Contains("three"));
            numberList.Clear();
            Console.WriteLine("Queue Count = {0}", numberList.Count);
        }
    }
}
