# FleetAPI 
Dette er den vejledende løsning til opgaven om design og dokumentation af en RESTful API for en biludlejningsvirksomhed. Der er et forslag til, hvordan du kan strukturere løsningen, inklusive forklaringer på de valg, der er truffet:

## Krav
The requirements for your service are as follows:
1.	Insert a new car into the database.
2.	Delete a car from the database.
3.	View a list of rented cars.
4.	View a list of available cars.
5.	Mark a car as rented.
6.	Mark it as returned.
7.	It must not be possible to mark an unrented car as returned.


## 1. Identificer Objektmodellen
Først skal vi identificere de objekter, der er relevante for systemet. I dette tilfælde er det primære objekt en bil.

### Objektmodel:
```json
{
  "Car": {
    "id": "integer",
    "make": "string",
    "model": "string",
    "year": "integer",
    "status": "string" // "available" eller "rented"
  }
}
```

## 2. Opret Model URIs
Vi skal definere de URIs, der vil blive brugt til at interagere med bilressourcerne.

### URIs:
- **/cars**: Tilgår alle biler. URI'en bruges til at hente en liste af biler. Der kan sendes en filterparameter med, som angiver om det skal skal være 'rented' eller 'available' (krav 3 og 4). URI'en bruges også når der skal oprettes en ny bil (krav 1)
- **/cars/{id}**: Tilgår en specifik bil identificeret med id parameteren. URI'en bruges når en bil skal fjernes fra databasen (krav 2).
- **/cars/{id}/{available|rented}**: Markerer en bil som udlejet eller returneret (krav 5 og 6).


## 3. Bestem Repræsentationer
Repræsentationerne vil være i JSON-format, da det er et almindeligt anvendt format til RESTful APIs. Kravene peger ikke på nogen særlige egenskaber ved bilerne ud over om de er udlejet eller ej, så nedenstående er den simpleste model med egenskaber udvalgt udfra hvad vi tror er relevant for en lejer.

### Eksempel på JSON-repræsentation:
```json
{
  "id": 1,
  "make": "Toyota",
  "model": "Corolla",
  "year": 2020,
  "status": "available"
}
```

## 4. Tildel HTTP Metoder
Vi skal tildele de korrekte HTTP-metoder til hver URI for at sikre, at API'et følger REST-principperne.

### HTTP Metoder:
- **GET /cars?filter=[available|rented]**: Returnerer en liste over biler. Filter parameteren bestemmer om de er tilgængelige eller udlejet.
- **POST /cars**: Opretter en ny bil i databasen.
- **DELETE /cars/{id}**: Sletter en bil fra databasen.
- **PATCH /cars/{id}/{available|rented}**: Den eneste opdatering af data på en bil er om den er udlejet eller returneret. Requestets body indeholder data der indikerer om status skal ændres til "rented" eller "available".
