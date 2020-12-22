using System;

namespace TrafikverketSharp
{
    public sealed class RequestBuilder : BaseRequestBuilder<RequestBuilder>
    {
        public Query Query { get; set; }
        public Filter Filter { get; set; }

        public override RequestBuilder Build()
        {
            var request = $"<REQUEST></REQUEST>";

            throw new NotImplementedException();
        }
    }

    public sealed class Query
    {
        /// <summary>
        /// Anger datatypen som efterfrågas.
        /// </summary>
        public String ObjectType { get; set; }
        /// <summary>
        /// Anger schemaversion för den datatyp som efterfrågas.
        /// </summary>
        public String SchemaVersion { get; set; }
        /// <summary>
        /// Kan innehålla ett av användaren godtyckligt värde som också returneras i svaret. 
        /// Om anropet innehåller flera frågor kan id-attributet användas för att veta vilket svar som hör ihop med vilken fråga.
        /// </summary>
        public String ID { get; set; }
        /// <summary>
        /// Borttagna dataposter returneras om satt till <see langword="true"/>.
        /// </summary>
        public Boolean IncludeDeletedObjects { get; set; }
        /// <summary>
        /// Begränsar antalet dataposter i svaret.
        /// </summary>
        public UInt32 Limit { get; set; }
        /// <summary>
        /// anger på vilket eller vilka datafält sortering skall göras. 
        /// Sorteringsordning anges med asc (ascending) eller desc (descending) efter datafältet (asc är default). <para/>
        /// Flera datafält separeras med komma-tecken. Exempel: <c>"SomeData.Name desc, SomeData.Description"</c>
        /// </summary>
        public String OrderBy { get; set; }
        /// <summary>
        /// Hoppar över ett visst antal dataposter i svaret (endast praktiskt användbart på statiskt data). Kan t.ex. användas vid paginering.
        /// </summary>
        public UInt32 Skip { get;set; }
        /// <summary>
        /// Returnerar tidpunkten för senast uppdaterade (ModifiedTime) datapost från returnerat dataset om satt till <see langword="true"/>.
        /// </summary>
        public Boolean LastModified { get; set; }
        /// <summary>
        /// Anger att man vill ha förändringar efter angivet unika löpnummer. Resultatet innehåller även största löpnummret i returnerat data. 
        /// </summary>
        public String ChangeID { get; set; }

        public Query() { }
    }

    public sealed class Filter
    {


        public Filter() { }
    }
}
