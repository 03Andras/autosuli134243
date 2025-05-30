# Jogosítvány Teszt Webalkalmazás

Ez a projekt egy interaktív webes kvízrendszer, amely a közlekedési szabályok gyakorlását segíti. A rendszer .NET WebAPI technológiára, SQLite adatbázisra, és Bootstrap + JQuery alapú reszponzív felületre épül. A kérdések és válaszok JSON fájlokból kerülnek importálásra, így a tartalom könnyen bővíthető.

---

## Technológiák és eszközök

- **Backend:** .NET 9 WebAPI (Visual Studio Code környezetben)
- **Adatbázis:** SQLite (fájlalapú, schema.sql alapján inicializálva)
- **Frontend:** HTML, CSS, Bootstrap 5, JQuery
- **Adatformátum:** JSON (kérdés-válasz import/export)
---

##  Főbb Funkciók

-  **Felhasználói kezelés**
  - Regisztráció (név, email, jelszó – SHA256 + salt)
  - Bejelentkezés és munkamenet-kezelés (session cookie)
  - Kijelentkezés és session törlés

-  **Kvízrendszer**
  - 10 véletlenszerű kérdés minden indításkor
  - Válaszlehetőségek keverése
  - Képes kérdések támogatása (opcionális képfájl)
  - Kérdésenként 1 válasz (radio gomb)

-  **Eredmények**
  - Kvíz eredmény mentése (dátum, pontszám)
  - Korábbi kvízek listázása
  - Részletes kvízmegtekintés

-  **Többnyelvű támogatás**
  - Magyar és angol felhasználói felület nyelvváltással

-  **Importálás JSON-ból**
  - `questions.json` – kérdésszövegek, válaszok, képfájlnevek
  - `answers.json` – helyes válaszok betűjelei
  - Import futtatás `Program.cs`-en belül induláskor

---

##  Adatbázis Szerkezet (schema.sql alapján)

| Tábla | Leírás |
|-------|--------|
| `Pouzivatel` | Felhasználók adatai |
| `Session` | Munkamenet-azonosítók |
| `Otazka` | Kérdések |
| `Odpoved` | Válaszopciók (kérdéshez kötve, igaz/hamis jelzéssel) |
| `Obrazok` | Kérdéshez tartozó képek útvonala |
| `Kviz` | Kitöltött kvíz adatai (felhasználó, időpont) |
| `KvizOdpoved` | Kérdésenként adott válasz (egy kvízhez kapcsolva) |

---

## Importálási Művelet

A `Program.cs` induláskor automatikusan végrehajtja az alábbiakat:

1. **Adatbázis újragenerálása** a `schema.sql` alapján (korábbi tartalom törlése)
2. **Kérdések és válaszok importálása**:
   - Betölti a `questions.json` és `answers.json` fájlokat
   - Beszúrja a kérdéseket (`Otazka`)
   - Beszúrja a válaszokat (`Odpoved`)
   - Kezeli a képfájlokat (`Obrazok`), figyelembe véve a hiányzó fájlokat (vannak képek az adatbázisban, amihez nincs fájl)

---

##  Képek kezelése
- A `kviz.html` fájl automatikusan megjeleníti a képet, ha az elérhető
- Ha egy kép nem található a fájlrendszerben, helyette figyelmeztető szöveg jelenik meg:  
  _"Ez a kérdés képhez tartozik, de a fájl hiányzik a rendszerből."_

---

##  Projekt felépítése

```
autosuli134243-main/
├── Controllers/
│   └── KvizController.cs
│   └── PouzivatelController.cs
├── wwwroot/
│   └── img/     <- ide kerülnek a képek
│   └── kviz.html
│   └── dashboard.html
├── Databaza.cs
├── Program.cs
├── schema.sql
├── questions.json
├── answers.json
```

---

## Felhasznált irodalom / források:

- [Microsoft.Data.Sqlite példa](https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/)
- [ASP.NET Core Web API példák](https://learn.microsoft.com/en-us/aspnet/core/web-api/)
- [GitHub – Simple Quiz API C#](https://github.com/dotnet/samples)
- [JQuery dokumentáció](https://jquery.com/)
- [Bootstrap 5](https://getbootstrap.com/)
- Fejlesztés támogatás: ChatGPT – kódszervezéshez és hibakereséshez használt segítség
