# NOTE: README.md is W.I.P

# TrafikverketSharp v2.0.0
A C# .NET Standard library for Trafikverket. This is **not** an official Trafikverket library.

## Documentation
All of the XML documentation found in this API library comes from [Trafikverket](https://api.trafikinfo.trafikverket.se/API/Model).

## Support
This project supports .NET Standard 2.1!

## NuGet
Download the library via [NuGet](https://www.nuget.org/packages/Trafikverket.NET/)!
>`Install-Package Trafikverket.NET`

## Usage
### How to create a basic, unfiltered TrainStation request:
```csharp
Trafikverket Trafikverket = new Trafikverket("Your-Key-Here");
TrainStationResponse TrainStationResponse = Trafikverket.TrainStation.ExecuteRequest();
Console.WriteLine(String.Join(",\r\n", TrainStationResponse.Data.Select(h => h.AdvertisedLocationName)));
```
Example Ouput: Abborrträsk, Almnäs, Astrid Lindgrens värld, Almedal, *[...]*

### How to create a more advanced, unfiltered TrainAnnouncement request (this way, you can create multiple queries instead of being restricted to only one like above):
```csharp
TrafikverketResponse TrafikverketResponse = Trafikverket.ExecuteRequest(new TrafikverketRequest(new Query(ObjectType.TrainAnnouncement, "1")));
Console.WriteLine(String.Join(",\r\n", TrafikverketResponse.TrainAnnouncementResponse[0].Data.Select(x => x.LocationSignature)));
```
Example Ouput: Hel, Sod, Sol, Sci, *[...]*

### How to create a more advanced, filtered TrainMessage request:
```csharp
Filter Filter = new Filter();
Filter.AddOperator(new FilterOperator(FilterOperatorType.EQ, "AffectedLocation", "Cst"));

Query Query = new Query(ObjectType.TrainMessage, Trafikverket.SchemaVersions[ObjectType.TrainMessage]);
Query.SetFilter(Filter);

TrafikverketResponse TrafikverketResponse = Trafikverket.ExecuteRequest(new TrafikverketRequest(Query));
Console.WriteLine(String.Join(",\r\n", TrafikverketResponse.TrainMessageResponse[0].Data.Select(x => x.Header)));
```
Example Ouput: Banarbete, Banarbete, Signalfel, Banarbete, *[...]*

### SchemaVersions Dictionary
To get which Schema Version the library supports, you can access a dictionary located in the 'Trafikverket' class.
Warning: Whichever 'CurrentSchemaVersion' version it's set to, does not mean that it's backwards compatible with previous versions, e.g if 'CurrentSchemaVersion' is "1.5", it does not support all the previous versions, you have to use version "1.5" specifically.
Example: `String SchemaVersion = Trafikverket.SchemaVersions[ObjectType.TrainStation];`

## Changelog 
For every release, you can find the changelog to see what has changed from the previous release to that one under the said release. If a release contains nothing but the 'Included APIs' tab, that means nothing that should concern the user has been changed and a few APIs have been added. If you still are curious for all the things which have been changed from version x to version y, you can check out the commit history since I try to document everything I do there.

## Dependencies
This project uses the following dependencies: 
1. [Newtonsoft.Json (12.0.2)](https://www.newtonsoft.com/) by [JamesNK](https://github.com/JamesNK), NuGet Link: [Newtonsoft.Json (12.0.2)](https://www.nuget.org/packages/Newtonsoft.Json/12.0.2/).
2. [System.Net.Http (4.3.4)](https://www.nuget.org/packages/System.Net.Http/) by Microsoft, NuGet Link: [System.Net.Http (4.3.4)](https://www.nuget.org/packages/System.Net.Http/), (.NET Framework 4.5, .NET Framework 4.6, .NET Framework 4.7 only). 

## API Implementation List (For more detailed progress head to [Projects](https://github.com/BloodfallenTear/Trafikverket.NET/projects/1)):
- [x] TrainAnnouncement 1.5 - Tidtabellsinformation, d.v.s information om tåg på trafikplatser (stationer, hållplatser) varje post motsvarar ett visst tåg vid respektive trafikplats.
- [x] TrainMessage 1.4 - Tågtrafikmeddelande, exempelvis information kring banarbete, tågfel, anläggningsfel och dylikt.
- [x] TrainStation 1 - Trafikplatser, både med och utan resandeutbyte.
- [x] Camera 1 - Kameror för automatisk väglag och trafikflöde.
- [x] FerryAnnouncement 1.2 - Ankomster och avgångar.
- [x] FerryRoute 1.2 - Information om färjeleder.
- [x] Icon 1 - Ikoner, exempelvis för använding i grafiska användargränssnitt och kartor.
- [x] Parking 1 - Information om rastplatser och parkeringar.
- [x] RoadCondition 1.2 - Information om väglag.
- [x] RoadConditionOverview 1 - Väglagsöversikter.
- [x] Situation 1.2 - Situationer innehållandes händelser och störningar som trafikmeddelanden, vägarbeten, olyckor, restiktioner m.m.
- [x] TrafficFlow 1 - Uppmätta eller härledda värden relaterat till trafik eller enskilda fordonets rörelser på en viss sektion eller vid en specifik punkt på vägnätet.
- [x] TrafficSafetyCamera 1 - Trafiksäkerhetskameror.
- [x] TravelTimeRoute 1.4 - Restider i större städer eller i högbelastade trafiksystem. Beräkning av restid baseras på data från detektorer som är utplacerade längs bestämda rutter.
- [x] WeatherStation 1 - Väderstationer med mätdata.
- [x] MeasurementData100 1 - Mätdata per 100 meter. Ett medelvärde har räknats fram för 100 meter baserat på de ingående 20-metersvärdena (se mer info i MeasurementData20). Observera att det inte finns 100-metersdata för alla våra 20-metersvariabler. Källsystem är PMS-systemen.
- [x] MeasurementData20 1 - Mätdata per 20 meter. Data från vägytemätningar med laserscanning alternativt som beräknats fram baserat på dem. Mätningarna utförs årligen eller vartannat år beroende på trafikmängd. Senast gällande mätdata finns att hämta dvs ej historik. Källsystem är PMS-systemen.
- [x] PavementData 1 - Beläggningsdata från PMS-systemen kombinerat med relevant vägdata från NVDB. Vi kan ej garantera att det är helt aktuellt data från NVDB. Datum för när data hämtades framgår av posten TimeStamp. För att se källa för respektive data, gå till fliken Om variabler i systemet PMSV3.
- [x] RoadData 1 - Vägdata från NVDB som är relevant tillsammans med PMS-systemens beläggnings och mätdata. Vi kan ej garantera att det är dagsaktuell data från NVDB. Datum för när data hämtades framgår av posten TimeStamp. För att se källa för respektive data, gå till fliken Om variabler i systemet PMSV3.
- [x] RoadGeometry 1 - Vägens geometri relaterat till det data vi tillhandahåller från PMS-systemen med data om beläggningar och mätdata. Vi kan ej garantera att geometrin är dagsaktuell från NVDB. Datum för när data hämtades framgår av posten TimeStamp. 

## Code of Conduct
This repository's Code of Conduct can be found here: [CODE_OF_CONDUCT.md](https://github.com/BloodfallenTear/TrafikverketSharp/blob/master/CODE_OF_CONDUCT.md)

## License
This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/BloodfallenTear/TrafikverketSharp/blob/master/LICENSE.md) file for details. © BloodfallenTear 2020
