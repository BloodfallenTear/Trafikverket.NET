using Newtonsoft.Json;
using System;
using TrafikverketSharp.Common;

namespace TrafikverketSharp
{
    /// <summary>
    /// Trafikplatser, både med och utan resandeutbyte.
    /// </summary>
    public sealed class TrainStation : TrafikverketResponseResultType
    {
        /// <summary>
        /// Anger om stationen annonseras i tidtabell.
        /// </summary>
        [JsonProperty("Advertised")] public Boolean Advertised { get; internal set; }
        /// <summary>
        /// Stationens namn.
        /// </summary>
        [JsonProperty("AdvertisedLocationName")] public String AdvertisedLocationName { get; internal set; }
        /// <summary>
        /// Stationens namn i kort version.
        /// </summary>
        [JsonProperty("AdvertisedShortLocationName")] public String AdvertisedShortLocationName { get; internal set; }
        /// <summary>
        /// Beteckning för i vilket land stationen finns. <see href="https://github.com/BloodfallenTear/TrafikverketSharp/blob/2.0.0/docs.md#landskod">Docs.md</see>
        /// </summary>
        [JsonProperty("CountryCode")] public CountryCode CountryCode { get; internal set; }
        /// <summary>
        /// Länsnummer. <see href="https://github.com/BloodfallenTear/TrafikverketSharp/blob/2.0.0/docs.md#länsnummer">Docs.md</see>
        /// </summary>
        [JsonProperty("CountyNo")] public Byte[] CountyNo { get; internal set; }
        /// <summary>
        /// Anger att dataposten raderats.
        /// </summary>
        [JsonProperty("Deleted")] public Boolean Deleted { get; internal set; }
        /// <summary>
        /// Geometrisk information.
        /// </summary>
        [JsonProperty("Geometry")] public Gemoetry Gemoetry { get; internal set; }
        /// <summary>
        /// Upplysningsinformation för stationen, ex. "SL-tåg omfattas ej.", "Ring 033-172444 för trafikinformation".
        /// </summary>
        [JsonProperty("LocationInformationText")] public String LocationInformationText { get; internal set; }
        /// <summary>
        /// Stationens unika signatur, ex. "Cst".
        /// </summary>
        [JsonProperty("LocationSignature")] public String LocationSignature { get; internal set; }
        /// <summary>
        /// Tidpunkt då dataposten ändrades.
        /// </summary>
        [JsonProperty("ModifiedTime")] public DateTime ModifiedTime { get; internal set; }
        /// <summary>
        /// Det av Transportstyrelsen fastslagna officiella namnet på stationen.
        /// </summary>
        [JsonProperty("OfficialLocationName")] public String OfficialLocationName { get; internal set; }
        /// <summary>
        /// Plattformens spår.
        /// </summary>
        [JsonProperty("PlatformLine")] public String[] PlatformLine { get; internal set; }
        /// <summary>
        /// Anger om stationen prognostiseras i tidtabell.
        /// </summary>
        [JsonProperty("Prognosticated")] public Boolean Prognosticated { get; internal set; }

        internal TrainStation() { }
    }
}
