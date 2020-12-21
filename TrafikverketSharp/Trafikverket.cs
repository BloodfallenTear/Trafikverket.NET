using System;
using System.Net.Http;

namespace TrafikverketSharp
{
    /// <summary>
    /// Trafikverkets öppna API för trafikinformation.
    /// </summary>
    public sealed class Trafikverket : BaseTrafikverket
    {
        internal static HttpClient HttpClient { get; private set; }
        internal static String Key { get; private set; }

        public RailroadEndpoint Railroad { get; } = new RailroadEndpoint();

        private bool disposed = false;

        /// <summary>
        /// Trafikverkets öppna API för trafikinformation.
        /// </summary>
        /// <param name="key">Unika nyckel.</param>
        public Trafikverket(String key)
        {
            Trafikverket.HttpClient = new HttpClient();
            Trafikverket.HttpClient.DefaultRequestHeaders.ConnectionClose = true;

            Trafikverket.Key = key;
        }

        ~Trafikverket() => this.Dispose();

        public override void Dispose()
        {
            if (this.disposed)
                return;

            Trafikverket.HttpClient.Dispose();

            this.disposed = true;
            GC.SuppressFinalize(this);
        }
    }

    /// <summary>
    /// Om något med anropet går fel så returneras någon av följande HTTP statuskoder.
    /// </summary>
    public enum ErrorCodes : UInt16
    {
        /// <summary>
        /// Svaret är för stort. Maximalt tillåten datamängd kommer at returneras följt av ERROR som meddelar att svaret inte är komplett.
        /// </summary>
        PartialContent = 206,
        /// <summary>
        /// Misslyckad autentisering.
        /// </summary>
        Unauthorized = 401,
        /// <summary>
        /// Internt serverfel.
        /// </summary>
        InternalServerError = 500,
        /// <summary>
        /// Servern stödjer inte en funktion som efterfrågades av klienten.
        /// </summary>
        NotImplemented = 501
    }

    public abstract class BaseTrafikverket : IDisposable
    {
        protected String BaseURL => "https://api.trafikinfo.trafikverket.se";

        protected internal BaseTrafikverket() { }

        public abstract void Dispose();
    }
}
