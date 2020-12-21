using System;

namespace TrafikverketSharp.Test
{
    internal class Program
    {
        private static void Main(string[] args) => new Program().Main();
        private void Main()
        {
            using(var trafikverket = new Trafikverket("6277af4b013e4a4b98319462f16d7776"))
            {
                trafikverket.Railroad.GetTrainStation(new RequestBuilder
                {
                    
                });
            }
        }
    }
}
