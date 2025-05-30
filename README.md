# Jogosítvány teszt webalkalmazás

Ez a projekt egy .NET WebAPI, SQLite, JQuery és Bootstrap alapú webalkalmazás, amely lehetővé teszi a jogosítványhoz szükséges jogszabályi ismeretek gyakorlását és ellenőrzését egy véletlenszerűen generált kvíz segítségével.

## Technológiák és eszközök
- .NET 9 WebAPI (Visual Studio Code környezetben)
- SQLite adatbázis
- JQuery (kliens oldali logika)
- Bootstrap (reszponzív felhasználói felület)
- HTML, CSS, JavaScript
- JSON-alapú adatimport kérdésekhez és válaszokhoz
- AI-támogatás a forráskód strukturálásához és hibakereséshez (OpenAI ChatGPT)

## Funkciók
- Felhasználói regisztráció biztonságos jelszótárolással (hash + salt)
- Bejelentkezés és session-kezelés (cookie és adatbázis alapú)
- Kvíz indítása 10 véletlenszerű kérdéssel
- Kérdések kevert válaszlehetőségekkel és opcionális képekkel
- Kvíz eredmények mentése és megtekintése
- Korábbi kvízek áttekintése, részletezése
- Frontend többnyelvűséggel (magyar és angol nyelv támogatása)
- Kérdés/válasz importálás JSON fájlokból (`questions.json`, `answers.json`)
- Konzolos logolás importáláskor a beolvasott adatok ellenőrzéséhez

## Adatbázis szerkezet
Az adatbázis szerkezete a `schema.sql` fájlban található, amely létrehozza az alábbi főbb táblákat:
- `Pouzivatel` – felhasználók (név, e-mail, jelszó)
- `Session` – munkamenetek (cookie azonosító + kapcsolódás a felhasználóhoz)
- `Otazka` – kérdések (szöveg + opcionális kép)
- `Odpoved` – válaszok (egy adott kérdéshez tartozó lehetőségek, igaz/hamis megjelöléssel)
- `Kviz` – egy kitöltött kvíz metaadatai (felhasználó és időpont)
- `KvizOdpoved` – konkrét kérdésre adott válasz mentése
- `Obrazok` – képfájlok hozzárendelése kérdésekhez

## Adatok betöltése
A `Program.cs` induláskor automatikusan meghívja a `Databaza.ImportFromJson("questions.json", "answers.json")` metódust, amely:
- törli és újratölti a `Otazka`, `Odpoved`, `Obrazok` táblák tartalmát
- minden importált kérdést, választ, képet részletesen naplóz a konzolra

## Felhasznált források
A projekt során az alábbi forrásokat használtam fel:

### Hivatalos dokumentációk
- [.NET WebAPI](https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-9.0) – backend keretrendszer
- [Microsoft.Data.Sqlite](https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/?tabs=netcore-cli) – adatbázis-kezelés C#-ban
- [JQuery](https://jquery.com) – kliensoldali dinamikus adatkezelés
- [Bootstrap](https://getbootstrap.com) – UI keretrendszer

### Kódminták és megoldások
- Stack Overflow – adatbázis műveletek, session-kezelés, JSON deszerializálás
- Github példaprojektek – inspiration for RESTful architecture
- ChatGPT (OpenAI) – segítség a hibaelhárításban, optimalizálásban, README struktúra kialakításában

### Képek és kérdésforrás
- Tesztelési célból használt kérdések és képek nem hivatalos forrásból származnak, oktatási célra generálva
- JSON fájlokat (questions.json, answers.json) manuálisan és AI segítségével állítottam össze

## Telepítés és futtatás
1. Telepítsd a .NET SDK 9-et és a Visual Studio Code-ot
2. Töltsd le vagy klónozd a repót:
   ```bash
   git clone https://github.com/03Andras/vodicak-quiz.git
   cd vodicak-quiz
