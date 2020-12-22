# NOTE: README.md is W.I.P

# TrafikverketSharp v2.0.0
A C# .NET Standard library for Trafikverket. This is **not** an official Trafikverket library.

## Documentation
All of the documentation found in this library comes from [Trafikverket](https://api.trafikinfo.trafikverket.se/).

## Support
This project supports .NET Standard 2.0!

## Usage
### How to create a basic, unfiltered TrainStation request:
```csharp
NULL
```
Example Ouput: NULL

### How to create a more advanced, unfiltered TrainAnnouncement request (this way, you can create multiple queries instead of being restricted to only one like above):
```csharp
NULL
```
Example Ouput: NULL

### How to create a more advanced, filtered TrainMessage request:
```csharp
NULL
```
Example Ouput: NULL

## Changelog 
For every release, you can find the changelog to see what has changed from the previous release to that one under the said release. If a release contains nothing but the 'Included APIs' tab, that means nothing that should concern the user has been changed and a few APIs have been added. If you still are curious for all the things which have been changed from version x to version y, you can check out the commit history since I try to document everything I do there.

## Dependencies
This project uses the following dependencies: 
 - [Newtonsoft.Json (12.0.2)](https://www.newtonsoft.com/) by [JamesNK](https://github.com/JamesNK), NuGet Link: [Newtonsoft.Json (12.0.2)](https://www.nuget.org/packages/Newtonsoft.Json/12.0.2/).

## API Implementation List (For more detailed progress head to [Projects](https://github.com/BloodfallenTear/Trafikverket.NET/projects/1)):
- [ ] RailCrossing 1.5 - Information om plankorsningar, varje post representerar en plankorsning.
För riktningsberoende företeelser anges höger och vänster med att stå i riktning vänd mot stigande km-tal.
- [ ] ReasonCode 1 - Orsakskoder, varje post representerar en orsakskod.
- [ ] TrainAnnouncement 1.6 - Tidtabellsinformation, d.v.s information om tåg på trafikplatser (stationer, hållplatser) varje post motsvarar ett visst tåg vid respektive trafikplats.
- [ ] TrainMessage 1.6 - Tågtrafikmeddelande, exempelvis information kring banarbete, tågfel, anläggningsfel och dylikt.
- [ ] TrainStation 1.4 - Trafikplatser, både med och utan resandeutbyte.
- [ ] Camera 1 - Kameror för automatisk väglag och trafikflöde.
- [ ] FerryAnnouncement 1.2 - Ankomster och avgångar.
- [ ] FerryRoute 1.2 - Information om färjeleder.
- [ ] Icon 1 - Ikoner, exempelvis för använding i grafiska användargränssnitt och kartor.
- [ ] Parking 1.4 - Information om rastplatser och parkeringar.
- [ ] RoadCondition 1.2 - Information om väglag.
- [ ] RoadConditionOverview 1 - Väglagsöversikter.
- [ ] Situation 1.5 - Situationer innehållandes händelser och störningar som trafikmeddelanden, vägarbeten, olyckor, restiktioner m.m.
- [ ] TrafficFlow 1.4 - Uppmätta eller härledda värden relaterat till trafik eller enskilda fordonets rörelser på en viss sektion eller vid en specifik punkt på vägnätet.
- [ ] TrafficSafetyCamera 1 - Trafiksäkerhetskameror.
- [ ] TravelTimeRoute 1.5 - Restider i större städer eller i högbelastade trafiksystem. Beräkning av restid baseras på data från detektorer som är utplacerade längs bestämda rutter.
- [ ] WeatherMeasurepoint 1 - Mätpunkter för vägväderobservationer.
- [ ] WeatherObservation 1 - Väderinformation på ett normativt sätt. Datamängden innehåller samtliga observationer 7 dagar tillbaka. Mättekniskt så levererar inte all sensorer exakt lika mätvärde trots att mätspecikationen kan vara densamma. Ur vägvädersynvinkel så kan det dock vara ett mätvärde som är representativt för tidpunkt och mätpunkt, exempelvis en yttemperatur och en lufttemperatur, dessa är då normativa.
- [ ] WeatherStation 1 - Väderstationer med mätdata.
- [ ] MeasurementData100 1 - Mätdata per 100 meter. Ett medelvärde har räknats fram för 100 meter baserat på de ingående 20-metersvärdena (se mer info i MeasurementData20). Observera att det inte finns 100-metersdata för alla våra 20-metersvariabler. Källsystem är PMS-systemen.
- [ ] MeasurementData20 1 - Mätdata per 20 meter. Data från vägytemätningar med laserscanning alternativt som beräknats fram baserat på dem. Mätningarna utförs årligen eller vartannat år beroende på trafikmängd. Senast gällande mätdata finns att hämta dvs ej historik. Källsystem är PMS-systemen.
- [ ] PavementData 1 - Beläggningsdata från PMS-systemen kombinerat med relevant vägdata från NVDB. Vi kan ej garantera att det är helt aktuellt data från NVDB. Datum för när data hämtades framgår av posten TimeStamp. För att se källa för respektive data, gå till fliken Om variabler i systemet PMSV3.
- [ ] RoadData 1 - Vägdata från NVDB som är relevant tillsammans med PMS-systemens beläggnings och mätdata. Vi kan ej garantera att det är dagsaktuell data från NVDB. Datum för när data hämtades framgår av posten TimeStamp. För att se källa för respektive data, gå till fliken Om variabler i systemet PMSV3.
- [ ] RoadGeometry 1 - Vägens geometri relaterat till det data vi tillhandahåller från PMS-systemen med data om beläggningar och mätdata. Vi kan ej garantera att geometrin är dagsaktuell från NVDB. Datum för när data hämtades framgår av posten TimeStamp. 

## License
This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/BloodfallenTear/TrafikverketSharp/blob/master/LICENSE.md) file for details. © BloodfallenTear 2020
