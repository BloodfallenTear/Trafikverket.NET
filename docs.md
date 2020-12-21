# W.I.P

## Landskod
Kod | Land
---:|:----
DE | Tyskland
DK | Danmark
NO | Norge
SE | Sverige

## Länsnummer
Nummer | Län
------:|:---
1 | Stockholms län
2 | DEPRECATED - Användes tidigare för Stockholms län
3 | Uppsala län
4 | Södermanlands län
5 | Östergötlands län
6 | Jönköpings län
7 | Kronobergs län
8 | Kalmar län
9 | Gotlands län
10 | Blekinge län
12 | Skåne län
13 | Hallands län
14 | Västra Götalands län
17 | Värmlands län
18 | Örebro län
19 | Västmanlands län
20 | Dalarnas län
21 | Gävleborgs län
22 | Västernorrlands län
23 | Jämtlands län
24 | Västerbottens län
25 | Norrbottens län

## Felmeddelanden
### Om något med anropet går fel så returneras någon av följande HTTP statuskoder: 
Kod | Meddelande
---:|:----------
206 | *Partial Content* - svaret är för stort. Maximalt tillåten datamängd kommer at returneras följt av ERROR som meddelar att svaret inte är komplett.
401 |	*Unauthorized* - misslyckad autentisering
500	| *Internal Server Error* - internt serverfel.
501	| *Not Implemented* - servern stödjer inte en funktion som efterfrågades av klienten.
