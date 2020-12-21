using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using TrafikverketSharp.Exceptions;

namespace TrafikverketSharp
{
    internal sealed class ResultConverter : JsonConverter
    {
        public override Boolean CanConvert(Type objectType) => throw new System.NotImplementedException();

        public override Object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
        {
            TrafikverketResponse.TRResponse.RResult result = default;
            var obj = JObject.Load(reader);
            var firstObj = obj.First;

            switch(((JProperty)firstObj).Name)
            {
                case "ERROR":
                    result = new TrafikverketResponse.TRResponse.RResult { Error = JsonConvert.DeserializeObject<TrafikverketResponseError>(obj["ERROR"].ToString()) };
                    serializer.Populate(obj.CreateReader(), result);
                    break;
                case "TrainStation":
                    var list = new List<TrainStation>();
                    foreach(var child in firstObj.Values())
                        list.Add(JsonConvert.DeserializeObject<TrainStation>(child.ToString()));

                    result = new TrafikverketResponse.TRResponse.RResult() { Type = list.ToArray() };
                    serializer.Populate(obj.CreateReader(), result);
                    break;
            }

            return result;
        }

        public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer) => throw new System.NotImplementedException();
    }

    public abstract class TrafikverketResponseResultType
    {
        protected internal TrafikverketResponseResultType() { }
    }

    public sealed class TrafikverketResponse
    {
        [JsonProperty("RESPONSE")] public TRResponse Response { get; internal set; }

        internal TrafikverketResponse() { }

        public sealed class TRResponse
        {
            [JsonProperty("RESULT")] public RResult[] Result { get; internal set; }

            internal TRResponse() { }

            [JsonConverter(typeof(ResultConverter))]
            public sealed class RResult
            {
                public TrafikverketResponseResultType[] Type { get; internal set; }
                public TrafikverketResponseError Error { get; internal set; }

                internal RResult() { }
            }
        }
    }

    public sealed class TrafikverketResponseError
    {
        [JsonProperty("SOURCE")] public String Source { get; internal set; }
        [JsonProperty("MESSAGE")] public String Message { get; internal set; }

        internal TrafikverketResponseError() { }
    }

    public sealed class RailroadEndpoint
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestBuilder"></param>
        /// <exception cref="PartialContentException">Thrown when "svaret är för stort."</exception>
        /// <exception cref="BadRequestException">Thrown when a malformed request is sent.</exception>
        /// <exception cref="UnauthorizedException">Thrown when "misslyckad autentisering."</exception>
        /// <exception cref="InternalServerErrorException">Thrown when "internt serverfel."</exception>
        /// <exception cref="NotImplementedException">Thrown when "servern stödjer inte en funktion som efterfrågades av klienten."</exception>
        /// <returns></returns>
        public TrainStation[] TrainStation(QueryBuilder queryBuilder) //These methods will provide a simple interface to request information from a single specified endpoint.
                                                                               //Only the inside of QUERY will be editable
        {
            if(Trafikverket.HttpClient.TrySend(out var response, out var exception, new HttpRequestMessage(HttpMethod.Post, "https://api.trafikinfo.trafikverket.se/v2/data.json")
            {
                Content = new StringContent($"<REQUEST>" +
                                            $"  <LOGIN authenticationkey= \"{Trafikverket.Key}\"/>" +
                                            $"  <QUERY objecttype=\"TrainStation\" schemaversion=\"1.4\" limit=\"2\">" +
                                            $"      <FILTER>" +
                                            $"          <EQ name=\"Advertised\" value=\"true\"/>" +
                                            $"      </FILTER>" +
                                            $"      <INCLUDE>AdvertisedLocationName</INCLUDE>" +
                                            $"  </QUERY>" +
                                            $"</REQUEST>")
            }))
            {
                if (exception != null)
                    throw exception;

                var obj = JsonConvert.DeserializeObject<TrafikverketResponse>(response.Content.ReadAsString());
                return (TrainStation[])obj.Response.Result[0].Type;
            }

            if (exception != null)
                throw exception;

            return null;
        }
    }
}
