# Jogosítvány teszt webalkalmazás

Ez a projekt egy .NET WebAPI, SQLite, JQuery és Bootstrap alapú webalkalmazás, amely lehetővé teszi a jogosítványhoz szükséges jogszabályi ismeretek gyakorlását és ellenőrzését egy véletlenszerűen generált kvíz segítségével.

## Technológiák és eszközök
- .NET 9 WebAPI (Visual Studio Code környezetben)
- SQLite adatbázis
- JQuery (kliens oldali logika)
- Bootstrap (reszponzív felhasználói felület)
- HTML, CSS, JavaScript

##  Funkciói:
- Felhasználói regisztráció biztonságos jelszótárolással (hash + salt)
- Bejelentkezés és session-kezelés (cookie és adatbázis alapú)
- Kvíz indítása 10 véletlenszerű kérdéssel
- Kérdések kevert válaszlehetőségekkel és opcionális képekkel
- Kvíz eredmények mentése és megtekintése
- Korábbi kvízek áttekintése, részletezése
- Frontend többnyelvűséggel (EN/HU)

## Adatbázis szerkezet
Az adatbázis szerkezete a `schema.sql` fájlban található, amely létrehozza az alábbi főbb táblákat:
- `Pouzivatel` (felhasználók)
- `Session` (munkamenetek)
- `Otazka` (kérdések)
- `Odpoved` (válaszok)
- `Kviz` (kitöltött kvízek)
- `KvizOdpoved` (válaszlehetőségek rögzítése)

##  Felhasznált források
- Microsoft hivatalos dokumentáció: [.NET WebAPI](https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-9.0)
- SQLite használat C#-ban: [Microsoft.Data.Sqlite](https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/?tabs=netcore-cli)
- JQuery hivatalos weboldal: [https://jquery.com](https://jquery.com)
- Bootstrap dokumentáció: [https://getbootstrap.com](https://getbootstrap.com)
- Stack Overflow (általános hibakeresés, minták)


##  Feltöltési követelményeknek való megfelelés
-  `.NET WebAPI` alapú backend
-  SQLite alapú adatbázis
-  `schema.sql` mellékelve
-  Kliens: JQuery, Bootstrap
-  Teljes forrás `zip` formátumban
-  README és forráslista jelen dokumentumban

---

Készítette: Nagy András
Elkészítés ideje: 2025.5.30  
Tantárgy: Adatbázis alkalmazások
"# autosuli134243" 
