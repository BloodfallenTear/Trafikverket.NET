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

            using (var sr = new StreamReader("key"))
                key = sr.ReadToEnd();

            using(var trafikverket = new Trafikverket(key))
            {
                var requestBuilder = new RequestBuilder
                {
                    Query = new Query
                    {

                    },
                    Filter = new Filter
                    {

                    }
                };

                var response = trafikverket.Railroad.TrainStation(new QueryBodyBuilder
                {
                    
                });
                Console.WriteLine(String.Join(",\r\n", response.Select(x => x.AdvertisedLocationName)));
            }
        }
    }
}
