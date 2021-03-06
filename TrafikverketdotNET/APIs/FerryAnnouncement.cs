﻿using System;
using TrafikverketdotNET.Subs;
using TrafikverketdotNET.Subs.FerryAnnouncementResponse;
using Newtonsoft.Json;

namespace TrafikverketdotNET
{ 
    public sealed class FerryAnnouncementResponse : BaseTrafikverketResponse
    {
        [JsonProperty("FerryAnnouncement")] internal FerryAnnouncementData[] _Data { get; set; }
        [JsonProperty("INFO")] internal Info _Info { get; set; }

        [JsonIgnore] public FerryAnnouncementData[] Data => _Data;
        [JsonIgnore] public Info Info => _Info;

        internal FerryAnnouncementResponse() { }
    }

    public sealed class FerryAnnouncementData
    {
        [JsonProperty("Deleted")] internal Boolean _Deleted { get; set; }
        [JsonProperty("DepartureTime")] internal DateTime _DepartureTime { get; set; }
        [JsonProperty("DeviationId")] internal String _DeviationId { get; set; }
        [JsonProperty("FromHarbor")] internal FromHarbor _FromHarbor { get; set; }
        [JsonProperty("Id")] internal Int64 _Id { get; set; }
        [JsonProperty("Info")] internal String[] _Info { get; set; }
        [JsonProperty("ModifiedTime")] internal DateTime _ModifiedTime { get; set; }
        [JsonProperty("Route")] internal Route _Route { get; set; }
        [JsonProperty("ToHarbor")] internal ToHarbor _ToHarbor { get; set; }

        /// <summary>
        /// Anger att dataposten raderats.
        /// </summary>
        [JsonIgnore] public Boolean Deleted => _Deleted;
        /// <summary>
        /// Avgångstid.
        /// </summary>
        [JsonIgnore] public DateTime DepartureTime => _DepartureTime;
        /// <summary>
        /// Referens till Deviation.Id i objektet Situation.
        /// </summary>
        [JsonIgnore] public String DeviationId => _DeviationId;
        [JsonIgnore] public FromHarbor FromHarbor => _FromHarbor;
        /// <summary>
        /// Avgångens id. Fältet är nyckel för objektet.
        /// </summary>
        [JsonIgnore] public Int64 Id => _Id;
        /// <summary>
        /// Information om avgången.
        /// </summary>
        [JsonIgnore] public String[] Info => _Info;
        /// <summary>
        /// Tidpunkt då dataposten ändrades
        /// </summary>
        [JsonIgnore] public DateTime ModifiedTime => _ModifiedTime;
        [JsonIgnore] public Route Route => _Route;
        [JsonIgnore] public ToHarbor ToHarbor => _ToHarbor;

        internal FerryAnnouncementData() { }
    }

    public sealed class FerryAnnouncementRequest : BaseTrafikverketRequest
    {
        public override ObjectType ObjectType => ObjectType.FerryAnnouncement;
        public override string SchemaVersion => Trafikverket.SchemaVersions[this.ObjectType];

        public FerryAnnouncementRequest(Filter Filter) : base(Filter) { }
        public FerryAnnouncementRequest(String ID = null, Boolean IncludeDeletedObjects = false,
                                        UInt32 Limit = 0, String OrderBy = null, UInt32 Skip = 0,
                                        Boolean LastModified = false, Int32 ChangeID = 0, Boolean SSEURL = false,
                                        String[] Include = null, String[] Exclude = null, String Distinct = null, Filter Filter = null) : base(ID, IncludeDeletedObjects,
                                                                                                                                               Limit, OrderBy, Skip, LastModified,
                                                                                                                                               ChangeID, SSEURL, Include, Exclude, Distinct, Filter) { }
    }

    /// <summary>
    /// Ankomster och avgångar.
    /// </summary>
    public sealed class FerryAnnouncement : BaseTrafikverket<FerryAnnouncementResponse, FerryAnnouncementRequest>
    {
        /// <summary>
        /// Ankomster och avgångar.
        /// </summary>
        /// <param name="APIKey">Användarens unika nyckel.</param>
        /// <exception cref="TrafikverketException">Thrown when there's an error returned from Trafikverket.</exception>
        public FerryAnnouncement(String APIKey) : base(APIKey) { }

        internal override ObjectType ObjectType => ObjectType.FerryAnnouncement;
        /// <summary>
        /// SchemaVersion versionen som biblioteken använder.
        /// </summary>
        public override String CurrentSchemaVersion => Trafikverket.SchemaVersions[this.ObjectType];

        /// <exception cref="TrafikverketException">Thrown when there's an error returned from Trafikverket.</exception>
        public override FerryAnnouncementResponse ExecuteRequest() => base.ExecuteRequest("FerryAnnouncement", CurrentSchemaVersion);
        /// <param name="XMLRequest">Custom requests must be written in XML, check "https://api.trafikinfo.trafikverket.se/API/TheRequest" in order to create custom requests.</param>
        /// <exception cref="TrafikverketException">Thrown when there's an error returned from Trafikverket.</exception>
        public override FerryAnnouncementResponse ExecuteRequest(String XMLRequest) => base.ExecuteRequest("FerryAnnouncement", CurrentSchemaVersion, XMLRequest);
        /// <exception cref="TrafikverketException">Thrown when there's an error returned from Trafikverket.</exception>
        public override FerryAnnouncementResponse ExecuteRequest(FerryAnnouncementRequest Request) => base.ExecuteCustomRequest(Request);
    }
}
