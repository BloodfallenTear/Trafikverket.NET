using Newtonsoft.Json;
using System;

namespace TrafikverketSharp.Common
{
    /// <summary>
    /// Geometrisk information.
    /// </summary>
    public sealed class Gemoetry
    {
        /// <summary>
        /// Geometrisk punkt i koordinatsystem SWEREF99TM.
        /// </summary>
        [JsonProperty("SWEREF99TM")] public String SWEREF99TM { get; private set; }
        /// <summary>
        /// Geometrisk punkt i koordinatsystem WGS84.
        /// </summary>
        [JsonProperty("WGS84")] public String WGS84 { get; private set; }

        internal Gemoetry() { }
    }
}
