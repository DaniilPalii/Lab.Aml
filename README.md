# Opis

Lab.Aml.WebApi - aplikacja .NET 8, ASP.NET Web API.

Lab.Aml.Domain - biblioteka zawierająca główną logikę aplikacji. Uporządkowana przy użyciu CQRS i MediatR.

Lab.Aml.DataPersistance - biblioteka odpowiadajaca za przechowywanie danych w bazie MS SQL Server. Używa Entity Framework Core.

Lab.Aml.DatabaseDesign - biblioteka potrzebna dla generowania migracji poprzez użycie narzędzia konsolowego EF Core CLI. Zawiera wygenerowane migracje w postaci C# i SQL.

Tests\Lab.Aml.Tests.DomainUnitTests - unit testy Lab.Aml.Domain. Używają NUnit i NSubstitute.

# Przed uruchomieniem

1. Utworzyć bazę danych w MS SQL Serverze.
2. Ustawić odpowiedni connection string w pliku "Lab.Aml.WebApi\appsettings.json".
3. Uruchomić na stworzonej bazie migracje z pliku "Lab.Aml.DatabaseDesign\SqlMigrations\CombinedMigration.sql".

# Po uruchomieniu

Swagger z listą endpointów dostępny pod adresem "/swagger".

Hangfire Dashboard z listą zaplanowanych zadań - pod adresem "/hangfire".
