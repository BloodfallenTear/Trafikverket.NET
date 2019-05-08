﻿using System;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TrafikverketdotNET
{
    public abstract class BaseTrafikverket<T> where T : class
    {
        protected const String URL = "https://api.trafikinfo.trafikverket.se/v2/data.json";
        protected readonly String APIKey;

        /// <param name="APIKey">Användarens unika nyckel.</param>
        protected BaseTrafikverket(String APIKey) { this.APIKey = APIKey; }

        public virtual async Task<T> ExecuteRequest(String ObjectType, String SchemaVersion)
        {
            var resp = await POSTRequest(new StringContent($"<REQUEST>" +
                                                            $"<LOGIN authenticationkey=\"{APIKey}\"/>" +
                                                            $"<QUERY objecttype=\"{ObjectType}\" schemaversion=\"{SchemaVersion}\"/>" +
                                                           $"</REQUEST>"));
            return JsonConvert.DeserializeObject<T>(JObject.Parse(resp)[$"{ObjectType}"].ToString());
        }

        /// <param name="Content">The HTTP request content sent to the server.</param>
        protected async Task<String> POSTRequest(HttpContent Content)
        {
            try
            {
                using (var http = new HttpClient())
                {
                    var resp = http.PostAsync(URL, Content).Result;
                    var respString = await resp.Content.ReadAsStringAsync();

                    var data = JObject.Parse(respString);
                    return data["RESPONSE"]["RESULT"][0].ToString();
                }
            }
            catch (HttpRequestException err) { throw new Exception(err.Message, err.InnerException); }
        }
    }
        
    public sealed class Trafikverket
    {
        private readonly String APIKey;

        /// <param name="APIKey">Användarens unika nyckel.</param>
        public Trafikverket(String APIKey) { this.APIKey = APIKey; }

        public TrainMessage TrainMessage => new TrainMessage(APIKey);
        public TrainStation TrainStation => new TrainStation(APIKey);
        public TrainAnnouncement TrainAnnouncement => new TrainAnnouncement(APIKey);

        public Camera Camera => new Camera(APIKey);
    }

    public sealed class Geometry
    {
        [JsonProperty("SWEREF99TM")] internal String _SWEREF99TM { get; set; }
        [JsonProperty("WGS84")] internal String _WGS84 { get; set; }

        /// <summary>
        /// Geometrisk punkt i koordinatsystem SWEREF99TM.
        /// </summary>
        [JsonIgnore] public String SWEREF99TM => _SWEREF99TM;
        /// <summary>
        /// Geometrisk punkt i koordinatsystem WGS84
        /// </summary>
        [JsonIgnore] public String WGS84 => _WGS84;

        internal Geometry() { }
    }
}
