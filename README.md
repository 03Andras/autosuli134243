
# Jogosítvány Teszt Webalkalmazás

Ez a projekt egy interaktív webes kvízrendszer, amely a közlekedési szabályok gyakorlását segíti. A rendszer .NET WebAPI technológiára, SQLite adatbázisra, és Bootstrap + JQuery alapú reszponzív felületre épül. A kérdések és válaszok JSON fájlokból kerülnek importálásra, így a tartalom könnyen bővíthető.

## Technológiák és eszközök

- **Backend:** .NET 9 WebAPI (Visual Studio Code környezetben)
- **Adatbázis:** SQLite (fájlalapú, schema.sql alapján inicializálva)
- **Frontend:** HTML, CSS, Bootstrap 5, JQuery
- **Adatformátum:** JSON (kérdés-válasz import/export)

## Főbb Funkciók

### Felhasználói kezelés

- Regisztráció (név, email, jelszó – SHA256 + salt)
- Bejelentkezés és munkamenet-kezelés (session cookie)
- Kijelentkezés és session törlés

### Kvízrendszer

- 10 véletlenszerű kérdés minden indításkor
- Válaszlehetőségek keverése
- Képes kérdések támogatása (opcionális képfájl)
- Kérdésenként 1 válasz (radio gomb)

### Eredmények

- Kvíz eredmény mentése (dátum, pontszám)
- Korábbi kvízek listázása
- Részletes kvízmegtekintés

### Többnyelvű támogatás

- Magyar és angol felhasználói felület nyelvváltással

### Importálás JSON-ból

- `questions.json` – kérdésszövegek, válaszok, képfájlnevek
- `answers.json` – helyes válaszok betűjelei
- Import futtatás `Program.cs`-en belül induláskor

## Adatbázis szerkezet (schema.sql alapján)

| Tábla | Leírás |
|-------|--------|
| `Pouzivatel` | Felhasználók adatai |
| `Session` | Munkamenet-azonosítók |
| `Otazka` | Kérdések |
| `Odpoved` | Válaszopciók (kérdéshez kötve, igaz/hamis jelzéssel) |
| `Obrazok` | Kérdéshez tartozó képek útvonala |
| `Kviz` | Kitöltött kvíz adatai (felhasználó, időpont) |
| `KvizOdpoved` | Kérdésenként adott válasz (egy kvízhez kapcsolva) |

## Importálási Művelet

A `Program.cs` induláskor automatikusan végrehajtja az alábbiakat:

1. **Adatbázis újragenerálása** a `schema.sql` alapján (korábbi tartalom törlése)
2. **Kérdések és válaszok importálása**:
   - Betölti a `questions.json` és `answers.json` fájlokat
   - Beszúrja a kérdéseket (`Otazka`)
   - Beszúrja a válaszokat (`Odpoved`)
   - Kezeli a képfájlokat (`Obrazok`), figyelembe véve a hiányzó fájlokat

## Képek kezelése

- A `kviz.html` automatikusan megjeleníti a képet, ha az elérhető
- Ha a kép nem található a fájlrendszerben, figyelmeztető szöveg jelenik meg

## Projekt Felépítése

```
autosuli134243-main/
├── Controllers/
│   └── KvizController.cs
│   └── PouzivatelController.cs
├── wwwroot/
│   └── img/
│   └── kviz.html
│   └── index.html
│   └── dashboard.html
│   └── kviz_detail.html
│   └── login.html
│   └── logout.html
│   └── signup.html
├── Databaza.cs
├── Program.cs
├── schema.sql
├── questions.json
├── answers.json
```

## Kódforrások és Inspiráció

- [Microsoft.Data.Sqlite dokumentáció](https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/)
- [ASP.NET Core Web API](https://learn.microsoft.com/en-us/aspnet/core/web-api/)
- [JQuery](https://jquery.com/)
- [Bootstrap 5](https://getbootstrap.com/)
- [GitHub – Simple Quiz API C#](https://github.com/dotnet/samples)
- [System.Text.Json példák](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-how-to)
- [CodeMaze – JSON feldolgozás C#-ban](https://code-maze.com/csharp-json-serialization/)
- Kérdések, képek forrása: https://cloud.ujs.sk/index.php/s/MG0fXgaXEYTH6VU
- Kódszervezéshez és hibakereséshez segítségül használtam AI-t konkrétan az OpenAI által fejlesztett ChatGPT modelljét.

## Hitelesítés és Biztonság

A jelszavakat SHA-256 algoritmussal és egyedi sóval hash-eljük. A session cookie UUID alapú azonosítót használ. A session-ök az adatbázisban tárolódnak, kijelentkezéskor törlődnek.

## Kvízlogika

A rendszer véletlenszerűen választ 10 kérdést, keveri a válaszokat, képeket társít ha van, majd elmenti a válaszokat és értékeli az eredményt.

## Beadandó követelmények – Összefoglaló

A projekt a Selye János Egyetem Adatbázis Alkalmazások kurzus "Kombinált beadandó" feladatának követelményei alapján lett elkészítve:

- Véletlenszerű 10 kérdéses kvíz
- Több válaszlehetőség kérdésenként
- Képes kérdések támogatása
- Regisztráció, bejelentkezés, munkamenet-kezelés
- Kvíz eredmények rögzítése, megtekintése
- JSON-ból történő kérdésimport
- Felhasználókezelés: SHA256+salt jelszóvédelem, session cookie, munkamenet azonosító
- Teljes adatbázis struktúra (User, Question, Answer, Quiz, stb.)
- .NET WebAPI + JQuery + Bootstrap + SQLite

A teljes kiírás elérhető: https://melytanulas.cc/DBAppHw/DBAppHw202425.html


Készítette:
Nagy András 2025.05.30
134243
