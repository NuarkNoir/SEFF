using NuarkNETOD;
using System;
using Newtonsoft.Json;

namespace x_path
{
    static class Program
    {
        static void Main(string[] args)
        {
            spth();
            Console.ReadKey();
        }

        private static void spth()
        {
            Console.WriteLine("Введите номер");
            string num = Console.ReadLine();
            string uri =
                "https://query.yahooapis.com/v1/public/yql?q=select * from html where url='https://stories.everypony.ru/story/" + num + "/' and xpath='.//*[@id=\"story_title\"]'&format=json&env=store://datatables.org/alltableswithkeys&callback=";
            string request = NuarkNeToD.GetResponse(uri);
            dynamic titla = JsonConvert.DeserializeObject(request);
            Console.WriteLine("Name: " + titla.ry.results.h1.content);
        }
    }
}
