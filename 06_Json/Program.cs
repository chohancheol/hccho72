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



            var json1 = "[\".Net\", \"Core\", \"ASP.NET\",\"홍길동\",\"1\"]";
            var jArray = JArray.Parse(json1);

            foreach (var item in jArray.Children())
            {
                Console.WriteLine(item.Value<string>().ToString());
            }

            Console.WriteLine(String.Join(",", jArray.Select(i => i.ToString())));

            Console.ReadKey();


            JArray jArray2 = JArray.Parse(@"[
                            {
                              ""name"": ""Croke Park II"",
            
                                          ""url"": ""http://twitter.com/search?q=%22Croke+Park+II%22"",
                              ""promoted_content"": null,
                              ""query"": """" % 22Croke + Park + II % 22"",
                              ""events"": null
                            },
                            {
                              ""name"": ""Siptu"",
                              ""url"": ""http://twitter.com/search?q=Siptu"",
                              ""promoted_content"": null,
                              ""query"": ""Siptu"",
                              ""events"": null
                            }]");

            foreach (JObject item in jArray2)
            {
                string name = item.GetValue("name").ToString();
                string url = item.GetValue("url").ToString();
                // ...
            }

            var str = @"[1, 2, 3]";
            var jArray3 = JArray.Parse(str);
            Console.WriteLine(String.Join("-", jArray3.Where(i => (int)i > 1).Select(i => i.ToString())));
        }

    }
}
