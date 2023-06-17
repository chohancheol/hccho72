using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Json
{
    class Program
    {
        //https://www.zetcode.com/csharp/json-net/
        //https://www.zetcode.com/csharp/json/
        static void Main(string[] args)
        {
            JObject json = new JObject();
            json["name"] = "John Doe";
            json["salary"] = 300100;
            string jsonstr = json.ToString();
            Console.WriteLine("Json : " + jsonstr);

            JObject json2 = JObject.Parse(jsonstr);
            Console.WriteLine($"Name : {json2["name"]}, Salary : {json2["salary"]}");
        }
    }
}
