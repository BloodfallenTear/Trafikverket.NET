using System;
using System.IO;
using System.Linq;

namespace TrafikverketSharp.Test
{
    internal class Program
    {
        private static void Main(string[] args) => new Program().Main();
        private void Main()
        {
            var key = String.Empty;
            if (!File.Exists("key"))
                File.Create("key").Close();

            using (var sw = new StreamReader("key"))
                key = sw.ReadToEnd();

            using(var trafikverket = new Trafikverket(key))
            {
                var response = trafikverket.Railroad.TrainStation(new QueryBuilder
                {
                    
                });
                Console.WriteLine(String.Join(",\r\n", response.Select(x => x.AdvertisedLocationName)));
            }
        }
    }
}
