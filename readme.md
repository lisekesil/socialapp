# Welcome to Socialapp!

Projekt zaliczeniowy z przedmiotu - Programowanie w środowisku ASP.NET


# Instrukcja
1. W `appsettings.json ` podmieniamy `Connection` na swoją ścieżkę.
2. W konsoli menadżera pakietów uruchamiamy komendę `add-migration <nazwa>`
3. W konsoli menadżera pakietów uruchamiamy komendę `update-database -verbose`
4. Baza danych powinna zostać utworzona.

W aplikacji są już utworzone konta:

|                |Login|Hasło|
|----------------|-------------------------------|-----------------------------|
|Admin|admin            |Admin12#           |
|User|January            |@Qwerty123            |


wymagane biblioteki:
1. Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="5.0.0"
2. Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation" Version="5.0.13"
3. Microsoft.EntityFrameworkCore" Version="5.0.0"
4. Microsoft.EntityFrameworkCore.SqlServer" Version="5.0.0"
5. Microsoft.EntityFrameworkCore.Tools" Version="5.0.0"